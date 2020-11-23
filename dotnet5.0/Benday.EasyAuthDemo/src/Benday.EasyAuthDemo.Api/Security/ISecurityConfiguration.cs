using System;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Security
{
    public interface ISecurityConfiguration
    {
        bool DevelopmentMode { get; }
        bool AzureActiveDirectory { get; }
        bool Google { get; }
        bool MicrosoftAccount { get; }
    }
}
