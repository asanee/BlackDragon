using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BlackDragon.TimeSheets.Shared
{
    public class PagedList<T> : ReadOnlyCollection<T>
    {
        public static PagedList<T> Create<TEntity>(IQueryable<TEntity> query, 
            Func<TEntity,T> projection, int pageSize, int currentPage)
        {
            int count = query.Count();

            int totalPages = count == 0 ? 1 :
                (count / pageSize) + (count % pageSize == 0 ? 0 : 1); 
            
            if (currentPage > totalPages)
                currentPage = totalPages;

            var target = new PagedList<T>(query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(projection)
                .ToList());

            target.CurrentPage = currentPage;
            target.TotalPages = totalPages;
            target.PageSize = pageSize;

            return target;
        }

        private PagedList(IList<T> list):base(list)
        {
        }

        public PagedList(IList<T> list, int totalPages)
            : base(list)
        {
            TotalPages = totalPages;
        }

        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
    }
}
