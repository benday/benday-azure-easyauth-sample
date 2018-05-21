using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.WebUi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    public class SecuritySummaryController : Controller
    {
        public IActionResult Index()
        {
            var model = new SecuritySummaryViewModel();
            
            var principal = this.User;

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

            model.Headers = this.Request.Headers;

            model.Cookies = this.Request.Cookies;

            PopulateUserInfo(model);

            return View(model);
        }

        private void PopulateUserInfo(SecuritySummaryViewModel model)
        {
            model.IsLoggedIn = "(not implemented)";
            model.FirstName = "(not implemented)";
            model.LastName = "(not implemented)";
            model.EmailAddress = "(not implemented)";
        }
    }
}