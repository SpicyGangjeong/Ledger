using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
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
    public partial class SignUp : Form
    {
        public static string strConn = "Server=ledgerdb.ctsyekhyqkwe.ap-northeast-2.rds.amazonaws.com;Port=3306;Database=ledgerdb;Uid=root;Pwd=rootpass";
        public static MySqlConnection conn = null;

        private const string basePath = "https://ledger-cc069-default-rtdb.firebaseio.com";
        private const string baseSecret = "4AT6nTl88LXsImHpFGRXEn3LKcFkgNTyZCAJpNVW";
        public FirebaseClient client;

        Boolean idChecker; // 아이디 중복 체크용 플래그 변수
        Login login;

        public SignUp(Login login)
        {
            idChecker = false;
            this.login = login;

            conn = new MySqlConnection(strConn);
            conn.Open();

            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig {
                AuthSecret = baseSecret,
                BasePath = basePath
            };
            client = new FirebaseClient(config);
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            if (suName.Text != "" && suId.Text != "" && suPw.Text != ""
                && suPwRe.Text != "" && suPhone.Text != "" && suEmail.Text != "")
            {
                if (idChecker == true)
                {
                    if (suPw.Text == suPwRe.Text)
                    {
                        DateTime today = DateTime.Today;
                        String sql1 = "insert into tb_user values ('" + suName.Text + "', '" +
                            suId.Text + "', '" + suPw.Text + "', '" + suPhone.Text + "', '" +
                            suEmail.Text + "', '" + today.ToString() + "')";
                        MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                        
                        try
                        {
                            if (cmd1.ExecuteNonQuery() == 1)
                            {
                                //로딩창 생성
                                Panel msPanel = new Panel();
                                msPanel.Size = new Size(this.Width, this.Height);

                                LoadingScreen searchForm = new LoadingScreen();
                                searchForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                                searchForm.TopLevel = false;
                                msPanel.Controls.Add(searchForm);
                                this.Controls.Add(msPanel);
                                searchForm.Show();
                                searchForm.Dock = DockStyle.Fill;
                                msPanel.BringToFront();

                                await Fireb.InitUserNode(client, suId.Text);

                                MessageBox.Show("가입을 축하합니다 " + suName.Text + "님!", "회원가입 완료",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("예기치 못한 문제로 가입에 실패했습니다.", "회원가입 실패",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("비밀번호와 비밀번호 재확인에 입력된 값이 서로 다릅니다.", "경고!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        suPwRe.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("아이디가 중복되는지 확인해주세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (suName.Text == "")
                {
                    MessageBox.Show("성명을 입력하세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (suId.Text == "")
                {
                    MessageBox.Show("사용할 아이디를 입력하세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (suPw.Text == "")
                {
                    MessageBox.Show("사용할 비밀번호를 입력하세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (suPwRe.Text == "")
                {
                    MessageBox.Show("사용할 비밀번호와 동일하게 입력하세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (suPhone.Text == "")
                {
                    MessageBox.Show("사용할 전화번호를 입력하세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (suEmail.Text == "")
                {
                    MessageBox.Show("사용할 이메일을 입력하세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void ShowLoadingScreen() {
            
        }
        private void checkDuple_Click(object sender, EventArgs e)
        {
            if (suId.Text != "")
            {
                String sql2 = "select f_id from tb_user where f_id='" + suId.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                Object rsm = cmd2.ExecuteScalar();

                if (rsm == null)
                {
                    idChecker = true;
                    suId.Enabled = false;
                    MessageBox.Show(suId.Text + "는 사용 가능한 아이디입니다.", "아이디 중복 확인",
                        MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(suId.Text + "는 사용 불가능한 아이디입니다.", "아이디 중복 확인",
                        MessageBoxButtons.OK);
                    suId.Focus();
                }
            }
            else
            {
                MessageBox.Show("먼저 아이디를 입력하세요.", "경고!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                suId.Focus();
            }
        }
    }
}
