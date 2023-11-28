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
    public partial class Login : Form
    {
        // 데이터베이스 연동
        public static string strConn = "Server=ledgerdb.ctsyekhyqkwe.ap-northeast-2.rds.amazonaws.com;Port=3306;Database=ledgerdb;Uid=root;Pwd=rootpass";
        public static MySqlConnection conn = null;

        // 로그인 확인 및 정보
        public static bool islogined = false;
        public static String logined_user = "";
        public static String logined_id = "";

        public Login()
        {

            conn = new MySqlConnection(strConn);
            conn.Open();

            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp(this);
            signup.ShowDialog();
        }

        private void btnSearchPw_Click(object sender, EventArgs e)
        {
            SeekAccount signup = new SeekAccount(this);
            signup.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String sql = "select * from tb_user where f_id='" + userId.Text
                + "' and f_pw='" + userPw.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader data = cmd.ExecuteReader();

            if (data.Read())
            {
                Login.islogined = true;
                Login.logined_user = data["f_name"].ToString();
                Login.logined_id = data["f_id"].ToString();

                MessageBox.Show(logined_user + "님, 환영합니다.");
                userId.Text = "";
                userPw.Text = "";

                

                FormMain formMain = new FormMain(this);
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("아이디가 존재하지 않거나 비밀번호가 다릅니다.", "경고!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userId.Text = "";
                userPw.Text = "";
            }

            data.Close();
        }

        private void userPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void userId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
