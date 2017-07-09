using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomSpider
{
    /// <summary>
    /// 定义文件爬取转换引擎，用于处理爬取到的内容（下载资源，或者寻找新的Urls）
    /// </summary>
    public interface IHtmlParser
    {
        /// <summary>
        /// 开始转换爬取到的内容
        /// 参数说明：
        /// 1.需要转换的文本内容（一般编码为UTF-8）
        /// 2.文件存储的根目录，用于文本存储方式下的存储本地文件
        /// 3.url地址，用于对新的url进行转换
        /// </summary>
        /// <param name="param">转换所需要的参数</param>
        /// <returns>新的Urls</returns>
        List<string> ParseUrl(params object[] param);
    }
}
