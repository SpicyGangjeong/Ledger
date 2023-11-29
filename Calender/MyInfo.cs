using Microsoft.VisualBasic.Logging;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Ledger
{
    public partial class MyInfo : Form
    {
        public static string strConn = "Server=ledgerdb.ctsyekhyqkwe.ap-northeast-2.rds.amazonaws.com;Port=3306;Database=ledgerdb;Uid=root;Pwd=rootpass";
        public static MySqlConnection conn = null;

        Login login;
        FormMain formMain;

        public MyInfo(FormMain formMain, Login login)
        {
            this.formMain = formMain;
            this.login = login;

            conn = new MySqlConnection(strConn);
            conn.Open();

            InitializeComponent();
            loadInfo();
        }

        public void loadInfo()
        {
            String sql1 = "select * from tb_user where f_id='" + login.logined_id + "'";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            MySqlDataReader data1 = cmd1.ExecuteReader();

            if (data1.Read())
            {
                infoName.Text = data1["f_name"].ToString();
                infoId.Text = data1["f_id"].ToString();
                infoPhone.Text = data1["f_tel"].ToString();
                infoEmail.Text = data1["f_email"].ToString();

                DateTime signDate = (DateTime)data1["f_join"];
                infoSignDate.Text = signDate.ToString("yy-MM-dd");
            }

            data1.Close();
        }

        private void deleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show("계정을 탈퇴하면 계정 내 저장된 정보가 모두 삭제되며\n" +
                "복구할 수 없습니다. 그래도 진행하시겠습니까?", "회원탈퇴",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                String sql2 = "delete from tb_user where f_id='" + login.logined_id + "'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("성공적으로 회원탈퇴 되었습니다.\n" +
                    "지금까지 사용해주셔서 감사합니다. " + login.logined_user + "님");

                cmd2.Dispose();

                login.islogined = false;
                login.logined_user = "";
                login.logined_id = "";

                conn.Close();
                this.Dispose();
                formMain.Dispose();
                login.Show();
            }
        }

        private void btnModifyinfo_Click(object sender, EventArgs e)
        {
            if (infoPw.Text == "")
            {
                String sql3 = "update tb_user set f_tel='" + infoPhone.Text +
                    "', f_email='" + infoEmail.Text + "' where f_id='" +
                    login.logined_id + "'";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("성공적으로 변경되었습니다.");

                cmd3.Dispose();

            } else
            {
                String sql3 = "update tb_user set f_tel='" + infoPhone.Text +
                    "', f_email='" + infoEmail.Text + "', f_pw='" + infoPw.Text +
                    "' where f_id='" + login.logined_id + "'";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("성공적으로 변경되었습니다.");

                infoPw.Text = "";

                cmd3.Dispose();
            }
        }
    }
}
