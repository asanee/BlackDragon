using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BlackDragon.TimeSheets.Domain;
using BlackDragon.DalFramework;

namespace BlackDragon.TimeSheets.Dal.Migrations
{
    public class AddCircleName : AddStringColumnMigration<Circle>
    {
        public override int? MaxLength
        {
            get { return 100; }
        }

        protected override Expression<Func<Circle, string>> Property
        {
            get { return x => x.Name; }
        }
    }
}
