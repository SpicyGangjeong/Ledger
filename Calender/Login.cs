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
        public bool islogined = false;
        public String logined_user = "";
        public String logined_id = "";

        public Login()
        {

            conn = new MySqlConnection(strConn);
            conn.Open();

            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // 회원가입 폼 열기
            SignUp signup = new SignUp(this);
            signup.ShowDialog();
        }

        private void btnSearchPw_Click(object sender, EventArgs e)
        {
            // 아이디 / 비밀번호 찾기 폼 열기
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
                // 로그인 정보 일치시, 로그인 정보에 해당 로그인 정보를 저장
                islogined = true;
                logined_user = data["f_name"].ToString();
                logined_id = data["f_id"].ToString();

                MessageBox.Show(logined_user + "님, 환영합니다.");
                userId.Text = "";
                userPw.Text = "";

                FormMain formMain = new FormMain(this);
                formMain.Show();
                this.Hide();
            }
            else
            {
                // 로그인 정보 불일치 시, 로그인 정보를 다시 입력할 수 있게 함
                MessageBox.Show("아이디가 존재하지 않거나 비밀번호가 다릅니다.", "경고!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userId.Text = "";
                userPw.Text = "";
            }

            data.Close();
        }

        // 엔터키로 로그인을 할 수 있게끔 설정
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
