using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Shared.BusinessModels;

namespace SignalRAssignment.DataAccess.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedResultModel<T>> ToPagedResultModelAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
                where T : class
        {
            return new PagedResultModel<T>
            {
                TotalCount = await query.CountAsync(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }
    }
}