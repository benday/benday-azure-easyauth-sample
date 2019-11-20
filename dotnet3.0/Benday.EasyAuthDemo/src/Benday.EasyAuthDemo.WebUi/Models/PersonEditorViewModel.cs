using Benday.EfCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Benday.Common;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class PersonEditorViewModel : IInt32Identity, ISelectable, IDeleteable
    {
		public bool IsSelected { get; set; }
        public bool IsMarkedForDelete { get; set; }
		[Display(Name = "Id")]
public int Id { get; set; }

[Display(Name = "first name")]
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string FirstName { get; set; }

[Display(Name = "last name")]
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string LastName { get; set; }

[Display(Name = "phone number")]
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string PhoneNumber { get; set; }

[Display(Name = "email address")]
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string EmailAddress { get; set; }

[Display(Name = "Status")]
public string Status { get; set; }

private List<SelectListItem> _Statuses;
[Display(Name = "Status")]
public List<SelectListItem> Statuses 
{ 
	get
	{
		if (_Statuses == null)
		{
			_Statuses = new List<SelectListItem>();
		}

		return _Statuses;
	}
	set
	{
		_Statuses = value;
	}
}
[Display(Name = "Created By")]
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string CreatedBy { get; set; }

[Display(Name = "Created Date")]
public DateTime CreatedDate { get; set; }

[Display(Name = "Last Modified By")]
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string LastModifiedBy { get; set; }

[Display(Name = "Last Modified Date")]
public DateTime LastModifiedDate { get; set; }

[Display(Name = "Timestamp")]
public byte[] Timestamp { get; set; }


    }
}
