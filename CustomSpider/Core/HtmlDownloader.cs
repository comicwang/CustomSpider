using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CustomSpider
{
    public class HtmlDownloader : IDisposable
    {
        private string _url = null;

        public string Url
        {
            get { return _url; }
        }

        private Uri _uri = null;

        public Uri Uri
        {
            get { return _uri; }
        }
        private WebClient _client = null;
        private Encoding _encoding = Encoding.Default;

        public Encoding Encoding
        {
            get { return _encoding; }
        }

        private string _downloadFilter = null;

        public string DownloadFilter
        {
            get { return _downloadFilter; }
        }

        public delegate void DownloadChangedHandle(object sender, DownloadProgressChangedEventArgs e);
        public event DownloadChangedHandle OnDownloadChanged;

        public delegate void DownloadCompletedHandle(object sender, DownloadCompletedEventArgs e);
        public event DownloadCompletedHandle OnDownloadCompleted;

        public HtmlDownloader(string url,string downloadFilter)
        {
            _uri = new Uri(url);
            _url = url;
            _downloadFilter = downloadFilter;
            _client = new WebClient();
            _client.Headers.Add("User-Agent", "Chrome");
        }

        public HtmlDownloader(string url, string downloadFilter, Encoding encoding)
            : this(url,downloadFilter)
        {
            _encoding = encoding;
        }

        public bool CanResponce()
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

        public bool IsLocalFile
        {
            get
            {
                foreach (var item in _downloadFilter.Split(';'))
                {
                    if (!string.IsNullOrEmpty(item) && _url.ToLower().EndsWith(item))
                        return true;
                }
                return false;
            }
        }

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

        void _client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (OnDownloadCompleted != null)
                OnDownloadCompleted(this, new DownloadCompletedEventArgs(e.Result, e.Result.GetType(), e.Cancelled, e.Error));
        }

        void _client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (OnDownloadCompleted != null)
                OnDownloadCompleted(this, new DownloadCompletedEventArgs(e.Result, e.Result.GetType(),e.Cancelled,e.Error));
        }

        void _client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (OnDownloadChanged != null)
                OnDownloadChanged(this, e);
        }

        void _client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (OnDownloadCompleted != null)
                OnDownloadCompleted(this, new DownloadCompletedEventArgs(null, null, e.Cancelled, e.Error));
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }

    public class DownloadCompletedEventArgs : EventArgs
    {
        public DownloadCompletedEventArgs(object obj, Type type,bool canceled,Exception exception)
        {
            Result = obj;
            ResultType = type;
            Canceled = canceled;
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public bool Canceled { get; private set; }

        public object Result { get; private set; }

        public Type ResultType { get; private set; }
    }
}
