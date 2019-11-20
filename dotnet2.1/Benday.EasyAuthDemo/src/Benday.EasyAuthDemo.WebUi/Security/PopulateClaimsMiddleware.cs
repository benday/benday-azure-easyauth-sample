using Benday.EasyAuthDemo.Api;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public class PopulateClaimsMiddleware : IMiddleware
    {
        private ISecurityConfiguration _Configuration;

        public PopulateClaimsMiddleware(ISecurityConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), $"{nameof(configuration)} is null.");
            }

            _Configuration = configuration;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            List<Claim> claims = new List<Claim>();

            if (_Configuration.IsDevelopmentMode() == true)
            {
                if (context.User != null &&
                    context.User.Identity != null &&
                    context.User.Identity.IsAuthenticated == true)
                {
                    // copy the existing claims
                    claims.AddRange(context.User.Claims);

                    AddClaim(claims, ClaimTypes.GivenName, "Testy");
                    AddClaim(claims, ClaimTypes.Surname, "McTestface");
                    AddClaim(claims, ClaimTypes.Email, "testy@testface.org");

                    var identity = new ClaimsIdentity(claims);

                    context.User = new System.Security.Claims.ClaimsPrincipal(identity);
                }
            }
            else
            {
                AddClaimsFromHeader(context, claims);
                AddClaimsFromAuthMeService(context, claims);

                var identity = new ClaimsIdentity(claims);

                context.User = new System.Security.Claims.ClaimsPrincipal(identity);
            }

            await next(context);
        }

        private void AddClaimsFromAuthMeService(
            HttpContext context, List<Claim> claims)
        {
            if (context.Request.Cookies.ContainsKey(SecurityConstants.Cookie_AppServiceAuthSession) == true)
            {
                var authMeJson = GetAuthMeInfo(context.Request);

                var jsonArray = JArray.Parse(authMeJson);

                var editor = new JsonEditor(jsonArray[0].ToString(), true);

                AddClaimIfExists(claims, editor, ClaimTypes.GivenName);
                AddClaimIfExists(claims, editor, ClaimTypes.Surname);
                if (AddClaimIfExists(claims, editor, ClaimTypes.Email) == false)
                {
                    var temp = editor.GetValue("user_id");

                    if (temp.IsNullOrWhitespace() == false)
                    {
                        claims.Add(new Claim(ClaimTypes.Email, temp));
                    }
                }
            }
        }

        private bool AddClaimIfExists(List<Claim> claims, JsonEditor editor, string claimTypeName)
        {
            var temp = GetClaimValue(editor, claimTypeName);

            if (temp.IsNullOrWhitespace() == false)
            {
                AddClaim(claims, claimTypeName, temp);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static void AddClaim(List<Claim> claims, string claimTypeName, string value)
        {
            claims.Add(new Claim(claimTypeName, value));
        }

        private string GetClaimValue(JsonEditor editor, string claimName)
        {
            var args = new SiblingValueArguments();

            args.SiblingSearchKey = "typ";
            args.SiblingSearchValue = claimName;

            args.DesiredNodeKey = "val";
            args.PathArguments = new[] { "user_claims" };

            var temp = editor.GetSiblingValue(args);

            return temp;
        }

        private string GetAuthMeInfo(HttpRequest request)
        {
            var client = new AzureEasyAuthClient(request);

            if (client.IsReadyForAuthenticatedCall == false)
            {
                return null;
            }
            else
            {
                var resultAsString = client.GetUserInformationJson();

                return resultAsString;
            }            
        }

        private void AddClaimsFromHeader(HttpContext context, List<Claim> claims)
        {
            var identityProviderHeader =
                            GetHeaderValue(context, SecurityConstants.Claim_X_MsClientPrincipalIdp);

            if (identityProviderHeader != null)
            {
                var identityHeader =
                    GetHeaderValue(
                        context,
                        SecurityConstants.Claim_X_MsClientPrincipalId);

                var nameHeader =
                    GetHeaderValue(
                        context,
                        SecurityConstants.Claim_X_MsClientPrincipalName);

                claims.Add(new Claim(
                    SecurityConstants.Claim_X_MsClientPrincipalIdp,
                    identityProviderHeader));

                claims.Add(new Claim(
                    SecurityConstants.Claim_X_MsClientPrincipalId,
                    identityHeader));

                claims.Add(new Claim(
                    SecurityConstants.Claim_X_MsClientPrincipalName,
                    nameHeader));
            }
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
