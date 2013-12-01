using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace BlackDragon.TimeSheets.Dal
{
    public class TimeSheetDbInitializer : IDatabaseInitializer<TimeSheetContext>
    {
        private bool isInit = false;

        public void InitializeDatabase(TimeSheetContext context)
        {
            if (isInit)
                return;

            isInit = true;

            if (!context.Database.Exists())
                context.Database.Create();

            if (!context.Database.CompatibleWithModel(false))
                throw new DalException("Schema is not compatible");
        }
    }
}
