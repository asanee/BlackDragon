using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Shared
{
    public interface IUserInformation
    {
        string UserName { get; }
        string Password { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
    }
}
