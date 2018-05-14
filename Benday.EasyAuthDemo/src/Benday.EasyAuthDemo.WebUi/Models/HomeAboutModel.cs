using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class HomeAboutModel
    {
        public HomeAboutModel()
        {
            Message = String.Empty;
            AuthInfo = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Name = String.Empty;
            EmailAddress = String.Empty;
        }

        public string Message { get; set; }
        public string AuthInfo { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
