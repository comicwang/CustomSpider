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

        public delegate void UrlAddedHander(object sender, OnUrlAddedEventArgs e);
        public static event UrlAddedHander OnUrlAdded;
        public delegate void UrlPopedHander(object sender, OnUrlPopedEventArgs e);
        public static event UrlPopedHander OnUrlPoped;

        public static void AddNewUrl(string url)
        {
            if (string.IsNullOrEmpty(url) || AuthurUrl(url) == false || urls.Contains(url) || oldUrls.Contains(url))
                return;
            urls.Enqueue(url);
            if (OnUrlAdded != null)
                OnUrlAdded(urls, new OnUrlAddedEventArgs(url));
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
            if (OnUrlPoped != null)
                OnUrlPoped(urls, new OnUrlPopedEventArgs(url));
            return url;
        }

        public static bool HasUrl
        { get { return urls.Count > 0; } }

        private static bool AuthurUrl(string url)
        {
            Regex regex = new Regex(string.Format(@Properties.Resources.FileRegex,Properties.Resources.FileFilter));

            return regex.IsMatch(url);
        }
    }

    public class OnUrlAddedEventArgs : EventArgs
    {
        public string Url { get;private set; }

        public OnUrlAddedEventArgs(string url)
        {
            Url = url;
        }
    }


    public class OnUrlPopedEventArgs : EventArgs
    {
        public string Url { get; private set; }

        public OnUrlPopedEventArgs(string url)
        {
            Url = url;
        }
    }
}
