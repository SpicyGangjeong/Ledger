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
    public partial class SeekAccount : Form
    {
        public static string strConn = "Server=ledgerdb.ctsyekhyqkwe.ap-northeast-2.rds.amazonaws.com;Port=3306;Database=ledgerdb;Uid=root;Pwd=rootpass";
        public static MySqlConnection conn = null;

        Login login;

        public SeekAccount(Login login)
        {
            this.login = login;

            conn = new MySqlConnection(strConn);
            conn.Open();

            InitializeComponent();
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            if (tbSearchIdName.Text != "" && tbSearchIdEmail.Text != "")
            {
                String sql1 = "select f_id from tb_user where f_name='" + tbSearchIdName.Text +
                "'and f_email='" + tbSearchIdEmail.Text + "'";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader data1 = cmd1.ExecuteReader();

                List<String> SeekIds = new List<string>();

                while (data1.Read())
                {
                    String seekid = data1["f_id"].ToString();
                    SeekIds.Add(seekid);
                }

                if (SeekIds.Count > 0)
                {
                    SearchIdResult.Text = "해당 성명과 이메일로 가입된 아이디는 ";
                    foreach (var id in SeekIds)
                    {
                        SearchIdResult.Text += id + " ";
                    }
                    SearchIdResult.Text += "입니다.";
                    tbSearchIdName.Text = "";
                    tbSearchIdEmail.Text = "";
                }
                else
                {
                    SearchIdResult.Text = "해당 성명과 이메일로 가입된 아이디가 없습니다.";
                    tbSearchIdName.Text = "";
                    tbSearchIdEmail.Text = "";
                }

                data1.Close();

            }
            else
            {
                MessageBox.Show("성명이나 이메일을 입력하세요.", "경고!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearchPw_Click(object sender, EventArgs e)
        {
            if (tbSearchPwName.Text != "" && tbSearchPwEmail.Text != ""
                && tbSearchPwId.Text != "")
            {
                String sql2 = "select f_pw from tb_user where f_name='" + tbSearchPwName.Text +
                "' and f_email='" + tbSearchPwEmail.Text + "' and f_id='" + tbSearchPwId.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader data2 = cmd2.ExecuteReader();

                if (data2.Read())
                {
                    SearchPwResult.Text = tbSearchPwId.Text + "의 비밀번호는 " + data2["f_pw"].ToString()
                        + "입니다.";
                    tbSearchPwName.Text = "";
                    tbSearchPwEmail.Text = "";
                    tbSearchPwId.Text = "";

                }
                else
                {
                    SearchPwResult.Text = "작성한 아이디가 존재하지 않거나 입력된 내용이 잘못되었습니다.";
                    tbSearchPwName.Text = "";
                    tbSearchPwEmail.Text = "";
                    tbSearchPwId.Text = "";
                }

                data2.Close();


            }
            else
            {
                MessageBox.Show("성명이나 이메일, 아이디를 입력하세요.", "경고!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = tabControl1.SelectedIndex;

            switch (selectIndex)
            {
                case 0:
                    tbSearchIdName.Text = "";
                    tbSearchIdEmail.Text = "";
                    SearchIdResult.Text = "성명과 사용했던 이메일을 입력하세요.";
                    break;
                case 1:
                    tbSearchPwName.Text = "";
                    tbSearchPwEmail.Text = "";
                    tbSearchPwId.Text = "";
                    SearchPwResult.Text = "성명과 사용했던 이메일과 아이디를 입력하세요.";
                    break;
            }
        }
    }
}
