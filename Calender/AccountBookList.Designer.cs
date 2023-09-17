namespace Calender
{
    partial class AccountBookList
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountBookList));
            btn_Close = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_Add = new Button();
            lb_Date = new Label();
            flpnl_Spend = new FlowLayoutPanel();
            imageList1 = new ImageList(components);
            flpnl_Income = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btn_Close
            // 
            btn_Close.Location = new Point(588, 443);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(66, 29);
            btn_Close.TabIndex = 0;
            btn_Close.Text = "닫기";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += btn_Close_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(334, 52);
            label1.Name = "label1";
            label1.Size = new Size(2, 400);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 2;
            label2.Text = "지출";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(347, 42);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 3;
            label3.Text = "수입";
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(518, 443);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(64, 29);
            btn_Add.TabIndex = 4;
            btn_Add.Text = "추가";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // lb_Date
            // 
            lb_Date.AutoSize = true;
            lb_Date.Location = new Point(12, 9);
            lb_Date.Name = "lb_Date";
            lb_Date.Size = new Size(54, 20);
            lb_Date.TabIndex = 5;
            lb_Date.Text = "년월일";
            // 
            // flpnl_Spend
            // 
            flpnl_Spend.Location = new Point(12, 65);
            flpnl_Spend.Name = "flpnl_Spend";
            flpnl_Spend.Size = new Size(307, 372);
            flpnl_Spend.TabIndex = 8;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "edit_icon.png");
            imageList1.Images.SetKeyName(1, "delete_icon.png");
            // 
            // flpnl_Income
            // 
            flpnl_Income.Location = new Point(347, 65);
            flpnl_Income.Name = "flpnl_Income";
            flpnl_Income.Size = new Size(307, 372);
            flpnl_Income.TabIndex = 9;
            // 
            // AccountBookList
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 484);
            ControlBox = false;
            Controls.Add(flpnl_Income);
            Controls.Add(flpnl_Spend);
            Controls.Add(lb_Date);
            Controls.Add(btn_Add);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Close);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AccountBookList";
            StartPosition = FormStartPosition.Manual;
            Load += AccountBookList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Close;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_Add;
        public Label lb_Date;
        private FlowLayoutPanel flpnl_Spend;
        private ImageList imageList1;
        private FlowLayoutPanel flpnl_Income;
    }
}