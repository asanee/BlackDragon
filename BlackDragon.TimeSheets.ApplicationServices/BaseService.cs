using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.TimeSheets.Shared;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Applications
{
    public abstract class BaseService
    {
        protected BaseService(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        protected static FullProfileDto GetFullDto(User user)
        {
            return new FullProfileDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                OwnCircles = user.OwnCircles.Select(x => x.Name).ToList()
            };
        }

        protected static ProfileFacadeDto GetFacadeDto(User x)
        {
            return new ProfileFacadeDto
            {
                FullName = x.FirstName + " " + x.LastName,
                UserName = x.UserName
            };
        }
    }
}
