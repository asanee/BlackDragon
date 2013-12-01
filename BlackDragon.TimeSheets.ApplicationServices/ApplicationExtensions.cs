using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Applications
{
    public static class ApplicationExtensions
    {
        public static IQueryable<T> WithoutInactive<T>(this IQueryable<T> query) 
            where T : ActiveEntity
        {
            return query.Where(x => x.IsActive && !x.IsDeleted);
        }
    }
}
