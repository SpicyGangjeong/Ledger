using Calender;
using Microsoft.VisualBasic;
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
    public partial class TreeMain : Form
    {

        public static string strConn = "Server=localhost;Port=3306;Database=jspdb;Uid=jspuser;Pwd=jsppass";
        public static MySqlConnection conn = null;

        FormMain formMain;
        public TreeMain(FormMain formMain) // 처음 FormMain에서 생성될 때 사용됨
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        public TreeMain(CalenderMain calenderMain, FormMain formMain) // 처음 Calender 에서 열렸을 때 사용됨
        {
            InitializeComponent();
            this.formMain = formMain;
        }
        public void InitializeTree()
        {
            TreeNode root = new TreeNode();
            string sql = "select distinct substr(f_date, 1, 4)from tb_spend";
            MySqlCommand cmd = new MySqlCommand(sql, TreeMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
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
            CalenderMain calenderMain = new CalenderMain(this, formMain); // 트리뷰 폼을 만들고 기존의 값들을 넘겨줌.
            calenderMain.Show();
            this.Hide();
        }

        private void btnSwitchTree_Click(object sender, EventArgs e)
        {

        }

        private void TreeMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMain.Dispose();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void TreeMain_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(strConn);
            conn.Open();
            MonthPicker.SelectedIndex = 2;
            InitializeTree();
        }
    }
}
