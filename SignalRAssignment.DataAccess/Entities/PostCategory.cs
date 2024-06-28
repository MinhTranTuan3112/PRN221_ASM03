using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.DataAccess.Entities
{
    public class PostCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        public required string CategoryName { get; set; }

        public string? Description { get; set; }

        //Navigators
        public virtual ICollection<Post> Posts { get; set; } = [];
    }
}
