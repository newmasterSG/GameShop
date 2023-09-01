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

            var siteForCORS = new[] { "https://localhost:5444", ""};

            var nameMyPolicy = "fromUI";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(nameMyPolicy, policy =>
                {
                    policy.WithOrigins(siteForCORS)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork<GameShopContext>>();
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IReviewsService, ReviewsService>();
            builder.Services.AddScoped<IHomeService, HomeService>();

            builder.Services.AddIdentityServerJWTAuthentication();
            builder.Services.AddLogging();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();


            app.UseAuthentication();

            app.UseCors(nameMyPolicy);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}