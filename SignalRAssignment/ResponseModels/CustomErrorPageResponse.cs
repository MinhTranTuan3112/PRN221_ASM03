using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.ResponseModels
{
    public class CustomErrorPageResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}