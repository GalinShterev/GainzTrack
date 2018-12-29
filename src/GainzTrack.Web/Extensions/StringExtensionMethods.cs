using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GainzTrack.Web.Extensions
{
    public static class StringExtensionMethods
    {
        public static string DecodeUrl(this string str)
        {
            return WebUtility.UrlDecode(str);
        }
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            var sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(char.ToUpper(str[i]));
                    continue;
                }
                    
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
