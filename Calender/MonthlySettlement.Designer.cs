namespace Ledger
{
    partial class MonthlySettlement
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
            btnBack = new Button();
            pnlChart = new Panel();
            pnlRank = new Panel();
            pnlDetailed = new Panel();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(841, 766);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 0;
            btnBack.Text = "뒤로가기";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pnlChart
            // 
            pnlChart.BackColor = SystemColors.InactiveBorder;
            pnlChart.Location = new Point(29, 31);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(906, 480);
            pnlChart.TabIndex = 1;
            // 
            // pnlRank
            // 
            pnlRank.BackColor = SystemColors.InactiveBorder;
            pnlRank.Location = new Point(29, 533);
            pnlRank.Name = "pnlRank";
            pnlRank.Size = new Size(355, 259);
            pnlRank.TabIndex = 2;
            // 
            // pnlDetailed
            // 
            pnlDetailed.BackColor = SystemColors.InactiveBorder;
            pnlDetailed.Location = new Point(405, 533);
            pnlDetailed.Name = "pnlDetailed";
            pnlDetailed.Size = new Size(530, 222);
            pnlDetailed.TabIndex = 3;
            // 
            // MonthlySettlement
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 804);
            Controls.Add(pnlDetailed);
            Controls.Add(pnlRank);
            Controls.Add(pnlChart);
            Controls.Add(btnBack);
            Name = "MonthlySettlement";
            Text = "MonthlySettlement";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBack;
        private Panel pnlChart;
        private Panel pnlRank;
        private Panel pnlDetailed;
    }
}