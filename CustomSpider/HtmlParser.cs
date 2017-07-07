using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomSpider
{
    public class HtmlParser
    {
        private string _url = string.Empty;
        public HtmlParser(string url)
        {
            _url = url;
        }

        public List<string> Parse(List<ParseModel> parseModels)
        {
            List<string> urls = new List<string>();

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
        File,
        Table,
        Sql
    }

    public enum DataType
    {
        Text,
        Image,
        Vedio
    }
}
