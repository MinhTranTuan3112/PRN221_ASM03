using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Enums;

namespace SignalRAssignment.BusinessLogic.RequestModels
{
    public class CreatePostRequest
    {
        [Required]
        public int AuthorID { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        [EnumDataType(typeof(PostPublishStatus))]
        public required string PublishStatus { get; set; } //Based on PostPublishStatus Enum

        [Required]
        public int CategoryID { get; set; }
    }
}