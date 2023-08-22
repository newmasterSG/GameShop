﻿using IdentityServer4.Models;
using IdentityServer4;
using IdentityServer4.Test;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace UI.Config
{
    public static class MyConfigIdentityServer
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            // machine to machine client
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                // scopes that client has access to
                AllowedScopes = { "api1" }
            },

            // interactive ASP.NET Core MVC client
            new Client
            {
                ClientId = "mvc",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                // where to redirect to after login
                RedirectUris = { "https://localhost:5002/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                }
            }
            };

        public static List<TestUser> TestUsers =>
       new List<TestUser>
       {
            new TestUser
            {
                SubjectId = "1",
                Username = "testing.project.ts@gmail.com",
                Password = "Eg.1234",
                IsActive = true,
                Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Name, "testing.project.ts@gmail.com"),
                    new Claim(JwtRegisteredClaimNames.Sub, "testing.project.ts@gmail.com")
                }
            }
       };
    }
}