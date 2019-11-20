using Benday.EfCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public partial class Lookup : DomainModelBase
    {
		public int DisplayOrder { get; set; }
public string LookupType { get; set; }
public string LookupKey { get; set; }
public string LookupValue { get; set; }

		
    }
}
