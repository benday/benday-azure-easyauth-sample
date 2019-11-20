using System;
using System.Linq;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public class SecurityConfiguration : ISecurityConfiguration
    {
        private Microsoft.Extensions.Configuration.IConfiguration _Configuration;

        public SecurityConfiguration(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), $"{nameof(configuration)} is null.");
            }

            _Configuration = configuration;
        }

        public bool IsDevelopmentMode()
        {
            if (_Configuration["MiscSettings:IsDevelopmentMode"] == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
