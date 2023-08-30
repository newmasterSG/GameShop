using Domain.User;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UI.Claims
{
    public class MyUserClaimsPrincipalFactory: IUserClaimsPrincipalFactory<UserEntity>
    {
        public Task<ClaimsPrincipal> CreateAsync(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Byuer"),
            };

            var identity = new ClaimsIdentity(claims, "custom");
            return Task.FromResult(new ClaimsPrincipal(identity));
        }
    }
}
