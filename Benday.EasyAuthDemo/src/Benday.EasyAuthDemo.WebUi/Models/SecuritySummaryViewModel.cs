﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class SecuritySummaryViewModel
    {
        public IEnumerable<System.Security.Claims.Claim> Claims { get; set; }
        public IHeaderDictionary Headers { get; set; }
        public IRequestCookieCollection Cookies { get; set; }

        public string IsLoggedIn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
