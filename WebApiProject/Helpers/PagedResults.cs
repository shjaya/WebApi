using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Helpers
{
    public static class PagedResults
    {
        /// <summary>
        /// Creates a paged set of results.
        /// </summary>
        /// <typeparam name="DisplayItem">The type of the source.</typeparam>
        /// <param name="itemsList">The source IEnumerable.</param>
        /// <param name="page">The page number you want to retrieve.</param>       
        /// <returns>Returns a paged set of results.</returns>
        public static PagedModel<DisplayItem> CreatePagedResults<DisplayItem>(
            IEnumerable<DisplayItem> itemsList,
            int page)
        {
            if (page == 0)
                page = 1;
            int pageSize = 10;
            var skipAmount = pageSize * (page - 1);

            var results = itemsList
                .Skip(skipAmount)
                .Take(pageSize).ToList();

            var totalNumberOfRecords = itemsList.Count();
            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            return new PagedModel<DisplayItem>
            {
                Results = results,
                PageNumber = page,
                PageSize = results.Count,
                TotalNumberOfPages = totalPageCount,
                TotalNumberOfRecords = totalNumberOfRecords
            };
        }
    }
}
