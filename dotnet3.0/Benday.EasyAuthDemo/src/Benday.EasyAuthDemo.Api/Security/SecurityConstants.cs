using System;
using System.IO;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Security
{
    public static class SecurityConstants
    {
        public const string Claim_X_MsClientPrincipalId = "X-MS-CLIENT-PRINCIPAL-ID";
        public const string Claim_X_MsClientPrincipalIdp = "X-MS-CLIENT-PRINCIPAL-IDP";
        public const string Claim_X_MsClientPrincipalName = "X-MS-CLIENT-PRINCIPAL-NAME";
        public const string Policy_LoggedInUsingEasyAuth = "LoggedInUsingEasyAuthHandler";
        public const string Cookie_AppServiceAuthSession = "AppServiceAuthSession";

        public const string Idp_DevelopmentMode = "DevelopmentMode";
    }
}
