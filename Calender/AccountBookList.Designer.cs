﻿namespace Ledger
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
            label4 = new Label();
            SuspendLayout();
            // 
            // btn_Close
            // 
            btn_Close.Location = new Point(507, 335);
            btn_Close.Margin = new Padding(2, 2, 2, 2);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(51, 22);
            btn_Close.TabIndex = 0;
            btn_Close.Text = "닫기";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += btn_Close_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(284, 40);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(2, 300);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 32);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "지출";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 32);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 3;
            label3.Text = "수입";
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(453, 335);
            btn_Add.Margin = new Padding(2, 2, 2, 2);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(50, 22);
            btn_Add.TabIndex = 4;
            btn_Add.Text = "추가";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // lb_Date
            // 
            lb_Date.AutoSize = true;
            lb_Date.Location = new Point(9, 7);
            lb_Date.Margin = new Padding(2, 0, 2, 0);
            lb_Date.Name = "lb_Date";
            lb_Date.Size = new Size(43, 15);
            lb_Date.TabIndex = 5;
            lb_Date.Text = "년월일";
            // 
            // flpnl_Spend
            // 
            flpnl_Spend.Location = new Point(9, 49);
            flpnl_Spend.Margin = new Padding(2, 2, 2, 2);
            flpnl_Spend.Name = "flpnl_Spend";
            flpnl_Spend.Size = new Size(270, 279);
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
            flpnl_Income.Location = new Point(291, 49);
            flpnl_Income.Margin = new Padding(2, 2, 2, 2);
            flpnl_Income.Name = "flpnl_Income";
            flpnl_Income.Size = new Size(268, 279);
            flpnl_Income.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(377, 15);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 10;
            label4.Text = "label4";
            // 
            // AccountBookList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 363);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(flpnl_Income);
            Controls.Add(flpnl_Spend);
            Controls.Add(lb_Date);
            Controls.Add(btn_Add);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Close);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2, 2, 2, 2);
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
        private Label label4;
    }
}