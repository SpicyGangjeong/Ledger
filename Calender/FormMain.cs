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
        private static FirebaseClient client;

        public FormMain()
        {
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
        }

        public void LoadLatestSpend()
        {
            String sql = "select count(*) from tb_spend";
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


                String sql1 = "select f_name, f_date, f_money, f_cate from tb_spend order by f_date desc limit 1";
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

            FirebaseResponse response = client.Get("UPPER");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(response.Body))
                {
                    // 지출 챌린지 정보를 가져오기 위한 코드
                    FirebaseResponse responseStart = client.Get("UPPER/START");
                    FirebaseResponse responseEnd = client.Get("UPPER/END");
                    FirebaseResponse responseMoney = client.Get("UPPER/MONEY");

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
                                + "' and '" + today + "' group by f_date order by f_date";
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
                String sql3 = "select f_cate from tb_spend where f_date <= '" + today.ToString() +
                    "' and f_date >= date_sub('" + today.ToString() + "', interval 30 day)";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                MySqlDataReader data3 = cmd3.ExecuteReader();

                List<String> f_cateList = new List<String>();

                while (data3.Read())
                {
                    String f_cate = data3["f_cate"].ToString();
                    f_cateList.Add(f_cate);
                }

                Dictionary<string, int> cateCount = new Dictionary<string, int>();

                cateCount["mealCount"] = 0; cateCount["dessertCount"] = 0;
                cateCount["leisureCount"] = 0; cateCount["shelterCount"] = 0;
                cateCount["beautyCount"] = 0; cateCount["savingCount"] = 0;
                cateCount["trafficCount"] = 0; cateCount["stockCount"] = 0;
                cateCount["medicalCount"] = 0; cateCount["gameCount"] = 0;
                cateCount["etcCount"] = 0;
                
                for (int i=0; i<f_cateList.Count; i++)
                {
                    if (f_cateList[i].ToString() == "식사")
                        cateCount["mealCount"]++;
                    else if (f_cateList[i].ToString() == "간식")
                        cateCount["dessertCount"]++;
                    else if (f_cateList[i].ToString() == "여가")
                        cateCount["leisureCount"]++;
                    else if (f_cateList[i].ToString() == "주거")
                        cateCount["shelterCount"]++;
                    else if (f_cateList[i].ToString() == "미용")
                        cateCount["beautyCount"]++;
                    else if (f_cateList[i].ToString() == "저축")
                        cateCount["savingCount"]++;
                    else if (f_cateList[i].ToString() == "교통")
                        cateCount["trafficCount"]++;
                    else if (f_cateList[i].ToString() == "주식")
                        cateCount["stockCount"]++;
                    else if (f_cateList[i].ToString() == "의료")
                        cateCount["medicalCount"]++;
                    else if (f_cateList[i].ToString() == "게임")
                        cateCount["gameCount"]++;
                    else if (f_cateList[i].ToString() == "기타")
                        cateCount["etcCount"]++;
                }

                int maxCate = cateCount.Values.Max();
                String maxCateName = cateCount.FirstOrDefault(x => x.Value == maxCate).Key;

                if (maxCateName == "mealCount")
                    maxCateName = "식사";
                else if (maxCateName == "dessertCount")
                    maxCateName = "간식";
                else if (maxCateName == "leisureCount")
                    maxCateName = "여가";
                else if (maxCateName == "shelterCount")
                    maxCateName = "주거";
                else if (maxCateName == "beautyCount")
                    maxCateName = "미용";
                else if (maxCateName == "savingCount")
                    maxCateName = "저축";
                else if (maxCateName == "trafficCount")
                    maxCateName = "교통";
                else if (maxCateName == "stockCount")
                    maxCateName = "주식";
                else if (maxCateName == "medicalCount")
                    maxCateName = "의료";
                else if (maxCateName == "gameCount")
                    maxCateName = "게임";
                else if (maxCateName == "etcCount")
                    maxCateName = "기타";

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

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            CalenderMain calenderMain = new CalenderMain(this);
            calenderMain.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            TreeMain tree = new TreeMain(this);
            tree.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            Analysis anly = new Analysis(this);
            anly.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("개발중입니다.", "경고!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
        }

        private void btnSpendanal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("개발중입니다.", "경고!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
            login.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnChallange_Click(object sender, EventArgs e)
        {
            UpperLimit upperLimit = new UpperLimit(this);
            upperLimit.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }
    }
}
