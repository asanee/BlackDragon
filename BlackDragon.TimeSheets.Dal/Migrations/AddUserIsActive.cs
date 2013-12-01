using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using BlackDragon.DalFramework;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Dal.Migrations
{
    public class AddUserIsActive : AddIsActive<User>
    {

    }
}
