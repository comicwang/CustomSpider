using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CustomSpider.UI
{
    /// <summary>
    /// 百度图片下载器
    /// </summary>
    public partial class BaiduBitmap : UserControl, IHtmlSpider, IHtmlParser
    {
        /// <summary>
        /// 初始化一个百度下载器的参数构造函数
        /// </summary>
        public BaiduBitmap()
        {
            InitializeComponent();
        }

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

            JObject objRoot = (JObject)JsonConvert.DeserializeObject(content);
            JArray imgs = (JArray)objRoot["imgs"];
            for (int j = 0; j < imgs.Count; j++)
            {
                JObject img = (JObject)imgs[j];
                string objUrl = (string)img["objURL"];//http://hibiadu....../1.jpg
                urls.Add(objUrl);
            }
            MyConsole.AppendLine(string.Format("找到{0}个图片..", urls.Count));
            return urls;
        }

        /// <summary>
        /// 爬虫的根Urls
        /// </summary>
        public string[] RootUrls
        {
            get
            {
                List<string> urls = new List<string>();
                int page = int.Parse(txtPage.Text);
                for (int i = 0; i < page; i++)
                {
                    foreach (string key in txtKeywords.Lines)
                    {
                        string temp = "http://image.baidu.com/search/avatarjson?tn=resultjsonavatarnew&ie=utf-8&word=" + Uri.EscapeUriString(key) + "&cg=girl&pn=" + (i + 1) * 60 + "&rn=60&itg=0&z=0&fr=&width=&height=&lm=-1&ic=0&s=0&st=-1&gsm=360600003c";
                        urls.Add(temp);
                    }

                }
                return urls.ToArray();
            }
        }

        /// <summary>
        /// 爬虫的获取策略
        /// </summary>
        public object RegexCondition
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 爬虫的解析引擎
        /// </summary>
        public IHtmlParser ParserEngin
        {
            get { return this; }
        }
    }
}
