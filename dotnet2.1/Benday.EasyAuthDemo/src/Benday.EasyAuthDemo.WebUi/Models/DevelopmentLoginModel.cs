using System;
using System.Linq;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class DevelopmentLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool KeepMeLoggedIn { get; set; }
    }
}
