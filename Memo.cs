using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseCalender
{
    public partial class Memo : Form
    {
        public Memo()
        {
            InitializeComponent();
        }

        void click_Add(string info)
        {
            this.checkedListBox1.Items.Add(info);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Add add = new Add(click_Add);
            add.Show();
        }


        private void Memo_Load(object sender, EventArgs e)
        {
            this.checkedListBox1.SelectionMode = SelectionMode.One;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.checkedListBox1.SelectedItem;
            if (obj != null)
            {
                this.listBox2.Items.Add(obj);
                this.checkedListBox1.Items.Remove(obj);
            }
        }

        private void Memo_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"memo.txt");
            int count = checkedListBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                string data = checkedListBox1.Items[i].ToString();
                sw.Write(data);
                sw.WriteLine();
            }
            sw.Flush();
            sw.Close();
        }
    }
}
