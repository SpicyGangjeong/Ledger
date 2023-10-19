namespace Ledger
{
    partial class Analysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analysis));
            formsPlot = new ScottPlot.FormsPlot();
            Title = new TextBox();
            button_f_cate = new Button();
            button_f_way = new Button();
            button_f_impulse = new Button();
            button_Days = new Button();
            rtbRank = new RichTextBox();
            btnPostMonth = new Button();
            btnPreMonth = new Button();
            txtNowMonth = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot
            // 
            formsPlot.Dock = DockStyle.Fill;
            formsPlot.Location = new Point(0, 0);
            formsPlot.Margin = new Padding(5, 4, 5, 4);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(687, 834);
            formsPlot.TabIndex = 0;
            // 
            // Title
            // 
            Title.BackColor = SystemColors.AppWorkspace;
            Title.BorderStyle = BorderStyle.None;
            Title.Dock = DockStyle.Top;
            Title.Font = new Font("맑은 고딕", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            Title.Location = new Point(0, 0);
            Title.Margin = new Padding(4, 4, 4, 4);
            Title.Name = "Title";
            Title.Size = new Size(426, 49);
            Title.TabIndex = 1;
            Title.Text = "분야별 소비 순위";
            // 
            // button_f_cate
            // 
            button_f_cate.Location = new Point(26, 25);
            button_f_cate.Margin = new Padding(4, 4, 4, 4);
            button_f_cate.Name = "button_f_cate";
            button_f_cate.Size = new Size(96, 31);
            button_f_cate.TabIndex = 2;
            button_f_cate.Text = "분야별";
            button_f_cate.UseVisualStyleBackColor = true;
            button_f_cate.Click += button_f_cate_Click;
            // 
            // button_f_way
            // 
            button_f_way.Location = new Point(130, 25);
            button_f_way.Margin = new Padding(4, 4, 4, 4);
            button_f_way.Name = "button_f_way";
            button_f_way.Size = new Size(96, 31);
            button_f_way.TabIndex = 2;
            button_f_way.Text = "수단별";
            button_f_way.UseVisualStyleBackColor = true;
            button_f_way.Click += button_f_way_Click;
            // 
            // button_f_impulse
            // 
            button_f_impulse.Location = new Point(234, 25);
            button_f_impulse.Margin = new Padding(4, 4, 4, 4);
            button_f_impulse.Name = "button_f_impulse";
            button_f_impulse.Size = new Size(96, 31);
            button_f_impulse.TabIndex = 2;
            button_f_impulse.Text = "충동별";
            button_f_impulse.UseVisualStyleBackColor = true;
            button_f_impulse.Click += button_f_impulse_Click;
            // 
            // button_Days
            // 
            button_Days.Location = new Point(338, 25);
            button_Days.Margin = new Padding(4, 4, 4, 4);
            button_Days.Name = "button_Days";
            button_Days.Size = new Size(96, 31);
            button_Days.TabIndex = 2;
            button_Days.Text = "날짜별";
            button_Days.UseVisualStyleBackColor = true;
            button_Days.Click += button_Days_Click;
            // 
            // rtbRank
            // 
            rtbRank.BackColor = SystemColors.ControlLightLight;
            rtbRank.BorderStyle = BorderStyle.None;
            rtbRank.Dock = DockStyle.Fill;
            rtbRank.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            rtbRank.Location = new Point(0, 0);
            rtbRank.Margin = new Padding(4, 4, 4, 4);
            rtbRank.Name = "rtbRank";
            rtbRank.Size = new Size(426, 834);
            rtbRank.TabIndex = 4;
            rtbRank.Text = "";
            // 
            // btnPostMonth
            // 
            btnPostMonth.BackColor = SystemColors.ControlLightLight;
            btnPostMonth.BackgroundImageLayout = ImageLayout.None;
            btnPostMonth.FlatAppearance.BorderSize = 0;
            btnPostMonth.FlatStyle = FlatStyle.Flat;
            btnPostMonth.Location = new Point(681, 23);
            btnPostMonth.Margin = new Padding(4, 4, 4, 4);
            btnPostMonth.Name = "btnPostMonth";
            btnPostMonth.Size = new Size(54, 31);
            btnPostMonth.TabIndex = 13;
            btnPostMonth.Text = "→ ";
            btnPostMonth.UseVisualStyleBackColor = false;
            btnPostMonth.Visible = false;
            // 
            // btnPreMonth
            // 
            btnPreMonth.BackColor = SystemColors.ControlLightLight;
            btnPreMonth.BackgroundImageLayout = ImageLayout.None;
            btnPreMonth.FlatAppearance.BorderSize = 0;
            btnPreMonth.FlatStyle = FlatStyle.Flat;
            btnPreMonth.Location = new Point(482, 23);
            btnPreMonth.Margin = new Padding(4, 4, 4, 4);
            btnPreMonth.Name = "btnPreMonth";
            btnPreMonth.Size = new Size(55, 31);
            btnPreMonth.TabIndex = 12;
            btnPreMonth.Text = "←";
            btnPreMonth.UseVisualStyleBackColor = false;
            btnPreMonth.Visible = false;
            // 
            // txtNowMonth
            // 
            txtNowMonth.BackColor = SystemColors.ControlLightLight;
            txtNowMonth.BorderStyle = BorderStyle.None;
            txtNowMonth.Enabled = false;
            txtNowMonth.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtNowMonth.Location = new Point(545, 24);
            txtNowMonth.Margin = new Padding(4, 4, 4, 4);
            txtNowMonth.Name = "txtNowMonth";
            txtNowMonth.Size = new Size(129, 27);
            txtNowMonth.TabIndex = 11;
            txtNowMonth.TextAlign = HorizontalAlignment.Center;
            txtNowMonth.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(txtNowMonth);
            panel1.Controls.Add(btnPostMonth);
            panel1.Controls.Add(button_f_cate);
            panel1.Controls.Add(btnPreMonth);
            panel1.Controls.Add(button_f_way);
            panel1.Controls.Add(button_f_impulse);
            panel1.Controls.Add(button_Days);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 834);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1113, 75);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(Title);
            panel2.Controls.Add(rtbRank);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(687, 0);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(426, 834);
            panel2.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonShadow;
            panel3.Controls.Add(formsPlot);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(687, 834);
            panel3.TabIndex = 16;
            // 
            // Analysis
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1113, 909);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Analysis";
            Text = "Analysis";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private TextBox Title;
        private Button button_f_cate;
        private Button button_f_way;
        private Button button_f_impulse;
        private Button button_Days;
        private RichTextBox rtbRank;
        private Button btnPostMonth;
        private Button btnPreMonth;
        private TextBox txtNowMonth;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}