using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class SecuritySummaryModel
    {
        public bool IsClaimsPrincipalNull { get; set; }
        public string Username { get; set; }
        public IEnumerable<System.Security.Claims.Claim> Claims { get; set; }

        public bool IsPrimaryIdentityNull { get; set; }
        public string PrimaryIdentityAuthenticationType { get; set; }
        public bool PrimaryIdentityIsAuthenticated { get; set; }
        public string PrimaryIdentityName { get; set; }
        public string IdentitiesInfo { get; set; }
        public IEnumerable<ClaimsIdentity> Identities { get; set; }
        public IHeaderDictionary Headers { get; set; }
        public IRequestCookieCollection Cookies { get; set; }
    }
}
