using System;
using System.Linq;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public interface ISecurityConfiguration
    {
        bool IsDevelopmentMode();
    }
}
