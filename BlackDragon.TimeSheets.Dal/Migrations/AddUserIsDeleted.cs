using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using BlackDragon.TimeSheets.Domain;
using BlackDragon.DalFramework;
using System.Linq.Expressions;

namespace BlackDragon.TimeSheets.Dal.Migrations
{
    public class AddUserIsDeleted : AddIsDeleted<User>
    {

    }
}
