using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CustomSpider.UI
{
    public partial class ResultChart : UserControl
    {
        List<int> _lstTime = new List<int>(); //X
        List<int> _lstTotal = new List<int>();//Y
        List<int> _lstLeft = new List<int>();
        List<int> _lstFailed = new List<int>();
        List<int> _lstCompleted = new List<int>();
        FormMain _main = null;
        public ResultChart()
        {
            InitializeComponent();
            comboxShowType.Bind<SeriesChartType>();
        }

        public ResultChart(FormMain main)
            : this()
        {
            _main = main;
        }

        private void comboxShowType_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void tmShow_Tick(object sender, EventArgs e)
        {
            //获取坐标值
            SetXY();

            ctMain.Series[0].Points.DataBindXY(_lstTime, _lstTotal);
            ctMain.Series[1].Points.DataBindXY(_lstTime, _lstLeft);
            ctMain.Series[2].Points.DataBindXY(_lstTime, _lstFailed);
            ctMain.Series[3].Points.DataBindXY(_lstTime, _lstCompleted);          
            SeriesChartType charType= comboxShowType.Get<SeriesChartType>();
            ctMain.Series[0].ChartType = charType;
            ctMain.Series[1].ChartType = charType;
            ctMain.Series[2].ChartType = charType;
            ctMain.Series[3].ChartType = charType;
        }


        private void SetXY()
        {
            int xNum=(int)lblXNum.Value;
            if (_lstTotal.Count >= xNum)
            {
                //移除最后一个，加入新的元素
                _lstTotal.RemoveAt(0);
                _lstCompleted.RemoveAt(0);
                _lstFailed.RemoveAt(0);
                _lstLeft.RemoveAt(0);
            }
            _lstTotal.Add(_main.TotalCount);
            _lstFailed.Add(_main.FailedCount);
            _lstCompleted.Add(_main.CompletedCount);
            _lstLeft.Add(_main.TotalCount - _main.CompletedCount - _main.FailedCount);

            _lstTime.Clear();
            for (int i = 0; i < _lstTotal.Count; i++)
            {
                _lstTime.Add(i);
            }
        }
    }
}
