namespace CustomSpider.UI
{
    partial class ResultChart
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ctMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboxShowType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmShow = new System.Windows.Forms.Timer(this.components);
            this.lblXNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ctMain)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblXNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ctMain
            // 
            this.ctMain.BackColor = System.Drawing.Color.Black;
            chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea3.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX2.MajorGrid.Enabled = false;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.Gray;
            chartArea3.Name = "ChartArea1";
            this.ctMain.ChartAreas.Add(chartArea3);
            this.ctMain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.BorderColor = System.Drawing.Color.Transparent;
            legend3.ForeColor = System.Drawing.Color.Green;
            legend3.Name = "Legend1";
            legend3.TitleForeColor = System.Drawing.Color.Maroon;
            this.ctMain.Legends.Add(legend3);
            this.ctMain.Location = new System.Drawing.Point(0, 29);
            this.ctMain.Name = "ctMain";
            series9.BorderColor = System.Drawing.Color.Transparent;
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Green;
            series9.LabelBackColor = System.Drawing.Color.White;
            series9.LabelBorderColor = System.Drawing.Color.White;
            series9.LabelForeColor = System.Drawing.Color.DimGray;
            series9.Legend = "Legend1";
            series9.LegendText = "总个数";
            series9.MarkerBorderColor = System.Drawing.Color.Transparent;
            series9.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series9.Name = "serTotal";
            series9.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series9.YValuesPerPoint = 2;
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            series10.Legend = "Legend1";
            series10.LegendText = "剩余个数";
            series10.Name = "serLeft";
            series10.YValuesPerPoint = 2;
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.Red;
            series11.Legend = "Legend1";
            series11.LegendText = "失败个数";
            series11.Name = "serFailed";
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.Blue;
            series12.Legend = "Legend1";
            series12.LegendText = "成功个数";
            series12.Name = "Series4";
            this.ctMain.Series.Add(series9);
            this.ctMain.Series.Add(series10);
            this.ctMain.Series.Add(series11);
            this.ctMain.Series.Add(series12);
            this.ctMain.Size = new System.Drawing.Size(342, 243);
            this.ctMain.TabIndex = 0;
            this.ctMain.Text = "chart1";
            title3.ForeColor = System.Drawing.Color.SpringGreen;
            title3.Name = "Title1";
            title3.Text = "爬虫爬取时间报表";
            this.ctMain.Titles.Add(title3);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblXNum);
            this.panel1.Controls.Add(this.comboxShowType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 29);
            this.panel1.TabIndex = 1;
            // 
            // comboxShowType
            // 
            this.comboxShowType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboxShowType.FormattingEnabled = true;
            this.comboxShowType.Location = new System.Drawing.Point(209, 5);
            this.comboxShowType.Name = "comboxShowType";
            this.comboxShowType.Size = new System.Drawing.Size(116, 20);
            this.comboxShowType.TabIndex = 2;
            this.comboxShowType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboxShowType_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "显示类别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X刻度数：";
            // 
            // tmShow
            // 
            this.tmShow.Enabled = true;
            this.tmShow.Interval = 5000;
            this.tmShow.Tick += new System.EventHandler(this.tmShow_Tick);
            // 
            // lblXNum
            // 
            this.lblXNum.Location = new System.Drawing.Point(65, 5);
            this.lblXNum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.lblXNum.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.lblXNum.Name = "lblXNum";
            this.lblXNum.Size = new System.Drawing.Size(69, 21);
            this.lblXNum.TabIndex = 3;
            this.lblXNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lblXNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ResultChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctMain);
            this.Controls.Add(this.panel1);
            this.Name = "ResultChart";
            this.Size = new System.Drawing.Size(342, 272);
            ((System.ComponentModel.ISupportInitialize)(this.ctMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblXNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ctMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboxShowType;
        private System.Windows.Forms.Timer tmShow;
        private System.Windows.Forms.NumericUpDown lblXNum;

    }
}
