namespace ChineseCalender
{
    partial class Calender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calender));
            this.panelMonthInfo = new System.Windows.Forms.Panel();      
            this.SuspendLayout();

            // panelMonthInfo
            //
            this.panelMonthInfo.BackColor = System.Drawing.Color.White;
            this.panelMonthInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonthInfo.Location = new System.Drawing.Point(0, 25);
            this.panelMonthInfo.Name = "panelMonthInfo";
            this.panelMonthInfo.Size = new System.Drawing.Size(978, 500);
            this.panelMonthInfo.TabIndex = 1;
            this.panelMonthInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonthInfo_Paint);
            this.panelMonthInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMonthInfo_MouseClick);
            this.panelMonthInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelMonthInfo_MouseDoubleClick);
            // 
            // Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 540);
            this.Controls.Add(this.panelMonthInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calender";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "万年历";
            this.Load += new System.EventHandler(this.Calender_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMonthInfo;
    }
}