using Application.Decorators;
using Application.InterfaceServices;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiSteam.Config
{
    public static class MyServicesBuilder
    {
        public static IServiceCollection AddCORSRealization(this IServiceCollection services)
        {
            var siteForCORS = new[] { "https://localhost:5444", "" };

            var nameMyPolicy = "fromUI";
            services.AddCors(options =>
            {
                options.AddPolicy(nameMyPolicy, policy =>
                {
                    policy.WithOrigins(siteForCORS)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddingOwnDI(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork<GameShopContext>>();
            services.AddScoped<GameService>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped(serviceProvider =>
            {
                var gameServices = serviceProvider.GetRequiredService<GameService>();
                var cache = serviceProvider.GetRequiredService<IDistributedCache>();

                IGameService gameDecorator = new GameDecorator(gameServices, cache);

                return gameDecorator;
            });

            return services;
        }
    }
}
