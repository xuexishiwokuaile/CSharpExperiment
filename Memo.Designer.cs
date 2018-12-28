namespace ChineseCalender
{
    partial class Memo
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
            this.add = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.BackColor = System.Drawing.Color.Transparent;
            this.add.Font = new System.Drawing.Font("黑体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.add.Location = new System.Drawing.Point(83, 30);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(74, 38);
            this.add.TabIndex = 1;
            this.add.Text = "ADD";
            this.add.Click += new System.EventHandler(this.label2_Click);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox2.ForeColor = System.Drawing.Color.LightGray;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 24;
            this.listBox2.Location = new System.Drawing.Point(117, 433);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(914, 172);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(117, 139);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(914, 236);
            this.checkedListBox1.TabIndex = 4;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // Memo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChineseCalender.Properties.Resources.memo;
            this.ClientSize = new System.Drawing.Size(1171, 623);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Memo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Memo_FormClosed);
            this.Load += new System.EventHandler(this.Memo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label add;
        private System.Windows.Forms.ListBox listBox2;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}