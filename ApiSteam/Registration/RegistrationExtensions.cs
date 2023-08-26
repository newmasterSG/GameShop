using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace ApiSteam.Registration
{
    public static class RegistrationExtensions
    {
        public static void AddIdentityServerJWTAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(async options =>
                {
                    string authority = "";
                    string validIssuer = "";
                    string validAudience = "ApiSteam";

                    options.Authority = authority;
                    options.Audience = validAudience;

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidAudience = validAudience,
                        ValidIssuer = validIssuer,
                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKeys = await GetSigninKeys()
                    };

                    async Task<IEnumerable<SecurityKey>> GetSigninKeys()
                    {
                        HttpClient httpClient = new HttpClient();
                        var metaDataRequest = new HttpRequestMessage(HttpMethod.Get, $"{authority}/.well-known/openid-configuration");
                        var metaDataResponse = await httpClient.SendAsync(metaDataRequest);

                        string content = await metaDataResponse.Content.ReadAsStringAsync();
                        var payload = JObject.Parse(content);
                        string jwksUri = payload.Value<string>("jwks_uri");

                        var keysRequest = new HttpRequestMessage(HttpMethod.Get, jwksUri);
                        var keysResponse = await httpClient.SendAsync(keysRequest);
                        var keysPayload = await keysResponse.Content.ReadAsStringAsync();
                        var signInKeys = new JsonWebKeySet(keysPayload).Keys;

                        return signInKeys;
                    }
                });
        }
    }
}
