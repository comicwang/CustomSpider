using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomSpider.UI
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        public void Show(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                Image image = Image.FromStream(stream);
                this.Width = 150;
                this.Height = (150 / image.Width) * image.Height;
            }
        }
    }
}
