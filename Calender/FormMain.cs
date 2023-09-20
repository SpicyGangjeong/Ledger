﻿using Calender;
using MySqlConnector;
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
    public partial class FormMain : Form
    {

        public static string strConn = "Server=localhost;Port=3306;Database=jspdb;Uid=jspuser;Pwd=jsppass";
        public static MySqlConnection conn = null;
        public FormMain()
        {
            InitializeComponent();
            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        private void btnSwitchTree_Click(object sender, EventArgs e)
        {
            TreeMain tree = new TreeMain(this);
            tree.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnSwitchCalender_Click(object sender, EventArgs e)
        {
            CalenderMain calenderMain = new CalenderMain(this);
            calenderMain.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
