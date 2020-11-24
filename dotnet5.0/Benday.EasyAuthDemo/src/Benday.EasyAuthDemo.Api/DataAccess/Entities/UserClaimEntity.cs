using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benday.EasyAuthDemo.Api.DataAccess.Entities
{


    [Table("UserClaim")]
    public class UserClaimEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}
