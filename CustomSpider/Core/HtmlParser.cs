using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomSpider
{
    public class HtmlParser
    {
        private string _content = null;
        private string _baseForlder = null;
        private string _url = null;
        public HtmlParser(string url, string content, string baseForlder)
        {
            _content = content;
            _baseForlder = baseForlder;
            _url = url;
        }

        public List<string> Parse(List<ParseModel> parseModels)
        {
            MyConsole.AppendLine(string.Format("开始解析Url:{0}的内容", _url));
            List<string> urls = new List<string>();

            Regex regex = new Regex(string.Format(@Properties.Resources.FileRegex, Properties.Resources.FileFilter));
            if (regex.IsMatch(_content))
            {
                MatchCollection collection = regex.Matches(_content);
                foreach (Match item in collection)
                    urls.Add(item.Value);
            }
            MyConsole.AppendLine(string.Format("找到{0}个新锚点..", urls.Count));
            //返回新的Url

            //储存需要的文本
            if (parseModels != null && parseModels.Count > 0)
                foreach (var item in parseModels)
                {
                    Regex temp = new Regex(item.RegexString);
                    if (temp.IsMatch(_content))
                    {
                        MatchCollection matches = temp.Matches(_content);
                        foreach (Match match in matches)
                        {
                            MyConsole.AppendLine(string.Format("正在写入Url:{0}里面的文件,写入时间:{1}", _url, DateTime.Now));
                            ContentSaver.Save(_baseForlder, Encoding.Default.GetBytes(match.Value), item.SaveType, ".txt");
                        }

                    }
                }
            return urls;
        }
    }

    public class ParseModel
    {
        public string RegexString { get; set; }

        public SaveType SaveType { get; set; }

        public DataType DataType { get; set; }
    }

    public enum SaveType
    {
        文本内容 = 0,
        文件 = 1,
        表格 = 2,
        数据库 = 3
    }

    public enum DataType
    {
        文本 = 0,
        图片 = 1,
        视频 = 2
    }
}
