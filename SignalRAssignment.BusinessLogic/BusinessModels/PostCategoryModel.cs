using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.BusinessLogic.BusinessModels
{
    public class PostCategoryModel
    {
        public int CategoryID { get; set; }

        public required string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}