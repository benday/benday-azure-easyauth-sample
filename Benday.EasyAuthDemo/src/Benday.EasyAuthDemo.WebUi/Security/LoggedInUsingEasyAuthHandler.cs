using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public class LoggedInUsingEasyAuthHandler : AuthorizationHandler<LoggedInUsingEasyAuthRequirement>
    {
        private IHttpContextAccessor _Accessor;

        public LoggedInUsingEasyAuthHandler(IHttpContextAccessor accessor)
        {
            if (accessor == null)
            {
                throw new ArgumentNullException(nameof(accessor), $"{nameof(accessor)} is null.");
            }

            _Accessor = accessor;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            LoggedInUsingEasyAuthRequirement requirement)
        {
            var identityProviderHeader =
                GetHeaderValue(_Accessor.HttpContext, 
                SecurityConstants.Claim_X_MsClientPrincipalIdp);

            if (identityProviderHeader == null)
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

        private string GetHeaderValue(HttpContext context, string headerName)
        {
            var match = (from temp in context.Request.Headers
                         where temp.Key == headerName
                         select temp.Value).FirstOrDefault();

            return match;
        }
    }
}
