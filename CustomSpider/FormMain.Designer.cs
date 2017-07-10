namespace CustomSpider
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNum = new System.Windows.Forms.NumericUpDown();
            this.txtThreadNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnSpider = new System.Windows.Forms.Button();
            this.txtBasePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.console = new System.Windows.Forms.TextBox();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblComplete = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.lblLeft = new DevComponents.DotNetBar.LabelItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.lblTotal = new DevComponents.DotNetBar.LabelItem();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.lblFailed = new DevComponents.DotNetBar.LabelItem();
            this.labelItem11 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem12 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem13 = new DevComponents.DotNetBar.LabelItem();
            this.lblWasteTime = new DevComponents.DotNetBar.LabelItem();
            this.labelItem15 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.lblFileCount = new DevComponents.DotNetBar.LabelItem();
            this.lblTime = new DevComponents.DotNetBar.LabelItem();
            this.pbAll = new DevComponents.DotNetBar.ProgressBarItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnBaiduImage = new DevComponents.DotNetBar.ButtonItem();
            this.btnCustomSpider = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem9 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem14 = new DevComponents.DotNetBar.LabelItem();
            this.tmShowNow = new System.Windows.Forms.Timer(this.components);
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThreadNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.console);
            this.splitContainer1.Panel2.Controls.Add(this.bar2);
            this.splitContainer1.Size = new System.Drawing.Size(1201, 617);
            this.splitContainer1.SplitterDistance = 463;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1201, 463);
            this.splitContainer2.SplitterDistance = 863;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightYellow;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(863, 463);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlRight);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 463);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "爬虫策略";
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(3, 17);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(328, 248);
            this.pnlRight.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNum);
            this.panel1.Controls.Add(this.txtThreadNum);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnScan);
            this.panel1.Controls.Add(this.btnSpider);
            this.panel1.Controls.Add(this.txtBasePath);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 195);
            this.panel1.TabIndex = 0;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(77, 12);
            this.txtNum.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(120, 21);
            this.txtNum.TabIndex = 36;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThreadNum
            // 
            this.txtThreadNum.Location = new System.Drawing.Point(77, 69);
            this.txtThreadNum.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtThreadNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThreadNum.Name = "txtThreadNum";
            this.txtThreadNum.Size = new System.Drawing.Size(120, 21);
            this.txtThreadNum.TabIndex = 35;
            this.txtThreadNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtThreadNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(207, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "爬取的线程个数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(207, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "0 - 无限个数";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(221, 38);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 23;
            this.btnScan.Text = "浏览";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnSpider
            // 
            this.btnSpider.Location = new System.Drawing.Point(18, 96);
            this.btnSpider.Name = "btnSpider";
            this.btnSpider.Size = new System.Drawing.Size(284, 92);
            this.btnSpider.TabIndex = 22;
            this.btnSpider.Text = "爬取";
            this.btnSpider.UseVisualStyleBackColor = true;
            this.btnSpider.Click += new System.EventHandler(this.btnSpider_Click);
            // 
            // txtBasePath
            // 
            this.txtBasePath.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtBasePath.Location = new System.Drawing.Point(77, 39);
            this.txtBasePath.Name = "txtBasePath";
            this.txtBasePath.Size = new System.Drawing.Size(140, 21);
            this.txtBasePath.TabIndex = 20;
            this.txtBasePath.Text = "D:\\新建文件夹";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "文件存储";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "线程数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "爬取个数";
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.console.ForeColor = System.Drawing.Color.White;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(1201, 131);
            this.console.TabIndex = 0;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.lblComplete,
            this.labelItem3,
            this.lblLeft,
            this.labelItem5,
            this.lblTotal,
            this.labelItem8,
            this.lblFailed,
            this.labelItem11,
            this.labelItem12,
            this.lblWasteTime,
            this.labelItem15,
            this.lblFileCount,
            this.lblTime,
            this.pbAll});
            this.bar2.Location = new System.Drawing.Point(0, 131);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1201, 19);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 1;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "已爬取：";
            // 
            // lblComplete
            // 
            this.lblComplete.ForeColor = System.Drawing.Color.Green;
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Text = "0";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "剩余：";
            // 
            // lblLeft
            // 
            this.lblLeft.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Text = "0";
            // 
            // labelItem5
            // 
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem7});
            this.labelItem5.Text = "总共：";
            // 
            // labelItem7
            // 
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.Text = "总共：";
            // 
            // lblTotal
            // 
            this.lblTotal.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "0";
            // 
            // labelItem8
            // 
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Text = "失败：";
            // 
            // lblFailed
            // 
            this.lblFailed.ForeColor = System.Drawing.Color.Red;
            this.lblFailed.Name = "lblFailed";
            this.lblFailed.Text = "0";
            // 
            // labelItem11
            // 
            this.labelItem11.Name = "labelItem11";
            this.labelItem11.Text = " | ";
            // 
            // labelItem12
            // 
            this.labelItem12.Name = "labelItem12";
            this.labelItem12.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem13});
            this.labelItem12.Text = "共耗时：";
            // 
            // labelItem13
            // 
            this.labelItem13.Name = "labelItem13";
            this.labelItem13.Text = "总共耗时：";
            // 
            // lblWasteTime
            // 
            this.lblWasteTime.Name = "lblWasteTime";
            this.lblWasteTime.Text = "0";
            // 
            // labelItem15
            // 
            this.labelItem15.Name = "labelItem15";
            this.labelItem15.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem2});
            this.labelItem15.Text = "爬取文件：";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "爬取文件：";
            // 
            // lblFileCount
            // 
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "2017-06-7";
            // 
            // pbAll
            // 
            // 
            // 
            // 
            this.pbAll.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pbAll.ChunkGradientAngle = 0F;
            this.pbAll.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.pbAll.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.pbAll.Name = "pbAll";
            this.pbAll.RecentlyUsed = false;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1201, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBaiduImage,
            this.btnCustomSpider});
            this.buttonItem1.Text = "爬取策略";
            // 
            // btnBaiduImage
            // 
            this.btnBaiduImage.Image = global::CustomSpider.Properties.Resources.百度;
            this.btnBaiduImage.Name = "btnBaiduImage";
            this.btnBaiduImage.Text = "百度图片";
            this.btnBaiduImage.Click += new System.EventHandler(this.btnBaiduImage_Click);
            // 
            // btnCustomSpider
            // 
            this.btnCustomSpider.Image = global::CustomSpider.Properties.Resources.通用解决方案;
            this.btnCustomSpider.Name = "btnCustomSpider";
            this.btnCustomSpider.Text = "通用爬取";
            this.btnCustomSpider.Click += new System.EventHandler(this.btnCustomSpider_Click);
            // 
            // labelItem9
            // 
            this.labelItem9.Name = "labelItem9";
            this.labelItem9.Text = "总共：";
            // 
            // labelItem6
            // 
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Text = "爬取文件：";
            // 
            // labelItem14
            // 
            this.labelItem14.Name = "labelItem14";
            this.labelItem14.Text = "爬取文件：";
            // 
            // tmShowNow
            // 
            this.tmShowNow.Enabled = true;
            this.tmShowNow.Interval = 1000;
            this.tmShowNow.Tick += new System.EventHandler(this.tmShowNow_Tick);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 9.316055F;
            this.Column4.HeaderText = "行数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 74.32313F;
            this.Column5.HeaderText = "爬取网址";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 11.63785F;
            this.Column6.HeaderText = "爬取状态";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 10.76577F;
            this.Column7.HeaderText = "查看结果";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 642);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "爬虫工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThreadNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox console;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem btnBaiduImage;
        private DevComponents.DotNetBar.ButtonItem btnCustomSpider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnSpider;
        private System.Windows.Forms.TextBox txtBasePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlRight;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lblComplete;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem lblLeft;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private DevComponents.DotNetBar.LabelItem labelItem7;
        private DevComponents.DotNetBar.LabelItem lblTotal;
        private DevComponents.DotNetBar.LabelItem labelItem8;
        private DevComponents.DotNetBar.LabelItem lblFailed;
        private DevComponents.DotNetBar.LabelItem labelItem9;
        private DevComponents.DotNetBar.LabelItem labelItem11;
        private DevComponents.DotNetBar.LabelItem labelItem12;
        private DevComponents.DotNetBar.LabelItem labelItem13;
        private DevComponents.DotNetBar.LabelItem lblWasteTime;
        private DevComponents.DotNetBar.LabelItem labelItem15;
        private DevComponents.DotNetBar.LabelItem lblFileCount;
        private DevComponents.DotNetBar.LabelItem lblTime;
        private DevComponents.DotNetBar.ProgressBarItem pbAll;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem labelItem6;
        private DevComponents.DotNetBar.LabelItem labelItem14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtNum;
        private System.Windows.Forms.NumericUpDown txtThreadNum;
        private System.Windows.Forms.Timer tmShowNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
    }
}

