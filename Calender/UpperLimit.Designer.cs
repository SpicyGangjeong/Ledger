namespace Ledger
{
    partial class UpperLimit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpperLimit));
            panel1 = new Panel();
            lbYearTop = new Label();
            btnSwitchUpper = new Button();
            btnSwitchGraph = new Button();
            btnSwitchTree = new Button();
            btnSwitchCalender = new Button();
            pnlBottom = new Panel();
            btnGiveUp = new Button();
            lbText6 = new Label();
            lbText5 = new Label();
            lbText4 = new Label();
            label2 = new Label();
            lbD_Day = new Label();
            lbText3 = new Label();
            label1 = new Label();
            lbText2 = new Label();
            lbText1 = new Label();
            pnlCenter = new Panel();
            pnlNoChallenge = new Panel();
            lbMoney = new Label();
            lbDay = new Label();
            lbMonth = new Label();
            lbYear = new Label();
            tbMoney = new TextBox();
            tbDay = new TextBox();
            tbMonth = new TextBox();
            tbYear = new TextBox();
            btnStart = new Button();
            lbNoChallenge = new Label();
            panel1.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlCenter.SuspendLayout();
            pnlNoChallenge.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbYearTop);
            panel1.Controls.Add(btnSwitchUpper);
            panel1.Controls.Add(btnSwitchGraph);
            panel1.Controls.Add(btnSwitchTree);
            panel1.Controls.Add(btnSwitchCalender);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(846, 95);
            panel1.TabIndex = 1;
            // 
            // lbYearTop
            // 
            lbYearTop.AutoSize = true;
            lbYearTop.Font = new Font("Cascadia Mono", 30F, FontStyle.Bold, GraphicsUnit.Point);
            lbYearTop.Location = new Point(699, 13);
            lbYearTop.Name = "lbYearTop";
            lbYearTop.Size = new Size(144, 66);
            lbYearTop.TabIndex = 20;
            lbYearTop.Text = "2023";
            // 
            // btnSwitchUpper
            // 
            btnSwitchUpper.Location = new Point(186, 13);
            btnSwitchUpper.Name = "btnSwitchUpper";
            btnSwitchUpper.Size = new Size(49, 45);
            btnSwitchUpper.TabIndex = 19;
            btnSwitchUpper.Text = "dd";
            btnSwitchUpper.UseVisualStyleBackColor = true;
            // 
            // btnSwitchGraph
            // 
            btnSwitchGraph.Image = (Image)resources.GetObject("btnSwitchGraph.Image");
            btnSwitchGraph.Location = new Point(130, 13);
            btnSwitchGraph.Margin = new Padding(4);
            btnSwitchGraph.Name = "btnSwitchGraph";
            btnSwitchGraph.Size = new Size(49, 45);
            btnSwitchGraph.TabIndex = 17;
            btnSwitchGraph.UseVisualStyleBackColor = true;
            // 
            // btnSwitchTree
            // 
            btnSwitchTree.Image = (Image)resources.GetObject("btnSwitchTree.Image");
            btnSwitchTree.Location = new Point(73, 13);
            btnSwitchTree.Margin = new Padding(4);
            btnSwitchTree.Name = "btnSwitchTree";
            btnSwitchTree.Size = new Size(49, 45);
            btnSwitchTree.TabIndex = 18;
            btnSwitchTree.UseVisualStyleBackColor = true;
            btnSwitchTree.Click += btnSwitchTree_Click;
            // 
            // btnSwitchCalender
            // 
            btnSwitchCalender.Image = (Image)resources.GetObject("btnSwitchCalender.Image");
            btnSwitchCalender.Location = new Point(16, 13);
            btnSwitchCalender.Margin = new Padding(4);
            btnSwitchCalender.Name = "btnSwitchCalender";
            btnSwitchCalender.Size = new Size(49, 45);
            btnSwitchCalender.TabIndex = 16;
            btnSwitchCalender.UseVisualStyleBackColor = true;
            btnSwitchCalender.Click += btnSwitchCalender_Click;
            // 
            // pnlBottom
            // 
            pnlBottom.BorderStyle = BorderStyle.Fixed3D;
            pnlBottom.Controls.Add(btnGiveUp);
            pnlBottom.Controls.Add(lbText6);
            pnlBottom.Controls.Add(lbText5);
            pnlBottom.Controls.Add(lbText4);
            pnlBottom.Controls.Add(label2);
            pnlBottom.Controls.Add(lbD_Day);
            pnlBottom.Controls.Add(lbText3);
            pnlBottom.Controls.Add(label1);
            pnlBottom.Controls.Add(lbText2);
            pnlBottom.Controls.Add(lbText1);
            pnlBottom.ForeColor = SystemColors.ControlText;
            pnlBottom.Location = new Point(0, 367);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(846, 134);
            pnlBottom.TabIndex = 2;
            // 
            // btnGiveUp
            // 
            btnGiveUp.Location = new Point(716, 92);
            btnGiveUp.Name = "btnGiveUp";
            btnGiveUp.Size = new Size(118, 29);
            btnGiveUp.TabIndex = 10;
            btnGiveUp.Text = "챌린지 포기";
            btnGiveUp.UseVisualStyleBackColor = true;
            btnGiveUp.Click += btnGiveUp_Click;
            // 
            // lbText6
            // 
            lbText6.AutoSize = true;
            lbText6.Location = new Point(383, 95);
            lbText6.Name = "lbText6";
            lbText6.Size = new Size(173, 20);
            lbText6.TabIndex = 8;
            lbText6.Text = "금일 권장액 : 0000000원";
            // 
            // lbText5
            // 
            lbText5.AutoSize = true;
            lbText5.Location = new Point(383, 60);
            lbText5.Name = "lbText5";
            lbText5.Size = new Size(158, 20);
            lbText5.TabIndex = 7;
            lbText5.Text = "잔여 금액 : 0000000원";
            // 
            // lbText4
            // 
            lbText4.AutoSize = true;
            lbText4.Location = new Point(383, 25);
            lbText4.Name = "lbText4";
            lbText4.Size = new Size(158, 20);
            lbText4.TabIndex = 6;
            lbText4.Text = "초기 금액 : 0000000원";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(364, 13);
            label2.Name = "label2";
            label2.Size = new Size(3, 112);
            label2.TabIndex = 5;
            // 
            // lbD_Day
            // 
            lbD_Day.Font = new Font("맑은 고딕", 25F, FontStyle.Bold, GraphicsUnit.Point);
            lbD_Day.Location = new Point(172, 50);
            lbD_Day.Name = "lbD_Day";
            lbD_Day.Size = new Size(182, 71);
            lbD_Day.TabIndex = 4;
            lbD_Day.Text = "0일";
            lbD_Day.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbText3
            // 
            lbText3.AutoSize = true;
            lbText3.Location = new Point(219, 30);
            lbText3.Name = "lbText3";
            lbText3.Size = new Size(84, 20);
            lbText3.TabIndex = 3;
            lbText3.Text = "종료일까지";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(163, 13);
            label1.Name = "label1";
            label1.Size = new Size(3, 112);
            label1.TabIndex = 2;
            // 
            // lbText2
            // 
            lbText2.AutoSize = true;
            lbText2.Location = new Point(14, 82);
            lbText2.Name = "lbText2";
            lbText2.Size = new Size(143, 20);
            lbText2.TabIndex = 1;
            lbText2.Text = "종료일 : 0000-00-00";
            // 
            // lbText1
            // 
            lbText1.AutoSize = true;
            lbText1.Location = new Point(14, 33);
            lbText1.Name = "lbText1";
            lbText1.Size = new Size(143, 20);
            lbText1.TabIndex = 0;
            lbText1.Text = "시작일 : 0000-00-00";
            // 
            // pnlCenter
            // 
            pnlCenter.Controls.Add(pnlNoChallenge);
            pnlCenter.Location = new Point(0, 94);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new Size(846, 274);
            pnlCenter.TabIndex = 3;
            // 
            // pnlNoChallenge
            // 
            pnlNoChallenge.Controls.Add(lbMoney);
            pnlNoChallenge.Controls.Add(lbDay);
            pnlNoChallenge.Controls.Add(lbMonth);
            pnlNoChallenge.Controls.Add(lbYear);
            pnlNoChallenge.Controls.Add(tbMoney);
            pnlNoChallenge.Controls.Add(tbDay);
            pnlNoChallenge.Controls.Add(tbMonth);
            pnlNoChallenge.Controls.Add(tbYear);
            pnlNoChallenge.Controls.Add(btnStart);
            pnlNoChallenge.Controls.Add(lbNoChallenge);
            pnlNoChallenge.Location = new Point(0, 0);
            pnlNoChallenge.Name = "pnlNoChallenge";
            pnlNoChallenge.Size = new Size(846, 274);
            pnlNoChallenge.TabIndex = 0;
            // 
            // lbMoney
            // 
            lbMoney.AutoSize = true;
            lbMoney.Location = new Point(433, 168);
            lbMoney.Name = "lbMoney";
            lbMoney.Size = new Size(164, 20);
            lbMoney.TabIndex = 19;
            lbMoney.Text = "원으로 버텨보겠습니다";
            // 
            // lbDay
            // 
            lbDay.AutoSize = true;
            lbDay.Location = new Point(531, 118);
            lbDay.Name = "lbDay";
            lbDay.Size = new Size(59, 20);
            lbDay.TabIndex = 18;
            lbDay.Text = "일 까지";
            // 
            // lbMonth
            // 
            lbMonth.AutoSize = true;
            lbMonth.Location = new Point(433, 118);
            lbMonth.Name = "lbMonth";
            lbMonth.Size = new Size(24, 20);
            lbMonth.TabIndex = 17;
            lbMonth.Text = "월";
            // 
            // lbYear
            // 
            lbYear.AutoSize = true;
            lbYear.Location = new Point(345, 118);
            lbYear.Name = "lbYear";
            lbYear.Size = new Size(24, 20);
            lbYear.TabIndex = 16;
            lbYear.Text = "년";
            // 
            // tbMoney
            // 
            tbMoney.Location = new Point(241, 165);
            tbMoney.Name = "tbMoney";
            tbMoney.Size = new Size(186, 27);
            tbMoney.TabIndex = 15;
            // 
            // tbDay
            // 
            tbDay.Location = new Point(469, 115);
            tbDay.Name = "tbDay";
            tbDay.Size = new Size(54, 27);
            tbDay.TabIndex = 14;
            // 
            // tbMonth
            // 
            tbMonth.Location = new Point(375, 115);
            tbMonth.Name = "tbMonth";
            tbMonth.Size = new Size(52, 27);
            tbMonth.TabIndex = 13;
            // 
            // tbYear
            // 
            tbYear.Location = new Point(241, 115);
            tbYear.Name = "tbYear";
            tbYear.Size = new Size(98, 27);
            tbYear.TabIndex = 12;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(363, 209);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 11;
            btnStart.Text = "도전하기";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lbNoChallenge
            // 
            lbNoChallenge.AutoSize = true;
            lbNoChallenge.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lbNoChallenge.Location = new Point(209, 36);
            lbNoChallenge.Name = "lbNoChallenge";
            lbNoChallenge.Size = new Size(428, 37);
            lbNoChallenge.TabIndex = 10;
            lbNoChallenge.Text = "진행중인 지출 챌린지가 없습니다.";
            // 
            // UpperLimit
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(846, 501);
            Controls.Add(pnlCenter);
            Controls.Add(pnlBottom);
            Controls.Add(panel1);
            Name = "UpperLimit";
            Text = "UpperLimit";
            FormClosing += UpperLimit_FormClosing;
            Load += UpperLimit_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            pnlCenter.ResumeLayout(false);
            pnlNoChallenge.ResumeLayout(false);
            pnlNoChallenge.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel pnlBottom;
        private Panel pnlCenter;
        private Label lbText2;
        private Label lbText1;
        private Label label1;
        private Label lbText3;
        private Label lbD_Day;
        private Label label2;
        private Label lbText4;
        private Label lbText6;
        private Label lbText5;
        private Button btnGiveUp;
        private Panel pnlNoChallenge;
        private Label lbMoney;
        private Label lbDay;
        private Label lbMonth;
        private Label lbYear;
        private TextBox tbMoney;
        private TextBox tbDay;
        private TextBox tbMonth;
        private TextBox tbYear;
        private Button btnStart;
        private Label lbNoChallenge;
        private Button btnSwitchUpper;
        private Button btnSwitchGraph;
        private Button btnSwitchTree;
        private Button btnSwitchCalender;
        private Label lbYearTop;
    }
}