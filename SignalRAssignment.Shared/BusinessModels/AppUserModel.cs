using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Shared.BusinessModels
{
    public class AppUserModel
    {
        public int UserID { get; set; }

        public required string Fullname { get; set; }

        public string? Address { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}