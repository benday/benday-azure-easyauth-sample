using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public class LoggedInUsingEasyAuthHandler : AuthorizationHandler<LoggedInUsingEasyAuthRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            LoggedInUsingEasyAuthRequirement requirement)
        {
            var identityProviderClaim =
                FindClaim(context, SecurityConstants.Claim_X_MsClientPrincipalIdp);

            if (identityProviderClaim == null)
            {
                // not logged in
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private Claim FindClaim(AuthorizationHandlerContext context, string claimName)
        {
            var match = context.User.Claims.Where(
                 x => x.Type == claimName
                 ).FirstOrDefault();

            return match;
        }
    }
}
