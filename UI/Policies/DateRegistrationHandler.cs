using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace UI.Policies
{
    public class DateRegistrationHandler : AuthorizationHandler<DateRegistrationRequirement>
    {
        private readonly UserManager<UserEntity> _userManager;

        public DateRegistrationHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DateRegistrationRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);

            if (user != null && user.DateRegistration.Date <= DateTime.Now.AddDays(-30).Date) // Example condition
            {
                context.Succeed(requirement);
            }
        }
    }
}
