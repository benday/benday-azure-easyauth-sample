using Benday.EasyAuthDemo.WebUi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    public class SecuritySummaryController : Controller
    {
        public IActionResult Index()
        {
            var model = new SecuritySummaryModel();

            var principal = this.User;

            if (principal == null)
            {
                model.IsClaimsPrincipalNull = true;
            }
            else
            {
                model.IsClaimsPrincipalNull = false;

                if (principal.Identity == null)
                {
                    model.IsPrimaryIdentityNull = true;
                }
                else
                {
                    model.IsPrimaryIdentityNull = false;
                    model.PrimaryIdentityAuthenticationType =
                        principal.Identity.AuthenticationType;
                    model.PrimaryIdentityIsAuthenticated =
                        principal.Identity.IsAuthenticated;
                    model.PrimaryIdentityName =
                        principal.Identity.Name;
                }
            }

            // principal.HasClaim()

            var identity = User.Identity;

            var claimsIdentityInstance = 
                identity as ClaimsIdentity;

            if (claimsIdentityInstance == null)
            {
                model.Claims = new List<Claim>();
            }
            else
            {
                model.Claims = 
                    claimsIdentityInstance.Claims.ToList();
            }

            if (principal.Identities == null ||
                principal.Identities.Count() == 0)
            {
                model.IdentitiesInfo = "Identities is null or 0 length.";
            }
            else
            {
                model.IdentitiesInfo = String.Format("Identities has '{0}' values", 
                    principal.Identities.Count());

                model.Identities =
                    principal.Identities;
            }

            model.Headers = this.Request.Headers;

            model.Cookies = this.Request.Cookies;

            return View(model);
        }
    }
}
