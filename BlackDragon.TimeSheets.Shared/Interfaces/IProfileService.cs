using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Shared
{
    public interface IProfileService
    {
        IList<ProfileFacadeDto> Search(string query, int skip, int take);

        FullProfileDto GetFullProfile(string userName);
    }
}
