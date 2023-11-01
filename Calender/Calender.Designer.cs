namespace Ledger
{
    partial class CalenderMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalenderMain));
            CalenderPanels = new TableLayoutPanel();
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
            btnSwitchCalender = new Button();
            btnSwitchTree = new Button();
            btnSwitchGraph = new Button();
            btnSwitchUpper = new Button();
            btnSettle = new Button();
            CalenderPanels.SuspendLayout();
            SuspendLayout();
            // 
            // CalenderPanels
            // 
            CalenderPanels.ColumnCount = 7;
            CalenderPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            CalenderPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalenderPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalenderPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalenderPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalenderPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalenderPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            CalenderPanels.Controls.Add(textBox1, 0, 0);
            CalenderPanels.Controls.Add(textBox2, 1, 0);
            CalenderPanels.Controls.Add(textBox3, 2, 0);
            CalenderPanels.Controls.Add(textBox4, 3, 0);
            CalenderPanels.Controls.Add(textBox5, 4, 0);
            CalenderPanels.Controls.Add(textBox6, 5, 0);
            CalenderPanels.Controls.Add(textBox7, 6, 0);
            CalenderPanels.Dock = DockStyle.Bottom;
            CalenderPanels.Location = new Point(0, 61);
            CalenderPanels.Margin = new Padding(0);
            CalenderPanels.Name = "CalenderPanels";
            CalenderPanels.RowCount = 7;
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666622F));
            CalenderPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            CalenderPanels.Size = new Size(752, 542);
            CalenderPanels.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = Color.IndianRed;
            textBox1.Location = new Point(0, 0);
            textBox1.Margin = new Padding(0);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(107, 36);
            textBox1.TabIndex = 0;
            textBox1.Text = "일";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(107, 0);
            textBox2.Margin = new Padding(0);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(107, 36);
            textBox2.TabIndex = 0;
            textBox2.Text = "월";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(214, 0);
            textBox3.Margin = new Padding(0);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(107, 36);
            textBox3.TabIndex = 0;
            textBox3.Text = "화";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Dock = DockStyle.Fill;
            textBox4.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox4.Location = new Point(321, 0);
            textBox4.Margin = new Padding(0);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(107, 36);
            textBox4.TabIndex = 0;
            textBox4.Text = "수";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Dock = DockStyle.Fill;
            textBox5.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox5.Location = new Point(428, 0);
            textBox5.Margin = new Padding(0);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(107, 36);
            textBox5.TabIndex = 0;
            textBox5.Text = "목";
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Dock = DockStyle.Fill;
            textBox6.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox6.Location = new Point(535, 0);
            textBox6.Margin = new Padding(0);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(107, 36);
            textBox6.TabIndex = 0;
            textBox6.Text = "금";
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Window;
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Dock = DockStyle.Fill;
            textBox7.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox7.ForeColor = SystemColors.MenuHighlight;
            textBox7.Location = new Point(642, 0);
            textBox7.Margin = new Padding(0);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(110, 36);
            textBox7.TabIndex = 0;
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
            // btnSwitchCalender
            // 
            btnSwitchCalender.Image = (Image)resources.GetObject("btnSwitchCalender.Image");
            btnSwitchCalender.Location = new Point(7, 4);
            btnSwitchCalender.Name = "btnSwitchCalender";
            btnSwitchCalender.Size = new Size(38, 34);
            btnSwitchCalender.TabIndex = 11;
            btnSwitchCalender.UseVisualStyleBackColor = true;
            btnSwitchCalender.Click += btnSwitchCalender_Click;
            // 
            // btnSwitchTree
            // 
            btnSwitchTree.Image = (Image)resources.GetObject("btnSwitchTree.Image");
            btnSwitchTree.Location = new Point(51, 4);
            btnSwitchTree.Name = "btnSwitchTree";
            btnSwitchTree.Size = new Size(38, 34);
            btnSwitchTree.TabIndex = 12;
            btnSwitchTree.UseVisualStyleBackColor = true;
            btnSwitchTree.Click += btnSwitchTree_Click;
            // 
            // btnSwitchGraph
            // 
            btnSwitchGraph.Image = (Image)resources.GetObject("btnSwitchGraph.Image");
            btnSwitchGraph.Location = new Point(96, 4);
            btnSwitchGraph.Name = "btnSwitchGraph";
            btnSwitchGraph.Size = new Size(38, 34);
            btnSwitchGraph.TabIndex = 15;
            btnSwitchGraph.UseVisualStyleBackColor = true;
            btnSwitchGraph.Click += btnSwitchGraph_Click;
            // 
            // btnSwitchUpper
            // 
            btnSwitchUpper.Location = new Point(139, 4);
            btnSwitchUpper.Margin = new Padding(2);
            btnSwitchUpper.Name = "btnSwitchUpper";
            btnSwitchUpper.Size = new Size(38, 34);
            btnSwitchUpper.TabIndex = 20;
            btnSwitchUpper.Text = "dd";
            btnSwitchUpper.UseVisualStyleBackColor = true;
            btnSwitchUpper.Click += btnSwitchUpper_Click;
            // 
            // btnSettle
            // 
            btnSettle.Location = new Point(611, 6);
            btnSettle.Margin = new Padding(2);
            btnSettle.Name = "btnSettle";
            btnSettle.Size = new Size(73, 22);
            btnSettle.TabIndex = 21;
            btnSettle.Text = "월간 정산";
            btnSettle.UseVisualStyleBackColor = true;
            btnSettle.Click += btnSettle_click;
            // 
            // CalenderMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(752, 603);
            Controls.Add(btnSettle);
            Controls.Add(btnSwitchUpper);
            Controls.Add(btnSwitchTree);
            Controls.Add(btnSwitchCalender);
            Controls.Add(btnPostMonth);
            Controls.Add(btnPreMonth);
            Controls.Add(txtNowMonth);
            Controls.Add(YearPicker);
            Controls.Add(MonthPicker);
            Controls.Add(btnSwitchGraph);
            Controls.Add(CalenderPanels);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CalenderMain";
            Text = "CalenderMain";
            FormClosing += CalenderMain_FormClosing;
            Load += CalenderMain_Load;
            CalenderPanels.ResumeLayout(false);
            CalenderPanels.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel CalenderPanels;
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
        private Button btnSwitchCalender;
        private Button btnSwitchTree;
        private Button btnSwitchGraph;
        private Button btnSwitchUpper;
        private Button btnSettle;
    }
}