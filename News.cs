using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;

namespace ChineseCalender
{
    public partial class News : Form
    {
        public News()
        {
            InitializeComponent();
            DrawControls();
        }

        private void News_Load(object sender, EventArgs e)
        {
            Control.ControlCollection controls1 = menu.Controls;
            foreach (Control control in controls1)
            {
                if (control.GetType() == typeof(Panel))
                {
                    menu = control as Panel;
                }
            }

        }

        private void DrawControls()
        {
            var tiyu = new Label();
            tiyu.Font = new Font("圆体", 10);
            tiyu.Name = "tiyu";
            tiyu.Text = "体育";
            tiyu.Location = new Point(440, 49);
            tiyu.Size = new Size(49, 40);
            tiyu.BackColor = Color.Transparent;
            tiyu.MouseDoubleClick += new MouseEventHandler(tiyu_clicked);

            var keji = new Label();
            keji.Font = new Font("圆体", 10);
            keji.Name = "keji";
            keji.Text = "科技";
            keji.Location = new Point(500, 49);
            keji.Size = new Size(49, 40);
            keji.BackColor = Color.Transparent;
            keji.MouseDoubleClick += new MouseEventHandler(keji_clicked);

            var yule = new Label();
            yule.Font = new Font("圆体", 10);
            yule.Name = "yule";
            yule.Text = "娱乐";
            yule.Location = new Point(680, 49);
            yule.Size = new Size(49, 40);
            yule.BackColor = Color.Transparent;
            yule.MouseDoubleClick += new MouseEventHandler(yule_clicked);

            var zhengshi = new Label();
            zhengshi.Font = new Font("圆体", 10);
            zhengshi.Name = "zhengshi";
            zhengshi.Text = "政事";
            zhengshi.Location = new Point(560, 49);
            zhengshi.Size = new Size(49, 40);
            zhengshi.BackColor = Color.Transparent;
            zhengshi.MouseDoubleClick += new MouseEventHandler(zhengshi_clicked);

            var meizhuang = new Label();
            meizhuang.Font = new Font("圆体", 10);
            meizhuang.Name = "meizhuang";
            meizhuang.Text = "美妆";
            meizhuang.Location = new Point(620, 49);
            meizhuang.Size = new Size(49, 40);
            meizhuang.BackColor = Color.Transparent;
            meizhuang.MouseDoubleClick += new MouseEventHandler(meizhuang_clicked);


            menu.Controls.Add(tiyu);
            menu.Controls.Add(yule);
            menu.Controls.Add(keji);
            menu.Controls.Add(zhengshi);
            menu.Controls.Add(meizhuang);

        }
        private void tiyu_clicked(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load("http://www.chinanews.com/rss/sports.xml");
            var query = (from item in xDoc.Descendants("item")
                         select new
                         {
                             Title = item.Element("title").Value,
                             Url = item.Element("link").Value
                         }).Take(7);
            int i = 20;
            if (panel1.Controls.Count != 0)
            {
                panel1.Controls.Clear();
                foreach (var item in query)
                {
                    SetLinkLabel(item.Title, item.Url, i);
                    i += 48;
                }
            }
        }
        private void keji_clicked(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load("http://www.chinanews.com/rss/it.xml");
            var query = (from item in xDoc.Descendants("item")
                         select new
                         {
                             Title = item.Element("title").Value,
                             Url = item.Element("link").Value
                         }).Take(7);
            int i = 20;
            if (panel1.Controls.Count != 0)
            {
                panel1.Controls.Clear();
                foreach (var item in query)
                {
                    SetLinkLabel(item.Title, item.Url, i);
                    i += 48;
                }
            }

        }
        private void zhengshi_clicked(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load("http://www.chinanews.com/rss/scroll-news.xml");

            var query = (from item in xDoc.Descendants("item")
                         select new
                         {
                             Title = item.Element("title").Value,
                             Url = item.Element("link").Value
                         }).Take(7);
            int i = 20;
            if (panel1.Controls.Count != 0)
            {
                panel1.Controls.Clear();
                foreach (var item in query)
                {
                    SetLinkLabel(item.Title, item.Url, i);
                    i += 48;
                }
            }
        }
        private void meizhuang_clicked(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load("http://rss.sina.com.cn/fashion/beauty/news.xml");

            var query = (from item in xDoc.Descendants("item")
                         select new
                         {
                             Title = item.Element("title").Value,
                             Url = item.Element("link").Value
                         }).Take(7);
            int i = 20;
            if (panel1.Controls.Count != 0)
            {
                panel1.Controls.Clear();
                foreach (var item in query)
                {
                    SetLinkLabel(item.Title, item.Url, i);
                    i += 48;
                }
            }
        }
        private void yule_clicked(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load("http://www.chinanews.com/rss/ent.xml");

            var query = (from item in xDoc.Descendants("item")
                         select new
                         {
                             Title = item.Element("title").Value,
                             Url = item.Element("link").Value
                         }).Take(7);
            int i = 20;
            if (panel1.Controls.Count != 0)
            {
                panel1.Controls.Clear();
                foreach (var item in query)
                {
                    SetLinkLabel(item.Title, item.Url, i);
                    i += 48;
                }
            }
        }
        private void SetLinkLabel(string T, string U, int i)
        {
            LinkLabel label = new LinkLabel();
            label.Visible = true;
            label.LinkColor = Color.Black;
            label.AutoSize = true;
            label.Text = T;
            label.Font = new Font("宋体", 9.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            label.Location = new Point(10, i);
            label.LinkBehavior = LinkBehavior.NeverUnderline;
            label.BackColor = Color.Transparent;
            label.LinkClicked += new LinkLabelLinkClickedEventHandler((senders, ex) =>
            {
                System.Diagnostics.Process.Start(U);
            });
            panel1.Controls.Add(label);
        }
    }
}
