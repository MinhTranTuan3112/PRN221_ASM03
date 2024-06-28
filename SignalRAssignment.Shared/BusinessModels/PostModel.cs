using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Shared.BusinessModels
{
    public class PostModel
    {
        public int PostID { get; set; }

        public int AuthorID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public required string PublishStatus { get; set; } //Based on PostPublishStatus Enum

        public int CategoryID { get; set; }
    }
}