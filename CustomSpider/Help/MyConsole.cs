using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomSpider
{
    public static class MyConsole
    {
        private static TextBox _textBox = null;
        static MyConsole() { }

        public static void Bind(this TextBox textBox)
        {
            _textBox = textBox;
        }

        private delegate void Append(string text);

        private static Append _appender = (t) => 
        {
            _textBox.AppendText(t);
            _textBox.AppendText("\r\n");
            _textBox.AppendText("\r\n");
        };

        public static void AppendLine(string text)
        {
            if (_textBox.InvokeRequired)
                _textBox.Invoke(_appender,text);
        }

        public static void AppendSign()
        {
            AppendLine("----------------------------------------------------------------");
        }
    }
}
