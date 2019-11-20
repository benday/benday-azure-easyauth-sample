using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public class UserInformation : IUserInformation
    {
        private IHttpContextAccessor _Accessor;

        public UserInformation(IHttpContextAccessor accessor)
        {
            _Accessor = accessor;
        }

        private HttpContext _Context;
        private HttpContext Context
        {
            get
            {
                if (_Context == null)
                {
                    _Context = _Accessor.HttpContext;
                }

                return _Context;
            }
        }

        private List<Claim> _Claims;
        public List<Claim> Claims
        {
            get
            {
                if (_Claims == null)
                {
                    if (Context.User == null || Context.User.Claims == null)
                    {
                        _Claims = new List<Claim>();
                    }
                    else
                    {
                        _Claims = Context.User.Claims.ToList();
                    }
                }

                return _Claims;
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return Claims.ContainsClaim(SecurityConstants.Claim_X_MsClientPrincipalIdp);
            }
        }

        public string FirstName
        {
            get
            {
                return Claims.GetClaimValue(ClaimTypes.GivenName).SafeToString();
            }
        }

        public string LastName
        {
            get
            {
                return Claims.GetClaimValue(ClaimTypes.Surname).SafeToString();
            }
        }

        public string EmailAddress
        {
            get
            {
                return Claims.GetClaimValue(ClaimTypes.Email).SafeToString();
            }
        }
    }
}
