using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackDragon.TimeSheets.Mvc.Models;
using BlackDragon.TimeSheets.Shared;

namespace BlackDragon.TimeSheets.Mvc.Controllers
{
    [HandleError]
    public class ProfileController : Controller
    {
        public IProfileService ProfileService { get; private set; }

        public ProfileController(IProfileService profileService)
        {
            ProfileService = profileService;
        }

        private const int PageSize = 1;

        [HttpPost]
        public ActionResult Search(SearchProfileModel search)
        {
            var result = ProfileService.Search(search.Query,
                1, PageSize);

            search.IsSearched = true;
            search.Results = result;
            search.TotalPages = result.TotalPages;
            search.PageSize = result.PageSize;
            search.CurrentPage = result.CurrentPage;

            return View(search);
        }

        [HttpPost]
        public ActionResult Paging(int currentPage, string currentFilter, int? pageSize)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return View(new SearchProfileModel());

            var search = new SearchProfileModel();

            var result = ProfileService.Search(currentFilter,
                currentPage, pageSize);

            search.IsSearched = true;
            search.Query = currentFilter;
            search.Results = result;
            search.TotalPages = result.TotalPages;
            search.PageSize = result.PageSize;
            search.CurrentPage = result.CurrentPage;

            return View("Search", search);
        }

        public ActionResult Search()
        {
            return View(new SearchProfileModel());
        }

        public new ActionResult View(string userName)
        {
            FullProfileDto profile = ProfileService.GetFullProfile(userName);

            return View(profile);
        }
    }
}
