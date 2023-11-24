namespace Ledger {
    partial class Achievement {
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
            LeftPanel = new Panel();
            FlowPanel = new FlowLayoutPanel();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // LeftPanel
            // 
            LeftPanel.Location = new Point(12, 12);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(225, 520);
            LeftPanel.TabIndex = 1;
            // 
            // FlowPanel
            // 
            FlowPanel.AutoScroll = true;
            FlowPanel.AutoSize = true;
            FlowPanel.Dock = DockStyle.Fill;
            FlowPanel.FlowDirection = FlowDirection.TopDown;
            FlowPanel.Location = new Point(0, 0);
            FlowPanel.Name = "FlowPanel";
            FlowPanel.Size = new Size(573, 520);
            FlowPanel.TabIndex = 2;
            FlowPanel.WrapContents = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(FlowPanel);
            panel2.Location = new Point(243, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(573, 520);
            panel2.TabIndex = 4;
            // 
            // Achievement
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 544);
            Controls.Add(panel2);
            Controls.Add(LeftPanel);
            Name = "Achievement";
            Text = "Achievement";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel LeftPanel;
        private FlowLayoutPanel FlowPanel;
        private Panel panel2;
    }
}