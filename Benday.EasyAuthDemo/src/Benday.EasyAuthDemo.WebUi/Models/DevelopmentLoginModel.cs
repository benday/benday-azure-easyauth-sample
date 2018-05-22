using System;
using System.ComponentModel;
using System.Linq;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class DevelopmentLoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        [DisplayName("Keep Me Logged In")]
        public bool KeepMeLoggedIn { get; set; }
    }
}
