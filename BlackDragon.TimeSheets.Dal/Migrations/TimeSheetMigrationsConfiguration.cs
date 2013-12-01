using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;

namespace BlackDragon.TimeSheets.Dal.Migrations
{
    public class TimeSheetMigrationsConfiguration : DbMigrationsConfiguration<TimeSheetContext>
    {
        public TimeSheetMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
            MigrationsNamespace = "BlackDragon.TimeSheets.Dal.Migrations";
        }

        protected override void Seed(TimeSheetContext context)
        {
            base.Seed(context);
        }
    }
}
