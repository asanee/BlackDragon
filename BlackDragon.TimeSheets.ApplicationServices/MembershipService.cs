using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.TimeSheets.Domain;
using BlackDragon.TimeSheets.Shared;

namespace BlackDragon.TimeSheets.Applications
{
    public class MembershipService : IMembershipService
    {
        public MembershipService(IContext context)
        {
            Context = context;
        }

        public int MinPasswordLength
        {
            get { return 7; }
        }

        public bool ValidateUser(string userName, string password)
        {
            var user = Context.Query<User>()
                .WithoutInactive()
                .FirstOrDefault(x => x.UserName == userName);

            if (user == null)
                return false;

            return user.IsValidPassword(password);
        }

        public void CreateUser(IUserInformation information)
        {
            if (Context.Query<User>().Any(x => x.UserName == information.UserName))
                throw new DomainException("Duplicate Username");

            Context.Add(User.Create(information, information.UserName));

            Context.Save();
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var user = Context.Query<User>()
                .WithoutInactive()
                .FirstOrDefault(x => x.UserName == userName);

            if (user == null)
                return false;

            if (!user.IsValidPassword(oldPassword))
                return false;

            user.UpdatePassword(newPassword);

            Context.Save();

            return true;
        }

        public IContext Context { get; set; }
    }
}
