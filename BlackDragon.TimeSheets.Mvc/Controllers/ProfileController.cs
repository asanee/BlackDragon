using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackDragon.TimeSheets.Mvc.Models;
using BlackDragon.TimeSheets.Shared;

namespace BlackDragon.TimeSheets.Mvc.Controllers
{
    public class ProfileController : Controller
    {
        public IProfileService ProfileService { get; private set; }

        public ProfileController(IProfileService profileService)
        {
            ProfileService = profileService;
        }

        [HttpPost]
        public ActionResult Search(SearchProfileModel search)
        {
            search.Results = ProfileService.Search(search.Query, 0, 100);

            return View(search);
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
