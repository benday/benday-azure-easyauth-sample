using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Benday.EasyAuthDemo.Api.ServiceLayers;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.WebUi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Benday.EasyAuthDemo.Api;
using Benday.Common;
using Microsoft.AspNetCore.Authorization;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    [Authorize(Roles = "admin")]
    public class LookupController : Controller
    {
        private readonly IValidatorStrategy<LookupEditorViewModel> _Validator;
        private readonly ILookupService _LookupService;

        private readonly ILookupService _Service;

        public LookupController(ILookupService service,
            IValidatorStrategy<LookupEditorViewModel> validator)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service), "service is null.");

            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator), "Argument cannot be null.");
            }

            _Validator = validator;
            _Service = service;
            _LookupService = service;
        }

        public ActionResult Index()
        {
            var items = _Service.GetAll();

            return View(items);
        }

        [Route("/[controller]/[action]/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null || id.HasValue == false)
            {
                return new BadRequestResult();
            }

            var item = _Service.GetById(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit", new { id = ApiConstants.UnsavedId });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            Lookup item;
            LookupEditorViewModel viewModel;

            if (id.Value == ApiConstants.UnsavedId)
            {
                // create new
                viewModel = new LookupEditorViewModel();

                PopulateLookups(viewModel);
                return View(viewModel);
            }
            else
            {
                item = _Service.GetById(id.Value);

                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    viewModel = new LookupEditorViewModel();

                    var adapter = new LookupEditorViewModelAdapter();

                    adapter.Adapt(item, viewModel);

                    PopulateLookups(viewModel);
                }
            }

            return View(viewModel);
        }

        private void PopulateLookups(LookupEditorViewModel viewModel)
        {
            viewModel.LookupTypes = ToSelectListItems(
    _LookupService.GetAllByType("System.Lookup.Types"));
            viewModel.Statuses = ToSelectListItems(
                _LookupService.GetAllByType("System.Lookup.Status"));

        }

        private List<SelectListItem> ToSelectListItems(IList<Lookup> fromValues)
        {
            var toValues = new List<SelectListItem>();

            if (fromValues != null && fromValues.Count > 0)
            {
                foreach (var fromValue in fromValues)
                {
                    toValues.Add(new SelectListItem(
                        fromValue.LookupValue,
                        fromValue.LookupKey));
                }
            }

            return toValues;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LookupEditorViewModel item)
        {
            if (_Validator.IsValid(item) == true)
            {
                Lookup toValue;

                if (item.Id == ApiConstants.UnsavedId)
                {
                    toValue = new Lookup();
                }
                else
                {
                    toValue =
                        _Service.GetById(item.Id);

                    if (toValue == null)
                    {
                        return NotFound();
                    }
                }

                var adapter = new LookupEditorViewModelAdapter();

                adapter.Adapt(item, toValue);

                _Service.Save(toValue);

                return RedirectToAction("Edit", new { id = toValue.Id });
            }
            else
            {
                return View(item);
            }
        }

        public ActionResult Search()
        {
            var viewModel = new LookupSearchViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(LookupSearchViewModel item, string pageNumber, string sortBy)
        {
            if (item == null)
            {
                return View(new LookupSearchViewModel());
            }
            else if (item.IsSimpleSearch == true)
            {
                return RunSimpleSearch(item, pageNumber, sortBy);
            }
            else
            {
                return RunDetailedSearch(item, pageNumber, sortBy);
            }
        }

        private ActionResult RunDetailedSearch(LookupSearchViewModel item, string pageNumber, string sortBy)
        {
            var sortDirection = GetSortDirection(item, sortBy);

            ModelState.Clear();

            var results = _Service.Search(
searchValueLookupType: item.LookupType,
searchValueLookupKey: item.LookupKey,
searchValueLookupValue: item.LookupValue,
searchValueStatus: item.Status,
searchValueCreatedBy: item.CreatedBy,
searchValueLastModifiedBy: item.LastModifiedBy,


                sortBy: sortBy, sortByDirection: sortDirection);

            var pageableResults = new PageableResults<Lookup>();

            pageableResults.Initialize(results);

            pageableResults.CurrentPage = pageNumber.SafeToInt32(0);

            item.Results = pageableResults;
            item.CurrentSortDirection = sortDirection;
            item.CurrentSortProperty = sortBy;

            return View(item);
        }

        private ActionResult RunSimpleSearch(
            LookupSearchViewModel item, string pageNumber, string sortBy)
        {
            if (item.SimpleSearchValue.IsNullOrWhitespace() == false)
            {
                ModelState.Clear();

                string sortDirection;

                if (sortBy == null)
                {
                    // the value didn't change because of HTTP POST
                    sortBy = item.CurrentSortProperty;
                    sortDirection = item.CurrentSortDirection;
                }
                else
                {
                    sortDirection = GetSortDirection(item, sortBy);
                }

                var results = _Service.SimpleSearch(item.SimpleSearchValue,
                    sortBy, sortDirection);

                var pageableResults = new PageableResults<Lookup>();

                pageableResults.Initialize(results);

                pageableResults.CurrentPage = pageNumber.SafeToInt32(0);

                item.Results = pageableResults;
                item.CurrentSortDirection = sortDirection;
                item.CurrentSortProperty = sortBy;
            }

            return View(item);
        }


        private string GetSortDirection(ISortableResult viewModel, string sortBy)
        {
            if (String.IsNullOrWhiteSpace(sortBy) == true)
            {
                return SearchConstants.SortDirectionAscending;
            }
            else
            {
                if (String.Compare(sortBy, viewModel.CurrentSortProperty, true) == 0)
                {
                    if (viewModel.CurrentSortDirection == SearchConstants.SortDirectionAscending)
                    {
                        return SearchConstants.SortDirectionDescending;
                    }
                    else
                    {
                        return SearchConstants.SortDirectionAscending;
                    }
                }
                else
                {
                    return SearchConstants.SortDirectionAscending;
                }
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            Lookup item;

            item = _Service.GetById(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Lookup item)
        {
            var deleteThis =
                _Service.GetById(item.Id);

            if (deleteThis == null)
            {
                return NotFound();
            }

            _Service.DeleteById(item.Id);

            return RedirectToAction("Index");
        }
    }
}
