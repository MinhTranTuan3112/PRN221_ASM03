using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.DataAccess.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }

        public int AuthorID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public required string PublishStatus { get; set; } //Based on PostPublishStatus Enum

        public int CategoryID { get; set; }

        //Navigators
        public virtual AppUser AppUser { get; set; } = null!;

        public virtual PostCategory PostCategory { get; set; } = null!;
    }
}
