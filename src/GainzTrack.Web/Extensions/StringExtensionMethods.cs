using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GainzTrack.Web.Extensions
{
    public static class StringExtensionMethods
    {
        public static string DecodeUrl(this string str)
        {
            return WebUtility.UrlDecode(str);
        }
    }
}
