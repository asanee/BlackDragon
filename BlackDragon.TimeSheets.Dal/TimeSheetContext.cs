using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BlackDragon.TimeSheets.Domain;
using BlackDragon.TimeSheets.Applications;
using BlackDragon.TimeSheets.Dal.Migrations;

namespace BlackDragon.TimeSheets.Dal
{
    public class TimeSheetContext: DbContext, IContext
    {
        static TimeSheetContext()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TimeSheetContext, 
                TimeSheetMigrationsConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CircleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public static int ContextCount { get; private set; }

        public TimeSheetContext():base("TimeSheet")
        {
            ContextCount++;
        }

        protected override void Dispose(bool disposing)
        {
            ContextCount--;
            base.Dispose(disposing);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return this.Set<T>();
        }

        public void Add<T>(T entity) where T : Entity
        {
            this.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            this.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
