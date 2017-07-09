using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CustomSpider
{
    /// <summary>
    /// 定义一个HTML文件的下载器
    /// </summary>
    public class HtmlDownloader : IDisposable
    {
        #region fields

        private string _url = null;

        private Uri _uri = null;

        private string _downloadFilter = null;

        #endregion

        #region attributes

        /// <summary>
        /// 下载器的Url
        /// </summary>
        public string Url
        {
            get { return _url; }
        }

        /// <summary>
        /// 下载器的Uri
        /// </summary>
        public Uri Uri
        {
            get { return _uri; }
        }
        private WebClient _client = null;
        private Encoding _encoding = Encoding.Default;

        /// <summary>
        /// 下载的编码
        /// </summary>
        public Encoding Encoding
        {
            get { return _encoding; }
        }

        /// <summary>
        /// 文件过滤（将需要下载的文件以|隔开，下载器会匹配下载）
        /// </summary>
        public string DownloadFilter
        {
            get { return _downloadFilter; }
        }

        public delegate void DownloadChangedHandle(object sender, DownloadProgressChangedEventArgs e);
        /// <summary>
        /// 下载状态改变事件
        /// </summary>
        public event DownloadChangedHandle OnDownloadChanged;

        public delegate void DownloadCompletedHandle(object sender, DownloadCompletedEventArgs e);
        /// <summary>
        /// 下载完成事件
        /// </summary>
        public event DownloadCompletedHandle OnDownloadCompleted;

        public delegate void DownloadErroredHandle(object sender, DownloadErroredEventArgs e);
        /// <summary>
        /// 下载失败事件
        /// </summary>
        public event DownloadErroredHandle OnDownloadErrored;

        /// <summary>
        /// 获取当前Url能否链接
        /// </summary>
        /// <returns>是否能链接上</returns>
        public bool HasResponse
        {
            get
            {
                bool connected = false;
                try
                {
                    // Creates an HttpWebRequest for the specified URL.
                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(_uri);
                    // 有些网站会阻止程序访问，需要加入下面这句
                    myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                    myHttpWebRequest.Method = "GET";
                    // Sends the HttpWebRequest and waits for a response.
                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    connected = myHttpWebResponse.StatusCode == HttpStatusCode.OK;
                    // Releases the resources of the response.
                    myHttpWebResponse.Close();
                }
                catch (WebException e)
                {
                    throw e;//("\r\nWebException Raised. The following error occured : {0}", e.Status);
                }
                catch (Exception e)
                {
                    throw e; //Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
                }
                return connected;
            }
        }

        /// <summary>
        /// 获取当前Url是否为下载文件
        /// </summary>
        public bool IsLocalFile
        {
            get
            {
                foreach (var item in _downloadFilter.Split('|'))
                {
                    if (!string.IsNullOrEmpty(item) && _url.ToLower().EndsWith(item))
                        return true;
                }
                return false;
            }
        }

        #endregion

        #region ctor

        /// <summary>
        /// 初始化一个默认编码的下载器
        /// </summary>
        /// <param name="url">下载器的Url</param>
        /// <param name="downloadFilter">文件过滤</param>
        public HtmlDownloader(string url, string downloadFilter)
        {
            _uri = new Uri(url);
            _url = url;
            _downloadFilter = downloadFilter;
            _client = new WebClient();
            _client.Headers.Add("User-Agent", "Chrome");
        }

        /// <summary>
        /// 初始化一个自定义编码的下载器
        /// </summary>
        /// <param name="url">下载器的Url</param>
        /// <param name="downloadFilter">文件过滤</param>
        /// <param name="encoding">编码格式</param>
        public HtmlDownloader(string url, string downloadFilter, Encoding encoding)
            : this(url, downloadFilter)
        {
            _encoding = encoding;
            _client.Encoding = encoding;
        }

        #endregion
 
        #region public methods

        /// <summary>
        /// 开始挂起异步下载
        /// </summary>
        public void DownloadAsync()
        {
            if (IsLocalFile)
            {
                _client.DownloadDataCompleted += _client_DownloadDataCompleted;
                _client.DownloadDataAsync(_uri);
            }
            else
            {
                _client.DownloadStringCompleted += _client_DownloadStringCompleted;
                _client.DownloadStringAsync(_uri);
            }
            _client.DownloadProgressChanged += _client_DownloadProgressChanged;
        }

        /// <summary>
        /// 销毁下载器
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }

        #endregion

        #region private events

        private void _client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (OnDownloadCompleted != null)
                    OnDownloadCompleted(this, new DownloadCompletedEventArgs(e.Result, e.Result.GetType(), e.Cancelled, e.Error));
            }
            catch (Exception ex)
            {
                MyConsole.AppendLine(string.Format("处理下载完成异常:{0}!时间：{1}", ex.Message, DateTime.Now));
                if (OnDownloadErrored != null)
                    OnDownloadErrored(sender, new DownloadErroredEventArgs(_url, ex));
            }
        }

        private void _client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                if (OnDownloadCompleted != null)
                    OnDownloadCompleted(this, new DownloadCompletedEventArgs(e.Result, e.Result.GetType(), e.Cancelled, e.Error));
            }
            catch (Exception ex)
            {
                MyConsole.AppendLine(string.Format("处理下载完成异常:{0}!时间：{1}", ex.Message, DateTime.Now));
                if (OnDownloadErrored != null)
                    OnDownloadErrored(sender, new DownloadErroredEventArgs(_url, ex));
            }
        }

        private void _client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (OnDownloadChanged != null)
                OnDownloadChanged(this, e);
        }

        private void _client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (OnDownloadCompleted != null)
                    OnDownloadCompleted(this, new DownloadCompletedEventArgs(null, null, e.Cancelled, e.Error));
            }
            catch (Exception ex)
            {
                MyConsole.AppendLine(string.Format("处理下载完成异常:{0}!时间：{1}", ex.Message, DateTime.Now));
                if (OnDownloadErrored != null)
                    OnDownloadErrored(sender, new DownloadErroredEventArgs(_url, ex));
            }
        }

        #endregion
    }
}
