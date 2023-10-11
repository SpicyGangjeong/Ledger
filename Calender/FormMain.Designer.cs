namespace Ledger
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnSwitchTree = new Button();
            btnSwitchCalender = new Button();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            종료ToolStripMenuItem = new ToolStripMenuItem();
            btnSwitchGraph = new Button();
            btnSwitchUpper = new Button();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // btnSwitchTree
            // 
            btnSwitchTree.Image = (Image)resources.GetObject("btnSwitchTree.Image");
            btnSwitchTree.Location = new Point(72, 16);
            btnSwitchTree.Margin = new Padding(4);
            btnSwitchTree.Name = "btnSwitchTree";
            btnSwitchTree.Size = new Size(49, 45);
            btnSwitchTree.TabIndex = 14;
            btnSwitchTree.UseVisualStyleBackColor = true;
            btnSwitchTree.Click += btnSwitchTree_Click;
            // 
            // btnSwitchCalender
            // 
            btnSwitchCalender.Image = (Image)resources.GetObject("btnSwitchCalender.Image");
            btnSwitchCalender.Location = new Point(15, 16);
            btnSwitchCalender.Margin = new Padding(4);
            btnSwitchCalender.Name = "btnSwitchCalender";
            btnSwitchCalender.Size = new Size(49, 45);
            btnSwitchCalender.TabIndex = 13;
            btnSwitchCalender.UseVisualStyleBackColor = true;
            btnSwitchCalender.Click += btnSwitchCalender_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Ledger";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { 종료ToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(109, 28);
            contextMenuStrip.Text = "Ledger";
            // 
            // 종료ToolStripMenuItem
            // 
            종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            종료ToolStripMenuItem.Size = new Size(108, 24);
            종료ToolStripMenuItem.Text = "종료";
            종료ToolStripMenuItem.Click += 종료ToolStripMenuItem_Click;
            // 
            // btnSwitchGraph
            // 
            btnSwitchGraph.Image = (Image)resources.GetObject("btnSwitchGraph.Image");
            btnSwitchGraph.Location = new Point(129, 16);
            btnSwitchGraph.Margin = new Padding(4);
            btnSwitchGraph.Name = "btnSwitchGraph";
            btnSwitchGraph.Size = new Size(49, 45);
            btnSwitchGraph.TabIndex = 14;
            btnSwitchGraph.UseVisualStyleBackColor = true;
            btnSwitchGraph.Click += btnSwitchTree_Click;
            // 
            // btnSwitchUpper
            // 
            btnSwitchUpper.Location = new Point(185, 16);
            btnSwitchUpper.Name = "btnSwitchUpper";
            btnSwitchUpper.Size = new Size(49, 45);
            btnSwitchUpper.TabIndex = 15;
            btnSwitchUpper.Text = "dd";
            btnSwitchUpper.UseVisualStyleBackColor = true;
            btnSwitchUpper.Click += btnSwitchUpper_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 469);
            Controls.Add(btnSwitchUpper);
            Controls.Add(btnSwitchGraph);
            Controls.Add(btnSwitchTree);
            Controls.Add(btnSwitchCalender);
            Margin = new Padding(4);
            Name = "FormMain";
            Text = "FormMain";
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnSwitchTree;
        private Button btnSwitchCalender;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem 종료ToolStripMenuItem;
        private Button btnSwitchGraph;
        private Button btnSwitchUpper;
    }
}