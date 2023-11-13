namespace Ledger
{
    partial class Search
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colMoney = new DataGridViewTextBoxColumn();
            colCate = new DataGridViewTextBoxColumn();
            btnReset = new Button();
            tabFilter = new TabControl();
            tabText = new TabPage();
            pnlText = new Panel();
            rbtnTextBoth = new RadioButton();
            rbtnContent = new RadioButton();
            rbtnTitle = new RadioButton();
            tbText = new TextBox();
            label1 = new Label();
            tabDate = new TabPage();
            pnlDateRange = new Panel();
            label2 = new Label();
            tbDateRange2 = new TextBox();
            tbDateRange1 = new TextBox();
            pnlDateSwitch = new Panel();
            tbDateDirect = new TextBox();
            rbtnDateRange = new RadioButton();
            rbtnDateDirect = new RadioButton();
            tabMoney = new TabPage();
            rbtnMoneyRange = new RadioButton();
            rbtnMoneyDirect = new RadioButton();
            pnlMoneyRange = new Panel();
            label3 = new Label();
            tbMoneyRange2 = new TextBox();
            tbMoneyRange1 = new TextBox();
            pnlMoneyDirect = new Panel();
            tbMoneyDirect = new TextBox();
            tabCate = new TabPage();
            btnCheckAll = new Button();
            btnUncheckAll = new Button();
            cbxOther = new CheckBox();
            cbxGame = new CheckBox();
            cbxMedical = new CheckBox();
            cbxStock = new CheckBox();
            cbxTraffic = new CheckBox();
            cbxSaving = new CheckBox();
            cbxBeauti = new CheckBox();
            cbxDwelling = new CheckBox();
            cbxLeisure = new CheckBox();
            cbxSnack = new CheckBox();
            cbxMeal = new CheckBox();
            tabImp = new TabPage();
            pnlImp = new Panel();
            rbtnNotImp = new RadioButton();
            rbtnImp = new RadioButton();
            rbtnImpBoth = new RadioButton();
            tabRegular = new TabPage();
            pnlReg = new Panel();
            rbtnNotReg = new RadioButton();
            rbtnReg = new RadioButton();
            rbtnRegBoth = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabFilter.SuspendLayout();
            tabText.SuspendLayout();
            pnlText.SuspendLayout();
            tabDate.SuspendLayout();
            pnlDateRange.SuspendLayout();
            pnlDateSwitch.SuspendLayout();
            tabMoney.SuspendLayout();
            pnlMoneyRange.SuspendLayout();
            pnlMoneyDirect.SuspendLayout();
            tabCate.SuspendLayout();
            tabImp.SuspendLayout();
            pnlImp.SuspendLayout();
            tabRegular.SuspendLayout();
            pnlReg.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(562, 116);
            btnSearch.Margin = new Padding(2, 2, 2, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(73, 22);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colDate, colName, colMoney, colCate });
            dataGridView1.Location = new Point(9, 142);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(625, 256);
            dataGridView1.TabIndex = 1;
            // 
            // colDate
            // 
            colDate.HeaderText = "날짜";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.Width = 177;
            // 
            // colName
            // 
            colName.HeaderText = "제목";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.Width = 300;
            // 
            // colMoney
            // 
            colMoney.HeaderText = "금액";
            colMoney.MinimumWidth = 6;
            colMoney.Name = "colMoney";
            colMoney.Width = 200;
            // 
            // colCate
            // 
            colCate.HeaderText = "분야";
            colCate.MinimumWidth = 6;
            colCate.Name = "colCate";
            colCate.Width = 125;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(453, 116);
            btnReset.Margin = new Padding(2, 2, 2, 2);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(103, 22);
            btnReset.TabIndex = 2;
            btnReset.Text = "모든 설정 초기화";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // tabFilter
            // 
            tabFilter.Controls.Add(tabText);
            tabFilter.Controls.Add(tabDate);
            tabFilter.Controls.Add(tabMoney);
            tabFilter.Controls.Add(tabCate);
            tabFilter.Controls.Add(tabImp);
            tabFilter.Controls.Add(tabRegular);
            tabFilter.Location = new Point(9, 9);
            tabFilter.Margin = new Padding(2, 2, 2, 2);
            tabFilter.Name = "tabFilter";
            tabFilter.SelectedIndex = 0;
            tabFilter.Size = new Size(625, 103);
            tabFilter.TabIndex = 3;
            // 
            // tabText
            // 
            tabText.Controls.Add(pnlText);
            tabText.Controls.Add(tbText);
            tabText.Controls.Add(label1);
            tabText.Location = new Point(4, 24);
            tabText.Margin = new Padding(2, 2, 2, 2);
            tabText.Name = "tabText";
            tabText.Padding = new Padding(2, 2, 2, 2);
            tabText.Size = new Size(617, 75);
            tabText.TabIndex = 0;
            tabText.Text = "문자 검색";
            tabText.UseVisualStyleBackColor = true;
            // 
            // pnlText
            // 
            pnlText.Controls.Add(rbtnTextBoth);
            pnlText.Controls.Add(rbtnContent);
            pnlText.Controls.Add(rbtnTitle);
            pnlText.Location = new Point(101, 40);
            pnlText.Margin = new Padding(2, 2, 2, 2);
            pnlText.Name = "pnlText";
            pnlText.Size = new Size(409, 34);
            pnlText.TabIndex = 2;
            // 
            // rbtnTextBoth
            // 
            rbtnTextBoth.AutoSize = true;
            rbtnTextBoth.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnTextBoth.Location = new Point(312, 8);
            rbtnTextBoth.Margin = new Padding(2, 2, 2, 2);
            rbtnTextBoth.Name = "rbtnTextBoth";
            rbtnTextBoth.Size = new Size(99, 21);
            rbtnTextBoth.TabIndex = 2;
            rbtnTextBoth.TabStop = true;
            rbtnTextBoth.Text = "제목 + 내용";
            rbtnTextBoth.UseVisualStyleBackColor = true;
            // 
            // rbtnContent
            // 
            rbtnContent.AutoSize = true;
            rbtnContent.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnContent.Location = new Point(170, 8);
            rbtnContent.Margin = new Padding(2, 2, 2, 2);
            rbtnContent.Name = "rbtnContent";
            rbtnContent.Size = new Size(68, 21);
            rbtnContent.TabIndex = 1;
            rbtnContent.TabStop = true;
            rbtnContent.Text = "내용만";
            rbtnContent.UseVisualStyleBackColor = true;
            // 
            // rbtnTitle
            // 
            rbtnTitle.AutoSize = true;
            rbtnTitle.Checked = true;
            rbtnTitle.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnTitle.Location = new Point(19, 8);
            rbtnTitle.Margin = new Padding(2, 2, 2, 2);
            rbtnTitle.Name = "rbtnTitle";
            rbtnTitle.Size = new Size(68, 21);
            rbtnTitle.TabIndex = 0;
            rbtnTitle.TabStop = true;
            rbtnTitle.Text = "제목만";
            rbtnTitle.UseVisualStyleBackColor = true;
            // 
            // tbText
            // 
            tbText.Font = new Font("예스 고딕 레귤러", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            tbText.Location = new Point(260, 14);
            tbText.Margin = new Padding(2, 2, 2, 2);
            tbText.Name = "tbText";
            tbText.Size = new Size(203, 24);
            tbText.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(147, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 18);
            label1.TabIndex = 0;
            label1.Text = "검색할 문자 입력";
            // 
            // tabDate
            // 
            tabDate.Controls.Add(pnlDateRange);
            tabDate.Controls.Add(pnlDateSwitch);
            tabDate.Controls.Add(rbtnDateRange);
            tabDate.Controls.Add(rbtnDateDirect);
            tabDate.Location = new Point(4, 24);
            tabDate.Margin = new Padding(2, 2, 2, 2);
            tabDate.Name = "tabDate";
            tabDate.Padding = new Padding(2, 2, 2, 2);
            tabDate.Size = new Size(617, 75);
            tabDate.TabIndex = 1;
            tabDate.Text = "날짜 검색";
            tabDate.UseVisualStyleBackColor = true;
            // 
            // pnlDateRange
            // 
            pnlDateRange.Controls.Add(label2);
            pnlDateRange.Controls.Add(tbDateRange2);
            pnlDateRange.Controls.Add(tbDateRange1);
            pnlDateRange.Location = new Point(104, 13);
            pnlDateRange.Margin = new Padding(2, 2, 2, 2);
            pnlDateRange.Name = "pnlDateRange";
            pnlDateRange.Size = new Size(393, 32);
            pnlDateRange.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(195, 7);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 20);
            label2.TabIndex = 2;
            label2.Text = "~";
            // 
            // tbDateRange2
            // 
            tbDateRange2.Location = new Point(219, 6);
            tbDateRange2.Margin = new Padding(2, 2, 2, 2);
            tbDateRange2.Name = "tbDateRange2";
            tbDateRange2.Size = new Size(96, 23);
            tbDateRange2.TabIndex = 1;
            tbDateRange2.TextChanged += PressTextBox;
            // 
            // tbDateRange1
            // 
            tbDateRange1.Location = new Point(95, 6);
            tbDateRange1.Margin = new Padding(2, 2, 2, 2);
            tbDateRange1.Name = "tbDateRange1";
            tbDateRange1.Size = new Size(96, 23);
            tbDateRange1.TabIndex = 0;
            tbDateRange1.TextChanged += PressTextBox;
            // 
            // pnlDateSwitch
            // 
            pnlDateSwitch.Controls.Add(tbDateDirect);
            pnlDateSwitch.Location = new Point(105, 13);
            pnlDateSwitch.Margin = new Padding(2, 2, 2, 2);
            pnlDateSwitch.Name = "pnlDateSwitch";
            pnlDateSwitch.Size = new Size(393, 32);
            pnlDateSwitch.TabIndex = 3;
            // 
            // tbDateDirect
            // 
            tbDateDirect.Location = new Point(158, 6);
            tbDateDirect.Margin = new Padding(2, 2, 2, 2);
            tbDateDirect.Name = "tbDateDirect";
            tbDateDirect.Size = new Size(96, 23);
            tbDateDirect.TabIndex = 0;
            tbDateDirect.TextChanged += PressTextBox;
            // 
            // rbtnDateRange
            // 
            rbtnDateRange.AutoSize = true;
            rbtnDateRange.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnDateRange.Location = new Point(320, 51);
            rbtnDateRange.Margin = new Padding(2, 2, 2, 2);
            rbtnDateRange.Name = "rbtnDateRange";
            rbtnDateRange.Size = new Size(86, 21);
            rbtnDateRange.TabIndex = 2;
            rbtnDateRange.Text = "범위 지정";
            rbtnDateRange.UseVisualStyleBackColor = true;
            rbtnDateRange.CheckedChanged += GetChangedDate;
            // 
            // rbtnDateDirect
            // 
            rbtnDateDirect.AutoSize = true;
            rbtnDateDirect.Checked = true;
            rbtnDateDirect.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnDateDirect.Location = new Point(231, 51);
            rbtnDateDirect.Margin = new Padding(2, 2, 2, 2);
            rbtnDateDirect.Name = "rbtnDateDirect";
            rbtnDateDirect.Size = new Size(86, 21);
            rbtnDateDirect.TabIndex = 1;
            rbtnDateDirect.TabStop = true;
            rbtnDateDirect.Text = "날짜 지정";
            rbtnDateDirect.UseVisualStyleBackColor = true;
            rbtnDateDirect.CheckedChanged += GetChangedDate;
            // 
            // tabMoney
            // 
            tabMoney.Controls.Add(rbtnMoneyRange);
            tabMoney.Controls.Add(rbtnMoneyDirect);
            tabMoney.Controls.Add(pnlMoneyRange);
            tabMoney.Controls.Add(pnlMoneyDirect);
            tabMoney.Location = new Point(4, 24);
            tabMoney.Margin = new Padding(2, 2, 2, 2);
            tabMoney.Name = "tabMoney";
            tabMoney.Size = new Size(617, 75);
            tabMoney.TabIndex = 2;
            tabMoney.Text = "금액 검색";
            tabMoney.UseVisualStyleBackColor = true;
            // 
            // rbtnMoneyRange
            // 
            rbtnMoneyRange.AutoSize = true;
            rbtnMoneyRange.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnMoneyRange.Location = new Point(320, 51);
            rbtnMoneyRange.Margin = new Padding(2, 2, 2, 2);
            rbtnMoneyRange.Name = "rbtnMoneyRange";
            rbtnMoneyRange.Size = new Size(86, 21);
            rbtnMoneyRange.TabIndex = 6;
            rbtnMoneyRange.Text = "범위 지정";
            rbtnMoneyRange.UseVisualStyleBackColor = true;
            rbtnMoneyRange.CheckedChanged += GetChangedMoney;
            // 
            // rbtnMoneyDirect
            // 
            rbtnMoneyDirect.AutoSize = true;
            rbtnMoneyDirect.Checked = true;
            rbtnMoneyDirect.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnMoneyDirect.Location = new Point(231, 51);
            rbtnMoneyDirect.Margin = new Padding(2, 2, 2, 2);
            rbtnMoneyDirect.Name = "rbtnMoneyDirect";
            rbtnMoneyDirect.Size = new Size(86, 21);
            rbtnMoneyDirect.TabIndex = 5;
            rbtnMoneyDirect.TabStop = true;
            rbtnMoneyDirect.Text = "금액 지정";
            rbtnMoneyDirect.UseVisualStyleBackColor = true;
            rbtnMoneyDirect.CheckedChanged += GetChangedMoney;
            // 
            // pnlMoneyRange
            // 
            pnlMoneyRange.Controls.Add(label3);
            pnlMoneyRange.Controls.Add(tbMoneyRange2);
            pnlMoneyRange.Controls.Add(tbMoneyRange1);
            pnlMoneyRange.Location = new Point(103, 13);
            pnlMoneyRange.Margin = new Padding(2, 2, 2, 2);
            pnlMoneyRange.Name = "pnlMoneyRange";
            pnlMoneyRange.Size = new Size(393, 32);
            pnlMoneyRange.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(195, 7);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(20, 20);
            label3.TabIndex = 2;
            label3.Text = "~";
            // 
            // tbMoneyRange2
            // 
            tbMoneyRange2.Location = new Point(219, 6);
            tbMoneyRange2.Margin = new Padding(2, 2, 2, 2);
            tbMoneyRange2.Name = "tbMoneyRange2";
            tbMoneyRange2.Size = new Size(96, 23);
            tbMoneyRange2.TabIndex = 1;
            tbMoneyRange2.TextChanged += PressMoneyBox;
            // 
            // tbMoneyRange1
            // 
            tbMoneyRange1.Location = new Point(95, 6);
            tbMoneyRange1.Margin = new Padding(2, 2, 2, 2);
            tbMoneyRange1.Name = "tbMoneyRange1";
            tbMoneyRange1.Size = new Size(96, 23);
            tbMoneyRange1.TabIndex = 0;
            tbMoneyRange1.TextChanged += PressMoneyBox;
            // 
            // pnlMoneyDirect
            // 
            pnlMoneyDirect.Controls.Add(tbMoneyDirect);
            pnlMoneyDirect.Location = new Point(104, 13);
            pnlMoneyDirect.Margin = new Padding(2, 2, 2, 2);
            pnlMoneyDirect.Name = "pnlMoneyDirect";
            pnlMoneyDirect.Size = new Size(393, 32);
            pnlMoneyDirect.TabIndex = 4;
            // 
            // tbMoneyDirect
            // 
            tbMoneyDirect.Location = new Point(158, 6);
            tbMoneyDirect.Margin = new Padding(2, 2, 2, 2);
            tbMoneyDirect.Name = "tbMoneyDirect";
            tbMoneyDirect.Size = new Size(96, 23);
            tbMoneyDirect.TabIndex = 0;
            tbMoneyDirect.TextChanged += PressMoneyBox;
            // 
            // tabCate
            // 
            tabCate.Controls.Add(btnCheckAll);
            tabCate.Controls.Add(btnUncheckAll);
            tabCate.Controls.Add(cbxOther);
            tabCate.Controls.Add(cbxGame);
            tabCate.Controls.Add(cbxMedical);
            tabCate.Controls.Add(cbxStock);
            tabCate.Controls.Add(cbxTraffic);
            tabCate.Controls.Add(cbxSaving);
            tabCate.Controls.Add(cbxBeauti);
            tabCate.Controls.Add(cbxDwelling);
            tabCate.Controls.Add(cbxLeisure);
            tabCate.Controls.Add(cbxSnack);
            tabCate.Controls.Add(cbxMeal);
            tabCate.Location = new Point(4, 24);
            tabCate.Margin = new Padding(2, 2, 2, 2);
            tabCate.Name = "tabCate";
            tabCate.Size = new Size(617, 75);
            tabCate.TabIndex = 3;
            tabCate.Text = "분야 검색";
            tabCate.UseVisualStyleBackColor = true;
            // 
            // btnCheckAll
            // 
            btnCheckAll.Location = new Point(544, 15);
            btnCheckAll.Margin = new Padding(2, 2, 2, 2);
            btnCheckAll.Name = "btnCheckAll";
            btnCheckAll.Size = new Size(64, 22);
            btnCheckAll.TabIndex = 12;
            btnCheckAll.Text = "전부 선택";
            btnCheckAll.UseVisualStyleBackColor = true;
            btnCheckAll.Click += btnCheckAll_Click;
            // 
            // btnUncheckAll
            // 
            btnUncheckAll.Location = new Point(544, 46);
            btnUncheckAll.Margin = new Padding(2, 2, 2, 2);
            btnUncheckAll.Name = "btnUncheckAll";
            btnUncheckAll.Size = new Size(64, 22);
            btnUncheckAll.TabIndex = 11;
            btnUncheckAll.Text = "전부 해제";
            btnUncheckAll.UseVisualStyleBackColor = true;
            btnUncheckAll.Click += btnUncheckAll_Click;
            // 
            // cbxOther
            // 
            cbxOther.AutoSize = true;
            cbxOther.Checked = true;
            cbxOther.CheckState = CheckState.Checked;
            cbxOther.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxOther.Location = new Point(418, 46);
            cbxOther.Margin = new Padding(2, 2, 2, 2);
            cbxOther.Name = "cbxOther";
            cbxOther.Size = new Size(55, 21);
            cbxOther.TabIndex = 10;
            cbxOther.Text = "기타";
            cbxOther.UseVisualStyleBackColor = true;
            // 
            // cbxGame
            // 
            cbxGame.AutoSize = true;
            cbxGame.Checked = true;
            cbxGame.CheckState = CheckState.Checked;
            cbxGame.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxGame.Location = new Point(351, 46);
            cbxGame.Margin = new Padding(2, 2, 2, 2);
            cbxGame.Name = "cbxGame";
            cbxGame.Size = new Size(55, 21);
            cbxGame.TabIndex = 9;
            cbxGame.Text = "게임";
            cbxGame.UseVisualStyleBackColor = true;
            // 
            // cbxMedical
            // 
            cbxMedical.AutoSize = true;
            cbxMedical.Checked = true;
            cbxMedical.CheckState = CheckState.Checked;
            cbxMedical.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxMedical.Location = new Point(283, 46);
            cbxMedical.Margin = new Padding(2, 2, 2, 2);
            cbxMedical.Name = "cbxMedical";
            cbxMedical.Size = new Size(55, 21);
            cbxMedical.TabIndex = 8;
            cbxMedical.Text = "의료";
            cbxMedical.UseVisualStyleBackColor = true;
            // 
            // cbxStock
            // 
            cbxStock.AutoSize = true;
            cbxStock.Checked = true;
            cbxStock.CheckState = CheckState.Checked;
            cbxStock.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxStock.Location = new Point(215, 46);
            cbxStock.Margin = new Padding(2, 2, 2, 2);
            cbxStock.Name = "cbxStock";
            cbxStock.Size = new Size(55, 21);
            cbxStock.TabIndex = 7;
            cbxStock.Text = "주식";
            cbxStock.UseVisualStyleBackColor = true;
            // 
            // cbxTraffic
            // 
            cbxTraffic.AutoSize = true;
            cbxTraffic.Checked = true;
            cbxTraffic.CheckState = CheckState.Checked;
            cbxTraffic.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxTraffic.Location = new Point(148, 46);
            cbxTraffic.Margin = new Padding(2, 2, 2, 2);
            cbxTraffic.Name = "cbxTraffic";
            cbxTraffic.Size = new Size(55, 21);
            cbxTraffic.TabIndex = 6;
            cbxTraffic.Text = "교통";
            cbxTraffic.UseVisualStyleBackColor = true;
            // 
            // cbxSaving
            // 
            cbxSaving.AutoSize = true;
            cbxSaving.Checked = true;
            cbxSaving.CheckState = CheckState.Checked;
            cbxSaving.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxSaving.Location = new Point(463, 15);
            cbxSaving.Margin = new Padding(2, 2, 2, 2);
            cbxSaving.Name = "cbxSaving";
            cbxSaving.Size = new Size(55, 21);
            cbxSaving.TabIndex = 5;
            cbxSaving.Text = "저축";
            cbxSaving.UseVisualStyleBackColor = true;
            // 
            // cbxBeauti
            // 
            cbxBeauti.AutoSize = true;
            cbxBeauti.Checked = true;
            cbxBeauti.CheckState = CheckState.Checked;
            cbxBeauti.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxBeauti.Location = new Point(394, 15);
            cbxBeauti.Margin = new Padding(2, 2, 2, 2);
            cbxBeauti.Name = "cbxBeauti";
            cbxBeauti.Size = new Size(55, 21);
            cbxBeauti.TabIndex = 4;
            cbxBeauti.Text = "미용";
            cbxBeauti.UseVisualStyleBackColor = true;
            // 
            // cbxDwelling
            // 
            cbxDwelling.AutoSize = true;
            cbxDwelling.Checked = true;
            cbxDwelling.CheckState = CheckState.Checked;
            cbxDwelling.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxDwelling.Location = new Point(324, 15);
            cbxDwelling.Margin = new Padding(2, 2, 2, 2);
            cbxDwelling.Name = "cbxDwelling";
            cbxDwelling.Size = new Size(55, 21);
            cbxDwelling.TabIndex = 3;
            cbxDwelling.Text = "주거";
            cbxDwelling.UseVisualStyleBackColor = true;
            // 
            // cbxLeisure
            // 
            cbxLeisure.AutoSize = true;
            cbxLeisure.Checked = true;
            cbxLeisure.CheckState = CheckState.Checked;
            cbxLeisure.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxLeisure.Location = new Point(255, 15);
            cbxLeisure.Margin = new Padding(2, 2, 2, 2);
            cbxLeisure.Name = "cbxLeisure";
            cbxLeisure.Size = new Size(55, 21);
            cbxLeisure.TabIndex = 2;
            cbxLeisure.Text = "여가";
            cbxLeisure.UseVisualStyleBackColor = true;
            // 
            // cbxSnack
            // 
            cbxSnack.AutoSize = true;
            cbxSnack.Checked = true;
            cbxSnack.CheckState = CheckState.Checked;
            cbxSnack.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxSnack.Location = new Point(186, 15);
            cbxSnack.Margin = new Padding(2, 2, 2, 2);
            cbxSnack.Name = "cbxSnack";
            cbxSnack.Size = new Size(55, 21);
            cbxSnack.TabIndex = 1;
            cbxSnack.Text = "간식";
            cbxSnack.UseVisualStyleBackColor = true;
            // 
            // cbxMeal
            // 
            cbxMeal.AutoSize = true;
            cbxMeal.Checked = true;
            cbxMeal.CheckState = CheckState.Checked;
            cbxMeal.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            cbxMeal.Location = new Point(117, 15);
            cbxMeal.Margin = new Padding(2, 2, 2, 2);
            cbxMeal.Name = "cbxMeal";
            cbxMeal.Size = new Size(55, 21);
            cbxMeal.TabIndex = 0;
            cbxMeal.Text = "식사";
            cbxMeal.UseVisualStyleBackColor = true;
            // 
            // tabImp
            // 
            tabImp.Controls.Add(pnlImp);
            tabImp.Location = new Point(4, 24);
            tabImp.Margin = new Padding(2, 2, 2, 2);
            tabImp.Name = "tabImp";
            tabImp.Size = new Size(617, 75);
            tabImp.TabIndex = 4;
            tabImp.Text = "충동구매 검색";
            tabImp.UseVisualStyleBackColor = true;
            // 
            // pnlImp
            // 
            pnlImp.Controls.Add(rbtnNotImp);
            pnlImp.Controls.Add(rbtnImp);
            pnlImp.Controls.Add(rbtnImpBoth);
            pnlImp.Location = new Point(114, 22);
            pnlImp.Margin = new Padding(2, 2, 2, 2);
            pnlImp.Name = "pnlImp";
            pnlImp.Size = new Size(366, 34);
            pnlImp.TabIndex = 0;
            // 
            // rbtnNotImp
            // 
            rbtnNotImp.AutoSize = true;
            rbtnNotImp.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnNotImp.Location = new Point(226, 8);
            rbtnNotImp.Margin = new Padding(2, 2, 2, 2);
            rbtnNotImp.Name = "rbtnNotImp";
            rbtnNotImp.Size = new Size(82, 21);
            rbtnNotImp.TabIndex = 2;
            rbtnNotImp.Text = "비충동적";
            rbtnNotImp.UseVisualStyleBackColor = true;
            // 
            // rbtnImp
            // 
            rbtnImp.AutoSize = true;
            rbtnImp.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnImp.Location = new Point(150, 8);
            rbtnImp.Margin = new Padding(2, 2, 2, 2);
            rbtnImp.Name = "rbtnImp";
            rbtnImp.Size = new Size(68, 21);
            rbtnImp.TabIndex = 1;
            rbtnImp.Text = "충동적";
            rbtnImp.UseVisualStyleBackColor = true;
            // 
            // rbtnImpBoth
            // 
            rbtnImpBoth.AutoSize = true;
            rbtnImpBoth.Checked = true;
            rbtnImpBoth.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnImpBoth.Location = new Point(86, 8);
            rbtnImpBoth.Margin = new Padding(2, 2, 2, 2);
            rbtnImpBoth.Name = "rbtnImpBoth";
            rbtnImpBoth.Size = new Size(54, 21);
            rbtnImpBoth.TabIndex = 0;
            rbtnImpBoth.TabStop = true;
            rbtnImpBoth.Text = "모두";
            rbtnImpBoth.UseVisualStyleBackColor = true;
            // 
            // tabRegular
            // 
            tabRegular.Controls.Add(pnlReg);
            tabRegular.Location = new Point(4, 24);
            tabRegular.Margin = new Padding(2, 2, 2, 2);
            tabRegular.Name = "tabRegular";
            tabRegular.Size = new Size(617, 75);
            tabRegular.TabIndex = 5;
            tabRegular.Text = "매월 정기 검색";
            tabRegular.UseVisualStyleBackColor = true;
            // 
            // pnlReg
            // 
            pnlReg.Controls.Add(rbtnNotReg);
            pnlReg.Controls.Add(rbtnReg);
            pnlReg.Controls.Add(rbtnRegBoth);
            pnlReg.Location = new Point(114, 22);
            pnlReg.Margin = new Padding(2, 2, 2, 2);
            pnlReg.Name = "pnlReg";
            pnlReg.Size = new Size(366, 34);
            pnlReg.TabIndex = 1;
            // 
            // rbtnNotReg
            // 
            rbtnNotReg.AutoSize = true;
            rbtnNotReg.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnNotReg.Location = new Point(241, 8);
            rbtnNotReg.Margin = new Padding(2, 2, 2, 2);
            rbtnNotReg.Name = "rbtnNotReg";
            rbtnNotReg.Size = new Size(114, 21);
            rbtnNotReg.TabIndex = 2;
            rbtnNotReg.Text = "매월 비정기적";
            rbtnNotReg.UseVisualStyleBackColor = true;
            // 
            // rbtnReg
            // 
            rbtnReg.AutoSize = true;
            rbtnReg.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnReg.Location = new Point(144, 8);
            rbtnReg.Margin = new Padding(2, 2, 2, 2);
            rbtnReg.Name = "rbtnReg";
            rbtnReg.Size = new Size(100, 21);
            rbtnReg.TabIndex = 1;
            rbtnReg.Text = "매월 정기적";
            rbtnReg.UseVisualStyleBackColor = true;
            // 
            // rbtnRegBoth
            // 
            rbtnRegBoth.AutoSize = true;
            rbtnRegBoth.Checked = true;
            rbtnRegBoth.Font = new Font("나눔스퀘어", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnRegBoth.Location = new Point(86, 8);
            rbtnRegBoth.Margin = new Padding(2, 2, 2, 2);
            rbtnRegBoth.Name = "rbtnRegBoth";
            rbtnRegBoth.Size = new Size(54, 21);
            rbtnRegBoth.TabIndex = 0;
            rbtnRegBoth.TabStop = true;
            rbtnRegBoth.Text = "모두";
            rbtnRegBoth.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 408);
            Controls.Add(tabFilter);
            Controls.Add(btnReset);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Search";
            Text = "Search";
            FormClosing += Search_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabFilter.ResumeLayout(false);
            tabText.ResumeLayout(false);
            tabText.PerformLayout();
            pnlText.ResumeLayout(false);
            pnlText.PerformLayout();
            tabDate.ResumeLayout(false);
            tabDate.PerformLayout();
            pnlDateRange.ResumeLayout(false);
            pnlDateRange.PerformLayout();
            pnlDateSwitch.ResumeLayout(false);
            pnlDateSwitch.PerformLayout();
            tabMoney.ResumeLayout(false);
            tabMoney.PerformLayout();
            pnlMoneyRange.ResumeLayout(false);
            pnlMoneyRange.PerformLayout();
            pnlMoneyDirect.ResumeLayout(false);
            pnlMoneyDirect.PerformLayout();
            tabCate.ResumeLayout(false);
            tabCate.PerformLayout();
            tabImp.ResumeLayout(false);
            pnlImp.ResumeLayout(false);
            pnlImp.PerformLayout();
            tabRegular.ResumeLayout(false);
            pnlReg.ResumeLayout(false);
            pnlReg.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSearch;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colMoney;
        private DataGridViewTextBoxColumn colCate;
        private Button btnReset;
        private TabControl tabFilter;
        private TabPage tabText;
        private TabPage tabDate;
        private TabPage tabMoney;
        private TabPage tabCate;
        private TabPage tabImp;
        private TabPage tabRegular;
        private Label label1;
        private TextBox tbText;
        private Panel pnlText;
        private RadioButton rbtnTextBoth;
        private RadioButton rbtnContent;
        private RadioButton rbtnTitle;
        private TextBox tbDateDirect;
        private CheckBox cbxMeal;
        private CheckBox cbxLeisure;
        private CheckBox cbxSnack;
        private CheckBox cbxDwelling;
        private CheckBox cbxBeauti;
        private CheckBox cbxOther;
        private CheckBox cbxGame;
        private CheckBox cbxMedical;
        private CheckBox cbxStock;
        private CheckBox cbxTraffic;
        private CheckBox cbxSaving;
        private Panel pnlImp;
        private RadioButton rbtnImpBoth;
        private RadioButton rbtnNotImp;
        private RadioButton rbtnImp;
        private Panel pnlReg;
        private RadioButton rbtnNotReg;
        private RadioButton rbtnReg;
        private RadioButton rbtnRegBoth;
        private RadioButton rbtnDateRange;
        private RadioButton rbtnDateDirect;
        private Panel pnlDateSwitch;
        private Panel pnlDateRange;
        private TextBox tbDateRange2;
        private TextBox tbDateRange1;
        private Label label2;
        private Panel pnlMoneyRange;
        private Label label3;
        private TextBox tbMoneyRange2;
        private TextBox tbMoneyRange1;
        private Panel pnlMoneyDirect;
        private TextBox tbMoneyDirect;
        private RadioButton rbtnMoneyRange;
        private RadioButton rbtnMoneyDirect;
        private Button btnUncheckAll;
        private Button btnCheckAll;
    }
}