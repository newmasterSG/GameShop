using Application.InterfaceServices;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.UnitOfWork.UnitOfWork;

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
            services.AddScoped<IUnitOfWork, UnitOfWork<GameShopContext>>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<IHomeService, HomeService>();

            return services;
        }
    }
}
