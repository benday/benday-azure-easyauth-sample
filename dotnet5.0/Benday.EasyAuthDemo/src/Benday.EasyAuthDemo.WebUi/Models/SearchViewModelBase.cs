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
    public abstract class SearchViewModelBase<T> : ISortableResult
    {
        protected SearchViewModelBase()
        {
            CurrentSortProperty = String.Empty;
            CurrentSortDirection = SearchConstants.SortDirectionAscending;
        }

        [Display(Name = "Simple Search")]
        public bool IsSimpleSearch { get; set; }

        [Display(Name = "Simple Search Value")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SimpleSearchValue { get; set; }

        [Display(Name = "Current Sort Property")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CurrentSortProperty { get; set; }

        [Display(Name = "Current Sort Direction")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CurrentSortDirection { get; set; }

        public PageableResults<T> Results
        {
            get;
            set;
        }
    }
}
