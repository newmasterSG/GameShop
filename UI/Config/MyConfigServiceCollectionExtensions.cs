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
using UI.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Duende.IdentityServer;
using Infrastructure.User;
using Duende.IdentityServer.Models;

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

            //IdentityServer
            services.AddIdentityServer()
                .AddInMemoryApiScopes(MyConfigIdentityServer.ApiScopes)
                .AddInMemoryClients(MyConfigIdentityServer.Clients)
                .AddTestUsers(MyConfigIdentityServer.TestUsers)
                .AddJwtBearerClientAuthentication()
                .AddDeveloperSigningCredential();

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

            //Authentication
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
           .AddOpenIdConnect("oidc", "Demo IdentityServer", option =>
           {
               option.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
               option.Authority = "https://localhost:7094";
               option.CallbackPath = "/signin-oidc";
               option.SignedOutCallbackPath = "/signout-callback-oidc";

               option.ClientId = "mvc";
               option.ClientSecret = "secret".Sha256();
               option.ResponseType = OpenIdConnectResponseType.Code;

               option.UsePkce = true;
               option.SaveTokens = true;
               option.RequireHttpsMetadata = false;

               option.Scope.Add(OpenIdConnectScope.OpenId);
               option.Scope.Add(OpenIdConnectScope.OfflineAccess);
               option.Scope.Add(IdentityServerConstants.StandardScopes.OpenId);
               option.Scope.Add(IdentityServerConstants.StandardScopes.Profile);
               option.Scope.Add(IdentityServerConstants.StandardScopes.Email);
               option.Scope.Add("ApiSteam");

           });

            return services;
        }
    }
}
