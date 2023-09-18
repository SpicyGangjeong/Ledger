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
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // btnSwitchTree
            // 
            btnSwitchTree.Image = (Image)resources.GetObject("btnSwitchTree.Image");
            btnSwitchTree.Location = new Point(56, 12);
            btnSwitchTree.Name = "btnSwitchTree";
            btnSwitchTree.Size = new Size(38, 34);
            btnSwitchTree.TabIndex = 14;
            btnSwitchTree.UseVisualStyleBackColor = true;
            btnSwitchTree.Click += btnSwitchTree_Click;
            // 
            // btnSwitchCalender
            // 
            btnSwitchCalender.Image = (Image)resources.GetObject("btnSwitchCalender.Image");
            btnSwitchCalender.Location = new Point(12, 12);
            btnSwitchCalender.Name = "btnSwitchCalender";
            btnSwitchCalender.Size = new Size(38, 34);
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
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { 종료ToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(99, 26);
            contextMenuStrip.Text = "Ledger";
            // 
            // 종료ToolStripMenuItem
            // 
            종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            종료ToolStripMenuItem.Size = new Size(98, 22);
            종료ToolStripMenuItem.Text = "종료";
            종료ToolStripMenuItem.Click += 종료ToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 352);
            Controls.Add(btnSwitchTree);
            Controls.Add(btnSwitchCalender);
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
    }
}