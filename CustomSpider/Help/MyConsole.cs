using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomSpider
{
    /// <summary>
    /// 扩展一个模拟控制台
    /// </summary>
    public static class MyConsole
    {
        private static TextBox _textBox = null;
        static MyConsole() { }

        /// <summary>
        /// 绑定宿主到当前控制台
        /// </summary>
        /// <param name="textBox"></param>
        public static void Bind(this TextBox textBox)
        {
            _textBox = textBox;
        }

        private delegate void Append(string text);

        private static Append _appender = (t) => 
        {
            _textBox.AppendText(t);
            _textBox.AppendText(Environment.NewLine);
            _textBox.AppendText(Environment.NewLine);
        };

        /// <summary>
        /// 加入文本到控制台
        /// </summary>
        /// <param name="text">文本内容</param>
        public static void AppendLine(string text)
        {
            if (_textBox.InvokeRequired)
                _textBox.Invoke(_appender,text);
        }

        /// <summary>
        /// 添加一个符号
        /// </summary>
        public static void AppendSign()
        {
            AppendLine("----------------------------------------------------------------");
        }
    }
}
