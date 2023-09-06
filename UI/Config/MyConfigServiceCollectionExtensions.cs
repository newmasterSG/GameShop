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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Duende.IdentityServer;
using Domain.User;
using Duende.IdentityServer.Models;
using UI.Claims;
using UI.Validate;
using Microsoft.IdentityModel.Tokens;
using IdentityModel.AspNetCore.AccessTokenManagement;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using IdentityModel;
using System.Security.Claims;

namespace UI.ServiceProvider
{
    public static class MyConfigServiceCollectionExtensions
    {

        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            //Settings Policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DateRegistrationPolicy", policy =>
                    policy.Requirements.Add(new DateRegistrationRequirement()));
            });
            services.AddScoped<IAuthorizationHandler, DateRegistrationHandler>();

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = "oidc";
            })
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
           {
               option.ExpireTimeSpan = TimeSpan.FromDays(30);
               option.Events.OnSigningOut = async e =>
               {
                   await e.HttpContext.RevokeUserRefreshTokenAsync();
               };
           })
           .AddOpenIdConnect("oidc", option =>
           {
               option.Authority = "https://localhost:5001";
               option.CallbackPath = "/signin-oidc";
               option.ClientId = "interactive";
               option.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
               option.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               option.ResponseType = OpenIdConnectResponseType.Code;
               option.RequireHttpsMetadata = false;
               option.ResponseMode = "query";
               option.Scope.Clear();

               option.Scope.Add("openid");
               option.Scope.Add("profile");
               option.Scope.Add("offline_access");
               option.Scope.Add("ApiSteam");
               option.Scope.Add("role");
               //option.ClaimActions.MapJsonKey("Role", "Role");

               option.TokenValidationParameters = new TokenValidationParameters
               {
                   NameClaimType = "email",
                   RoleClaimType = "role",
               };

               option.GetClaimsFromUserInfoEndpoint = true;
               option.SaveTokens = true;

           });

            services.AddAccessTokenManagement(options =>
            {
                // client config is inferred from OpenID Connect settings
                // if you want to specify scopes explicitly, do it here, otherwise the scope parameter will not be sent
                options.Client.DefaultClient.Scope = "ApiSteam";
            })
           .ConfigureBackchannelHttpClient();

            return services;
        }

        public static IServiceCollection AddLoca(this IServiceCollection services)
        {
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(ValidationResources));
                });

            return services;
        }

        public static IServiceCollection AddOwnServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<GameShopContext>>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IGameService, GameService>();
            services.AddTransient<EmailSender, SmtpEmailSender>();
            services.AddScoped<IUserService, UserService>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, MyUserClaimsPrincipalFactory>();
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }

        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services,
             IConfiguration config)
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

            //Caching
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            //My own services
            services.AddOwnServices();

            //Localizations
            services.AddLoca();

            //Authentication
            services.AddAuth();

            services.AddSignalR();

            services.AddHttpClient("apisteam", h =>
            {
                h.BaseAddress = new Uri("https://localhost:7242/");
            });


            return services;
        }
    }
}
