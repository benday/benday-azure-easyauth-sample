using System;
using System.Collections.Generic;
using System.Linq;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public class PageableResults<T> : IPageableResults
    {
        private IList<T> _Results;
        private int _CurrentPage;

        public PageableResults()
        {
            ItemsPerPage = 10;
        }

        public void Initialize(IList<T> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            Results = values;

            PageCount = CalculatePageCount();
            SetCurrentPage(1);
        }

        private void SetCurrentPage(int pageNumber)
        {
            if (pageNumber >= PageCount)
            {
                _CurrentPage = PageCount;
            }
            else if (pageNumber < 1)
            {
                _CurrentPage = 1;
            }
            else
            {
                _CurrentPage = pageNumber;
            }

            PopulatePageValues();
        }

        private void PopulatePageValues()
        {
            if (CurrentPage == 1)
            {
                PageValues = Results.Take(ItemsPerPage).ToList();
            }
            else
            {
                PageValues = Results
                    .Skip((CurrentPage - 1) * ItemsPerPage)
                    .Take(ItemsPerPage).ToList();
            }
        }

        private int CalculatePageCount()
        {
            if (ItemsPerPage == 0)
            {
                return 0;
            }
            else if (ItemsPerPage < 0)
            {
                return 0;
            }
            else
            {
                int pageCount = TotalCount / ItemsPerPage;
                int remainder = TotalCount % ItemsPerPage;

                if (remainder == 0)
                {
                    return pageCount;
                }
                else
                {
                    return pageCount + 1;
                }
            }
        }

        public IList<T> Results
        {
            get
            {
                if (_Results == null)
                {
                    _Results = new List<T>();
                }

                return _Results;
            }
            private set
            {
                _Results = value;
            }
        }

        public int TotalCount
        {
            get
            {
                return Results.Count;
            }
        }

        public int ItemsPerPage { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage
        {
            get
            {
                return _CurrentPage;
            }
            set
            {
                SetCurrentPage(value);
            }
        }

        public IList<T> PageValues { get; private set; }
    }
}
