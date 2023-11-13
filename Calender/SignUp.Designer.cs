namespace Ledger
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            btnSignUp = new Button();
            suNameWarning = new Label();
            checkDuple = new Button();
            suEmail = new TextBox();
            label7 = new Label();
            suPhone = new TextBox();
            label6 = new Label();
            suPwRe = new TextBox();
            label5 = new Label();
            suPw = new TextBox();
            label4 = new Label();
            suId = new TextBox();
            label3 = new Label();
            suName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(108, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(36, 33);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(150, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(248, 33);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnSignUp);
            panel3.Controls.Add(suNameWarning);
            panel3.Controls.Add(checkDuple);
            panel3.Controls.Add(suEmail);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(suPhone);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(suPwRe);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(suPw);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(suId);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(suName);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(12, 108);
            panel3.Name = "panel3";
            panel3.Size = new Size(478, 397);
            panel3.TabIndex = 3;
            // 
            // btnSignUp
            // 
            btnSignUp.BackgroundImage = (Image)resources.GetObject("btnSignUp.BackgroundImage");
            btnSignUp.BackgroundImageLayout = ImageLayout.None;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSignUp.Location = new Point(21, 331);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(433, 47);
            btnSignUp.TabIndex = 14;
            btnSignUp.Text = "가입하기";
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // suNameWarning
            // 
            suNameWarning.AutoSize = true;
            suNameWarning.Location = new Point(138, 45);
            suNameWarning.Name = "suNameWarning";
            suNameWarning.Size = new Size(0, 20);
            suNameWarning.TabIndex = 13;
            // 
            // checkDuple
            // 
            checkDuple.BackColor = Color.WhiteSmoke;
            checkDuple.FlatStyle = FlatStyle.Flat;
            checkDuple.Location = new Point(327, 70);
            checkDuple.Name = "checkDuple";
            checkDuple.Size = new Size(79, 29);
            checkDuple.TabIndex = 12;
            checkDuple.Text = "중복확인";
            checkDuple.UseVisualStyleBackColor = false;
            // 
            // suEmail
            // 
            suEmail.BackColor = Color.WhiteSmoke;
            suEmail.Location = new Point(173, 283);
            suEmail.Name = "suEmail";
            suEmail.Size = new Size(248, 27);
            suEmail.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ImageAlign = ContentAlignment.BottomLeft;
            label7.Location = new Point(108, 286);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 10;
            label7.Text = "이메일";
            // 
            // suPhone
            // 
            suPhone.BackColor = Color.WhiteSmoke;
            suPhone.Location = new Point(173, 230);
            suPhone.Name = "suPhone";
            suPhone.Size = new Size(211, 27);
            suPhone.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImageAlign = ContentAlignment.BottomLeft;
            label6.Location = new Point(93, 233);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 8;
            label6.Text = "전화번호";
            // 
            // suPwRe
            // 
            suPwRe.BackColor = Color.WhiteSmoke;
            suPwRe.Location = new Point(173, 177);
            suPwRe.Name = "suPwRe";
            suPwRe.Size = new Size(211, 27);
            suPwRe.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImageAlign = ContentAlignment.BottomLeft;
            label5.Location = new Point(58, 180);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 6;
            label5.Text = "비밀번호 확인";
            // 
            // suPw
            // 
            suPw.BackColor = Color.WhiteSmoke;
            suPw.Location = new Point(173, 124);
            suPw.Name = "suPw";
            suPw.PasswordChar = '*';
            suPw.Size = new Size(211, 27);
            suPw.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImageAlign = ContentAlignment.BottomLeft;
            label4.Location = new Point(93, 127);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 4;
            label4.Text = "비밀번호";
            // 
            // suId
            // 
            suId.BackColor = Color.WhiteSmoke;
            suId.Location = new Point(173, 71);
            suId.Name = "suId";
            suId.Size = new Size(145, 27);
            suId.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 74);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "아이디";
            // 
            // suName
            // 
            suName.BackColor = Color.WhiteSmoke;
            suName.Location = new Point(173, 18);
            suName.Name = "suName";
            suName.Size = new Size(116, 27);
            suName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 21);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 0;
            label2.Text = "성명";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(205, 65);
            label1.Name = "label1";
            label1.Size = new Size(92, 28);
            label1.TabIndex = 3;
            label1.Text = "회원가입";
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(502, 517);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SignUp";
            Text = "회원가입";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox suName;
        private TextBox suPw;
        private Label label4;
        private TextBox suId;
        private Button checkDuple;
        private TextBox suEmail;
        private Label label7;
        private TextBox suPhone;
        private Label label6;
        private TextBox suPwRe;
        private Label label5;
        private Button btnSignUp;
        private Label suNameWarning;
    }
}