using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackDragon.TimeSheets.Shared;

namespace BlackDragon.TimeSheets.Mvc.Models
{
    public class ProfileModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class SearchProfileModel
    {
        public SearchProfileModel()
        {
            Results = new List<ProfileFacadeDto>();
        }

        public string Query { get; set; }
        public IList<ProfileFacadeDto> Results { get; set; }

        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public bool CanGoNext { get { return CurrentPage < TotalPages; } }

        public bool CanGoPrevious { get { return CurrentPage > 1; } }

        public bool IsSearched { get; set; }
    }
}