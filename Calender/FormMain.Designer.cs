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
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            종료ToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            btnChallange = new Button();
            btnMonthly = new Button();
            btnSpendanal = new Button();
            btnSearch = new Button();
            btnGraph = new Button();
            btnTree = new Button();
            btnCalendar = new Button();
            panel2 = new Panel();
            ContentLayout = new FlowLayoutPanel();
            contextMenuStrip.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
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
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(btnChallange);
            panel1.Controls.Add(btnMonthly);
            panel1.Controls.Add(btnSpendanal);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnGraph);
            panel1.Controls.Add(btnTree);
            panel1.Controls.Add(btnCalendar);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(112, 544);
            panel1.TabIndex = 2;
            // 
            // btnChallange
            // 
            btnChallange.Image = (Image)resources.GetObject("btnChallange.Image");
            btnChallange.Location = new Point(26, 467);
            btnChallange.Name = "btnChallange";
            btnChallange.Size = new Size(60, 55);
            btnChallange.TabIndex = 7;
            btnChallange.UseVisualStyleBackColor = true;
            btnChallange.Click += btnChallange_Click;
            // 
            // btnMonthly
            // 
            btnMonthly.Image = (Image)resources.GetObject("btnMonthly.Image");
            btnMonthly.Location = new Point(26, 393);
            btnMonthly.Name = "btnMonthly";
            btnMonthly.Size = new Size(60, 55);
            btnMonthly.TabIndex = 6;
            btnMonthly.UseVisualStyleBackColor = true;
            btnMonthly.Click += btnMonthly_Click;
            // 
            // btnSpendanal
            // 
            btnSpendanal.Image = (Image)resources.GetObject("btnSpendanal.Image");
            btnSpendanal.Location = new Point(26, 319);
            btnSpendanal.Name = "btnSpendanal";
            btnSpendanal.Size = new Size(60, 55);
            btnSpendanal.TabIndex = 5;
            btnSpendanal.UseVisualStyleBackColor = true;
            btnSpendanal.Click += btnSpendanal_Click;
            // 
            // btnSearch
            // 
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(26, 245);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(60, 55);
            btnSearch.TabIndex = 4;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnGraph
            // 
            btnGraph.Image = (Image)resources.GetObject("btnGraph.Image");
            btnGraph.Location = new Point(26, 171);
            btnGraph.Name = "btnGraph";
            btnGraph.Size = new Size(60, 55);
            btnGraph.TabIndex = 3;
            btnGraph.UseVisualStyleBackColor = true;
            btnGraph.Click += btnGraph_Click;
            // 
            // btnTree
            // 
            btnTree.Image = (Image)resources.GetObject("btnTree.Image");
            btnTree.Location = new Point(26, 97);
            btnTree.Name = "btnTree";
            btnTree.Size = new Size(60, 55);
            btnTree.TabIndex = 2;
            btnTree.UseVisualStyleBackColor = true;
            btnTree.Click += btnTree_Click;
            // 
            // btnCalendar
            // 
            btnCalendar.Image = (Image)resources.GetObject("btnCalendar.Image");
            btnCalendar.Location = new Point(26, 23);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(60, 55);
            btnCalendar.TabIndex = 1;
            btnCalendar.UseVisualStyleBackColor = true;
            btnCalendar.Click += btnCalendar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(ContentLayout);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(112, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(716, 544);
            panel2.TabIndex = 3;
            // 
            // ContentLayout
            // 
            ContentLayout.Location = new Point(22, 17);
            ContentLayout.Name = "ContentLayout";
            ContentLayout.Size = new Size(673, 510);
            ContentLayout.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 544);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FormMain";
            Text = "HOME";
            contextMenuStrip.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem 종료ToolStripMenuItem;
        private Panel panel1;
        private Button btnChallange;
        private Button btnMonthly;
        private Button btnSpendanal;
        private Button btnSearch;
        private Button btnGraph;
        private Button btnTree;
        private Button btnCalendar;
        private Panel panel2;
        private FlowLayoutPanel ContentLayout;
    }
}