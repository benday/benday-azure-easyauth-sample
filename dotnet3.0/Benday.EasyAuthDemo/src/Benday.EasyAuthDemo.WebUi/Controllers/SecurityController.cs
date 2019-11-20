using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.Api.Security;
using Benday.EasyAuthDemo.WebUi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    public class SecurityController : Controller
    {
        private ISecurityConfiguration _Configuration;

        public SecurityController(ISecurityConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), $"{nameof(configuration)} is null.");
            }

            _Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var model = new SecurityLoginModel();

            if (_Configuration.AzureActiveDirectory == true)
            {
                AddLoginType(model, "Azure Active Directory", "aad");
            }

            if (_Configuration.MicrosoftAccount == true)
            {
                AddLoginType(model, "Microsoft Account", "microsoftaccount");
            }

            if (_Configuration.Google == true)
            {
                AddLoginType(model, "Google", "google");
            }

            if (_Configuration.DevelopmentMode == true)
            {
                AddLoginTypeKeyValue(model, "Local Development",
                    Url.Action("DevelopmentLogin"));
            }

            return View(model);
        }

        private string GetPostActionRedirectUri()
        {
            if (Request.Query.ContainsKey("ReturnUrl") == false)
            {
                return "/";
            }
            else
            {
                return Request.Query["ReturnUrl"];
            }
        }

        public IActionResult DevelopmentLogin()
        {
            if (_Configuration.DevelopmentMode == false)
            {
                return NotFound();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DevelopmentLogin(DevelopmentLoginModel model)
        {
            if (_Configuration.DevelopmentMode == false)
            {
                return NotFound();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(SecurityConstants.Claim_X_MsClientPrincipalId, Guid.NewGuid().ToString()),
                    new Claim(
                        SecurityConstants.Claim_X_MsClientPrincipalIdp,
                        SecurityConstants.Idp_DevelopmentMode),
                    new Claim(SecurityConstants.Claim_X_MsClientPrincipalName, model.Username)
                };

                var temp = new ClaimsPrincipal(new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme));

                await HttpContext.SignInAsync(temp, new AuthenticationProperties
                {
                    IsPersistent = model.KeepMeLoggedIn,
                    AllowRefresh = true
                });

                return RedirectToAction("Index", "SecuritySummary");
            }
        }

        public async Task<IActionResult> Logout()
        {
            if (_Configuration.DevelopmentMode == false)
            {
                var easyAuthLogoutUrl = "/.auth/logout?post_logout_redirect_uri=" +
                    GetPostActionRedirectUri();

                return Redirect(easyAuthLogoutUrl);
            }
            else
            {
                await HttpContext.SignOutAsync();

                return RedirectToAction("Login");
            }
        }

        private void AddLoginType(SecurityLoginModel model, string displayName, string argName)
        {
            AddLoginTypeKeyValue(model, displayName, GetAuthUrlForProvider(argName));
        }

        private void AddLoginTypeKeyValue(SecurityLoginModel model, string key, string value)
        {
            if (model.LoginTypes == null)
            {
                model.LoginTypes = new List<KeyValuePair<string, string>>();
            }

            var temp = new KeyValuePair<string, string>(key, value);

            model.LoginTypes.Add(temp);
        }

        private string GetAuthUrlForProvider(string provider)
        {
            if (string.IsNullOrEmpty(provider))
            {
                throw new ArgumentException($"{nameof(provider)} is null or empty.", nameof(provider));
            }

            var temp = String.Format("/.auth/login/{0}?post_login_redirect_uri={1}",
                provider,
                GetPostActionRedirectUri());

            return temp;
        }
    }
}