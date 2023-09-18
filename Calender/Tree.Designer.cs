namespace Ledger
{
    partial class TreeMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeMain));
            panelHeader = new Panel();
            btnSwitchTree = new Button();
            btnSwitchCalender = new Button();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            splitContainer2 = new SplitContainer();
            groupBoxIncome = new GroupBox();
            groupBoxSpend = new GroupBox();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnSwitchTree);
            panelHeader.Controls.Add(btnSwitchCalender);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 53);
            panelHeader.TabIndex = 4;
            // 
            // btnSwitchTree
            // 
            btnSwitchTree.Image = (Image)resources.GetObject("btnSwitchTree.Image");
            btnSwitchTree.Location = new Point(54, 12);
            btnSwitchTree.Name = "btnSwitchTree";
            btnSwitchTree.Size = new Size(38, 34);
            btnSwitchTree.TabIndex = 14;
            btnSwitchTree.UseVisualStyleBackColor = true;
            btnSwitchTree.Click += btnSwitchTree_Click;
            // 
            // btnSwitchCalender
            // 
            btnSwitchCalender.Image = (Image)resources.GetObject("btnSwitchCalender.Image");
            btnSwitchCalender.Location = new Point(10, 12);
            btnSwitchCalender.Name = "btnSwitchCalender";
            btnSwitchCalender.Size = new Size(38, 34);
            btnSwitchCalender.TabIndex = 13;
            btnSwitchCalender.UseVisualStyleBackColor = true;
            btnSwitchCalender.Click += btnSwitchCalender_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 53);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(800, 397);
            splitContainer1.SplitterDistance = 200;
            splitContainer1.TabIndex = 5;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(200, 397);
            treeView1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBoxIncome);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBoxSpend);
            splitContainer2.Size = new Size(596, 397);
            splitContainer2.SplitterDistance = 298;
            splitContainer2.TabIndex = 0;
            // 
            // groupBoxIncome
            // 
            groupBoxIncome.Dock = DockStyle.Fill;
            groupBoxIncome.Location = new Point(0, 0);
            groupBoxIncome.Name = "groupBoxIncome";
            groupBoxIncome.Size = new Size(298, 397);
            groupBoxIncome.TabIndex = 0;
            groupBoxIncome.TabStop = false;
            groupBoxIncome.Text = "수입";
            // 
            // groupBoxSpend
            // 
            groupBoxSpend.Dock = DockStyle.Fill;
            groupBoxSpend.Location = new Point(0, 0);
            groupBoxSpend.Name = "groupBoxSpend";
            groupBoxSpend.Size = new Size(294, 397);
            groupBoxSpend.TabIndex = 0;
            groupBoxSpend.TabStop = false;
            groupBoxSpend.Text = "지출";
            // 
            // TreeMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(panelHeader);
            Name = "TreeMain";
            Text = "TreeMain";
            FormClosing += TreeMain_FormClosing;
            panelHeader.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelHeader;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private SplitContainer splitContainer2;
        private GroupBox groupBoxIncome;
        private GroupBox groupBoxSpend;
        private Button btnSwitchTree;
        private Button btnSwitchCalender;
    }
}