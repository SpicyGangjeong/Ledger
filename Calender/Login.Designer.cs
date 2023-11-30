namespace Ledger {
    partial class Login {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            btnSearchPw = new Button();
            btnSignUp = new Button();
            btnLogin = new Button();
            label3 = new Label();
            label2 = new Label();
            userPw = new TextBox();
            userId = new TextBox();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(188, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(126, 124);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(68, 169);
            panel2.Name = "panel2";
            panel2.Size = new Size(366, 49);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(219, 235);
            label1.Name = "label1";
            label1.Size = new Size(72, 28);
            label1.TabIndex = 2;
            label1.Text = "로그인";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnSearchPw);
            panel3.Controls.Add(btnSignUp);
            panel3.Controls.Add(btnLogin);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(userPw);
            panel3.Controls.Add(userId);
            panel3.Location = new Point(42, 277);
            panel3.Name = "panel3";
            panel3.Size = new Size(417, 200);
            panel3.TabIndex = 3;
            // 
            // btnSearchPw
            // 
            btnSearchPw.BackColor = Color.WhiteSmoke;
            btnSearchPw.FlatStyle = FlatStyle.Flat;
            btnSearchPw.Location = new Point(208, 131);
            btnSearchPw.Name = "btnSearchPw";
            btnSearchPw.Size = new Size(192, 37);
            btnSearchPw.TabIndex = 6;
            btnSearchPw.Text = "아이디/비밀번호 찾기";
            btnSearchPw.UseVisualStyleBackColor = false;
            btnSearchPw.Click += btnSearchPw_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.WhiteSmoke;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Location = new Point(15, 131);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(186, 37);
            btnSignUp.TabIndex = 5;
            btnSignUp.Text = "회원가입";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.WhiteSmoke;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(291, 29);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 76);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 83);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 3;
            label3.Text = "비밀번호";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 33);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 2;
            label2.Text = "아이디";
            // 
            // userPw
            // 
            userPw.BackColor = Color.WhiteSmoke;
            userPw.Location = new Point(94, 79);
            userPw.Name = "userPw";
            userPw.PasswordChar = '*';
            userPw.Size = new Size(181, 27);
            userPw.TabIndex = 1;
            userPw.KeyDown += userPw_KeyDown;
            // 
            // userId
            // 
            userId.BackColor = Color.WhiteSmoke;
            userId.Location = new Point(94, 29);
            userId.Name = "userId";
            userId.Size = new Size(181, 27);
            userId.TabIndex = 0;
            userId.KeyDown += userId_KeyDown;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(501, 517);
            Controls.Add(panel3);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "로그인";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Button btnSearchPw;
        private Button btnSignUp;
        private Button btnLogin;
        private Label label3;
        private Label label2;
        private TextBox userPw;
        private TextBox userId;
    }
}