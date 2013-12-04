using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Shared
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        void CreateUser(IUserInformation information);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
