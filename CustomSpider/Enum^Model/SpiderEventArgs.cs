using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomSpider
{

    /// <summary>
    /// 下载器下载完成参数
    /// </summary>
    public class DownloadCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化一个下载器完成参数
        /// </summary>
        /// <param name="obj">完成返回的值</param>
        /// <param name="type">返回的类型</param>
        /// <param name="canceled">是否取消</param>
        /// <param name="exception">下载异常</param>
        public DownloadCompletedEventArgs(object obj, Type type, bool canceled, Exception exception)
        {
            Result = obj;
            ResultType = type;
            Canceled = canceled;
            Exception = exception;
        }

        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool Canceled { get; private set; }

        /// <summary>
        /// 下载结果
        /// </summary>
        public object Result { get; private set; }

        /// <summary>
        /// 结果类型
        /// </summary>
        public Type ResultType { get; private set; }
    }

    /// <summary>
    /// 下载失败事件参数
    /// </summary>
    public class DownloadErroredEventArgs : EventArgs
    {
        /// <summary>
        /// 下载器的地址
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// 初始化一个下载失败事件参数
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="ex">异常</param>
        public DownloadErroredEventArgs(string url, Exception ex)
        {
            Url = url;
            Exception = ex;
        }
    }

    public class OnUrlAddedEventArgs : EventArgs
    {
        public string Url { get; private set; }

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
