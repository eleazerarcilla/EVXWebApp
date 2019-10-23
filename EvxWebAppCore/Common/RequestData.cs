using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common
{
    public class RequestData
    {
        public string APIBaseAddress { get; set; }
        public HttpMethod Method { get; set; }
        public string Paramters { get; set; }
        public string JSONData { get; set; }
        public string ContentType { get; set; }
    }
}
