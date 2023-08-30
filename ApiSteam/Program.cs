using ApiSteam.Registration;
using Application.InterfaceServices;
using Application.Services;
using Domain.Interfaces;
using Domain.User;
using Infrastructure.Context;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiSteam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            var connectionString = builder.Configuration["ConnectionString"];
            builder.Services.AddDbContext<GameShopContext>(options =>
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork<GameShopContext>>();
            builder.Services.AddScoped<GameService>();
            builder.Services.AddScoped<OrderServices>();
            builder.Services.AddScoped<ReviewsService>();
            builder.Services.AddScoped<IHomeService, HomeService>();

            builder.Services.AddIdentity<UserEntity, IdentityRole>(option =>
            {
                option.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<GameShopContext>()
            .AddDefaultTokenProviders();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddIdentityServerJWTAuthentication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}