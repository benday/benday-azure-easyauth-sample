using System;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Security
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

        public bool DevelopmentMode
        {
            get
            {
                if (_Configuration["SecuritySettings:DevelopmentMode"] == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool AzureActiveDirectory
        {
            get
            {
                if (_Configuration["SecuritySettings:AzureActiveDirectory"] == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Google
        {
            get
            {
                if (_Configuration["SecuritySettings:Google"] == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool MicrosoftAccount
        {
            get
            {
                if (_Configuration["SecuritySettings:MicrosoftAccount"] == "true")
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
}
