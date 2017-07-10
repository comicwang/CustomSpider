using CustomSpider.UI;
using DevComponents.DotNetBar;
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
        #region fields

        private BaiduBitmap _baiduBitmap = null;//百度爬取控件
        private CustomCatch _customCatch = null; //一般爬取控件
        private DateTime? _startTime = null; //爬取开始时间
        private ResultChart _chart = null; //报表控件
        private SpiderType _spiderType = SpiderType.BaiduBitmap;//爬取类型
        private string _baseForlder = null; //保存文件根目录

        private int _downloadFileCount = 0;
        private int _totalCount = 0;
        private int _completedCount = 0;
        private int _failedCount = 0;
        private int _limitedCount = 0;

        /// <summary>
        /// 更新表格的方法
        /// </summary>
        private Action<DataGridView, string, SpiderState> UpdateGrid = (d, u, s) =>
        {
            int rowIndex = d.Find(u);
            if (rowIndex == -1)
            {
                rowIndex = d.Rows.Add();
            }
            if (s == SpiderState.失败)
                d.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
            d.Rows[rowIndex].SetValues(rowIndex, u, s, s == SpiderState.已完成 ? "查看" : "");
        };

        /// <summary>
        /// 更新LabelItem
        /// </summary>
        private Action<LabelItem, int> UpdateCount = (t, c) =>
        {
            t.Text = c.ToString();
        };


        #endregion

        #region attributes

        /// <summary>
        /// 限制下载文件个数
        /// </summary>
        public int LimitedCount
        {
            get { return _limitedCount; }
            set { _limitedCount = value; }
        }

        /// <summary>
        /// 下载完成文件个数
        /// </summary>
        public int DownloadFileCount
        {
            get { return _downloadFileCount; }
            set { _downloadFileCount = value; }
        }

            /// <summary>
        /// 文件总个数
        /// </summary>
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
}

        /// <summary>
        /// 完成个数
        /// </summary>
        public int CompletedCount
        {
            get { return _completedCount; }
            set { _completedCount = value; }
        }

        /// <summary>
        /// 失败个数
        /// </summary>
        public int FailedCount
        {
            get { return _failedCount; }
            set { _failedCount = value; }
        }

        /// <summary>
        /// 爬取条件控件
        /// </summary>
        public Control AttachControl
        {
            get { return pnlRight.HasChildren ? pnlRight.Controls[0] : null; }

            internal set
            {
                pnlRight.Controls.Clear();
                pnlRight.Controls.Add(value);
            }
        }

        /// <summary>
        /// 爬取类型
        /// </summary>
        public SpiderType SpiderType
        {
            get { return _spiderType; }
            set { _spiderType = value; }
        }

        #endregion

        #region ctor

        /// <summary>
        /// 初始化爬虫控件
        /// </summary>
        public FormMain()
        {
            InitializeComponent();          
        }

        #endregion

        #region private methods

        private void InitializeControl()
        {
            if (_baiduBitmap == null)
            {
                _baiduBitmap = new BaiduBitmap();
                _baiduBitmap.Dock = DockStyle.Fill;
            }
            if (_chart == null)
            {
                _chart = new ResultChart(this);
                _chart.Dock = DockStyle.Fill;
            }
            AttachControl = _baiduBitmap;                    
            console.Bind();
        }

        private void InitializeUrlManager()
        {
            UrlManager.OneUrlAdded += UrlManager_OnUrlAdded;
            UrlManager.OneUrlPoped += UrlManager_OnUrlPoped;
        }

        private void SetControlState(bool enable)
        {
            txtNum.Enabled = enable;
            txtBasePath.ReadOnly = !enable;
            btnScan.Enabled = enable;
            AttachControl.Enabled = enable;
            AttachControl.Visible = enable;
        }

        private void UpdateGridView(string url, SpiderState state)
        {
            switch (state)
            {
                case SpiderState.等待中:
                    _totalCount++;
                    break;
                case SpiderState.准备爬取:
                    break;
                case SpiderState.爬取中:
                    break;
                case SpiderState.已完成:
                    _completedCount++;
                    break;
                case SpiderState.失败:
                    _failedCount++;
                    break;
                case SpiderState.取消:
                    _completedCount++;
                    break;
                default:
                    break;
            }
            if (dataGridView2.InvokeRequired)
                dataGridView2.Invoke(UpdateGrid, dataGridView2, url, state);
            if (lblTotal.InvokeRequired)
                lblTotal.Invoke(UpdateCount, new object[] { lblTotal, _totalCount });
            if (lblLeft.InvokeRequired)
                lblLeft.Invoke(UpdateCount, new object[] { lblLeft, _totalCount - _completedCount - _failedCount });
            if (lblFailed.InvokeRequired)
                lblFailed.Invoke(UpdateCount, new object[] { lblFailed, _failedCount });
            if (lblComplete.InvokeRequired)
                lblComplete.Invoke(UpdateCount, new object[] { lblComplete, _completedCount });
            if (pbAll.InvokeRequired)
                pbAll.Invoke(new Action<int>((t) => { pbAll.Value = t; }), new object[] { (int)((_completedCount + _failedCount) * 100 / _totalCount) });
            if (lblFileCount.InvokeRequired)
                lblFileCount.Invoke(new Action<int>((t) => { lblFileCount.Text = t.ToString(); }), new object[] { _downloadFileCount });
        }

        #endregion

        #region private event

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
            _baseForlder = txtBasePath.Text;         
            string[] rootUrl = (AttachControl as IHtmlSpider).RootUrls; ;           
            if (string.IsNullOrEmpty(_baseForlder) || rootUrl == null || rootUrl.Length == 0)
                return;
            SetControlState(false);

            MyConsole.AppendLine("爬取程序正在启动...");
            //获取参数
            MyConsole.AppendLine("开始收集爬虫需要的参数>>>");  
       
            _limitedCount = int.Parse(txtNum.Text);
            pnlRight.Controls.Add(_chart); //显示报表控件
            MyConsole.AppendSign();         
            MyConsole.AppendLine("开始爬取..");

            _startTime = DateTime.Now; //记录爬取初始时间
            UrlManager.BaseForlder = _baseForlder;
            UrlManager.LimitedCount = _limitedCount;
          
            UrlManager.AddNewUrls(rootUrl[0],rootUrl);  //添加根地址

            //设置爬虫的线程个数
            for (int i = 0; i < txtThreadNum.Value; i++)
            {
                //开始爬取
                Thread spiderThead = new Thread(new ThreadStart(delegate
                {
                    while (true)
                    {
                        if (_limitedCount != 0 && _totalCount > _limitedCount)
                        {
                            continue;
                        }
                        if (UrlManager.HasUrl)
                        {
                            string url = UrlManager.PopOneUrl();
                            try
                            {
                                //初始化爬虫下载器
                                HtmlDownloader download = new HtmlDownloader(url, Properties.Resources.FileFilter, Encoding.UTF8);
                                download.OnDownloadChanged += download_OnDownloadChanged;
                                download.OnDownloadCompleted += download_OnDownloadCompleted;
                                download.OnDownloadErrored += download_OnDownloadErrored;                              
                                if (download.HasResponse)
                                {
                                    MyConsole.AppendLine(string.Format("开始爬取Url:{0},时间:{1}", url, DateTime.Now));
                                    download.DownloadAsync();
                                    UpdateGridView(url, SpiderState.爬取中);
                                }
                                else
                                {
                                    MyConsole.AppendLine(string.Format("爬取Url:{0}失败,异常原因:远程链接失败,时间:{1}", url, DateTime.Now));
                                    UpdateGridView(url, SpiderState.失败);
                                }
                            }
                            catch (Exception ex)
                            {
                                MyConsole.AppendLine(string.Format("爬取Url:{0}失败,异常原因:{1},时间:{2}", url, ex.Message, DateTime.Now));
                                UpdateGridView(url, SpiderState.失败);
                            }
                        }
                    }
                }));
                spiderThead.Name = "SpiderThead" + i;
                spiderThead.IsBackground = true;
                spiderThead.Start();
            }
        }

        private void download_OnDownloadErrored(object sender, DownloadErroredEventArgs e)
        {
            UpdateGridView(e.Url, SpiderState.失败);
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
                MyConsole.AppendLine(string.Format("下载Url：{0}失败,异常原因：{1}" + url, e.Exception.Message));
                return;
            }
            if (e.ResultType == typeof(String))
            {
                IHtmlParser parser = (AttachControl as IHtmlSpider).ParserEngin;
                List<string> newUrls = parser.ParseUrl(e.Result.ToString(), _baseForlder, url);
                UrlManager.AddNewUrls(url, newUrls.ToArray());
            }
            else
            {
                //文件存储
                ContentManger.Save(txtBasePath.Text, e.Result as byte[], SaveType.文件, Path.GetFileName(url));
                _downloadFileCount++;
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeControl();
            InitializeUrlManager();
        }

        private void btnBaiduImage_Click(object sender, EventArgs e)
        {
            if (_baiduBitmap == null)
            {
                _baiduBitmap = new BaiduBitmap();
                _baiduBitmap.Dock = DockStyle.Fill;
            }
            AttachControl = _baiduBitmap;
            _spiderType = CustomSpider.SpiderType.BaiduBitmap;
        }

        private void btnCustomSpider_Click(object sender, EventArgs e)
        {
            if (_customCatch == null)
            {
                _customCatch = new CustomCatch(this);
                _customCatch.Dock = DockStyle.Fill;
            }
            AttachControl = _customCatch;
            _spiderType = CustomSpider.SpiderType.CustiomCatch;
        }

        private void tmShowNow_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
            if (_startTime != null)
                lblWasteTime.Text = (DateTime.Now - _startTime.Value).ToString();
        }

        #endregion

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != Column7.Index)
                return;
            ContentManger.View(_baseForlder, SaveType.文件, Path.GetFileName(dataGridView2[1, e.RowIndex].Value.ToString()));
        }
    }
}
