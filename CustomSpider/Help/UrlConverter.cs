using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomSpider
{
    /// <summary>
    /// Url的转换器
    /// </summary>
    public static class UrlConverter
    {
        /// <summary>
        /// 判读Url是否为完整的
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>是否完整</returns>
        public static bool IsFullUrl(this string url)
        {
            try
            {
                return url.ToLower().StartsWith("http://") || url.ToLower().StartsWith("https://");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 转换为完整目录
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="baseUrl">url所属根url</param>
        /// <returns>完整的url<returns>
        public static string ConvertToFull(this  string url,string baseUrl)
        {
            Uri uri = new Uri(baseUrl);
            return string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, url);
        }
    }
}
