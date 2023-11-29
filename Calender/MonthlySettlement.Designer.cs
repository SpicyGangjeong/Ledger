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
            btnBack.Location = new Point(654, 574);
            btnBack.Margin = new Padding(2, 2, 2, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(73, 22);
            btnBack.TabIndex = 0;
            btnBack.Text = "뒤로가기";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pnlChart
            // 
            pnlChart.BackColor = SystemColors.InactiveBorder;
            pnlChart.Location = new Point(23, 23);
            pnlChart.Margin = new Padding(2, 2, 2, 2);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(705, 360);
            pnlChart.TabIndex = 1;
            // 
            // pnlRank
            // 
            pnlRank.BackColor = SystemColors.InactiveBorder;
            pnlRank.Location = new Point(23, 400);
            pnlRank.Margin = new Padding(2, 2, 2, 2);
            pnlRank.Name = "pnlRank";
            pnlRank.Size = new Size(276, 194);
            pnlRank.TabIndex = 2;
            // 
            // pnlDetailed
            // 
            pnlDetailed.BackColor = SystemColors.InactiveBorder;
            pnlDetailed.Location = new Point(315, 400);
            pnlDetailed.Margin = new Padding(2, 2, 2, 2);
            pnlDetailed.Name = "pnlDetailed";
            pnlDetailed.Size = new Size(412, 166);
            pnlDetailed.TabIndex = 3;
            // 
            // MonthlySettlement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 603);
            Controls.Add(pnlDetailed);
            Controls.Add(pnlRank);
            Controls.Add(pnlChart);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
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