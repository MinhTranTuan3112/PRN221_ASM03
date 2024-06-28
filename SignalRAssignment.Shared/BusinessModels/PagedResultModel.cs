using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Shared.BusinessModels
{
    public class PagedResultModel<T> where T : class
    {
        public int TotalCount { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));

        public List<T> Items { get; set; } = [];
    }
}