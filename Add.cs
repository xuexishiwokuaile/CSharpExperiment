using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseCalender
{
    public delegate void Info(string getinfo);
    public partial class Add : Form
    {
        private Info _info;
        public Add(Info info)
        {
            InitializeComponent();
            this._info = info;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //确定
        public void label1_Click(object sender, EventArgs e)
        {
            _info(textBox1.Text);
            this.Close();
        }

        //取消
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
