using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.DTO
{
    class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
