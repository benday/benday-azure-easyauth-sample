using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.Security
{
    public class LoggedInUsingEasyAuthRequirement : IAuthorizationRequirement
    {
    }
}
