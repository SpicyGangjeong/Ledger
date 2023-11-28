namespace Ledger
{
    partial class CalendarMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarMain));
            CalendarPanels = new TableLayoutPanel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            MonthPicker = new ComboBox();
            YearPicker = new TextBox();
            txtNowMonth = new TextBox();
            btnPreMonth = new Button();
            btnPostMonth = new Button();
            btnSettle = new Button();
            btnNowDate = new Button();
            CalendarPanels.SuspendLayout();
            SuspendLayout();
            // 
            // CalendarPanels
            // 
            CalendarPanels.BackColor = SystemColors.Info;
            CalendarPanels.ColumnCount = 7;
            CalendarPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            CalendarPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalendarPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalendarPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalendarPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalendarPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalendarPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalendarPanels.Controls.Add(textBox1, 0, 0);
            CalendarPanels.Controls.Add(textBox2, 1, 0);
            CalendarPanels.Controls.Add(textBox3, 2, 0);
            CalendarPanels.Controls.Add(textBox4, 3, 0);
            CalendarPanels.Controls.Add(textBox5, 4, 0);
            CalendarPanels.Controls.Add(textBox6, 5, 0);
            CalendarPanels.Controls.Add(textBox7, 6, 0);
            CalendarPanels.Dock = DockStyle.Bottom;
            CalendarPanels.Location = new Point(0, 61);
            CalendarPanels.Margin = new Padding(0);
            CalendarPanels.Name = "CalendarPanels";
            CalendarPanels.RowCount = 7;
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666622F));
            CalendarPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            CalendarPanels.Size = new Size(752, 542);
            CalendarPanels.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = Color.IndianRed;
            textBox1.Location = new Point(0, 0);
            textBox1.Margin = new Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(103, 40);
            textBox1.TabIndex = 0;
            textBox1.TabStop = false;
            textBox1.Text = "일";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(107, 0);
            textBox2.Margin = new Padding(0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(104, 40);
            textBox2.TabIndex = 0;
            textBox2.TabStop = false;
            textBox2.Text = "월";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(214, 0);
            textBox3.Margin = new Padding(0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(104, 40);
            textBox3.TabIndex = 0;
            textBox3.TabStop = false;
            textBox3.Text = "화";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox4.Location = new Point(321, 0);
            textBox4.Margin = new Padding(0);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(104, 40);
            textBox4.TabIndex = 0;
            textBox4.TabStop = false;
            textBox4.Text = "수";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox5.Location = new Point(428, 0);
            textBox5.Margin = new Padding(0);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(104, 40);
            textBox5.TabIndex = 0;
            textBox5.TabStop = false;
            textBox5.Text = "목";
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox6.Location = new Point(535, 0);
            textBox6.Margin = new Padding(0);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(104, 40);
            textBox6.TabIndex = 0;
            textBox6.TabStop = false;
            textBox6.Text = "금";
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Window;
            textBox7.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox7.ForeColor = SystemColors.MenuHighlight;
            textBox7.Location = new Point(642, 0);
            textBox7.Margin = new Padding(0);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(105, 40);
            textBox7.TabIndex = 0;
            textBox7.TabStop = false;
            textBox7.Text = "토";
            textBox7.TextAlign = HorizontalAlignment.Center;
            // 
            // MonthPicker
            // 
            MonthPicker.FormattingEnabled = true;
            MonthPicker.Items.AddRange(new object[] { "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월" });
            MonthPicker.Location = new Point(690, 6);
            MonthPicker.Name = "MonthPicker";
            MonthPicker.Size = new Size(50, 23);
            MonthPicker.TabIndex = 6;
            MonthPicker.SelectedIndexChanged += MonthPicker_SelectedIndexChanged;
            // 
            // YearPicker
            // 
            YearPicker.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            YearPicker.Location = new Point(354, 6);
            YearPicker.Name = "YearPicker";
            YearPicker.Size = new Size(41, 29);
            YearPicker.TabIndex = 7;
            YearPicker.Text = "2023";
            YearPicker.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNowMonth
            // 
            txtNowMonth.BorderStyle = BorderStyle.None;
            txtNowMonth.Enabled = false;
            txtNowMonth.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtNowMonth.Location = new Point(327, 38);
            txtNowMonth.Name = "txtNowMonth";
            txtNowMonth.Size = new Size(100, 22);
            txtNowMonth.TabIndex = 8;
            txtNowMonth.TextAlign = HorizontalAlignment.Center;
            // 
            // btnPreMonth
            // 
            btnPreMonth.BackgroundImageLayout = ImageLayout.None;
            btnPreMonth.Location = new Point(278, 39);
            btnPreMonth.Name = "btnPreMonth";
            btnPreMonth.Size = new Size(43, 23);
            btnPreMonth.TabIndex = 9;
            btnPreMonth.Text = "←";
            btnPreMonth.UseVisualStyleBackColor = true;
            btnPreMonth.Click += btnPreMonth_Click;
            // 
            // btnPostMonth
            // 
            btnPostMonth.BackgroundImageLayout = ImageLayout.None;
            btnPostMonth.Location = new Point(433, 39);
            btnPostMonth.Name = "btnPostMonth";
            btnPostMonth.Size = new Size(42, 23);
            btnPostMonth.TabIndex = 10;
            btnPostMonth.Text = "→ ";
            btnPostMonth.UseVisualStyleBackColor = true;
            btnPostMonth.Click += btnPostMonth_Click;
            // 
            // btnSettle
            // 
            btnSettle.Location = new Point(578, 34);
            btnSettle.Margin = new Padding(2);
            btnSettle.Name = "btnSettle";
            btnSettle.Size = new Size(162, 22);
            btnSettle.TabIndex = 21;
            btnSettle.Text = "월간 정산";
            btnSettle.UseVisualStyleBackColor = true;
            btnSettle.Click += btnSettle_click;
            // 
            // btnNowDate
            // 
            btnNowDate.Location = new Point(576, 6);
            btnNowDate.Name = "btnNowDate";
            btnNowDate.Size = new Size(108, 23);
            btnNowDate.TabIndex = 22;
            btnNowDate.UseVisualStyleBackColor = true;
            btnNowDate.Click += btnNowDate_Click;
            // 
            // CalendarMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(752, 603);
            Controls.Add(btnNowDate);
            Controls.Add(btnSettle);
            Controls.Add(btnPostMonth);
            Controls.Add(btnPreMonth);
            Controls.Add(txtNowMonth);
            Controls.Add(YearPicker);
            Controls.Add(MonthPicker);
            Controls.Add(CalendarPanels);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CalendarMain";
            Text = "CalendarMain";
            FormClosing += CalendarMain_FormClosing;
            Load += CalendarMain_Load;
            CalendarPanels.ResumeLayout(false);
            CalendarPanels.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel CalendarPanels;
        private ComboBox MonthPicker;
        private TextBox YearPicker;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox txtNowMonth;
        private Button btnPreMonth;
        private Button btnPostMonth;
        private Button btnSettle;
        private Button btnNowDate;
    }
}