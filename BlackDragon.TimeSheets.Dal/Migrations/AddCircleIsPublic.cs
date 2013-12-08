using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.TimeSheets.Domain;
using BlackDragon.DalFramework;
using System.Linq.Expressions;

namespace BlackDragon.TimeSheets.Dal.Migrations
{
    public class AddCircleIsPublic : AddBoolColumnMigration<Circle>
    {
        protected override Expression<Func<Circle, bool>> Property
        {
            get { return x => x.IsPublic; }
        }

        protected override bool DefaultValue
        {
            get
            {
                return true;
            }
        }
    }
}
