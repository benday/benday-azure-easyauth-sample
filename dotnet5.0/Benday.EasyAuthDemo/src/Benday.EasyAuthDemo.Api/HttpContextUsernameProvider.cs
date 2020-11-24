using Microsoft.AspNetCore.Http;
using System;

namespace Benday.EasyAuthDemo.Api
{
    public class HttpContextUsernameProvider : IUsernameProvider
    {
        private IHttpContextAccessor _ContextAccessor;

        public HttpContextUsernameProvider(IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor),
                    $"{nameof(contextAccessor)} is null.");

            _ContextAccessor = contextAccessor;
        }

        public string GetUsername()
        {
            var context = _ContextAccessor.HttpContext;

            if (context != null && 
                context.User != null && 
                context.User.Identity != null &&
                String.IsNullOrWhiteSpace(context.User.Identity.Name) == false)
            {
                return 
                    ApiUtilities.SafeToString(context.User.Identity.Name,
                        "(unknown username)");
            }
            else
            {
                return "(unknown username)";
            }
        }
    }
}
