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
    }
}