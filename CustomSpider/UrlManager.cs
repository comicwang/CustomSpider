using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomSpider
{
    public class UrlManager
    {
        private static Queue<string> urls = new Queue<string>();
        private static List<string> oldUrls = new List<string>();

        private UrlManager() { }
        public static void AddNewUrl(string url)
        {
            if (string.IsNullOrEmpty(url) || AuthurUrl(url) == false || urls.Contains(url) || oldUrls.Contains(url))
                return;
            urls.Enqueue(url);
        }

        public static void AddNewUrls(params string[] paramUrls)
        {
            if (paramUrls.Length > 0)
                Array.ForEach(paramUrls, t => { AddNewUrl(t); });
        }

        public static string PopOneUrl()
        {
            if (urls.Count == 0)
                return null;
            string url = urls.Dequeue();
            oldUrls.Add(url);
            return url;
        }

        public static bool HasUrl
        { get { return urls.Count > 0; } }

        private static bool AuthurUrl(string url)
        {
            Regex regex = new Regex(@"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$");

            return regex.IsMatch(url);
        }
    }
}
