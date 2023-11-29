namespace Ledger {
    partial class LoadingScreen {
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("나눔스퀘어_ac", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(136, 433);
            label1.Name = "label1";
            label1.Size = new Size(239, 22);
            label1.TabIndex = 0;
            label1.Text = "유저 정보를 초기화중입니다...";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.loading_gif;
            pictureBox1.Location = new Point(138, 131);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 242);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // LoadingScreen
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_loading;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(502, 517);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "LoadingScreen";
            Text = "LoadingScreen";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
    }
}