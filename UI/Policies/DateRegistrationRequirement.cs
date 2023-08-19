using Microsoft.AspNetCore.Authorization;

namespace UI.Policies
{
    public class DateRegistrationRequirement : IAuthorizationRequirement
    {
        public DateRegistrationRequirement()
        {
        }
    }

}
