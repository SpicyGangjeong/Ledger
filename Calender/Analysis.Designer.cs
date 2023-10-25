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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analysis));
            formsPlot = new ScottPlot.FormsPlot();
            Title = new TextBox();
            button_f_cate = new Button();
            button_f_way = new Button();
            button_Days = new Button();
            rtbRank = new RichTextBox();
            btnPostMonth = new Button();
            btnPreMonth = new Button();
            txtNowMonth = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            rbt_GroupBox = new GroupBox();
            cbNoImpulseSum = new CheckBox();
            cbCard_NoImpulseSum = new CheckBox();
            cbImPulse_Sum = new CheckBox();
            cbCash_NoImpulseSum = new CheckBox();
            cbCard_ImpulseSum = new CheckBox();
            cbCash_ImpulseSum = new CheckBox();
            cbCard_Sum = new CheckBox();
            cbCash_Sum = new CheckBox();
            panel3 = new Panel();
            btnSwitchUpper = new Button();
            btnSwitchTree = new Button();
            btnSwitchCalender = new Button();
            btnSwitchGraph = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            rbt_GroupBox.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot
            // 
            formsPlot.Location = new Point(0, 0);
            formsPlot.Margin = new Padding(4, 3, 4, 3);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(652, 818);
            formsPlot.TabIndex = 0;
            // 
            // Title
            // 
            Title.BackColor = SystemColors.AppWorkspace;
            Title.BorderStyle = BorderStyle.None;
            Title.Dock = DockStyle.Top;
            Title.Font = new Font("맑은 고딕", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            Title.Location = new Point(0, 0);
            Title.Name = "Title";
            Title.Size = new Size(513, 39);
            Title.TabIndex = 1;
            Title.Text = "분야별 소비 순위";
            Title.TextAlign = HorizontalAlignment.Center;
            // 
            // button_f_cate
            // 
            button_f_cate.Location = new Point(20, 19);
            button_f_cate.Name = "button_f_cate";
            button_f_cate.Size = new Size(75, 23);
            button_f_cate.TabIndex = 2;
            button_f_cate.Text = "분야별";
            button_f_cate.UseVisualStyleBackColor = true;
            button_f_cate.Click += button_f_cate_Click;
            // 
            // button_f_way
            // 
            button_f_way.Location = new Point(101, 19);
            button_f_way.Name = "button_f_way";
            button_f_way.Size = new Size(75, 23);
            button_f_way.TabIndex = 2;
            button_f_way.Text = "수단별";
            button_f_way.UseVisualStyleBackColor = true;
            button_f_way.Click += button_f_way_Click;
            // 
            // button_Days
            // 
            button_Days.Location = new Point(182, 19);
            button_Days.Name = "button_Days";
            button_Days.Size = new Size(75, 23);
            button_Days.TabIndex = 2;
            button_Days.Text = "날짜별";
            button_Days.UseVisualStyleBackColor = true;
            button_Days.Click += button_Days_Click;
            // 
            // rtbRank
            // 
            rtbRank.BackColor = SystemColors.Control;
            rtbRank.BorderStyle = BorderStyle.None;
            rtbRank.Dock = DockStyle.Fill;
            rtbRank.Enabled = false;
            rtbRank.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            rtbRank.Location = new Point(0, 0);
            rtbRank.Name = "rtbRank";
            rtbRank.ReadOnly = true;
            rtbRank.Size = new Size(513, 818);
            rtbRank.TabIndex = 4;
            rtbRank.Text = " ";
            // 
            // btnPostMonth
            // 
            btnPostMonth.BackColor = SystemColors.ControlLightLight;
            btnPostMonth.BackgroundImageLayout = ImageLayout.None;
            btnPostMonth.FlatAppearance.BorderSize = 0;
            btnPostMonth.FlatStyle = FlatStyle.Flat;
            btnPostMonth.Location = new Point(530, 17);
            btnPostMonth.Name = "btnPostMonth";
            btnPostMonth.Size = new Size(42, 23);
            btnPostMonth.TabIndex = 13;
            btnPostMonth.Text = "→ ";
            btnPostMonth.UseVisualStyleBackColor = false;
            btnPostMonth.Visible = false;
            btnPostMonth.Click += btnPostMonth_Click;
            // 
            // btnPreMonth
            // 
            btnPreMonth.BackColor = SystemColors.ControlLightLight;
            btnPreMonth.BackgroundImageLayout = ImageLayout.None;
            btnPreMonth.FlatAppearance.BorderSize = 0;
            btnPreMonth.FlatStyle = FlatStyle.Flat;
            btnPreMonth.Location = new Point(375, 17);
            btnPreMonth.Name = "btnPreMonth";
            btnPreMonth.Size = new Size(43, 23);
            btnPreMonth.TabIndex = 12;
            btnPreMonth.Text = "←";
            btnPreMonth.UseVisualStyleBackColor = false;
            btnPreMonth.Visible = false;
            btnPreMonth.Click += btnPreMonth_Click;
            // 
            // txtNowMonth
            // 
            txtNowMonth.BackColor = SystemColors.ControlLightLight;
            txtNowMonth.BorderStyle = BorderStyle.None;
            txtNowMonth.Enabled = false;
            txtNowMonth.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtNowMonth.Location = new Point(424, 18);
            txtNowMonth.Name = "txtNowMonth";
            txtNowMonth.Size = new Size(100, 22);
            txtNowMonth.TabIndex = 11;
            txtNowMonth.TextAlign = HorizontalAlignment.Center;
            txtNowMonth.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(btnSwitchUpper);
            panel1.Controls.Add(btnSwitchTree);
            panel1.Controls.Add(btnSwitchCalender);
            panel1.Controls.Add(btnSwitchGraph);
            panel1.Controls.Add(txtNowMonth);
            panel1.Controls.Add(btnPostMonth);
            panel1.Controls.Add(button_f_cate);
            panel1.Controls.Add(btnPreMonth);
            panel1.Controls.Add(button_f_way);
            panel1.Controls.Add(button_Days);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 818);
            panel1.Name = "panel1";
            panel1.Size = new Size(1165, 56);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(rbt_GroupBox);
            panel2.Controls.Add(Title);
            panel2.Controls.Add(rtbRank);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(652, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(513, 818);
            panel2.TabIndex = 15;
            // 
            // rbt_GroupBox
            // 
            rbt_GroupBox.Controls.Add(cbNoImpulseSum);
            rbt_GroupBox.Controls.Add(cbCard_NoImpulseSum);
            rbt_GroupBox.Controls.Add(cbImPulse_Sum);
            rbt_GroupBox.Controls.Add(cbCash_NoImpulseSum);
            rbt_GroupBox.Controls.Add(cbCard_ImpulseSum);
            rbt_GroupBox.Controls.Add(cbCash_ImpulseSum);
            rbt_GroupBox.Controls.Add(cbCard_Sum);
            rbt_GroupBox.Controls.Add(cbCash_Sum);
            rbt_GroupBox.Dock = DockStyle.Bottom;
            rbt_GroupBox.Location = new Point(0, 718);
            rbt_GroupBox.Name = "rbt_GroupBox";
            rbt_GroupBox.Size = new Size(513, 100);
            rbt_GroupBox.TabIndex = 6;
            rbt_GroupBox.TabStop = false;
            // 
            // cbNoImpulseSum
            // 
            cbNoImpulseSum.AutoSize = true;
            cbNoImpulseSum.Location = new Point(291, 46);
            cbNoImpulseSum.Name = "cbNoImpulseSum";
            cbNoImpulseSum.Size = new Size(109, 19);
            cbNoImpulseSum.TabIndex = 6;
            cbNoImpulseSum.Text = "NoImpulseSum";
            cbNoImpulseSum.UseVisualStyleBackColor = true;
            cbNoImpulseSum.CheckedChanged += cb_CheckedChanged;
            // 
            // cbCard_NoImpulseSum
            // 
            cbCard_NoImpulseSum.AutoSize = true;
            cbCard_NoImpulseSum.Location = new Point(153, 71);
            cbCard_NoImpulseSum.Name = "cbCard_NoImpulseSum";
            cbCard_NoImpulseSum.Size = new Size(139, 19);
            cbCard_NoImpulseSum.TabIndex = 6;
            cbCard_NoImpulseSum.Text = "Card_NoImpulseSum";
            cbCard_NoImpulseSum.UseVisualStyleBackColor = true;
            cbCard_NoImpulseSum.CheckedChanged += cb_CheckedChanged;
            // 
            // cbImPulse_Sum
            // 
            cbImPulse_Sum.AutoSize = true;
            cbImPulse_Sum.Location = new Point(291, 21);
            cbImPulse_Sum.Name = "cbImPulse_Sum";
            cbImPulse_Sum.Size = new Size(93, 19);
            cbImPulse_Sum.TabIndex = 6;
            cbImPulse_Sum.Text = "ImPulseSum";
            cbImPulse_Sum.UseVisualStyleBackColor = true;
            cbImPulse_Sum.CheckedChanged += cb_CheckedChanged;
            // 
            // cbCash_NoImpulseSum
            // 
            cbCash_NoImpulseSum.AutoSize = true;
            cbCash_NoImpulseSum.Location = new Point(7, 71);
            cbCash_NoImpulseSum.Name = "cbCash_NoImpulseSum";
            cbCash_NoImpulseSum.Size = new Size(140, 19);
            cbCash_NoImpulseSum.TabIndex = 6;
            cbCash_NoImpulseSum.Text = "Cash_NoImpulseSum";
            cbCash_NoImpulseSum.UseVisualStyleBackColor = true;
            cbCash_NoImpulseSum.CheckedChanged += cb_CheckedChanged;
            // 
            // cbCard_ImpulseSum
            // 
            cbCard_ImpulseSum.AutoSize = true;
            cbCard_ImpulseSum.Location = new Point(153, 46);
            cbCard_ImpulseSum.Name = "cbCard_ImpulseSum";
            cbCard_ImpulseSum.Size = new Size(132, 19);
            cbCard_ImpulseSum.TabIndex = 6;
            cbCard_ImpulseSum.Text = "Card_Impulse_Sum ";
            cbCard_ImpulseSum.UseVisualStyleBackColor = true;
            cbCard_ImpulseSum.CheckedChanged += cb_CheckedChanged;
            // 
            // cbCash_ImpulseSum
            // 
            cbCash_ImpulseSum.AutoSize = true;
            cbCash_ImpulseSum.Location = new Point(7, 46);
            cbCash_ImpulseSum.Name = "cbCash_ImpulseSum";
            cbCash_ImpulseSum.Size = new Size(124, 19);
            cbCash_ImpulseSum.TabIndex = 6;
            cbCash_ImpulseSum.Text = "Cash_ImpulseSum";
            cbCash_ImpulseSum.UseVisualStyleBackColor = true;
            cbCash_ImpulseSum.CheckedChanged += cb_CheckedChanged;
            // 
            // cbCard_Sum
            // 
            cbCard_Sum.AutoSize = true;
            cbCard_Sum.Location = new Point(153, 22);
            cbCard_Sum.Name = "cbCard_Sum";
            cbCard_Sum.Size = new Size(81, 19);
            cbCard_Sum.TabIndex = 6;
            cbCard_Sum.Text = "Card_Sum";
            cbCard_Sum.UseVisualStyleBackColor = true;
            cbCard_Sum.CheckedChanged += cb_CheckedChanged;
            // 
            // cbCash_Sum
            // 
            cbCash_Sum.AutoSize = true;
            cbCash_Sum.Location = new Point(7, 22);
            cbCash_Sum.Name = "cbCash_Sum";
            cbCash_Sum.Size = new Size(82, 19);
            cbCash_Sum.TabIndex = 6;
            cbCash_Sum.Text = "Cash_Sum";
            cbCash_Sum.UseVisualStyleBackColor = true;
            cbCash_Sum.CheckedChanged += cb_CheckedChanged;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonShadow;
            panel3.Controls.Add(formsPlot);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(652, 818);
            panel3.TabIndex = 16;
            // 
            // btnSwitchUpper
            // 
            btnSwitchUpper.Location = new Point(1116, 11);
            btnSwitchUpper.Margin = new Padding(2);
            btnSwitchUpper.Name = "btnSwitchUpper";
            btnSwitchUpper.Size = new Size(38, 34);
            btnSwitchUpper.TabIndex = 24;
            btnSwitchUpper.Text = "dd";
            btnSwitchUpper.UseVisualStyleBackColor = true;
            btnSwitchUpper.Click += btnSwitchUpper_Click;
            // 
            // btnSwitchTree
            // 
            btnSwitchTree.Image = (Image)resources.GetObject("btnSwitchTree.Image");
            btnSwitchTree.Location = new Point(1028, 11);
            btnSwitchTree.Name = "btnSwitchTree";
            btnSwitchTree.Size = new Size(38, 34);
            btnSwitchTree.TabIndex = 22;
            btnSwitchTree.UseVisualStyleBackColor = true;
            btnSwitchTree.Click += btnSwitchTree_Click;
            // 
            // btnSwitchCalender
            // 
            btnSwitchCalender.Image = (Image)resources.GetObject("btnSwitchCalender.Image");
            btnSwitchCalender.Location = new Point(984, 11);
            btnSwitchCalender.Name = "btnSwitchCalender";
            btnSwitchCalender.Size = new Size(38, 34);
            btnSwitchCalender.TabIndex = 21;
            btnSwitchCalender.UseVisualStyleBackColor = true;
            btnSwitchCalender.Click += btnSwitchCalender_Click;
            // 
            // btnSwitchGraph
            // 
            btnSwitchGraph.Image = (Image)resources.GetObject("btnSwitchGraph.Image");
            btnSwitchGraph.Location = new Point(1073, 11);
            btnSwitchGraph.Name = "btnSwitchGraph";
            btnSwitchGraph.Size = new Size(38, 34);
            btnSwitchGraph.TabIndex = 23;
            btnSwitchGraph.UseVisualStyleBackColor = true;
            btnSwitchGraph.Click += btnSwitchGraph_Click;
            // 
            // Analysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1165, 874);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Analysis";
            Text = "Analysis";
            FormClosing += Analysis_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            rbt_GroupBox.ResumeLayout(false);
            rbt_GroupBox.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private TextBox Title;
        private Button button_f_cate;
        private Button button_f_way;
        private Button button_Days;
        private RichTextBox rtbRank;
        private Button btnPostMonth;
        private Button btnPreMonth;
        private TextBox txtNowMonth;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private GroupBox rbt_GroupBox;
        private CheckBox cbCash_Sum;
        private CheckBox cbCard_NoImpulseSum;
        private CheckBox cbCash_NoImpulseSum;
        private CheckBox cbCard_ImpulseSum;
        private CheckBox cbCash_ImpulseSum;
        private CheckBox cbCard_Sum;
        private CheckBox cbNoImpulseSum;
        private CheckBox cbImPulse_Sum;
        private Button btnSwitchUpper;
        private Button btnSwitchTree;
        private Button btnSwitchCalender;
        private Button btnSwitchGraph;
    }
}