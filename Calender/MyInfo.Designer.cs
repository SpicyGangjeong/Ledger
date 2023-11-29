namespace Ledger
{
    partial class MyInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyInfo));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnModifyinfo = new Button();
            deleteAccount = new Label();
            infoName = new Label();
            infoId = new Label();
            infoSignDate = new Label();
            label8 = new Label();
            label10 = new Label();
            label5 = new Label();
            infoEmail = new TextBox();
            infoPhone = new TextBox();
            infoPw = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(23, 24);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "성명";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 98);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "가입일";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 61);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "아이디";
            // 
            // btnModifyinfo
            // 
            btnModifyinfo.Location = new Point(23, 253);
            btnModifyinfo.Name = "btnModifyinfo";
            btnModifyinfo.Size = new Size(270, 29);
            btnModifyinfo.TabIndex = 3;
            btnModifyinfo.Text = "내정보 수정";
            btnModifyinfo.UseVisualStyleBackColor = true;
            btnModifyinfo.Click += btnModifyinfo_Click;
            // 
            // deleteAccount
            // 
            deleteAccount.AutoSize = true;
            deleteAccount.BackColor = Color.Transparent;
            deleteAccount.Font = new Font("맑은 고딕", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            deleteAccount.ForeColor = SystemColors.ControlDark;
            deleteAccount.Location = new Point(261, 4);
            deleteAccount.Name = "deleteAccount";
            deleteAccount.Size = new Size(60, 17);
            deleteAccount.TabIndex = 4;
            deleteAccount.Text = "회원탈퇴";
            deleteAccount.Click += deleteAccount_Click;
            // 
            // infoName
            // 
            infoName.AutoSize = true;
            infoName.BackColor = Color.Transparent;
            infoName.ForeColor = Color.Black;
            infoName.Location = new Point(97, 24);
            infoName.Name = "infoName";
            infoName.Size = new Size(54, 20);
            infoName.TabIndex = 5;
            infoName.Text = "테스트";
            // 
            // infoId
            // 
            infoId.AutoSize = true;
            infoId.BackColor = Color.Transparent;
            infoId.ForeColor = Color.Black;
            infoId.Location = new Point(97, 61);
            infoId.Name = "infoId";
            infoId.Size = new Size(57, 20);
            infoId.TabIndex = 6;
            infoId.Text = "test123";
            // 
            // infoSignDate
            // 
            infoSignDate.AutoSize = true;
            infoSignDate.BackColor = Color.Transparent;
            infoSignDate.ForeColor = Color.Black;
            infoSignDate.Location = new Point(97, 98);
            infoSignDate.Name = "infoSignDate";
            infoSignDate.Size = new Size(85, 20);
            infoSignDate.TabIndex = 7;
            infoSignDate.Text = "2023-11-06";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(23, 172);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 8;
            label8.Text = "전화번호";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(23, 209);
            label10.Name = "label10";
            label10.Size = new Size(54, 20);
            label10.TabIndex = 10;
            label10.Text = "이메일";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(23, 135);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 12;
            label5.Text = "비밀번호";
            // 
            // infoEmail
            // 
            infoEmail.BackColor = Color.WhiteSmoke;
            infoEmail.Location = new Point(97, 206);
            infoEmail.Name = "infoEmail";
            infoEmail.Size = new Size(170, 27);
            infoEmail.TabIndex = 14;
            // 
            // infoPhone
            // 
            infoPhone.BackColor = Color.WhiteSmoke;
            infoPhone.Location = new Point(97, 169);
            infoPhone.Name = "infoPhone";
            infoPhone.Size = new Size(170, 27);
            infoPhone.TabIndex = 15;
            // 
            // infoPw
            // 
            infoPw.BackColor = Color.WhiteSmoke;
            infoPw.Location = new Point(98, 132);
            infoPw.Name = "infoPw";
            infoPw.PasswordChar = '*';
            infoPw.Size = new Size(169, 27);
            infoPw.TabIndex = 16;
            // 
            // MyInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(318, 295);
            Controls.Add(infoPw);
            Controls.Add(infoPhone);
            Controls.Add(infoEmail);
            Controls.Add(label5);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(infoSignDate);
            Controls.Add(infoId);
            Controls.Add(infoName);
            Controls.Add(deleteAccount);
            Controls.Add(btnModifyinfo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MyInfo";
            Text = "내정보";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnModifyinfo;
        private Label deleteAccount;
        private Label infoName;
        private Label infoId;
        private Label infoSignDate;
        private Label label8;
        private Label label10;
        private Label label5;
        private TextBox infoEmail;
        private TextBox infoPhone;
        private TextBox infoPw;
    }
}