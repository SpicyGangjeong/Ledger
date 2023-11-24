namespace Ledger
{
    partial class SeekAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeekAccount));
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            SearchId = new TabPage();
            SearchIdResult = new Label();
            btnSearchId = new Button();
            tbSearchIdEmail = new TextBox();
            tbSearchIdName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            SearchPw = new TabPage();
            SearchPwResult = new Label();
            btnSearchPw = new Button();
            tbSearchPwId = new TextBox();
            tbSearchPwEmail = new TextBox();
            tbSearchPwName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            SearchId.SuspendLayout();
            SearchPw.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(377, 402);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(77, 63);
            label1.Name = "label1";
            label1.Size = new Size(222, 28);
            label1.TabIndex = 4;
            label1.Text = "아이디 / 비밀번호 찾기";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Location = new Point(90, 18);
            panel3.Name = "panel3";
            panel3.Size = new Size(248, 33);
            panel3.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(44, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(36, 33);
            panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(SearchId);
            tabControl1.Controls.Add(SearchPw);
            tabControl1.Location = new Point(12, 105);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(353, 291);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // SearchId
            // 
            SearchId.Controls.Add(SearchIdResult);
            SearchId.Controls.Add(btnSearchId);
            SearchId.Controls.Add(tbSearchIdEmail);
            SearchId.Controls.Add(tbSearchIdName);
            SearchId.Controls.Add(label3);
            SearchId.Controls.Add(label2);
            SearchId.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SearchId.Location = new Point(4, 29);
            SearchId.Name = "SearchId";
            SearchId.Padding = new Padding(3);
            SearchId.Size = new Size(345, 258);
            SearchId.TabIndex = 0;
            SearchId.Text = "아이디 찾기";
            SearchId.UseVisualStyleBackColor = true;
            // 
            // SearchIdResult
            // 
            SearchIdResult.BackColor = Color.WhiteSmoke;
            SearchIdResult.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SearchIdResult.Location = new Point(7, 175);
            SearchIdResult.Name = "SearchIdResult";
            SearchIdResult.Size = new Size(330, 76);
            SearchIdResult.TabIndex = 0;
            SearchIdResult.Text = "성명과 사용했던 이메일을 입력하세요.";
            SearchIdResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSearchId
            // 
            btnSearchId.BackgroundImage = (Image)resources.GetObject("btnSearchId.BackgroundImage");
            btnSearchId.FlatStyle = FlatStyle.Flat;
            btnSearchId.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearchId.Location = new Point(105, 121);
            btnSearchId.Name = "btnSearchId";
            btnSearchId.Size = new Size(135, 40);
            btnSearchId.TabIndex = 4;
            btnSearchId.Text = "아이디 찾기";
            btnSearchId.UseVisualStyleBackColor = true;
            btnSearchId.Click += btnSearchId_Click;
            // 
            // tbSearchIdEmail
            // 
            tbSearchIdEmail.BackColor = Color.WhiteSmoke;
            tbSearchIdEmail.BorderStyle = BorderStyle.FixedSingle;
            tbSearchIdEmail.Location = new Point(97, 76);
            tbSearchIdEmail.Name = "tbSearchIdEmail";
            tbSearchIdEmail.Size = new Size(207, 27);
            tbSearchIdEmail.TabIndex = 3;
            // 
            // tbSearchIdName
            // 
            tbSearchIdName.BackColor = Color.WhiteSmoke;
            tbSearchIdName.BorderStyle = BorderStyle.FixedSingle;
            tbSearchIdName.Location = new Point(97, 30);
            tbSearchIdName.Name = "tbSearchIdName";
            tbSearchIdName.Size = new Size(135, 27);
            tbSearchIdName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 79);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 1;
            label3.Text = "이메일";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 33);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 0;
            label2.Text = "성명";
            // 
            // SearchPw
            // 
            SearchPw.Controls.Add(SearchPwResult);
            SearchPw.Controls.Add(btnSearchPw);
            SearchPw.Controls.Add(tbSearchPwId);
            SearchPw.Controls.Add(tbSearchPwEmail);
            SearchPw.Controls.Add(tbSearchPwName);
            SearchPw.Controls.Add(label6);
            SearchPw.Controls.Add(label5);
            SearchPw.Controls.Add(label4);
            SearchPw.Location = new Point(4, 29);
            SearchPw.Name = "SearchPw";
            SearchPw.Padding = new Padding(3);
            SearchPw.Size = new Size(345, 258);
            SearchPw.TabIndex = 1;
            SearchPw.Text = "비밀번호 찾기";
            SearchPw.UseVisualStyleBackColor = true;
            // 
            // SearchPwResult
            // 
            SearchPwResult.BackColor = Color.WhiteSmoke;
            SearchPwResult.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SearchPwResult.Location = new Point(7, 175);
            SearchPwResult.Name = "SearchPwResult";
            SearchPwResult.Size = new Size(330, 76);
            SearchPwResult.TabIndex = 8;
            SearchPwResult.Text = "성명과 사용했던 이메일과 아이디를 입력하세요.";
            SearchPwResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSearchPw
            // 
            btnSearchPw.BackgroundImage = (Image)resources.GetObject("btnSearchPw.BackgroundImage");
            btnSearchPw.FlatStyle = FlatStyle.Flat;
            btnSearchPw.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearchPw.Location = new Point(105, 122);
            btnSearchPw.Name = "btnSearchPw";
            btnSearchPw.Size = new Size(135, 40);
            btnSearchPw.TabIndex = 7;
            btnSearchPw.Text = "비밀번호 찾기";
            btnSearchPw.UseVisualStyleBackColor = true;
            btnSearchPw.Click += btnSearchPw_Click;
            // 
            // tbSearchPwId
            // 
            tbSearchPwId.BackColor = Color.WhiteSmoke;
            tbSearchPwId.Location = new Point(97, 81);
            tbSearchPwId.Name = "tbSearchPwId";
            tbSearchPwId.Size = new Size(146, 27);
            tbSearchPwId.TabIndex = 6;
            // 
            // tbSearchPwEmail
            // 
            tbSearchPwEmail.BackColor = Color.WhiteSmoke;
            tbSearchPwEmail.Location = new Point(97, 48);
            tbSearchPwEmail.Name = "tbSearchPwEmail";
            tbSearchPwEmail.Size = new Size(187, 27);
            tbSearchPwEmail.TabIndex = 5;
            // 
            // tbSearchPwName
            // 
            tbSearchPwName.BackColor = Color.WhiteSmoke;
            tbSearchPwName.Location = new Point(97, 14);
            tbSearchPwName.Name = "tbSearchPwName";
            tbSearchPwName.Size = new Size(146, 27);
            tbSearchPwName.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 84);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 3;
            label6.Text = "아이디";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 51);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 2;
            label5.Text = "이메일";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 17);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 1;
            label4.Text = "성명";
            // 
            // SeekAccount
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 402);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SeekAccount";
            Text = "아이디 / 비밀번호 찾기";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            SearchId.ResumeLayout(false);
            SearchId.PerformLayout();
            SearchPw.ResumeLayout(false);
            SearchPw.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TabControl tabControl1;
        private TabPage SearchId;
        private TabPage SearchPw;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Button btnSearchId;
        private TextBox tbSearchIdEmail;
        private TextBox tbSearchIdName;
        private Label label3;
        private Button btnSearchPw;
        private TextBox tbSearchPwId;
        private TextBox tbSearchPwEmail;
        private TextBox tbSearchPwName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label SearchIdResult;
        private Label SearchPwResult;
    }
}