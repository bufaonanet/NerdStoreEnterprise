using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomHttpResponseExcption : Exception
    {
        public HttpStatusCode StatusCode;

        public CustomHttpResponseExcption() { }
        public CustomHttpResponseExcption(string message, Exception innerException) : base(message, innerException)
        { }

        public CustomHttpResponseExcption(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;                
        }

    }
}
