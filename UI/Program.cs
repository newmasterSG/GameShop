using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Infrastructure.UnitOfWork.Interface;
using Infrastructure.UnitOfWork.UnitOfWork;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Interfaces;
using Infrastructure.Email;
using Application.InterfaceServices;
using IdentityModel;
using ParsingData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Infrastructure.Email.Options;
using UI.ServiceProvider;
using UI.Middlewares;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration["ConnectionString"];
            builder.Services.AddDbContext<GameShopContext>(options =>
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            builder.Services
                .AddConfig(builder.Configuration)
                .AddMyDependencyGroup();

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddCookie(options =>
           {
               options.Cookie.HttpOnly = true;
               options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
               options.SlidingExpiration = true;
               options.LoginPath = "/Account/Login";
           })
           .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            builder.Services.AddIdentity<UserModel, IdentityRole>(option => option.SignIn.RequireConfirmedEmail = true)
                .AddEntityFrameworkStores<GameShopContext>()
                .AddDefaultTokenProviders();

            var app = builder.Build();

            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("uk"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            });

            app.UseCulture();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "Contents")),
                RequestPath = "/Contents"
            });


            //Seeding data if they are not existed
            using(var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<GameShopContext>();

                dbContext.Database.EnsureCreated();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();

                var roles = new[] { "Admin", "Manager", "Buyer" };

                var gameEntity = Seeding.Seed();
                
                if(await dbContext.Games.FirstOrDefaultAsync(g => g.Name == gameEntity.Name) == null)
                {
                    dbContext.Games.Add(gameEntity);
                }

                string email = "testing.project.ts@gmail.com";
                string userPassword = "Eg.1234";

                foreach (var role in roles)
                {
                    if(!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }    
                }

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    UserModel adminUser = new UserModel
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true,
                        DateRegistration = DateTime.Now,
                    };

                    IdentityResult result = await userManager.CreateAsync(adminUser, userPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(adminUser, new Claim(ClaimTypes.Role, "Admin"));
                        await userManager.AddClaimAsync(adminUser, new Claim(ClaimTypes.Name, adminUser.UserName));
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
                dbContext.SaveChanges();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.Use(async (context, next) =>
            {
                var user = context.User;

                if (user.Identity.IsAuthenticated)
                {
                    var userService = context.RequestServices.GetRequiredService<IUserService>();
                    bool isEmailVerified = userService.IsEmailVerified(user.Identity.Name);

                    if (!isEmailVerified)
                    {
                        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        context.Response.Redirect("/Home/Index");
                        return;
                    }
                }

                await next();
            });

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}