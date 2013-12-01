using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BlackDragon.TimeSheets.Domain;
using BlackDragon.DalFramework;

namespace BlackDragon.TimeSheets.Dal.Migrations
{
    public abstract class AddIsDeleted<T> : AddBoolColumnMigration<T> where T: ActiveEntity
    {
        protected override Expression<Func<T, bool>> Property
        {
            get { return x => x.IsDeleted; }
        }
    }
}
