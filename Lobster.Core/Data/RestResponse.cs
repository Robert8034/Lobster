using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Lobster.Core.Data
{
    public class RestResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object ResponseObject { get; set; }

        public RestResponse()
        {

        }

        public RestResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public RestResponse(HttpStatusCode statusCode, object data)
        {
            StatusCode = statusCode;
            ResponseObject = data;
        }
    }
}
