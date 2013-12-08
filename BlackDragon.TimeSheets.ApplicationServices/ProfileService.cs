using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.TimeSheets.Shared;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Applications
{
    public class ProfileService : BaseService, IProfileService
    {
        public ProfileService(IContext context): base(context)
        {
        }

        public PagedList<ProfileFacadeDto> Search(string query, int? currentPage, int? pageSize)
        {
            var users = Context.Query<User>().Where(x =>
                x.UserName.Contains(query) ||
                x.FirstName.Contains(query) ||
                x.LastName.Contains(query))
                .OrderByDescending(x => x.ID);

            return PagedList<ProfileFacadeDto>.Create(users,
                x => GetFacadeDto(x), pageSize ?? 1, currentPage ?? 1);
        }

        public FullProfileDto GetFullProfile(string userName)
        {
            var user = Context.Query<User>().FirstOrDefault(x =>
                x.UserName == userName);

            if (user == null)
                throw new ApplicationServiceException("User is not found.");

            return GetFullDto(user);
        }
    }
}
