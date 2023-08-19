using Application.InterfaceServices;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Email;
using Infrastructure.Email.Options;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyModel;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using UI.Policies;

namespace UI.ServiceProvider
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {

            services.Configure<SmtpOptions>(config.GetSection("Smtp"));

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });

            return services;
        }


        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            //Caching
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            //Localizations
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            //My own services
            services.AddScoped<IUnitOfWork, UnitOfWork<GameShopContext>>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<GameService>();
            services.AddTransient<EmailSender, SmtpEmailSender>();
            services.AddScoped<IUserService, UserService>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<OrderServices>();

            //Settings Policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DateRegistrationPolicy", policy =>
                    policy.Requirements.Add(new DateRegistrationRequirement()));
            });
            services.AddScoped<IAuthorizationHandler, DateRegistrationHandler>();

            return services;
        }
    }
}
