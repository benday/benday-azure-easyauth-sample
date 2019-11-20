using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Benday.EasyAuthDemo.WebUi.Models;
using Microsoft.AspNetCore.Authorization;
using Benday.EasyAuthDemo.WebUi.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using Benday.EasyAuthDemo.Api;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = SecurityConstants.Policy_LoggedInUsingEasyAuth)]
        public IActionResult About()
        {
            HomeAboutModel model = new HomeAboutModel();

            model.Message = String.Empty;

            model.AuthInfo = String.Empty;

            return View(model);
        }

        [Authorize(Policy = SecurityConstants.Policy_LoggedInUsingEasyAuth)]
        [HttpPost]
        public IActionResult About(HomeAboutModel model)
        {
            try
            {
                var authMeJson = GetAuthMeInfo();

                model.AuthInfo = authMeJson;
            }
            catch (Exception ex)
            {
                model.Message = ex.ToString();
            }

            return View(model);
        }

        private string GetAuthMeInfo()
        {
            var client = new AzureEasyAuthClient(this.Request);

            if (client.IsReadyForAuthenticatedCall == false)
            {
                return "(can't call /.auth/me...probably not auth cookie)";
            }
            else
            {                
                return client.GetUserInformationJson();
            }
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
