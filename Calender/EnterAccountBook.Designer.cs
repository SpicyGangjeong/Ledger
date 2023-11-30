namespace Ledger
{
    partial class EnterAccountBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterAccountBook));
            tabControl1 = new TabControl();
            tabSpend = new TabPage();
            dtp_spend = new DateTimePicker();
            cbx_RegSpend = new CheckBox();
            cbx_Imp = new CheckBox();
            pnl_Way = new Panel();
            rbtn_Cash = new RadioButton();
            rbtn_Card = new RadioButton();
            btn_Cancel = new Button();
            tbx_Memo = new TextBox();
            label9 = new Label();
            cmbx_Cate = new ComboBox();
            label7 = new Label();
            tbx_Money = new TextBox();
            label6 = new Label();
            label5 = new Label();
            tbx_Name = new TextBox();
            label4 = new Label();
            btn_Add = new Button();
            tabIncome = new TabPage();
            dtp_income = new DateTimePicker();
            cbx_RegIncome = new CheckBox();
            btn_Cancel2 = new Button();
            btn_Add2 = new Button();
            tbx_Memo2 = new TextBox();
            label11 = new Label();
            tbx_From = new TextBox();
            label3 = new Label();
            label2 = new Label();
            tbx_Money2 = new TextBox();
            tbx_Name2 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            tabControl1.SuspendLayout();
            tabSpend.SuspendLayout();
            pnl_Way.SuspendLayout();
            tabIncome.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabSpend);
            tabControl1.Controls.Add(tabIncome);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(353, 298);
            tabControl1.TabIndex = 0;
            // 
            // tabSpend
            // 
            tabSpend.Controls.Add(dtp_spend);
            tabSpend.Controls.Add(cbx_RegSpend);
            tabSpend.Controls.Add(cbx_Imp);
            tabSpend.Controls.Add(pnl_Way);
            tabSpend.Controls.Add(btn_Cancel);
            tabSpend.Controls.Add(tbx_Memo);
            tabSpend.Controls.Add(label9);
            tabSpend.Controls.Add(cmbx_Cate);
            tabSpend.Controls.Add(label7);
            tabSpend.Controls.Add(tbx_Money);
            tabSpend.Controls.Add(label6);
            tabSpend.Controls.Add(label5);
            tabSpend.Controls.Add(tbx_Name);
            tabSpend.Controls.Add(label4);
            tabSpend.Controls.Add(btn_Add);
            tabSpend.Location = new Point(4, 24);
            tabSpend.Margin = new Padding(2);
            tabSpend.Name = "tabSpend";
            tabSpend.Padding = new Padding(2);
            tabSpend.Size = new Size(345, 270);
            tabSpend.TabIndex = 1;
            tabSpend.Text = "지출 입력";
            tabSpend.UseVisualStyleBackColor = true;
            // 
            // dtp_spend
            // 
            dtp_spend.CustomFormat = "yyyy/MM/dd";
            dtp_spend.Enabled = false;
            dtp_spend.Format = DateTimePickerFormat.Custom;
            dtp_spend.Location = new Point(12, 240);
            dtp_spend.Name = "dtp_spend";
            dtp_spend.Size = new Size(200, 23);
            dtp_spend.TabIndex = 23;
            dtp_spend.Visible = false;
            // 
            // cbx_RegSpend
            // 
            cbx_RegSpend.AutoSize = true;
            cbx_RegSpend.Location = new Point(173, 70);
            cbx_RegSpend.Margin = new Padding(2);
            cbx_RegSpend.Name = "cbx_RegSpend";
            cbx_RegSpend.Size = new Size(158, 19);
            cbx_RegSpend.TabIndex = 22;
            cbx_RegSpend.Text = "정기 지출 기간 설정 (월)";
            cbx_RegSpend.UseVisualStyleBackColor = true;
            cbx_RegSpend.CheckedChanged += cbx_Reg_CheckedChanged;
            // 
            // cbx_Imp
            // 
            cbx_Imp.AutoSize = true;
            cbx_Imp.Location = new Point(173, 99);
            cbx_Imp.Margin = new Padding(2);
            cbx_Imp.Name = "cbx_Imp";
            cbx_Imp.Size = new Size(102, 19);
            cbx_Imp.TabIndex = 21;
            cbx_Imp.Text = "충동구매 여부";
            cbx_Imp.UseVisualStyleBackColor = true;
            // 
            // pnl_Way
            // 
            pnl_Way.Controls.Add(rbtn_Cash);
            pnl_Way.Controls.Add(rbtn_Card);
            pnl_Way.Location = new Point(71, 36);
            pnl_Way.Margin = new Padding(2);
            pnl_Way.Name = "pnl_Way";
            pnl_Way.Size = new Size(257, 24);
            pnl_Way.TabIndex = 20;
            // 
            // rbtn_Cash
            // 
            rbtn_Cash.AutoSize = true;
            rbtn_Cash.Location = new Point(2, 4);
            rbtn_Cash.Margin = new Padding(2);
            rbtn_Cash.Name = "rbtn_Cash";
            rbtn_Cash.Size = new Size(133, 19);
            rbtn_Cash.TabIndex = 6;
            rbtn_Cash.Text = "현금(계좌이체 포함)";
            rbtn_Cash.UseVisualStyleBackColor = true;
            // 
            // rbtn_Card
            // 
            rbtn_Card.AutoSize = true;
            rbtn_Card.Checked = true;
            rbtn_Card.Location = new Point(135, 4);
            rbtn_Card.Margin = new Padding(2);
            rbtn_Card.Name = "rbtn_Card";
            rbtn_Card.Size = new Size(49, 19);
            rbtn_Card.TabIndex = 1;
            rbtn_Card.TabStop = true;
            rbtn_Card.Text = "카드";
            rbtn_Card.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(282, 242);
            btn_Cancel.Margin = new Padding(2);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(51, 22);
            btn_Cancel.TabIndex = 18;
            btn_Cancel.Text = "취소";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // tbx_Memo
            // 
            tbx_Memo.Location = new Point(59, 131);
            tbx_Memo.Margin = new Padding(2);
            tbx_Memo.Multiline = true;
            tbx_Memo.Name = "tbx_Memo";
            tbx_Memo.ScrollBars = ScrollBars.Vertical;
            tbx_Memo.Size = new Size(275, 98);
            tbx_Memo.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 131);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 16;
            label9.Text = "메모";
            // 
            // cmbx_Cate
            // 
            cmbx_Cate.FormattingEnabled = true;
            cmbx_Cate.Items.AddRange(new object[] { "식사", "여가", "간식", "주거", "미용", "저축", "교통", "주식", "의료", "게임", "기타" });
            cmbx_Cate.Location = new Point(59, 97);
            cmbx_Cate.Margin = new Padding(2);
            cmbx_Cate.Name = "cmbx_Cate";
            cmbx_Cate.Size = new Size(98, 23);
            cmbx_Cate.TabIndex = 10;
            cmbx_Cate.Text = "기타";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 99);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 9;
            label7.Text = "분야";
            // 
            // tbx_Money
            // 
            tbx_Money.Location = new Point(59, 68);
            tbx_Money.Margin = new Padding(2);
            tbx_Money.Name = "tbx_Money";
            tbx_Money.Size = new Size(98, 23);
            tbx_Money.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 70);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 7;
            label6.Text = "가격";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 41);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 5;
            label5.Text = "결제수단";
            // 
            // tbx_Name
            // 
            tbx_Name.Location = new Point(59, 11);
            tbx_Name.Margin = new Padding(2);
            tbx_Name.Name = "tbx_Name";
            tbx_Name.Size = new Size(275, 23);
            tbx_Name.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 14);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 3;
            label4.Text = "제목";
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(226, 242);
            btn_Add.Margin = new Padding(2);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(51, 22);
            btn_Add.TabIndex = 0;
            btn_Add.Text = "추가";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += InsertRecordSpend;
            // 
            // tabIncome
            // 
            tabIncome.Controls.Add(dtp_income);
            tabIncome.Controls.Add(cbx_RegIncome);
            tabIncome.Controls.Add(btn_Cancel2);
            tabIncome.Controls.Add(btn_Add2);
            tabIncome.Controls.Add(tbx_Memo2);
            tabIncome.Controls.Add(label11);
            tabIncome.Controls.Add(tbx_From);
            tabIncome.Controls.Add(label3);
            tabIncome.Controls.Add(label2);
            tabIncome.Controls.Add(tbx_Money2);
            tabIncome.Controls.Add(tbx_Name2);
            tabIncome.Controls.Add(label1);
            tabIncome.Controls.Add(button1);
            tabIncome.Location = new Point(4, 24);
            tabIncome.Margin = new Padding(2);
            tabIncome.Name = "tabIncome";
            tabIncome.Padding = new Padding(2);
            tabIncome.Size = new Size(345, 270);
            tabIncome.TabIndex = 0;
            tabIncome.Text = "수입 입력";
            tabIncome.UseVisualStyleBackColor = true;
            // 
            // dtp_income
            // 
            dtp_income.CustomFormat = "yyyy/MM/dd";
            dtp_income.Enabled = false;
            dtp_income.Format = DateTimePickerFormat.Custom;
            dtp_income.Location = new Point(21, 240);
            dtp_income.Name = "dtp_income";
            dtp_income.Size = new Size(200, 23);
            dtp_income.TabIndex = 22;
            dtp_income.Visible = false;
            // 
            // cbx_RegIncome
            // 
            cbx_RegIncome.AutoSize = true;
            cbx_RegIncome.Location = new Point(171, 47);
            cbx_RegIncome.Margin = new Padding(2);
            cbx_RegIncome.Name = "cbx_RegIncome";
            cbx_RegIncome.Size = new Size(158, 19);
            cbx_RegIncome.TabIndex = 21;
            cbx_RegIncome.Text = "정기 수입 기간 설정 (월)";
            cbx_RegIncome.UseVisualStyleBackColor = true;
            cbx_RegIncome.CheckedChanged += cbx_Reg_CheckedChanged;
            // 
            // btn_Cancel2
            // 
            btn_Cancel2.Location = new Point(282, 242);
            btn_Cancel2.Margin = new Padding(2);
            btn_Cancel2.Name = "btn_Cancel2";
            btn_Cancel2.Size = new Size(51, 22);
            btn_Cancel2.TabIndex = 20;
            btn_Cancel2.Text = "취소";
            btn_Cancel2.UseVisualStyleBackColor = true;
            btn_Cancel2.Click += btn_Cancel2_Click;
            // 
            // btn_Add2
            // 
            btn_Add2.Location = new Point(226, 242);
            btn_Add2.Margin = new Padding(2);
            btn_Add2.Name = "btn_Add2";
            btn_Add2.Size = new Size(51, 22);
            btn_Add2.TabIndex = 19;
            btn_Add2.Text = "추가";
            btn_Add2.UseVisualStyleBackColor = true;
            btn_Add2.Click += InsertRecordIncome;
            // 
            // tbx_Memo2
            // 
            tbx_Memo2.Location = new Point(60, 106);
            tbx_Memo2.Margin = new Padding(2);
            tbx_Memo2.Multiline = true;
            tbx_Memo2.Name = "tbx_Memo2";
            tbx_Memo2.ScrollBars = ScrollBars.Vertical;
            tbx_Memo2.Size = new Size(275, 124);
            tbx_Memo2.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 106);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(31, 15);
            label11.TabIndex = 17;
            label11.Text = "메모";
            // 
            // tbx_From
            // 
            tbx_From.Location = new Point(59, 74);
            tbx_From.Margin = new Padding(2);
            tbx_From.Name = "tbx_From";
            tbx_From.Size = new Size(98, 23);
            tbx_From.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 5;
            label3.Text = "수입처";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "가격";
            // 
            // tbx_Money2
            // 
            tbx_Money2.Location = new Point(59, 43);
            tbx_Money2.Margin = new Padding(2);
            tbx_Money2.Name = "tbx_Money2";
            tbx_Money2.Size = new Size(98, 23);
            tbx_Money2.TabIndex = 3;
            // 
            // tbx_Name2
            // 
            tbx_Name2.Location = new Point(59, 11);
            tbx_Name2.Margin = new Padding(2);
            tbx_Name2.Name = "tbx_Name2";
            tbx_Name2.Size = new Size(275, 23);
            tbx_Name2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "제목";
            // 
            // button1
            // 
            button1.Location = new Point(356, 107);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(73, 22);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // EnterAccountBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 296);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "EnterAccountBook";
            RightToLeft = RightToLeft.No;
            Text = "지출 / 수입 입력";
            tabControl1.ResumeLayout(false);
            tabSpend.ResumeLayout(false);
            tabSpend.PerformLayout();
            pnl_Way.ResumeLayout(false);
            pnl_Way.PerformLayout();
            tabIncome.ResumeLayout(false);
            tabIncome.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabIncome;
        private TabPage tabSpend;
        private Button button1;
        private Button btn_Add;
        private Label label1;
        private Label label2;
        private TextBox tbx_Money2;
        private TextBox tbx_Name2;
        private TextBox tbx_From;
        private Label label3;
        private TextBox tbx_Name;
        private Label label4;
        private Label label5;
        private RadioButton rbtn_Cash;
        private RadioButton rbtn_Card;
        private Label label6;
        private TextBox tbx_Money;
        private ComboBox cmbx_Cate;
        private Label label7;
        private Label label9;
        private Button btn_Cancel;
        private TextBox tbx_Memo;
        private Button btn_Cancel2;
        private Button btn_Add2;
        private TextBox tbx_Memo2;
        private Label label11;
        private Panel pnl_Way;
        private CheckBox cbx_Imp;
        private CheckBox cbx_RegSpend;
        private CheckBox cbx_RegIncome;
        private DateTimePicker dtp_spend;
        private DateTimePicker dtp_income;
    }
}