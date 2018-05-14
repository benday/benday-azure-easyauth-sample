using System;
using System.IO;
using System.Linq;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public static class SecurityConstants
    {
        public const string Claim_X_MsClientPrincipalId = "X-MS-CLIENT-PRINCIPAL-ID";
        public const string Claim_X_MsClientPrincipalIdp = "X-MS-CLIENT-PRINCIPAL-IDP";
        public const string Claim_X_MsClientPrincipalName = "X-MS-CLIENT-PRINCIPAL-NAME";
        public const string Policy_LoggedInUsingEasyAuth = "LoggedInUsingEasyAuthHandler";
        public const string Header_XZumoAuth = "x-zumo-auth";
        public const string Cookie_AppServiceAuthSession = "AppServiceAuthSession";
    }
}
