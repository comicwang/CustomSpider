using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CustomSpider
{
    public partial class FormMain : Form
    {
        private List<ParseModel> _parses = null;
        public FormMain()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            clmDataType.Bind<DataType>();
            clmSaveType.Bind<SaveType>();
            console.Bind();
            UrlManager.OnUrlAdded += UrlManager_OnUrlAdded;
            UrlManager.OnUrlPoped += UrlManager_OnUrlPoped;
        }

        private Func<DataGridView, string, SpiderState, bool> UpdateGrid = (d, u, s) =>
        {
            int rowIndex = d.Find(u);
            if (rowIndex == -1)
            {
                rowIndex = d.Rows.Add();
            }
            d.Rows[rowIndex].SetValues(rowIndex, u, s, s == SpiderState.已完成 ? "查看" : "");
            return false;
        };

        private void UpdateGridView(string url,SpiderState state)
        {
             if (dataGridView2.InvokeRequired)
                dataGridView2.Invoke(UpdateGrid,dataGridView2,url,state);
        }

        private void UrlManager_OnUrlAdded(object sender, OnUrlAddedEventArgs e)
        {
            UpdateGridView(e.Url, SpiderState.等待中);
        }

        private void UrlManager_OnUrlPoped(object sender, OnUrlPopedEventArgs e)
        {
            UpdateGridView(e.Url, SpiderState.准备爬取);
        }

        private void btnSpider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRootUrl.Text) || dataGridView1.Rows.Count < 1)
                return;
            MyConsole.AppendSign();
            MyConsole.AppendLine("爬取程序正在启动...");
            //获取参数
            MyConsole.AppendLine("开始收集爬虫需要的参数>>>");
            string rootUrl = txtRootUrl.Text;
            string baseForlder = txtBasePath.Text;
            _parses = new List<ParseModel>();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ParseModel model = new ParseModel();
                model.DataType = clmDataType.Get<DataType>(i);
                model.RegexString = dataGridView1.Rows[i].Cells[1].Value.ToString();
                model.SaveType = clmSaveType.Get<SaveType>(i);
                _parses.Add(model);
            }
            MyConsole.AppendLine("开始爬取..");
            UrlManager.AddNewUrl(rootUrl);
            //开始爬取
            Thread spiderThead = new Thread(new ThreadStart(delegate {
                while (true)
                {
                    if (UrlManager.HasUrl)
                    {
                        try
                        {
                            string url = UrlManager.PopOneUrl();
                            //开始爬取
                            HtmlDownloader download = new HtmlDownloader(url,Properties.Resources.FileFilter);
                            download.OnDownloadChanged += download_OnDownloadChanged;
                            download.OnDownloadCompleted += download_OnDownloadCompleted;
                            if (download.CanResponce())
                            {
                                download.DownloadAsync();
                                UpdateGridView(url, SpiderState.爬取中);
                            }
                            else
                            {
                                UpdateGridView(url, SpiderState.失败);
                            }                          
                        }
                        catch (Exception ex)
                        {
                            MyConsole.AppendLine(string.Format("爬取失败：", ex.Message));
                        }
                    }
                }          
            }));

            spiderThead.IsBackground = true;
            spiderThead.Start();
        }

        void download_OnDownloadCompleted(object sender, DownloadCompletedEventArgs e)
        {
            string url = (sender as HtmlDownloader).Url;
            if (e.Canceled)
            {
                UpdateGridView(url, SpiderState.取消);
                return;
            }
            if (e.Exception != null)
            {
                UpdateGridView(url, SpiderState.失败);
                MyConsole.AppendLine(string.Format("下载Url：{0}失败,异常原因：" + e.Exception.Message));
                return;
            }
            if (e.ResultType == typeof(String))
            {
                HtmlParser parser = new HtmlParser(url, e.Result.ToString(), txtBasePath.Text);
                UrlManager.AddNewUrls(parser.Parse(_parses).ToArray());
            }
            else
            {
                MyConsole.AppendLine(string.Format("正在写入Url:{0}里面的文件,写入时间:{1}", url, DateTime.Now));
                //文件存储
                ContentSaver.Save(txtBasePath.Text, e.Result as byte[], SaveType.文件, Path.GetExtension(url));
            }
            UpdateGridView(url, SpiderState.已完成);
        }

        void download_OnDownloadChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBasePath.Text = dialog.SelectedPath;
            }
        }
    }

    public enum SpiderState
    {
        等待中 = 0,
        准备爬取 = 1,
        爬取中 = 2,
        已完成 = 3,
        失败 = 4,
        取消=5
    }
}
