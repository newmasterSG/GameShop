using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Duende.IdentityServer.Models;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

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
            new ApiScope("ApiSteam", "My API")
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
                AllowedScopes = { "ApiSteam" }
            },

            // interactive ASP.NET Core MVC client
            new Client
            {
                ClientId = "mvc",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                // where to redirect to after login
                RedirectUris = { "https://localhost:7094/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:7094/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "ApiSteam"
                },
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
