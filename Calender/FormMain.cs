using Calender;
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
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSwitchTree_Click(object sender, EventArgs e)
        {
            TreeMain tree = new TreeMain();
            tree.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnSwitchCalender_Click(object sender, EventArgs e)
        {
            CalenderMain calenderMain = new CalenderMain();
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
