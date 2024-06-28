using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.DataAccess.Entities
{
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public required string Fullname { get; set; }

        public string? Address { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        //Navigators
        public virtual ICollection<Post> Posts { get; set; } = [];
    }
}
