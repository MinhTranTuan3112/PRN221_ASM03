using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Shared.RequestModels
{
    public class DeletePostRequest
    {
        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}