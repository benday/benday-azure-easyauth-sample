using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public class AzureEasyAuthClient
    {
        private HttpClient _Client;

        public AzureEasyAuthClient(HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), $"{nameof(request)} is null.");
            }

            TryInitializeHttpClientUsingSessionCookie(request);
        }

        public bool IsReadyForAuthenticatedCall
        {
            get;
            private set;
        }

        private void TryInitializeHttpClientUsingSessionCookie(HttpRequest request)
        {
            var requestCookies = request.Cookies;

            if (requestCookies.ContainsKey(SecurityConstants.Cookie_AppServiceAuthSession) == false)
            {
                IsReadyForAuthenticatedCall = false;
            }
            else
            {
                var handler = new HttpClientHandler();

                var client = new HttpClient(handler);

                var baseUrl = $"{request.Scheme}://{request.Host}";

                client.BaseAddress = new Uri(baseUrl);

                var container = new CookieContainer();

                handler.CookieContainer = container;

                var authCookie =
                    requestCookies[SecurityConstants.Cookie_AppServiceAuthSession];

                container.Add(
                    new Uri(baseUrl),
                    new Cookie(
                        SecurityConstants.Cookie_AppServiceAuthSession,
                        authCookie));

                IsReadyForAuthenticatedCall = true;

                _Client = client;
            }
        }

        public string GetUserInformationJson()
        {
            if (IsReadyForAuthenticatedCall == false)
            {
                return null;
            }
            else
            {
                var resultAsString = _Client.GetStringAsync("/.auth/me").Result;

                return resultAsString;
            }
        }
    }
}
