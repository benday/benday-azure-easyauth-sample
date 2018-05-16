using System;
using System.IO;
using System.Linq;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public static class SecurityConstants
    {
        public const string Claim_X_MsClientPrincipalIdp = "X-MS-CLIENT-PRINCIPAL-IDP";
        public const string Policy_LoggedInUsingEasyAuth = "LoggedInUsingEasyAuthHandler";
    }
}
