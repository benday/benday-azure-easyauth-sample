using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.WebUi.Models;
using Benday.EasyAuthDemo.WebUi.Security;
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

            if (_Configuration.IsDevelopmentMode() == true)
            {
                AddLoginTypeKeyValue(model, "Local Development",
                    Url.Action("DevelopmentLogin"));
            }
            
            AddLoginType(model, "Azure Active Directory", "aad");
            AddLoginType(model, "Microsoft Account", "microsoftaccount");
            AddLoginType(model, "Google", "google");
            
            return View(model);
        }

        public IActionResult DevelopmentLogin()
        {
            if (_Configuration.IsDevelopmentMode() == false)
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
            if (_Configuration.IsDevelopmentMode() == false)
            {
                return NotFound();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(SecurityConstants.Claim_X_MsClientPrincipalId, Guid.NewGuid().ToString()),
                    new Claim(SecurityConstants.Claim_X_MsClientPrincipalIdp, "LocalDev"),
                    new Claim(SecurityConstants.Claim_X_MsClientPrincipalName, model.Username)
                };

                var temp = new ClaimsPrincipal(new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme));

                await HttpContext.SignInAsync(temp, new AuthenticationProperties
                {
                    IsPersistent = model.KeepMeLoggedIn,
                    AllowRefresh = true
                });

                /*
                var owinContext = HttpContext.SignInAsync(temp);
                    
                    
                    .Current.GetOwinContext();
                var authmanager = owinContext.Authentication;
                var claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                authmanager.SignIn(new AuthenticationProperties { IsPersistent = false, AllowRefresh = true }, claimsIdentity);
                */

                return RedirectToAction("Index", "SecuritySummary");
            }
        }

        public async Task<IActionResult> Logout()
        {            
            if (_Configuration.IsDevelopmentMode() == false)
            {
                //var easyAuthLogoutUrl = String.Format("/.auth/logout?post_login_redirect_uri={0}",
                //    this.Url.Action("PostLogoutRedirect", "SecurityCallback"));

                var easyAuthLogoutUrl = "/.auth/logout?post_login_redirect_uri=/";

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

            //var temp = String.Format("/.auth/login/{0}?post_login_redirect_uri={1}",
            //    provider,
            //    this.Url.Action("PostLoginRedirect", "SecurityCallback"));

            var temp = String.Format("/.auth/login/{0}?post_login_redirect_uri={1}",
                provider,
                "/");
            
            return temp;
        }


    }
}