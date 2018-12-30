using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace ChineseCalender
{
    public partial class Calender : Form
    {

        private DateTime dtNow = DateTime.Now;   //初始化当天日期
        private int daysOfMonth = 30;     //初始化每月天数
        private int weekOfFirstDay = 1;   //初始化某月第一天的星期
        private int selectYear;     //初始化选择年份
        private int selectMonth;   //初始化选择月份
        private DateTime dtInfo = DateTime.Now;    //初始化日期信息
        private string[,] dateArray = new string[7, 6];   //记录日期信息
        Panel panelDateInfo = null;  
        private bool flag = true; //标记是否重绘panel

        public Calender()
        {
            InitializeComponent();
            DrawControls();
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            Control.ControlCollection controls = panelMonthInfo.Controls;
            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(Panel))
                {
                    panelDateInfo = control as Panel;
                   
                }
            }
            clock f = new clock();
            // 不是顶级窗体，即不是桌面窗口
            f.TopLevel = false;
            // 将窗体放入panel
            panelDateInfo.Controls.Add(f);
            // 显示
            f.SetDesktopLocation(-30, 0);
            f.Show();
        }
       

        #region 绘制控件
        //绘制控件
        private void DrawControls()
        {
            var news = new Label();
            news.Name = "NEWS";
            news.Text = "NEWS.";
            news.Location = new Point(830, 450);
            news.Font = new Font("圆体", 30);
            news.Size = new Size(160, 120);
            news.BackColor = Color.Transparent;
            news.MouseDoubleClick += new MouseEventHandler(news_clicked);

            var lblYear = new Label();
            lblYear.Name = "lblYear";
            lblYear.Text = "年份";
            lblYear.Location = new Point(620, 19);
            lblYear.Size = new Size(29, 20);
            lblYear.BackColor = Color.Transparent;

            var lblMonth = new Label();
            lblMonth.Name = "lblMonth";
            lblMonth.Text = "月份";
            lblMonth.Location = new Point(720, 19);
            lblMonth.Size = new Size(29, 20);
            lblMonth.BackColor = Color.Transparent;

            var cmbSelectYear = new ComboBox();
            cmbSelectYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectYear.FormattingEnabled = true;
            cmbSelectYear.Location = new Point(650, 15);
            cmbSelectYear.Name = "cmbSelectYear";
            cmbSelectYear.AutoSize = false;
            cmbSelectYear.Size = new Size(50, 20);
            cmbSelectYear.TabIndex = 0;
            cmbSelectYear.SelectionChangeCommitted += new EventHandler(cmbSelectYear_SelectionChangeCommitted);

            var cmbSelectMonth = new ComboBox();
            cmbSelectMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectMonth.FormattingEnabled = true;
            cmbSelectMonth.Location = new Point(750, 15);
            cmbSelectMonth.Name = "cmbSelectMonth";
            cmbSelectMonth.AutoSize = false;
            cmbSelectMonth.Size = new Size(50, 20);
            cmbSelectMonth.TabIndex = 0;
            cmbSelectMonth.SelectionChangeCommitted += new EventHandler(cmbSelectMonth_SelectionChangeCommitted);

            var panelDateInfo = new Panel();
            panelDateInfo.BackColor = Color.Transparent;
            panelDateInfo.Location = new Point(700, 30);
            panelDateInfo.Size = new Size(300, 480);
            panelDateInfo.Paint += new PaintEventHandler(panelDateInfo_Paint);


         
       
            for (int i = 1949; i <= 2049; i++)
            {
                cmbSelectYear.Items.Add(i);
                if (i == dtNow.Year)
                {
                    cmbSelectYear.SelectedItem = i;
                    selectYear = i;
                }
            }
            for (int i = 1; i <= 12; i++)
            {
                cmbSelectMonth.Items.Add(i);
                if (i == dtNow.Month)
                {
                    cmbSelectMonth.SelectedItem = i;
                    selectMonth = i;
                }
            }
            panelMonthInfo.Controls.Add(news);
            panelMonthInfo.Controls.Add(lblMonth);
            panelMonthInfo.Controls.Add(lblYear);
            panelMonthInfo.Controls.Add(cmbSelectYear);
            panelMonthInfo.Controls.Add(cmbSelectMonth);
            panelMonthInfo.Controls.Add(panelDateInfo);
    
        }


        #endregion

        //主窗体绘制月历
        private void panelMonthInfo_Paint(object sender, PaintEventArgs e)
        {

            //绘制日历
            Graphics g = e.Graphics;
            var pen1 = new Pen(Color.Black, 2);
            var pen = new Pen(Color.Black, 1);

            var tb = new TextureBrush(global::ChineseCalender.Properties.Resources.wnlbg, WrapMode.TileFlipXY);
            g.FillRectangle(tb, 0, 0, 750, 550);
            g.FillRectangle(new SolidBrush(Color.Transparent), 5, 40, 740, 550);

            SolidBrush sb = new SolidBrush(Color.FromArgb(50, 255, 247, 241));
            g.FillRectangle(sb, 10, 45, 560, 30);

            if (flag)
            {
                GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
                DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
 
            }
        }

        private void panelDateInfo_Paint(object sender, PaintEventArgs e)
        {
            ChineseCalendar cc = new ChineseCalendar(dtInfo);
            string dateString = cc.DateString; //阳历
            string chineseDateString = cc.ChineseDateString; //农历
            string dateHoliday = cc.DateHoliday; //阳历节日
            string chineseTwentyFourDay = cc.ChineseTwentyFourDay; //农历节日
            string constellation = cc.Constellation; //星座
            string weekDayString = cc.WeekDayStr; //星期
            string ganZhiDateString = cc.GanZhiDateString;
            string animalString = cc.AnimalString;
            string chineseConstellation = cc.ChineseConstellation;

            if (panelDateInfo != null)
            {
                Graphics g = panelDateInfo.CreateGraphics();
                if (dateString != null)
                    g.DrawString(dateString + " " + weekDayString, new Font("", 9), new SolidBrush(Color.Black), 40, 270);
                g.DrawString(dtInfo.Day.ToString(CultureInfo.InvariantCulture), new Font("", 45, FontStyle.Bold),
                             new SolidBrush(Color.Black), 70, 290);
                var family = new FontFamily("宋体");
                g.DrawString(chineseDateString.Substring(7, chineseDateString.Length - 7), new Font(family, 10),
                             new SolidBrush(Color.Black), 74, 345);
               g.DrawString(ganZhiDateString.Substring(0, 3) + " 【" + animalString + "年】", new Font(family, 10),
                             new SolidBrush(Color.Black), 60, 360);
                g.DrawString(ganZhiDateString.Substring(3, ganZhiDateString.Length - 3), new Font(family, 10),
                             new SolidBrush(Color.Black), 70, 375);
                g.DrawString(constellation + "   " + chineseConstellation, new Font(family, 10),
                             new SolidBrush(Color.Black), 60, 390);
              
                g.DrawString(chineseTwentyFourDay, new Font(family, 10), new SolidBrush(Color.Black), 70, 415);
            }
        }

        private void news_clicked(object sender,EventArgs e)
        {
            News news = new News();
            news.Show();
            //this.Hide();
        }

        private void cmbSelectMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectMonth = sender as ComboBox;
            selectMonth = (int)cmbSelectMonth.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
        }

        private void cmbSelectYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectYear = sender as ComboBox;
            selectYear = (int)cmbSelectYear.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
        }

        private void panelMonthInfo_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {


                if (e.X < 10 || e.X > 658)
                {
                    return;
                }
                if (e.Y < 75 || e.Y > 480)
                {
                    return;
                }
                int x = (e.X - 10) / 95;
                int y = (e.Y - 75) / 70;
                if (dateArray[x, y] == null)
                {
                    return;
                }
                DateTime dtSelect = DateTime.Parse(dateArray[x, y]);
                dtInfo = dtSelect;
            }
            panelDateInfo.Refresh();
        }

        //双击打开备忘录
        private void panelMonthInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Memo memo = new Memo();
            memo.Show();
            StreamReader sr = new StreamReader(@"memo.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                memo.checkedListBox1.Items.Add(line);
            }
            sr.Close();
        }


        //绘制月历日期
        private void DrawDateNum(int firstDayofWeek, int endMonthDay, int year, int month)
        {
            DateTime dtNow = DateTime.Parse(DateTime.Now.ToShortDateString());

            var font = new Font("", 14);
            var solidBrushWeekdays = new SolidBrush(Color.Black);
            var solidBrushWeekend = new SolidBrush(Color.Black);
            var solidBrushHoliday = new SolidBrush(Color.Gray);
            Graphics g = panelMonthInfo.CreateGraphics();
            int num = 1;

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (j == 0 && i < firstDayofWeek) //定义当月第一天的星期的位置
                    {
                        continue;
                    }
                    else
                    {
                        if (num > endMonthDay) //定义当月最后一天的位置
                        {
                            break;
                        }
                        string cMonth = null;
                        string cDay = null;
                        string cHoliday = null;
                        string ccHoliday = null;

                        if (i > 0 && i < 6)
                        {
                            DateTime dt = DateTime.Parse(year + "-" + month + "-" + num);
                            TimeSpan ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();

                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (62 + 95 * i), (80 + 70 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);
                            
                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("", 9),
                                             solidBrushHoliday, (40 + 95 * i), (100 + 70 * j));
                            }
                            //绘农历
                            if (ccHoliday != "")
                            {
                                g.DrawString(ccHoliday, new Font("", 10), solidBrushWeekdays, (25 + 95 * i),
                                                                         (115 + 70 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("", 10), solidBrushWeekdays, (25 + 95 * i),
                                                                         (115 + 70 * j));
                            }
                            

                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekdays,
                                         (62 + 95 * i), (80 + 70 * j));

                        }
                        else
                        {
                            var dt = DateTime.Parse(year + "-" + month + "-" + num);
                            var ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();
                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (62 + 95 * i), (80 + 70 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);

                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("", 9),
                                             solidBrushHoliday, (40 + 95 * i), (90 + 70 * j));
                            }
                            //绘农历
                            if (ccHoliday!="")
                            {
                                g.DrawString(ccHoliday, new Font("", 10), solidBrushWeekend, (25 + 95 * i),
                                         (115 + 70 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("", 10), solidBrushWeekend, (25 + 95 * i),
                                         (115 + 70 * j));
                            }

                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekend,
                                         (62 + 95 * i), (80 + 70 * j));
                        }

                        num++;

                    }

                }
            }
        }

        //获取某月首日星期及某月天数
        private void GetWeekInfo(ref int weekOfFirstDay, ref int daysOfMonth, int year = 1900, int month = 2, int day = 1)
        {
            DateTime dt =
                DateTime.Parse(year.ToString(CultureInfo.InvariantCulture) + "-" +
                               month.ToString(CultureInfo.InvariantCulture) + "-" +
                               day.ToString(CultureInfo.InvariantCulture));
            weekOfFirstDay = (int)dt.DayOfWeek;
            daysOfMonth = (int)DateTime.DaysInMonth(year, month);
        }
    }
}
