namespace Ledger {
    partial class AchievementGet {
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
            button1 = new Button();
            achImage = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)achImage).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(125, 159);
            button1.Name = "button1";
            button1.Size = new Size(63, 29);
            button1.TabIndex = 0;
            button1.Text = "닫기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // achImage
            // 
            achImage.Image = Properties.Resources.Ach0;
            achImage.Location = new Point(55, 50);
            achImage.Name = "achImage";
            achImage.Size = new Size(92, 92);
            achImage.TabIndex = 1;
            achImage.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("나눔스퀘어", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(46, 13);
            label1.Name = "label1";
            label1.Size = new Size(108, 26);
            label1.TabIndex = 2;
            label1.Text = "업적 획득!";
            // 
            // AchievementGet
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_loading;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(200, 200);
            Controls.Add(label1);
            Controls.Add(achImage);
            Controls.Add(button1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AchievementGet";
            Text = "AchievementGet";
            ((System.ComponentModel.ISupportInitialize)achImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox achImage;
        private Label label1;
    }
}