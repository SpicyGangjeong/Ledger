using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Response;
using Microsoft.VisualBasic.Logging;

namespace Ledger
{
    public partial class FormMain : Form
    {
        public static string strConn = "Server=ledgerdb.ctsyekhyqkwe.ap-northeast-2.rds.amazonaws.com;Port=3306;Database=ledgerdb;Uid=root;Pwd=rootpass";
        public static MySqlConnection conn = null;

        private const string basePath = "https://ledger-cc069-default-rtdb.firebaseio.com";
        private const string baseSecret = "4AT6nTl88LXsImHpFGRXEn3LKcFkgNTyZCAJpNVW";
        public FirebaseClient client;

        Login login;

        //검색 폼 변수 선언
        private Panel msPanel;

        public FormMain(Login login)
        {
            this.login = login;

            conn = new MySqlConnection(strConn);
            conn.Open();

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = baseSecret,
                BasePath = basePath
            };
            client = new FirebaseClient(config);

            InitializeComponent();
            LoadLatestSpend();
            //Fireb.InitUserNode(client);
        }

        #region LoadLatestSpend
        
        // 메인 폼 동적 패널 생성 함수
        public void LoadLatestSpend()
        {
            // 간단한 로그인 정보
            LoginedName.Text = login.logined_user + "(" + login.logined_id + ")님";

            // 소비 내역이 있는지 확인
            String sql = "select count(*) from tb_spend where f_id='" + login.logined_id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            Object data = cmd.ExecuteScalar();
            int spendCount = Convert.ToInt32(data);

            if (spendCount > 0)
            {
                // 최근 지출 알림판
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.Fixed3D;
                panel.BackColor = Color.White;
                panel.Size = new Size(ContentLayout.Width - 5, 120);
                ContentLayout.Controls.Add(panel);

                Label spendTitle = new Label(); // 제목
                spendTitle.Text = "최근 지출 알림";
                spendTitle.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
                spendTitle.Size = new Size(panel.Width - 5, 40);
                spendTitle.Padding = new Padding(15, 8, 0, 2);
                panel.Controls.Add(spendTitle);

                Label lineText1 = new Label(); // 구분선
                lineText1.Text = "-------------------------------------------------------------------------------";
                lineText1.ForeColor = Color.Gray;
                lineText1.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                lineText1.Size = new Size(panel.Width - 5, 30);
                lineText1.Padding = new Padding(0, 5, 0, 2);
                lineText1.Location = new Point(10, 30);
                panel.Controls.Add(lineText1);


                String sql1 = $"select f_name, f_date, f_money, f_cate from tb_spend where f_id = '{Login.logined_id}' order by f_date desc limit 1";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader data1 = cmd1.ExecuteReader();
                data1.Read();

                Label date = new Label(); // 지출 날짜
                Label datecontent = new Label(); // 지출 제목, 소비 분야, 지출 금액

                String bufferdate = data1["f_date"].ToString(); // 지출 날짜용 레이블
                DateTime datetext = DateTime.Parse(bufferdate);
                date.Text = "일시 : " + datetext.Date.ToString("yyyy-MM-dd");
                date.Font = new Font("맑은 고딕", 11);
                date.Size = new Size(panel.Width - 5, 30);
                date.Padding = new Padding(5, 5, 0, 2);
                date.Location = new Point(10, 55);
                panel.Controls.Add(date);

                // 지출 제목, 소비 분야, 지출 금액용 레이블
                datecontent.Text = "제목 : " + data1["f_name"].ToString() + " / 소비 분야 : " +
                    data1["f_cate"].ToString() + " / 금액 : " + string.Format("{0:n0}", data1["f_money"]) + "원";
                datecontent.Font = new Font("맑은 고딕", 11);
                datecontent.Size = new Size(panel.Width - 5, 30);
                datecontent.Padding = new Padding(5, 5, 0, 0);
                datecontent.Location = new Point(10, 80);
                panel.Controls.Add(datecontent);

                data1.Close();
            }

            // 파이어베이스 연동
            FirebaseResponse response = client.Get("UPPER");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(response.Body))
                {
                    // 지출 챌린지 정보를 파이어베이스에서 가져옴
                    FirebaseResponse responseStart = client.Get("test_id/UPPER/START");
                    FirebaseResponse responseEnd = client.Get("test_id/UPPER/END");
                    FirebaseResponse responseMoney = client.Get("test_id/UPPER/MONEY");

                    if (responseStart.StatusCode == System.Net.HttpStatusCode.OK &&
                        responseEnd.StatusCode == System.Net.HttpStatusCode.OK &&
                        responseMoney.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string startDate = responseStart.ResultAs<String>();
                        string endDate = responseEnd.ResultAs<String>();

                        if (startDate != null && endDate != null)
                        {
                            // 지출 챌린지 현황 알림판
                            Panel upper_panel = new Panel();
                            upper_panel.BorderStyle = BorderStyle.Fixed3D;
                            upper_panel.BackColor = Color.White;
                            upper_panel.Size = new Size(ContentLayout.Width - 5, 150);
                            ContentLayout.Controls.Add(upper_panel);

                            DateTime startDay = DateTime.Parse(startDate);
                            DateTime endday = DateTime.Parse(endDate);
                            DateTime today = DateTime.Today;
                            TimeSpan total_day = endday.Date - startDay.Date;
                            TimeSpan primary_day = today.Date - startDay.Date;

                            if (responseMoney != null)
                            {
                                int money = responseMoney.ResultAs<int>();

                                Label upperTitle = new Label(); // 제목
                                upperTitle.Text = "현재 " + String.Format("{0:n0}", money) +
                                    "원 지출 챌린지 진행중!";
                                upperTitle.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
                                upperTitle.ForeColor = Color.IndianRed;
                                upperTitle.Size = new Size(upper_panel.Width - 5, 40);
                                upperTitle.Padding = new Padding(15, 8, 0, 2);
                                upper_panel.Controls.Add(upperTitle);
                            }

                            Label lineText2 = new Label(); // 구분선
                            lineText2.Text = "-------------------------------------------------------------------------------";
                            lineText2.ForeColor = Color.Gray;
                            lineText2.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                            lineText2.Size = new Size(upper_panel.Width - 5, 30);
                            lineText2.Padding = new Padding(0, 5, 0, 2);
                            lineText2.Location = new Point(10, 30);
                            upper_panel.Controls.Add(lineText2);

                            Label upperTime = new Label(); // 챌린지 진행 기간
                            upperTime.Text = "기간 : " + startDate + " ~ " + endDate + " (총 "
                                + total_day.Days.ToString() + "일)";
                            upperTime.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                            upperTime.Size = new Size(upper_panel.Width - 5, 30);
                            upperTime.Padding = new Padding(9, 5, 0, 2);
                            upperTime.Location = new Point(10, 55);
                            upper_panel.Controls.Add(upperTime);

                            Label primaryday = new Label(); // 며칠째인지 표시
                            primaryday.Text = "TODAY - " + primary_day.Days.ToString() + "일차";
                            primaryday.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                            primaryday.ForeColor = Color.DarkGray;
                            primaryday.Size = new Size(upper_panel.Width - 5, 30);
                            primaryday.Padding = new Padding(9, 5, 0, 2);
                            primaryday.Location = new Point(10, 80);
                            upper_panel.Controls.Add(primaryday);


                            String sql2 = "select sum(f_money) from tb_spend where f_date between '" + startDate
                                + "' and '" + today + $"' and f_id = '{Login.logined_id}' group by f_date order by f_date";
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            Object rsm = cmd2.ExecuteScalar();

                            if (rsm != null)
                            {
                                int rsmText = Convert.ToInt32(rsm);
                                Label recentSpend = new Label(); // 현재까지의 소비 금액 표시
                                recentSpend.Text = "현재까지 사용한 금액 : " + String.Format("{0:n0}", rsmText) + "원";
                                recentSpend.Font = new Font("맑은 고딕", 10, FontStyle.Bold | FontStyle.Underline);
                                recentSpend.ForeColor = Color.Red;
                                recentSpend.Size = new Size(upper_panel.Width - 5, 30);
                                recentSpend.Padding = new Padding(9, 5, 0, 2);
                                recentSpend.Location = new Point(10, 105);
                                upper_panel.Controls.Add(recentSpend);
                            }
                            else
                            {
                                Label recentSpend = new Label(); // 현재까지의 소비 금액 표시
                                recentSpend.Text = "현재까지 어떠한 돈도 사용하지 않았어요! 대단해요!";
                                recentSpend.Font = new Font("맑은 고딕", 10, FontStyle.Bold | FontStyle.Underline);
                                recentSpend.ForeColor = Color.Blue;
                                recentSpend.Size = new Size(upper_panel.Width - 5, 30);
                                recentSpend.Padding = new Padding(9, 5, 0, 2);
                                recentSpend.Location = new Point(10, 105);
                                upper_panel.Controls.Add(recentSpend);
                            }
                        }
                    }
                }
            }

            if (spendCount > 0)
            {
                // 가장 많이 소비한 분야 알림판
                Panel MostCate = new Panel();
                MostCate.BorderStyle = BorderStyle.Fixed3D;
                MostCate.BackColor = Color.White;
                MostCate.Size = new Size(ContentLayout.Width - 5, 55);
                ContentLayout.Controls.Add(MostCate);

                // 가장 많이 소비한 분야를 뽑아내기 위한 코드
                DateTime today = DateTime.Today;
                String sql3 = $"SELECT * FROM ledgerdb.view_MonthSpendCount where f_id = '{Login.logined_id}'";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                MySqlDataReader data3 = cmd3.ExecuteReader();

                List<String> f_cateList = new List<String>();

                while (data3.Read())
                {
                    String f_cate = data3["f_cate"].ToString();
                    f_cateList.Add(f_cate);
                }

                Dictionary<string, int> cateCount = new Dictionary<string, int>
                {
                    { "mealCount", 0 }, { "dessertCount", 0 }, { "leisureCount", 0 },
                    { "shelterCount", 0 }, { "beautyCount", 0 }, { "savingCount", 0 },
                    { "trafficCount", 0 }, { "stockCount", 0 }, { "medicalCount", 0 },
                    { "gameCount", 0 }, { "etcCount", 0 }
                };
                foreach (var category in f_cateList)
                {
                    switch (category.ToString())
                    {
                        case "식사":
                            cateCount["mealCount"]++;
                            break;
                        case "간식":
                            cateCount["dessertCount"]++;
                            break;
                        case "여가":
                            cateCount["leisureCount"]++;
                            break;
                        case "주거":
                            cateCount["shelterCount"]++;
                            break;
                        case "미용":
                            cateCount["beautyCount"]++;
                            break;
                        case "저축":
                            cateCount["savingCount"]++;
                            break;
                        case "교통":
                            cateCount["trafficCount"]++;
                            break;
                        case "주식":
                            cateCount["stockCount"]++;
                            break;
                        case "의료":
                            cateCount["medicalCount"]++;
                            break;
                        case "게임":
                            cateCount["gameCount"]++;
                            break;
                        case "기타":
                            cateCount["etcCount"]++;
                            break;
                    }
                }
                int maxCate = cateCount.Values.Max();
                String maxCateName = cateCount.FirstOrDefault(x => x.Value == maxCate).Key;

                switch (maxCateName)
                {
                    case "mealCount":
                        maxCateName = "식사";
                        break;
                    case "dessertCount":
                        maxCateName = "간식";
                        break;
                    case "leisureCount":
                        maxCateName = "여가";
                        break;
                    case "shelterCount":
                        maxCateName = "주거";
                        break;
                    case "beautyCount":
                        maxCateName = "미용";
                        break;
                    case "savingCount":
                        maxCateName = "저축";
                        break;
                    case "trafficCount":
                        maxCateName = "교통";
                        break;
                    case "stockCount":
                        maxCateName = "주식";
                        break;
                    case "medicalCount":
                        maxCateName = "의료";
                        break;
                    case "gameCount":
                        maxCateName = "게임";
                        break;
                    case "etcCount":
                        maxCateName = "기타";
                        break;
                }
                data3.Close();

                // 출력 부분
                RichTextBox mcTitle = new RichTextBox();
                mcTitle.Size = new Size(MostCate.Width, MostCate.Height);
                mcTitle.BackColor = Color.White;
                mcTitle.Font = new Font("맑은 고딕", 13, FontStyle.Bold);
                mcTitle.ReadOnly = true;
                mcTitle.SelectionColor = Color.Black;
                mcTitle.AppendText("  최근 한달간 가장 많이 소비한 분야는 ");
                mcTitle.SelectionColor = Color.DarkGreen;
                mcTitle.AppendText(maxCateName);
                mcTitle.SelectionColor = Color.Black;
                mcTitle.AppendText("입니다.");
                MostCate.Controls.Add(mcTitle);
            }
        }

        #endregion 

        #region btnFormClick
        private void btnCalendar_Click(object sender, EventArgs e)
        {
            // 캘린터 폼 열기
            if (isthisOpenedForm("CalendarMain")) return;
            CalendarMain CalendarMain = new CalendarMain(this);
            CalendarMain.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            // 트리 폼 열기
            if (isthisOpenedForm("TreeMain")) return;
            TreeMain tree = new TreeMain(this);
            tree.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            // 그래프 폼 열기
            if (isthisOpenedForm("Analysis")) return;
            Analysis anly = new Analysis(this);
            anly.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //패널 안에 폼 추가
            msPanel = new Panel();
            msPanel.Size = new Size(this.Width, this.Height);

            Search searchForm = new Search(this);
            searchForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //캘린더 폼 내의 모든 컨트롤을 숨김
            foreach (Control control in this.Controls)
            {
                control.Hide();
            }
            searchForm.TopLevel = false;
            msPanel.Controls.Add(searchForm);
            this.Controls.Add(msPanel);
            searchForm.Show();
            searchForm.Dock = DockStyle.Fill;
            this.Text = searchForm.Text;
        }

        private void btnAchievement_Click(object sender, EventArgs e)
        {
            //패널 안에 폼 추가
            msPanel = new Panel();
            msPanel.Size = new Size(this.Width, this.Height);

            Achievement achForm = new Achievement(this);
            achForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //캘린더 폼 내의 모든 컨트롤을 숨김
            foreach (Control control in this.Controls)
            {
                control.Hide();
            }
            achForm.TopLevel = false;
            msPanel.Controls.Add(achForm);
            this.Controls.Add(msPanel);
            achForm.Show();
            achForm.Dock = DockStyle.Fill;
            this.Text = achForm.Text;
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            // 업적 폼 열기
            MessageBox.Show("개발중입니다.", "경고!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
        }

        private void btnChallange_Click(object sender, EventArgs e)
        {
            if (isthisOpenedForm("UpperLimit")) return;
            UpperLimit upperLimit = new UpperLimit(this);
            upperLimit.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }
        private bool isthisOpenedForm(string formname)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                // 폼 중복 열기 방지
                if (openForm.Name == formname) // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {   // 폼이 active 인지 검사
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X, this.Location.Y);
                    }
                    openForm.Show();
                    this.Hide();
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void FormMain_Activated(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (msPanel != null && Controls.Contains(msPanel))
            {

                foreach (Control control in this.Controls)
                {
                    control.Show();
                }
                // Remove the pnl_1 panel from the form's Controls collection
                Controls.Remove(msPanel);
                // Optionally, you can also dispose of the pnl_1 panel
                msPanel.Dispose();
                this.Text = "HOME";
                e.Cancel = true;
            }

            // 로그인 중일때 폼을 닫기를 눌러도 로그아웃을 할 수 있게 구현
            if (login.islogined == true)
            {
                DialogResult result = MessageBox.Show("로그인된 상태입니다. 로그아웃 하시겠습니까?", "경고!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    MessageBox.Show("성공적으로 로그아웃 되었습니다.");

                    Login.islogined = false;
                    Login.logined_user = "";
                    Login.logined_id = "";

                    this.Dispose();
                    login.Show();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        // 로그아웃
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                MessageBox.Show("성공적으로 로그아웃 되었습니다.");

                Login.islogined = false;
                Login.logined_user = "";
                Login.logined_id = "";

                this.Dispose();
                login.Show();
            }
        }

        private void btnMyinfo_Click(object sender, EventArgs e)
        {
            // 내정보 폼 열기
            MyInfo myinfo = new MyInfo(this, login);
            myinfo.ShowDialog();
        }

        
    }
}
