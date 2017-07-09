using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomSpider.UI
{
    public partial class CustomCatch : UserControl,IHtmlSpider
    {
        private FormMain _main = null;
        
        /// <summary>
        /// 初始化一个通用爬虫参数构造函数
        /// </summary>
        /// <param name="main">主窗体</param>
        public CustomCatch(FormMain main)
        {
            InitializeComponent();
            _main = main;
        }

        private void CustomCatch_Paint(object sender, PaintEventArgs e)
        {
            clmDataType.Bind<DataType>();
            clmSaveType.Bind<SaveType>();
        }

        /// <summary>
        /// 爬虫的根Urls
        /// </summary>
        public string[] RootUrls
        {
            get { return new string[]{ txtRootUrl.Text}; }
        }

        /// <summary>
        /// 爬虫的获取策略
        /// </summary>
        public object RegexCondition
        {
            get
            {
                List<ParseModel> result = new List<ParseModel>();
                if (dataGridView1.Rows.Count > 1)
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        ParseModel model = new ParseModel();
                        model.DataType = clmDataType.Get<DataType>(i);
                        model.RegexString = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        model.SaveType = clmSaveType.Get<SaveType>(i);
                        result.Add(model);
                    }
                return result;
            }
        }

        /// <summary>
        /// 爬虫的解析引擎
        /// </summary>
        public IHtmlParser ParserEngin
        {
            get 
            {
                return this;
            }
        }
    }
}
