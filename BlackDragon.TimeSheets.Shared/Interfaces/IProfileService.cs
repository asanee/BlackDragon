using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Shared
{
    public interface IProfileService
    {
        PagedList<ProfileFacadeDto> Search(string query, int? currentPage, int? pageSize);

        FullProfileDto GetFullProfile(string userName);
    }
}
