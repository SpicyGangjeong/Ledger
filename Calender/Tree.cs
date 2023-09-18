﻿using Calender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ledger
{
    public partial class TreeMain : Form
    {
        public TreeMain() // 처음 FormMain에서 생성될 때 사용됨
        {
            InitializeComponent();
        }

        public TreeMain(CalenderMain calenderMain, int year = 2023, int month = 1) // 처음 Calender 에서 열렸을 때 사용됨
        {
            InitializeComponent();
        }

        private void btnSwitchCalender_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                // 폼 중복 열기 방지
                if (openForm.Name == "CalenderMain") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {   // 폼이 active 인지 검사
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X, this.Location.Y);
                    }
                    openForm.Activate();
                    openForm.Show();
                    this.Hide();
                    return;
                }
            }
            CalenderMain calenderMain = new CalenderMain(this); // 트리뷰 폼을 만들고 기존의 값들을 넘겨줌.
            calenderMain.Show();
            this.Hide();
        }

        private void btnSwitchTree_Click(object sender, EventArgs e)
        {

        }
    }
}
