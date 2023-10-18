using Ledger.Properties;
using MySqlConnector;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ledger
{
    public partial class UpperLimit : Form
    {
        FormMain formMain;
        string path = "UpperLimit.txt";
        public UpperLimit(FormMain formMain)
        {
            this.formMain = formMain;
            InitializeComponent();
            lbYearTop.Text = DateTime.Now.Year.ToString();
        }
        //챌린지 진행 중의 인터페이스를 로드해옵니다.
        private void LoadChallengeInterface()
        {
            //텍스트 파일이 존재할 경우에만 실행
            if (File.Exists(path))
            {
                //먼저 초기화
                RemoveNestedFlowLayoutPanels();
                //플로우 레이아웃 패널 생성
                FlowLayoutPanel flpnlDate = new FlowLayoutPanel();
                flpnlDate.Dock = DockStyle.Fill;
                flpnlDate.WrapContents = false;
                flpnlDate.AutoScroll = true;
                flpnlDate.BackColor = ColorTranslator.FromHtml("#f2f2f2");
                //flpnlDate.BackColor = Color.Red;
                /*
                flpnlDate.Scroll += (sender, e) => {
                    this.Text = flpnlDate.HorizontalScroll.LargeChange.ToString();
                };
                */



                StreamReader sr = new StreamReader(
                    new FileStream(path, FileMode.Open));
                string startDate = sr.ReadLine();
                string endDate = sr.ReadLine();
                int money = Convert.ToInt32(sr.ReadLine());

                DateTime startday = DateTime.Parse(startDate);
                DateTime endday = DateTime.Parse(endDate);
                DateTime today = DateTime.Today;
                TimeSpan diff = endday.Date - today.Date;
                TimeSpan diff_start_to_today = today.Date - startday.Date;
                TimeSpan start_to_end = endday.Date - startday.Date;
                MessageBox.Show(diff_start_to_today.Days.ToString());
                
                
                if (DateTime.Compare(today, endday) > 0) {
                    diff_start_to_today = endday.Date - startday.Date;
                    diff = endday.Date - startday.Date;
                }

                string[] tf = new string[diff_start_to_today.Days + 1];

                for (int i = 0; i < diff_start_to_today.Days + 1; i++)
                {
                    tf[i] = sr.ReadLine();
                }
                sr.Close();

                pnlNoChallenge.Hide(); //지출 챌린지 없음 패널은 숨김
                pnlBottom.Show(); //하단 패널은 보임
                lbText1.Text = "시작일 : " + startDate;
                lbText2.Text = "종료일 : " + endDate;
                lbD_Day.Text = diff.Days.ToString() + "일";
                lbText4.Text = "초기 금액 : " + string.Format("{0:#,###}", money) + "원";

                //DB에 접근
                string sql;
                if (DateTime.Compare(today, endday) > 0)
                {
                    sql = "select f_date, sum(f_money) \"f_money\" from tb_spend where f_date between '" + startDate
                    + "' and '" + endDate + "' group by f_date order by f_date";
                    
                } else
                {
                    sql = "select f_date, sum(f_money) \"f_money\" from tb_spend where f_date between '" + startDate
                    + "' and '" + today + "' and f_date != '" + today + "' group by f_date order by f_date";
                }
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                MySqlDataReader data = cmd.ExecuteReader();
                object[,] datas = new object[diff_start_to_today.Days + 1, 2];
                DateTime tempTime = DateTime.Parse(startDate);

                int INT = 0;
                //레코드를 가져와서 객체를 배열에 저장
                while (data.Read())
                {
                    DateTime tempNow = Convert.ToDateTime(data["f_date"]);
                    TimeSpan tempSpan = tempNow.Date - tempTime.Date; //시작일 - 순회일

                    ///if (DateTime.Compare(today, endday) > 0)
                    //{
                    //    tempSpan = endday.Date - startday.Date;
                    //}
                    //MessageBox.Show("시작일 : " + tempTime.Date.Day.ToString() + ", 순회일 : " + tempNow.Date.Day.ToString() + ", " + tempSpan.Days.ToString());
                    datas[tempSpan.Days, 0] = data["f_date"];
                    datas[tempSpan.Days, 1] = data["f_money"];
                    //INT++;
                    //MessageBox.Show(datas[tempSpan.Days, 1].ToString());
                }
                //MessageBox.Show(INT.ToString());

                //잔여 금액
                int left_money = money;
                //권장 금액
                int rec_money = money;
                int[] rec_m = new int[diff_start_to_today.Days + 1];
                for (int i = 0; i < start_to_end.Days + 1; i++)  //diff_start_to_today.Days + 1 = 2, [0, 1]
                {
                    if (i > diff_start_to_today.Days) { break;  }
                    TimeSpan tempSpan = endday - (startday.AddDays(i));
                    if (tempSpan.Days + 1 - i != 0)
                    {
                        if (tf[i] != null && tf[i].Equals("-"))
                        {
                            // 권장 금액 계산해서 배열에 추가
                            rec_m[i] = left_money / (tempSpan.Days + 1 - i);
                            left_money -= (datas[i, 1] == null) ? 0 : Convert.ToInt32(datas[i, 1]); //잔여 금액을 줄임. (줄이는 양은 그 날 쓴 총 비용)
                            rec_money = rec_m[i];
                        }
                        else
                        {
                            //작성된 권장 금액을 배열에 추가
                            if (tf[i] == null)
                            {
                                rec_m[i] = left_money / (tempSpan.Days + 1 - i);
                            }
                            else
                            {
                                rec_m[i] = Convert.ToInt32(tf[i]);
                            }
                            rec_money = rec_m[i];
                            left_money -= (datas[i, 1] == null) ? 0 : Convert.ToInt32(datas[i, 1]);
                        }
                    }
                }
                //텍스트 파일에 덮어씌움
                StreamWriter sw = new StreamWriter(
                    new FileStream(path, FileMode.Create));

                string str_end = tbYear.Text + "-" + tbMonth.Text + "-" + tbDay.Text;  //입력받은 값을 문자열로 이음

                //첫번째 줄은 현재 날짜
                sw.WriteLine(string.Format("{0:yyyy-MM-dd}", startday));
                //두번째 줄은 입력 날짜
                sw.WriteLine(string.Format("{0:yyyy-MM-dd}", endday));
                //세번째 줄은 입력 금액
                sw.WriteLine(money.ToString());
                //네번째 줄부터는 그 사이 날짜와 - 기호
                for (int i = 0; i < diff_start_to_today.Days + 1; i++)
                {
                    sw.WriteLine(rec_m[i].ToString());
                }
                sw.Close();

                lbText5.Text = "잔여금액 : " + string.Format("{0:#,####}원", left_money);
                lbText6.Text = "금일 권장액 : " + string.Format("{0:#,####}원", Convert.ToInt32(rec_money));
                data.Close();
                pnlCenter.Controls.Add(flpnlDate);
                //MessageBox.Show(diff.Days.ToString());
                //패널 추가 
                for (int i = 0; i < start_to_end.Days + 1; i++)
                {
                    FlowLayoutPanel fnl = new FlowLayoutPanel();
                    fnl.Size = new Size(160, 247);
                    //fnl.BackColor = Color.Green;
                    flpnlDate.Controls.Add(fnl);
                    fnl.Tag = (DateTime)startday.AddDays(i);


                    Label lb = new Label();
                    lb.Size = new Size(fnl.Width, 40);
                    lb.Text = startday.AddDays(i).ToString("ddd");
                    lb.ForeColor = (lb.Text.Equals("토")) ? Color.Blue : ((lb.Text.Equals("일")) ? Color.Red : Color.Black);
                    lb.Font = new Font(lb.Font.Name, 20, FontStyle.Bold);
                    lb.TextAlign = ContentAlignment.MiddleCenter;


                    Panel pn = new Panel();
                    pn.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                    pn.Size = new Size(fnl.Width - 16, 192);
                    pn.Margin = new Padding(8, 8, 8, 8);
                    pn.Paint += new PaintEventHandler(setBorder);
                    pn.Invalidate();


                    Label lb2 = new Label();
                    lb2.Size = new Size(pn.Width - 4, 30);
                    lb2.Font = new Font(lb2.Font.Name, 14);
                    lb2.TextAlign = ContentAlignment.MiddleCenter;
                    lb2.Text = startday.AddDays(i).ToString("MM\\/dd");
                    lb2.Location = new Point(pn.Width / 2 - lb2.Width / 2, 2);
                    lb2.BackColor = Color.Transparent;
                    //lb2.BackColor = Color.Yellow;
                    
                    if (i < diff_start_to_today.Days || DateTime.Compare(today, endday) > 0)
                    {
                        //이미지
                        PictureBox pic = new PictureBox();
                        if (rec_m[i] >= Convert.ToInt32(datas[i, 1]))
                        {
                            pic.Image = Properties.Resources.success_icon;
                        } else
                        {
                            pic.Image = Properties.Resources.fail_icon;
                        }
                        pic.Size = new Size(60, 60);
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Location = new Point(pn.Width / 2 - pic.Width / 2, 40);
                        pic.BackColor = Color.Transparent;

                        //지출 비용
                        Label lb3 = new Label();
                        lb3.Size = new Size(pn.Width - 4, 27);
                        lb3.Font = new Font(lb3.Font.Name, 13);
                        lb3.TextAlign = ContentAlignment.MiddleRight;
                        lb3.Text = (datas[i, 1] == null) ? "0" : string.Format("{0:-#,####}", datas[i, 1]);
                        lb3.ForeColor = Color.Red;
                        lb3.Location = new Point(2, 158);
                        lb3.BackColor = Color.Transparent;

                        pn.Controls.Add(pic);
                        pn.Controls.Add(lb3);
                    }
                    if (i < diff_start_to_today.Days + 1)
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
                        lb4.Text = string.Format("{0:#,####}", rec_m[i]);
                        lb4.Location = new Point(4, 120);
                        lb4.BackColor = Color.Transparent;

                        pn.Controls.Add(pic2);
                        pn.Controls.Add(lb4);
                    }

                    pn.Controls.Add(lb2);


                    fnl.Controls.Add(lb);
                    fnl.Controls.Add(pn);

                    if (i < diff_start_to_today.Days || DateTime.Compare(today, endday) > 0)
                    {
                        Color col = ColorTranslator.FromHtml("#c7c7c7");
                        pn.BackColor = col;
                        foreach (Control con in pn.Controls)
                        {
                            con.BackColor = col;
                        }
                    }
                    else if (i > diff_start_to_today.Days)
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
                    if (fp.Tag.ToString().Equals(today.ToString()))
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
                if (DateTime.Compare(today, endday) > 0)
                {
                    lbText6.Text = "";
                    lbText5.Text = "";
                    btnGiveUp.Text = "챌린지 초기화";
                    //만약 잔여금액이 0 이상일 경우 성공
                    if (left_money < 0)
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
            else
            {
                pnlBottom.Hide();
            }
        }
        private void UpperLimit_Load(object sender, EventArgs e)
        {
            LoadChallengeInterface();
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
            //챌린지 시작

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
            LoadChallengeInterface();
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
            //세이브 파일 삭제
            File.Delete(path);
            LoadChallengeInterface();
            pnlNoChallenge.Show();
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
    }
}
