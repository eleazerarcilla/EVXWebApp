using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.ViewModel
{
    public class ErrorViewModel
    {
        public Exception Exception { get; set; }
        public string ErrorMessage { get; set; } = "An unexpected error occurred.";
        public int ErrorCode { get; set; }
    }
}
