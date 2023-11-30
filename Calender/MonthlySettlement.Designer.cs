namespace Ledger {
    partial class MonthlySettlement {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            pnlChart = new Panel();
            pnlRank = new Panel();
            pnlDetailed = new Panel();
            cmbxMonth = new ComboBox();
            SuspendLayout();
            // 
            // pnlChart
            // 
            pnlChart.BackColor = SystemColors.InactiveBorder;
            pnlChart.Location = new Point(30, 31);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(906, 480);
            pnlChart.TabIndex = 1;
            // 
            // pnlRank
            // 
            pnlRank.BackColor = SystemColors.InactiveBorder;
            pnlRank.Location = new Point(30, 533);
            pnlRank.Name = "pnlRank";
            pnlRank.Size = new Size(355, 259);
            pnlRank.TabIndex = 2;
            // 
            // pnlDetailed
            // 
            pnlDetailed.BackColor = SystemColors.InactiveBorder;
            pnlDetailed.Location = new Point(405, 533);
            pnlDetailed.Name = "pnlDetailed";
            pnlDetailed.Size = new Size(530, 221);
            pnlDetailed.TabIndex = 3;
            // 
            // cmbxMonth
            // 
            cmbxMonth.FormattingEnabled = true;
            cmbxMonth.Location = new Point(837, 1);
            cmbxMonth.Name = "cmbxMonth";
            cmbxMonth.Size = new Size(128, 28);
            cmbxMonth.TabIndex = 4;
            // 
            // MonthlySettlement
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 804);
            Controls.Add(cmbxMonth);
            Controls.Add(pnlDetailed);
            Controls.Add(pnlRank);
            Controls.Add(pnlChart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MonthlySettlement";
            Text = "MonthlySettlement";
            FormClosing += Monthly_FormClosing;
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlChart;
        private Panel pnlRank;
        private Panel pnlDetailed;
        private ComboBox cmbxMonth;
    }
}