using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class SecurityLoginModel
    {
        public SecurityLoginModel()
        {
            LoginTypes = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> LoginTypes { get; set; }
    }
}
