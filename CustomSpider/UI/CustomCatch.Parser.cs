using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomSpider.UI
{
    public partial class CustomCatch : IHtmlParser
    {
        /// <summary>
        /// 开始解析转换爬取到的Url内容
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>新的Urls</returns>
        public List<string> ParseUrl(params object[] param)
        {
            if (param.Length < 3)
                return null;
            string content = param[0].ToString();
            string baseForlder = param[1].ToString();
            string url = param[2].ToString();

            MyConsole.AppendLine(string.Format("开始解析Url:{0}的内容", url));
            List<string> urls = new List<string>();

            Regex regex = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))",
 RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (regex.IsMatch(content))
            {
                MatchCollection collection = regex.Matches(content);
                foreach (Match item in collection)
                    urls.Add(item.Groups[1].Value);
            }
            MyConsole.AppendLine(string.Format("找到{0}个锚点..", urls.Count));

            regex = new Regex(@"(?i)<img[^>]*?\ssrc\s*=\s*(['""]?)(?<src>[^'""\s>]+)\1[^>]*>");
            MatchCollection mc = regex.Matches(content);
            foreach (Match m in mc)
            {
                urls.Add(m.Groups["src"].Value);
            }
            MyConsole.AppendLine(string.Format("找到{0}个图片..", mc.Count));

            //返回新的Url
            List<ParseModel> parseModels = RegexCondition as List<ParseModel>;
            //储存需要的文本
            if (parseModels != null && parseModels.Count > 0)
                foreach (var item in parseModels)
                {
                    Regex temp = new Regex(item.RegexString);
                    if (temp.IsMatch(content))
                    {
                        MatchCollection matches = temp.Matches(content);
                        foreach (Match match in matches)
                        {
                            ContentManger.Save(baseForlder, Encoding.Default.GetBytes(match.Value), item.SaveType, Guid.NewGuid().ToString() + ".txt");
                            _main.DownloadFileCount++;
                        }
                    }
                }
            return urls;
        }
    }

}
