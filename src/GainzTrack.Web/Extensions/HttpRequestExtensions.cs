using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Extensions
{
    public static class HttpRequestExtensions
    {
        private const string REQUESTED_WITH_HEADER = "X-Requested-With";
        private const string XML_HTTP_REQUEST = "XMLHttpRequest";

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.Headers[REQUESTED_WITH_HEADER] == XML_HTTP_REQUEST;
        }
    }
}
