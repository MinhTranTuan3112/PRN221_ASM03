using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Shared.RequestModels
{
    public class SignUpRequest
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string FullName { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }
    }
}