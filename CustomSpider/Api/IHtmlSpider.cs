using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomSpider
{
    /// <summary>
    /// 定义一个爬取的接口，用于存储爬虫流程中的参数，以及转换引擎
    /// </summary>
    public interface IHtmlSpider
    {
        /// <summary>
        /// 获取爬虫的入口Urls
        /// </summary>
        string[] RootUrls { get; }

        /// <summary>
        /// 获取需要爬取的文件的规则
        /// </summary>
        object RegexCondition { get; }

        /// <summary>
        /// 获取文件爬取引擎
        /// </summary>
        IHtmlParser ParserEngin { get; }
    }
}
