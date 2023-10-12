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
            formsPlot = new ScottPlot.FormsPlot();
            Title = new TextBox();
            button_f_cate = new Button();
            button_f_way = new Button();
            button_f_impulse = new Button();
            button_stats = new Button();
            groupBox1 = new GroupBox();
            rtbRank = new RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot
            // 
            formsPlot.Dock = DockStyle.Fill;
            formsPlot.Location = new Point(3, 19);
            formsPlot.Margin = new Padding(4, 3, 4, 3);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(560, 450);
            formsPlot.TabIndex = 0;
            // 
            // Title
            // 
            Title.BackColor = SystemColors.ControlLightLight;
            Title.BorderStyle = BorderStyle.None;
            Title.Font = new Font("맑은 고딕", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            Title.Location = new Point(605, 20);
            Title.Name = "Title";
            Title.Size = new Size(223, 39);
            Title.TabIndex = 1;
            Title.Text = "분야별 소비 순위";
            // 
            // button_f_cate
            // 
            button_f_cate.Location = new Point(33, 500);
            button_f_cate.Name = "button_f_cate";
            button_f_cate.Size = new Size(75, 23);
            button_f_cate.TabIndex = 2;
            button_f_cate.Text = "분야별";
            button_f_cate.UseVisualStyleBackColor = true;
            button_f_cate.Click += button_f_cate_Click;
            // 
            // button_f_way
            // 
            button_f_way.Location = new Point(193, 500);
            button_f_way.Name = "button_f_way";
            button_f_way.Size = new Size(75, 23);
            button_f_way.TabIndex = 2;
            button_f_way.Text = "수단별";
            button_f_way.UseVisualStyleBackColor = true;
            button_f_way.Click += button_f_way_Click;
            // 
            // button_f_impulse
            // 
            button_f_impulse.Location = new Point(294, 500);
            button_f_impulse.Name = "button_f_impulse";
            button_f_impulse.Size = new Size(75, 23);
            button_f_impulse.TabIndex = 2;
            button_f_impulse.Text = "충동별";
            button_f_impulse.UseVisualStyleBackColor = true;
            button_f_impulse.Click += button_f_impulse_Click;
            // 
            // button_stats
            // 
            button_stats.Location = new Point(384, 500);
            button_stats.Name = "button_stats";
            button_stats.Size = new Size(75, 23);
            button_stats.TabIndex = 2;
            button_stats.Text = "소비유형별";
            button_stats.UseVisualStyleBackColor = true;
            button_stats.Click += button_stats_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(formsPlot);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(566, 472);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // rtbRank
            // 
            rtbRank.BackColor = SystemColors.ControlLightLight;
            rtbRank.BorderStyle = BorderStyle.None;
            rtbRank.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            rtbRank.Location = new Point(605, 65);
            rtbRank.Name = "rtbRank";
            rtbRank.Size = new Size(223, 416);
            rtbRank.TabIndex = 4;
            rtbRank.Text = "";
            // 
            // Analysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(858, 545);
            Controls.Add(rtbRank);
            Controls.Add(groupBox1);
            Controls.Add(button_stats);
            Controls.Add(button_f_impulse);
            Controls.Add(button_f_way);
            Controls.Add(button_f_cate);
            Controls.Add(Title);
            Margin = new Padding(2);
            Name = "Analysis";
            Text = "Analysis";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private TextBox Title;
        private Button button_f_cate;
        private Button button_f_way;
        private Button button_f_impulse;
        private Button button_stats;
        private GroupBox groupBox1;
        private RichTextBox rtbRank;
    }
}