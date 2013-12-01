using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BlackDragon.DalFramework;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Dal.Migrations
{
    public class AddUserLastName : AddStringColumnMigration<User>
    {
        public override int? MaxLength
        {
            get { return 150; }
        }

        protected override Expression<Func<User, string>> Property
        {
            get { return x => x.LastName; }
        }

        protected override bool IsNullable
        {
            get
            {
                return true;
            }
        }
    }
}
