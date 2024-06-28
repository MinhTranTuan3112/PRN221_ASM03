using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.Shared.BusinessModels;

namespace SignalRAssignment.ResponseModels
{
    public class PostDetailPageResponse
    {
        public PostDetailsModel? Post { get; set; }

        public List<PostCategoryModel> PostCategories { get; set; } = [];
        
        public string Action { get; set; } = "Update";
    }
}