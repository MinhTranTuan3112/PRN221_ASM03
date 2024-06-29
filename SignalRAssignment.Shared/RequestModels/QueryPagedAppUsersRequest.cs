using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAssignment.Shared.RequestModels
{
    public class QueryPagedAppUsersRequest
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 10;

        [FromQuery(Name = "keyword")]
        public string Keyword { get; set; } = ""; 
    }
}