using Benday.EfCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public partial class Person : DomainModelBase
    {
		public string FirstName { get; set; }
public string LastName { get; set; }
public string PhoneNumber { get; set; }
public string EmailAddress { get; set; }

		
    }
}
