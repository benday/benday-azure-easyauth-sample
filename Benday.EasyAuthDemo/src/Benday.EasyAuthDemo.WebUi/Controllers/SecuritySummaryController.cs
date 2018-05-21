using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.WebUi.Models;
using Benday.EasyAuthDemo.WebUi.Security;
using Microsoft.AspNetCore.Mvc;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    public class SecuritySummaryController : Controller
    {
        private IUserInformation _UserInfo;

        public SecuritySummaryController(IUserInformation userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo),
                    $"{nameof(userInfo)} is null.");
            }

            _UserInfo = userInfo;
        }

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
            model.IsLoggedIn = _UserInfo.IsLoggedIn.ToString();
            model.FirstName = _UserInfo.FirstName;
            model.LastName = _UserInfo.LastName;
            model.EmailAddress = _UserInfo.EmailAddress;
        }
    }
}