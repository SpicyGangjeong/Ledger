using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Ledger.Properties;
using MySqlConnector;
using ScottPlot.Drawing.Colormaps;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Ledger
{
    public partial class UpperLimit : Form
    {
        FormMain formMain;
        private const string basePath = "https://ledger-cc069-default-rtdb.firebaseio.com";
        private const string baseSecret = "4AT6nTl88LXsImHpFGRXEn3LKcFkgNTyZCAJpNVW";
        private static FirebaseClient _client;

        public UpperLimit(FormMain formMain)
        {
            this.formMain = formMain;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = baseSecret,
                BasePath = basePath
            };
            _client = new FirebaseClient(config);

            InitializeComponent();
            lbYearTop.Text = DateTime.Now.Year.ToString();
        }

        private void AddDataToFirebase(FirebaseClient client)
        {
            try
            {
                string str_end = tbYear.Text + "-" + tbMonth.Text + "-" + tbDay.Text;  //입력받은 값을 문자열로 이음
                DateTime endday = DateTime.Parse(str_end); //이은 문자열을 데이트타임 객체로 변환
                // "UPPER" 노드 아래에 "START," "END," "MONEY" 노드를 만들고 값을 설정합니다.
                FirebaseResponse responseStart = client.Set("UPPER/START", string.Format("{0:yyyy-MM-dd}", DateTime.Today));
                FirebaseResponse responseEnd = client.Set("UPPER/END", string.Format("{0:yyyy-MM-dd}", endday));
                FirebaseResponse responseMoney = client.Set("UPPER/MONEY", tbMoney.Text);

                if (responseStart.StatusCode == System.Net.HttpStatusCode.OK &&
                    responseEnd.StatusCode == System.Net.HttpStatusCode.OK &&
                    responseMoney.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("데이터 추가 성공");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"데이터 추가 실패: {ex.Message}");
            }
        }

        private bool CheckUpperNode(FirebaseClient client)
        {
            try
            {
                FirebaseResponse response = client.Get("UPPER/END");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //비어있으면 안됨.
                    if (string.IsNullOrEmpty(response.Body)) {
                        return false;
                    }
                    LoadChallengeInterface();
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Firebase 연결 실패: {ex.Message}");
            }
            return false;
        }
        private string[] ReadDataFromFirebase(FirebaseClient client)
        {
            
            string[] ret = new string[3];
            try
            {
                FirebaseResponse responseStart = client.Get("UPPER/START");
                FirebaseResponse responseEnd = client.Get("UPPER/END");
                FirebaseResponse responseMoney = client.Get("UPPER/MONEY");

                if (responseStart.StatusCode == System.Net.HttpStatusCode.OK &&
                    responseEnd.StatusCode == System.Net.HttpStatusCode.OK &&
                    responseMoney.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ret[0] = responseStart.ResultAs<string>();
                    ret[1] = responseEnd.ResultAs<string>();
                    ret[2] = responseMoney.ResultAs<string>();
                }
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"데이터 읽기 실패: {ex.Message}");
            }
            return ret;
        }
        private void DropFromFirebase(FirebaseClient client)
        {
            try
            {
                FirebaseResponse responseStart = client.Delete("UPPER");

                if (responseStart.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("데이터 제거 성공");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"데이터 제거 실패: {ex.Message}");
            }
        }

        //챌린지 진행 중의 인터페이스를 로드해옵니다.
        private void LoadChallengeInterface()
        {
            string[] from_base = new string[3];
            /*if (!CheckUpperNode(_client)) {
                return;
            }*/
            from_base = ReadDataFromFirebase(_client);
            string str_start = from_base[0];
            string str_end = from_base[1];
            int init_money = Convert.ToInt32(from_base[2]);


            DateTime startDT = DateTime.Parse(str_start);
            DateTime todayDT = DateTime.Today;
            DateTime endDT = DateTime.Parse(str_end);
            DateTime lastDT = (DateTime.Compare(todayDT, endDT) <= 0 ? todayDT : endDT);
            TimeSpan start_to_end = endDT - startDT;
            TimeSpan start_to_last = lastDT - startDT;
            TimeSpan end_to_today = endDT - todayDT;

            //권장 금액을 담을 배열
            int[] rec_array = new int[start_to_last.Days + 1];
            for(int i = 0; i < rec_array.Length; i++)
            {
                rec_array[i] = 0;
            }
            //그날그날 쓴 금액을 담을 배열
            int[] spend_array = new int[start_to_last.Days + 1];
            for (int i = 0; i < spend_array.Length; i++)
            {
                spend_array[i] = 0;
            }

            string sql = "select sum(f_money), f_date from tb_spend ";
            sql += "where f_date between '" + startDT.ToString() + "' and '";
            sql += lastDT.ToString() + "' group by f_date";

            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();

            //그날그날 쓴 값을 spend_array에 저장
            while (data.Read())
            {
                int _spend = Convert.ToInt32(data["sum(f_money)"]);
                TimeSpan _span = lastDT - DateTime.Parse(data["f_date"].ToString());
                int _ind = start_to_last.Days - _span.Days;

                spend_array[_ind] = _spend; 
            }
            data.Close();
            //권장 금액을 계산하여 rec_array에 저장

            //첫날은 무조건 (초기금액 / 처음일과 종료일 간격 + 1)
            rec_array[0] = init_money / (start_to_end.Days + 1);
            int rec = init_money;
            for (int i = 1; i < rec_array.Length; i++)
            {
                rec -= spend_array[i - 1];
                int _span = start_to_end.Days + 1 - i;
                rec_array[i] = rec / _span;
            }
            //먼저 초기화
            RemoveNestedFlowLayoutPanels();
            //플로우 레이아웃 패널 생성
            FlowLayoutPanel flpnlDate = new FlowLayoutPanel();
            flpnlDate.Dock = DockStyle.Fill;
            flpnlDate.WrapContents = false;
            flpnlDate.AutoScroll = true;
            flpnlDate.BackColor = ColorTranslator.FromHtml("#f2f2f2");

            pnlNoChallenge.Hide(); //지출 챌린지 없음 패널은 숨김
            pnlBottom.Show(); //하단 패널은 보임
            lbText1.Text = "시작일 : " + str_start;
            lbText2.Text = "종료일 : " + str_end;
            lbD_Day.Text = end_to_today.Days.ToString() + "일";
            lbText4.Text = "초기 금액 : " + string.Format("{0:#,###}", init_money) + "원";

            lbText5.Text = "잔여금액 : " + string.Format((rec > 0) ? "{0:#,####}원" : "0원", rec);
            lbText6.Text = "금일 권장액 : " + string.Format((rec_array[rec_array.Length - 1] > 0) ? "{0:#,####}원" : "0원", rec_array[rec_array.Length - 1]);
            pnlCenter.Controls.Add(flpnlDate);

            //패널 추가 
            for (int i = 0; i < start_to_end.Days + 1; i++)
            {
                FlowLayoutPanel fnl = new FlowLayoutPanel();
                fnl.Size = new Size(160, 247);
                flpnlDate.Controls.Add(fnl);
                //날짜 저장
                fnl.Tag = (DateTime)startDT.AddDays(i);

                //요일 레이블
                Label lb = new Label();
                lb.Size = new Size(fnl.Width, 40);
                lb.Text = startDT.AddDays(i).ToString("ddd");
                lb.ForeColor = (lb.Text.Equals("토")) ? Color.Blue : ((lb.Text.Equals("일")) ? Color.Red : Color.Black);
                lb.Font = new Font(lb.Font.Name, 20, FontStyle.Bold);
                lb.TextAlign = ContentAlignment.MiddleCenter;

                //요일 아래의 커다란 패널 추가
                Panel pn = new Panel();
                pn.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                pn.Size = new Size(fnl.Width - 16, 192);
                pn.Margin = new Padding(8, 8, 8, 8);
                pn.Paint += new PaintEventHandler(setBorder);
                pn.Invalidate();

                //날짜 레이블 추가
                Label lb2 = new Label();
                lb2.Size = new Size(pn.Width - 4, 30);
                lb2.Font = new Font(lb2.Font.Name, 14);
                lb2.TextAlign = ContentAlignment.MiddleCenter;
                lb2.Text = startDT.AddDays(i).ToString("MM\\/dd");
                lb2.Location = new Point(pn.Width / 2 - lb2.Width / 2, 2);
                lb2.BackColor = Color.Transparent;

                //경고 또는 양호 아이콘
                if (DateTime.Compare(todayDT, (DateTime)startDT.AddDays(i)) > 0
                    || i < start_to_last.Days)
                {
                    //이미지
                    PictureBox pic = new PictureBox();
                    if (rec_array[i] >= spend_array[i] && rec >= 0)
                    {
                        pic.Image = Properties.Resources.success_icon;
                    }
                    else
                    {
                        pic.Image = Properties.Resources.fail_icon;
                    }
                    pic.Size = new Size(60, 60);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Location = new Point(pn.Width / 2 - pic.Width / 2, 40);
                    pic.BackColor = Color.Transparent;
                    pn.Controls.Add(pic);
                }

                //지출 비용
                if (i < start_to_last.Days + 1)
                {
                    Label lb3 = new Label();
                    lb3.Size = new Size(pn.Width - 4, 27);
                    lb3.Font = new Font(lb3.Font.Name, 13);
                    lb3.TextAlign = ContentAlignment.MiddleRight;
                    lb3.Text = (spend_array[i] == 0) ? "0" : string.Format("{0:-#,####}", spend_array[i]);
                    lb3.ForeColor = Color.Red;
                    lb3.Location = new Point(2, 158);
                    lb3.BackColor = Color.Transparent;

                    pn.Controls.Add(lb3);
                }

                if (i < start_to_last.Days + 1)
                {
                    //권장 금액 아이콘
                    PictureBox pic2 = new PictureBox();
                    pic2.Image = Properties.Resources.recommend_icon;
                    pic2.Size = new Size(25, 25);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Location = new Point(112, 121);
                    pic2.BackColor = Color.Transparent;

                    //권장 금액
                    Label lb4 = new Label();
                    lb4.Size = new Size(pn.Width - 36, 27);
                    lb4.Font = new Font(lb4.Font.Name, 11);
                    lb4.TextAlign = ContentAlignment.MiddleRight;
                    lb4.Text = string.Format((rec_array[i] > 0) ? "{0:#,####}" : "0", rec_array[i]);
                    lb4.Location = new Point(4, 120);
                    lb4.BackColor = Color.Transparent;

                    pn.Controls.Add(pic2);
                    pn.Controls.Add(lb4);
                }

                pn.Controls.Add(lb2);
                fnl.Controls.Add(lb);
                fnl.Controls.Add(pn);

                //이미 지난 날은 회색 처리
                if (i < start_to_last.Days || DateTime.Compare(todayDT, endDT) > 0)
                {
                    Color col = ColorTranslator.FromHtml("#c7c7c7");
                    pn.BackColor = col;
                    foreach (Control con in pn.Controls)
                    {
                        con.BackColor = col;
                    }
                } //남은 날은 하얀색 처리
                else if (i > start_to_last.Days)
                {
                    Color col = ColorTranslator.FromHtml("#ffffff");
                    pn.BackColor = col;
                    foreach (Control con in pn.Controls)
                    {
                        con.BackColor = col;
                        con.ForeColor = ColorTranslator.FromHtml("#a3a3a3");
                    }
                }
            }
            foreach (FlowLayoutPanel fp in flpnlDate.Controls)
            {
                if (fp.Tag.ToString().Equals(todayDT.ToString()))
                {
                    int point = fp.Location.X - (this.Width / 2) + (fp.Width / 2);
                    //MessageBox.Show(point.ToString() + "포인트");
                    if (point < 0)
                    {
                        point = 0;
                    }
                    else if (point > flpnlDate.HorizontalScroll.Maximum - flpnlDate.HorizontalScroll.LargeChange - 1)
                    {
                        point = flpnlDate.HorizontalScroll.Maximum;
                    }
                    flpnlDate.HorizontalScroll.Value = point;
                    break;
                }
            }
            // 지출 챌린지 종료일자를 넘겼을 경우
            if (DateTime.Compare(todayDT, endDT) > 0)
            {
                lbText6.Text = "";
                //lbText5.Text = "";
                btnGiveUp.Text = "챌린지 초기화";
                //만약 잔여금액이 0 이상일 경우 성공
                if (rec >= 0)
                {
                    PictureBox picSuc = new PictureBox();
                    picSuc.Image = Properties.Resources.suc_chall_icon;
                    picSuc.Size = new Size(120, 120);
                    picSuc.SizeMode = PictureBoxSizeMode.Zoom;
                    picSuc.Location = new Point(210, 6);
                    pnlBottom.Controls.Add(picSuc);
                    picSuc.BringToFront();
                }
                else //잔여금액이 0 미만일 경우 실패
                {
                    PictureBox picFail = new PictureBox();
                    picFail.Image = Properties.Resources.fail_chall_icon;
                    picFail.Size = new Size(110, 110);
                    picFail.SizeMode = PictureBoxSizeMode.Zoom;
                    picFail.Location = new Point(215, 11);
                    pnlBottom.Controls.Add(picFail);
                    picFail.BringToFront();
                }

            }
        }
        private void UpperLimit_Load(object sender, EventArgs e)
        {
            if (!CheckUpperNode(_client))
            {
                pnlBottom.Hide();
            }
        }

        private void UpperLimit_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMain.Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //입력란이 전부 작성되어야 함.
            if (String.IsNullOrWhiteSpace(tbYear.Text) || String.IsNullOrWhiteSpace(tbMonth.Text) ||
                String.IsNullOrWhiteSpace(tbDay.Text) || String.IsNullOrWhiteSpace(tbMoney.Text))
            {
                MessageBox.Show("비어있는 입력칸이 존재합니다.");
                return;
            }
            AddDataToFirebase(_client);
            LoadChallengeInterface();
            //챌린지 시작
            /*
            StreamWriter sw = new StreamWriter(
                    new FileStream(path, FileMode.Create));

            string str_end = tbYear.Text + "-" + tbMonth.Text + "-" + tbDay.Text;  //입력받은 값을 문자열로 이음
            DateTime endday = DateTime.Parse(str_end); //이은 문자열을 데이트타임 객체로 변환
            DateTime today = DateTime.Today;
            TimeSpan diff = endday.Date - today.Date;

            //첫번째 줄은 현재 날짜
            sw.WriteLine(string.Format("{0:yyyy-MM-dd}", today));
            //두번째 줄은 입력 날짜
            sw.WriteLine(string.Format("{0:yyyy-MM-dd}", endday));
            //세번째 줄은 입력 금액
            sw.WriteLine(tbMoney.Text);
            //네번째 줄부터는 그 사이 날짜와 - 기호
            sw.WriteLine('-');
            sw.Close();
            //챌린지 인터페이스를 로드합니다.
            LoadChallengeInterface();/
            */
        }
        private void setBorder(object sender, PaintEventArgs e)
        {
            int w = 3;
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Gray, w);
            Rectangle rec = new Rectangle(0, 0, (sender as Control).Width - (w / 2), (sender as Control).Height - (w / 2));
            g.DrawRectangle(p, rec);
        }
        static Bitmap SetAlpha(Bitmap bmpIn, int alpha)
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
        new float[] {1, 0, 0, 0, 0},
        new float[] {0, 1, 0, 0, 0},
        new float[] {0, 0, 1, 0, 0},
        new float[] {0, 0, 0, a, 0},
        new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
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
            CalenderMain calenderMain = new CalenderMain(formMain); // 캘린더 폼을 만들고 기존의 값들을 넘겨줌.
            calenderMain.Show();
            this.Hide();
        }
        private void btnSwitchTree_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                // 폼 중복 열기 방지
                if (openForm.Name == "TreeMain") // 열린 폼의 이름 검사
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
            TreeMain TreeMain = new TreeMain(formMain); // 트리뷰 폼을 만들고 기존의 값들을 넘겨줌.
            TreeMain.Show();
            this.Hide();
        }

        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            //파이어 베이스에서 UPPER 노드 삭제
            DropFromFirebase(_client);
            RemoveNestedFlowLayoutPanels();
            pnlNoChallenge.Show();
            pnlBottom.Hide();
            tbYear.Clear();
            tbMonth.Clear();
            tbDay.Clear();
            tbMoney.Clear();
        }
        private void RemoveNestedFlowLayoutPanels()
        {
            List<Control> panelsToRemove = new List<Control>();

            foreach (Control control in pnlCenter.Controls)
            {
                if (control is FlowLayoutPanel nestedFlowLayoutPanel)
                {
                    // 다른 작업을 수행하기 전에 제거할 FlowLayoutPanel을 리스트에 추가
                    panelsToRemove.Add(nestedFlowLayoutPanel);
                }
            }

            // 리스트에 추가된 FlowLayoutPanel을 제거
            foreach (Control panelToRemove in panelsToRemove)
            {
                pnlCenter.Controls.Remove(panelToRemove);
                panelToRemove.Dispose(); // 메모리 누수 방지를 위해 Dispose 호출
            }
        }

        private void btnSwitchGraph_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                // 폼 중복 열기 방지
                if (openForm.Name == "Analysis") // 열린 폼의 이름 검사
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
            Analysis Analysis = new Analysis(formMain); // 트리뷰 폼을 만들고 기존의 값들을 넘겨줌.
            Analysis.Show();
            this.Hide();
        }
    }
}
