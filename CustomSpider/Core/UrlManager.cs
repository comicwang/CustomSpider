using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomSpider
{
    /// <summary>
    /// 爬取地址管理
    /// </summary>
    public class UrlManager
    {
        #region fields

        private static Queue<string> _newUrls = new Queue<string>();
        private static List<string> _oldUrls = new List<string>();
        private static string _baseForlder = null;
        private static int _limitedCount = 0;

        #endregion

        #region ctor hide

        /// <summary>
        /// 隐藏构造函数
        /// </summary>
        private UrlManager() { }

        #endregion

        #region attributes

        public delegate void UrlAddedHander(object sender, OnUrlAddedEventArgs e);
        /// <summary>
        /// 触发新增一个Url事件
        /// </summary>
        public static event UrlAddedHander OneUrlAdded;
        public delegate void UrlPopedHander(object sender, OnUrlPopedEventArgs e);
        /// <summary>
        /// 触发移出一个Url事件
        /// </summary>
        public static event UrlPopedHander OneUrlPoped;

        /// <summary>
        /// 获取存储已经爬取的地址的集合
        /// </summary>
        public static List<string> OldUrls
        {
            get { return UrlManager._oldUrls; }
        }

        /// <summary>
        /// 获取存储和移出新的地址的集合
        /// </summary>
        public static Queue<string> NewUrls
        {
            get { return UrlManager._newUrls; }
        }

        /// <summary>
        /// 获取或者设置限制下载个数
        /// </summary>
        public static int LimitedCount
        {
            get { return UrlManager._limitedCount; }
            set { UrlManager._limitedCount = value; }
        }

        /// <summary>
        /// 获取或者设置文件下载到的根目录（用于本地文件去重）
        /// </summary>
        public static string BaseForlder
        {
            get { return UrlManager._baseForlder; }
            set { UrlManager._baseForlder = value; }
        }

        /// <summary>
        /// 获取当前是否存在未爬取的Url
        /// </summary>
        public static bool HasUrl
        { 
            get { return _newUrls.Count > 0; } 
        }

        #endregion

        #region public methods

        /// <summary>
        /// 增加一个Url地址
        /// </summary>
        /// <param name="baseUrl">爬取到的Url链接所属Url-用于补全部分缺少Host的地址</param>
        /// <param name="url">Url地址</param>
        public static void AddNewUrl(string baseUrl,string url)
        {
            if (!url.IsFullUrl())
                url = url.ConvertToFull(baseUrl);
            if (string.IsNullOrEmpty(url) || (_limitedCount != 0 && (_newUrls.Count + _oldUrls.Count) > _limitedCount) || AuthurUrl(url) == false || _newUrls.Contains(url) || _oldUrls.Contains(url) || AuthurFile(url, _baseForlder) == false)
                return;
            if (OneUrlAdded != null)
                OneUrlAdded(_newUrls, new OnUrlAddedEventArgs(url));
            _newUrls.Enqueue(url);         
        }

        /// <summary>
        /// 批量增加Url地址
        /// </summary>
        /// <param name="baseUrl">爬取到的Url链接所属Url-用于补全部分缺少Host的地址</param>
        /// <param name="paramUrls">Url地址</param>
        public static void AddNewUrls(string baseUrl,params string[] paramUrls)
        {
            if (paramUrls.Length > 0)
                Array.ForEach(paramUrls, t => { AddNewUrl(baseUrl,t); });
        }

        /// <summary>
        /// 移出一个Url(有队列组成，先进先出)
        /// </summary>
        /// <returns>移出的Url地址</returns>
        public static string PopOneUrl()
        {
            if (_newUrls.Count == 0)
                return null;
            string url = _newUrls.Dequeue();
            _oldUrls.Add(url);
            if (OneUrlPoped != null)
                OneUrlPoped(_newUrls, new OnUrlPopedEventArgs(url));
            return url;
        }

        #endregion

        #region private methods

        private static bool AuthurUrl(string url)
        {
            Regex regex = new Regex(@"http(s)?://\s*");
            return regex.IsMatch(url);
        }

        private static bool AuthurFile(string url, string searchForlder)
        {
            using (HtmlDownloader downloader = new HtmlDownloader(url, Properties.Resources.FileFilter))
            {
                if (downloader.IsLocalFile)
                {
                    //文件去重
                    string[] result = Directory.GetFiles(searchForlder, Path.GetFileName(url), SearchOption.AllDirectories);
                    if (result != null && result.Length > 0)
                        return false;
                }
            }
            return true;
        }

        #endregion
    }
}
