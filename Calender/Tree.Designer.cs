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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeMain));
            panelHeader = new Panel();
            txtNowMonth = new TextBox();
            YearPicker = new TextBox();
            MonthPicker = new ComboBox();
            btnSwitchTree = new Button();
            btnSwitchCalender = new Button();
            splitContainer1 = new SplitContainer();
            IOTree = new TreeView();
            TreeImages = new ImageList(components);
            splitContainer2 = new SplitContainer();
            groupBoxIncome = new GroupBox();
            flpnl_Spend = new FlowLayoutPanel();
            groupBoxSpend = new GroupBox();
            flpnl_Income = new FlowLayoutPanel();
            imageList1 = new ImageList(components);
            imageList2 = new ImageList(components);
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBoxIncome.SuspendLayout();
            groupBoxSpend.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(txtNowMonth);
            panelHeader.Controls.Add(YearPicker);
            panelHeader.Controls.Add(MonthPicker);
            panelHeader.Controls.Add(btnSwitchTree);
            panelHeader.Controls.Add(btnSwitchCalender);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1029, 71);
            panelHeader.TabIndex = 4;
            // 
            // txtNowMonth
            // 
            txtNowMonth.BorderStyle = BorderStyle.None;
            txtNowMonth.Enabled = false;
            txtNowMonth.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtNowMonth.Location = new Point(460, 34);
            txtNowMonth.Margin = new Padding(4);
            txtNowMonth.Name = "txtNowMonth";
            txtNowMonth.Size = new Size(129, 27);
            txtNowMonth.TabIndex = 17;
            txtNowMonth.TextAlign = HorizontalAlignment.Center;
            // 
            // YearPicker
            // 
            YearPicker.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            YearPicker.Location = new Point(503, 4);
            YearPicker.Margin = new Padding(4);
            YearPicker.Name = "YearPicker";
            YearPicker.Size = new Size(52, 34);
            YearPicker.TabIndex = 16;
            YearPicker.Text = "2023";
            YearPicker.TextAlign = HorizontalAlignment.Center;
            // 
            // MonthPicker
            // 
            MonthPicker.FormattingEnabled = true;
            MonthPicker.Items.AddRange(new object[] { "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월" });
            MonthPicker.Location = new Point(953, 10);
            MonthPicker.Margin = new Padding(4);
            MonthPicker.Name = "MonthPicker";
            MonthPicker.Size = new Size(63, 28);
            MonthPicker.TabIndex = 15;
            // 
            // btnSwitchTree
            // 
            btnSwitchTree.Image = (Image)resources.GetObject("btnSwitchTree.Image");
            btnSwitchTree.Location = new Point(69, 16);
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
            btnSwitchCalender.Location = new Point(13, 16);
            btnSwitchCalender.Margin = new Padding(4);
            btnSwitchCalender.Name = "btnSwitchCalender";
            btnSwitchCalender.Size = new Size(49, 45);
            btnSwitchCalender.TabIndex = 13;
            btnSwitchCalender.UseVisualStyleBackColor = true;
            btnSwitchCalender.Click += btnSwitchCalender_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 71);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(IOTree);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1029, 529);
            splitContainer1.SplitterDistance = 257;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 5;
            // 
            // IOTree
            // 
            IOTree.Dock = DockStyle.Fill;
            IOTree.ImageIndex = 0;
            IOTree.ImageList = TreeImages;
            IOTree.Location = new Point(0, 0);
            IOTree.Margin = new Padding(4);
            IOTree.Name = "IOTree";
            IOTree.SelectedImageIndex = 0;
            IOTree.Size = new Size(257, 529);
            IOTree.TabIndex = 0;
            IOTree.AfterCollapse += IOTree_AfterCollapse;
            IOTree.AfterSelect += IOTree_AfterSelect;
            // 
            // TreeImages
            // 
            TreeImages.ColorDepth = ColorDepth.Depth8Bit;
            TreeImages.ImageStream = (ImageListStreamer)resources.GetObject("TreeImages.ImageStream");
            TreeImages.TransparentColor = Color.Transparent;
            TreeImages.Images.SetKeyName(0, "스크린샷 2023-09-19 154946.ico");
            TreeImages.Images.SetKeyName(1, "스크린샷 2023-09-19 155041.ico");
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBoxIncome);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBoxSpend);
            splitContainer2.Size = new Size(767, 529);
            splitContainer2.SplitterDistance = 383;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // groupBoxIncome
            // 
            groupBoxIncome.Controls.Add(flpnl_Spend);
            groupBoxIncome.Dock = DockStyle.Fill;
            groupBoxIncome.Location = new Point(0, 0);
            groupBoxIncome.Margin = new Padding(4);
            groupBoxIncome.Name = "groupBoxIncome";
            groupBoxIncome.Padding = new Padding(4);
            groupBoxIncome.Size = new Size(383, 529);
            groupBoxIncome.TabIndex = 0;
            groupBoxIncome.TabStop = false;
            groupBoxIncome.Text = "수입";
            // 
            // flpnl_Spend
            // 
            flpnl_Spend.Dock = DockStyle.Fill;
            flpnl_Spend.Location = new Point(4, 24);
            flpnl_Spend.Name = "flpnl_Spend";
            flpnl_Spend.Size = new Size(375, 501);
            flpnl_Spend.TabIndex = 10;
            // 
            // groupBoxSpend
            // 
            groupBoxSpend.Controls.Add(flpnl_Income);
            groupBoxSpend.Dock = DockStyle.Fill;
            groupBoxSpend.Location = new Point(0, 0);
            groupBoxSpend.Margin = new Padding(4);
            groupBoxSpend.Name = "groupBoxSpend";
            groupBoxSpend.Padding = new Padding(4);
            groupBoxSpend.Size = new Size(379, 529);
            groupBoxSpend.TabIndex = 0;
            groupBoxSpend.TabStop = false;
            groupBoxSpend.Text = "지출";
            // 
            // flpnl_Income
            // 
            flpnl_Income.Dock = DockStyle.Fill;
            flpnl_Income.Location = new Point(4, 24);
            flpnl_Income.Name = "flpnl_Income";
            flpnl_Income.Size = new Size(371, 501);
            flpnl_Income.TabIndex = 11;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "edit_icon.png");
            imageList1.Images.SetKeyName(1, "delete_icon.png");
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth8Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "edit_icon.png");
            imageList2.Images.SetKeyName(1, "delete_icon.png");
            // 
            // TreeMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1029, 600);
            Controls.Add(splitContainer1);
            Controls.Add(panelHeader);
            Margin = new Padding(4);
            Name = "TreeMain";
            Text = "TreeMain";
            FormClosing += TreeMain_FormClosing;
            Load += TreeMain_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBoxIncome.ResumeLayout(false);
            groupBoxSpend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelHeader;
        private SplitContainer splitContainer1;
        private TreeView IOTree;
        private SplitContainer splitContainer2;
        private GroupBox groupBoxIncome;
        private GroupBox groupBoxSpend;
        private Button btnSwitchTree;
        private Button btnSwitchCalender;
        private TextBox txtNowMonth;
        private TextBox YearPicker;
        private ComboBox MonthPicker;
        private ImageList TreeImages;
        private FlowLayoutPanel flpnl_Spend;
        private FlowLayoutPanel flpnl_Income;
        private ImageList imageList1;
        private ImageList imageList2;
    }
}