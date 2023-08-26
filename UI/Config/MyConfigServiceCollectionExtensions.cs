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
using Domain.User;
using Duende.IdentityServer.Models;
using UI.Claims;
using UI.Validate;

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

            //My own services
            services.AddScoped<IUnitOfWork, UnitOfWork<GameShopContext>>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<GameService>();
            services.AddTransient<EmailSender, SmtpEmailSender>();
            services.AddScoped<IUserService, UserService>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<OrderServices>();
            services.AddScoped<ReviewsService>();
            services.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, MyUserClaimsPrincipalFactory>();

            //IdentityServer
            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
                .AddAspNetIdentity<UserEntity>()
                .AddInMemoryApiScopes(MyConfigIdentityServer.ApiScopes)
                .AddInMemoryClients(MyConfigIdentityServer.Clients)
                .AddTestUsers(MyConfigIdentityServer.TestUsers)
                .AddDeveloperSigningCredential();

            //Localizations
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(ValidationResources));
                });

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
                option.DefaultAuthenticateScheme = "Cookies";
                option.DefaultSignInScheme = "Cookies";
                option.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
           .AddOpenIdConnect("oidc", "Demo IdentityServer", option =>
           {
               option.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
               option.SignOutScheme = IdentityServerConstants.SignoutScheme;
               option.Authority = "https://localhost:7094";
               option.CallbackPath = "/signin-oidc";
               option.SignedOutCallbackPath = "/signout-callback-oidc";

               option.ClientId = "mvc";
               option.ClientSecret = "secret";
               option.ResponseType = OpenIdConnectResponseType.Code;
               option.UsePkce = true;
               option.RequireHttpsMetadata = false;
               option.Scope.Clear();

               option.Scope.Add(OpenIdConnectScope.OpenId);
               option.Scope.Add(OpenIdConnectScope.OfflineAccess);
               option.Scope.Add(IdentityServerConstants.StandardScopes.OpenId);
               option.Scope.Add(IdentityServerConstants.StandardScopes.Profile);
               option.Scope.Add(IdentityServerConstants.StandardScopes.Email);
               option.Scope.Add("ApiSteam");
               option.GetClaimsFromUserInfoEndpoint = true;
               option.SaveTokens = true;

           });

            return services;
        }
    }
}
