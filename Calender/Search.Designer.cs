namespace Ledger {
    partial class Search {
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colMoney = new DataGridViewTextBoxColumn();
            colCate = new DataGridViewTextBoxColumn();
            btnReset = new Button();
            tabFilter = new TabControl();
            tabText = new TabPage();
            tabDate = new TabPage();
            tabMoney = new TabPage();
            tabCate = new TabPage();
            tabImp = new TabPage();
            tabRegular = new TabPage();
            label1 = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            rbtnTitle = new RadioButton();
            rbtnContent = new RadioButton();
            rbtnBoth = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabFilter.SuspendLayout();
            tabText.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(722, 155);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colDate, colName, colMoney, colCate });
            dataGridView1.Location = new Point(12, 190);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(804, 342);
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
            btnReset.Location = new Point(583, 155);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(132, 29);
            btnReset.TabIndex = 2;
            btnReset.Text = "모든 설정 초기화";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // tabFilter
            // 
            tabFilter.Controls.Add(tabText);
            tabFilter.Controls.Add(tabDate);
            tabFilter.Controls.Add(tabMoney);
            tabFilter.Controls.Add(tabCate);
            tabFilter.Controls.Add(tabImp);
            tabFilter.Controls.Add(tabRegular);
            tabFilter.Location = new Point(12, 12);
            tabFilter.Name = "tabFilter";
            tabFilter.SelectedIndex = 0;
            tabFilter.Size = new Size(804, 137);
            tabFilter.TabIndex = 3;
            // 
            // tabText
            // 
            tabText.Controls.Add(panel1);
            tabText.Controls.Add(textBox1);
            tabText.Controls.Add(label1);
            tabText.Location = new Point(4, 29);
            tabText.Name = "tabText";
            tabText.Padding = new Padding(3);
            tabText.Size = new Size(796, 104);
            tabText.TabIndex = 0;
            tabText.Text = "문자 검색";
            tabText.UseVisualStyleBackColor = true;
            // 
            // tabDate
            // 
            tabDate.Location = new Point(4, 29);
            tabDate.Name = "tabDate";
            tabDate.Padding = new Padding(3);
            tabDate.Size = new Size(796, 104);
            tabDate.TabIndex = 1;
            tabDate.Text = "날짜 검색";
            tabDate.UseVisualStyleBackColor = true;
            // 
            // tabMoney
            // 
            tabMoney.Location = new Point(4, 29);
            tabMoney.Name = "tabMoney";
            tabMoney.Size = new Size(796, 104);
            tabMoney.TabIndex = 2;
            tabMoney.Text = "금액 검색";
            tabMoney.UseVisualStyleBackColor = true;
            // 
            // tabCate
            // 
            tabCate.Location = new Point(4, 29);
            tabCate.Name = "tabCate";
            tabCate.Size = new Size(796, 104);
            tabCate.TabIndex = 3;
            tabCate.Text = "분야 검색";
            tabCate.UseVisualStyleBackColor = true;
            // 
            // tabImp
            // 
            tabImp.Location = new Point(4, 29);
            tabImp.Name = "tabImp";
            tabImp.Size = new Size(796, 104);
            tabImp.TabIndex = 4;
            tabImp.Text = "충동구매 검색";
            tabImp.UseVisualStyleBackColor = true;
            // 
            // tabRegular
            // 
            tabRegular.Location = new Point(4, 29);
            tabRegular.Name = "tabRegular";
            tabRegular.Size = new Size(796, 104);
            tabRegular.TabIndex = 5;
            tabRegular.Text = "매월 정기 검색";
            tabRegular.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔스퀘어_ac Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(171, 22);
            label1.Name = "label1";
            label1.Size = new Size(132, 21);
            label1.TabIndex = 0;
            label1.Text = "검색할 문자 입력";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("예스 고딕 레귤러", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(316, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(260, 28);
            textBox1.TabIndex = 1;
            textBox1.Text = "나는 신재웅";
            // 
            // panel1
            // 
            panel1.Controls.Add(rbtnBoth);
            panel1.Controls.Add(rbtnContent);
            panel1.Controls.Add(rbtnTitle);
            panel1.Location = new Point(130, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 45);
            panel1.TabIndex = 2;
            // 
            // rbtnTitle
            // 
            rbtnTitle.AutoSize = true;
            rbtnTitle.Checked = true;
            rbtnTitle.Location = new Point(25, 11);
            rbtnTitle.Name = "rbtnTitle";
            rbtnTitle.Size = new Size(75, 24);
            rbtnTitle.TabIndex = 0;
            rbtnTitle.TabStop = true;
            rbtnTitle.Text = "제목만";
            rbtnTitle.UseVisualStyleBackColor = true;
            // 
            // rbtnContent
            // 
            rbtnContent.AutoSize = true;
            rbtnContent.Location = new Point(218, 10);
            rbtnContent.Name = "rbtnContent";
            rbtnContent.Size = new Size(75, 24);
            rbtnContent.TabIndex = 1;
            rbtnContent.TabStop = true;
            rbtnContent.Text = "내용만";
            rbtnContent.UseVisualStyleBackColor = true;
            // 
            // rbtnBoth
            // 
            rbtnBoth.AutoSize = true;
            rbtnBoth.Location = new Point(401, 11);
            rbtnBoth.Name = "rbtnBoth";
            rbtnBoth.Size = new Size(111, 24);
            rbtnBoth.TabIndex = 2;
            rbtnBoth.TabStop = true;
            rbtnBoth.Text = "제목 + 내용";
            rbtnBoth.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 544);
            Controls.Add(tabFilter);
            Controls.Add(btnReset);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "Search";
            Text = "Search";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabFilter.ResumeLayout(false);
            tabText.ResumeLayout(false);
            tabText.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox textBox1;
        private Panel panel1;
        private RadioButton rbtnBoth;
        private RadioButton rbtnContent;
        private RadioButton rbtnTitle;
    }
}