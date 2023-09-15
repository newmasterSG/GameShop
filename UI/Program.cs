using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Infrastructure.UnitOfWork.UnitOfWork;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Interfaces;
using Infrastructure.Email;
using Application.InterfaceServices;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Infrastructure.Email.Options;
using UI.ServiceProvider;
using UI.Middlewares;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.IdentityModel.Tokens.Jwt;
using Duende.IdentityServer;
using Domain.User;
using UI.Seedings;
using UI.Hubs;

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

            builder.Services.AddIdentity<UserEntity, IdentityRole>(option =>
            {
                option.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<GameShopContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddMyDependencyGroup(builder.Configuration);

            var app = builder.Build();

            app.Configure(builder.Environment);

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

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();

                var roles = new[] { "Admin", "Manager", "Buyer" };

                var gameEntity = Seeding.Seed();

                if (await dbContext.Games.FirstOrDefaultAsync(g => g.Name == gameEntity.Name) == null)
                {
                    dbContext.Games.Add(gameEntity);
                }

                string email = builder.Configuration["DefaultUser:email"];
                string userPassword = builder.Configuration["DefaultUser:password"];

                foreach (var role in roles)
                {
                    if(!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }    
                }

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    UserEntity adminUser = new UserEntity
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true,
                        DateRegistration = DateTime.Now,
                    };

                    IdentityResult result = await userManager.CreateAsync(adminUser, userPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(adminUser, new Claim(JwtClaimTypes.Role, "Admin"));
                        await userManager.AddClaimAsync(adminUser, new Claim(JwtClaimTypes.Name, adminUser.UserName));
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }

                dbContext.SaveChanges();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapHub<ChatHub>("/chatHub");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}