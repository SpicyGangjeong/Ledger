using Ledger;
using MySqlConnector;


namespace Ledger
{

    public partial class CalenderMain : Form
    {
        FormMain formMain;
        public CalenderMain(FormMain _formMain) // FormMain에서 처음 들어갈때 사용
        {
            formMain = _formMain;
            InitializeComponent();
        }

        private void CalenderMain_Load(object sender, EventArgs e)
        {
            MonthPicker.SelectedIndex = DateTime.Now.Month - 1;
            YearPicker.Text = DateTime.Now.Year.ToString();
            Calc_day();
        }
        private void Calc_day()
        {
            int year = Convert.ToInt32(YearPicker.Text);
            int Month;
            if (MonthPicker.Text.Length > 2) Month = Convert.ToInt32(MonthPicker.Text.Substring(0, 2)) - 1;
            else Month = Convert.ToInt32(MonthPicker.Text.Substring(0, 1)) - 1;
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int startday = (year + (year / 4 - year / 100 + year / 400)) % 7; // 첫 날짜 확인, 일요일 = 0
            if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))
            {
                days[1] = 29; // 윤년 판단
                if (startday < 1)
                {
                    startday = startday + 6;
                }
                else
                {
                    startday--;
                }
            }
            else days[1] = 28;

            for (int i = 0; i < Month; i++)
            {
                startday += days[i];
            }
            startday = startday % 7;
            Filling(startday, Month, days, year);
            ActiveSettle();
        }
        private void Filling(int startday, int Month, int[] days, int year)
        {
            List<int[]> arrays = MonthQuery(year, Month + 1, days[Month]);

            while (CalenderPanels.Controls.Count > 7)
            {
                CalenderPanels.Controls[7].Dispose();
            }
            int row = 1;
            int col = 0;
            for (int i = 0; i < startday; i++) // 첫 주 시작일까지 공백 출력
            {
                int inday;
                if (Month - 1 < 0)
                {
                    inday = 11;
                }
                else
                {
                    inday = days[Month - 1];
                }
                RichTextBox rtb = CreateRichTextBox(Month + "/" + (inday - startday + i + 1));
                CalenderPanels.Controls.Add(rtb, i, row);
                col++;
            }
            for (int i = 0; i < days[Month]; i++) // 시작일부터 말일까지 출력
            {
                if (startday == 7)
                {
                    startday = 0;
                    col = 0;
                    row++;
                }
                startday++;
                RichTextBox rtb = CreateRichTextBox((Month + 1) + "/" + (i + 1), true, arrays[0][i].ToString(), arrays[1][i].ToString(), arrays[2][i].ToString());
                CalenderPanels.Controls.Add(rtb, col, row);

                col++;
            }
            for (int i = 0; CalenderPanels.Controls.Count < 49; i++) // 마지막칸까지 달력 채우기
            {
                if (startday == 7)
                {
                    startday = 0;
                    col = 0;
                    row++;
                }
                startday++;
                RichTextBox rtb;
                if (Month + 2 > 12)
                {
                    rtb = CreateRichTextBox(1 + "/" + (i + 1));
                }
                else
                {
                    rtb = CreateRichTextBox((Month + 2) + "/" + (i + 1));
                }
                CalenderPanels.Controls.Add(rtb, col, row);
                col++;
            }
        }
        private List<int[]> MonthQuery(int year, int Month, int days)
        {
            int[] spend = new int[days + 1];
            int[] income = new int[days + 1];
            int[] regular = new int[days + 1];
            for (int i = 0; i < days; i++)
            {
                spend[i] = 0; income[i] = 0; regular[i] = 0;
            }
            string nowMonthFirst = year + "/" + Month + "/01";
            string nowMonthLast = year + "/" + Month + "/" + days;
            string sql = "select f_date, f_money, f_regular from tb_spend where f_date between '" + nowMonthFirst + "' and '" + nowMonthLast + "' order by f_date";


            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())                             // 지출내용이 있다면 - spends 추가
            {
                string f_date = data["f_date"].ToString();
                spend[Convert.ToInt32(f_date.Substring(8, 2)) - 1] += Convert.ToInt32(data["f_money"]);
            }
            data.Close();

            sql = "select f_date, f_money, f_regular from tb_income where f_date between '" + nowMonthFirst + "' and '" + nowMonthLast + "' order by f_date";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                string f_date = data["f_date"].ToString();
                income[Convert.ToInt32(f_date.Substring(8, 2)) - 1] += Convert.ToInt32(data["f_money"]);
            }
            data.Close();

            sql = "select f_date, f_money, f_regular from tb_spend where f_regular = 2 union all select f_date, f_money, f_regular from tb_income where f_regular = 2;";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                string f_date = data["f_date"].ToString();
                regular[Convert.ToInt32(f_date.Substring(8, 2)) - 1] += Convert.ToInt32(data["f_money"]);
            }
            data.Close();

            List<int[]> arrayOfArrays = new List<int[]>();
            arrayOfArrays.Add(spend);
            arrayOfArrays.Add(income);
            arrayOfArrays.Add(regular);

            return arrayOfArrays;
        }
        private void MonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNowMonth.Text = MonthPicker.Text;
            Calc_day();
        }

        public RichTextBox CreateRichTextBox(string text, bool able = false, string spend = "", string income = "", string regular = "")
        {
            RichTextBox rtb = new RichTextBox();

            rtb.Text = text + "\n";
            if (able)
            {
                int indexRegular = rtb.Text.Length; // 레귤러 시작 지점
                rtb.Text += "±" + regular + "\n";
                int indexspend = rtb.Text.Length; // spend 시작 지점
                rtb.Text += "-" + spend + "\n";
                int indexincome = rtb.Text.Length; // income 시작 지점
                rtb.Text += "+" + income + "\n";

                rtb.Select(indexRegular, indexspend);
                rtb.SelectionColor = System.Drawing.Color.Green;
                rtb.SelectionAlignment = HorizontalAlignment.Right;
                rtb.Select(indexspend, indexincome);
                rtb.SelectionColor = System.Drawing.Color.Red;
                rtb.SelectionAlignment = HorizontalAlignment.Right;
                rtb.Select(indexincome, rtb.Text.Length);
                rtb.SelectionColor = System.Drawing.Color.Blue;
                rtb.SelectionAlignment = HorizontalAlignment.Right;
            }
            rtb.Dock = DockStyle.Fill;                      // 가득 채움
            rtb.Enabled = able;                             // 활성화 전환
            rtb.Click += Rtb_Click;             // 클릭 이벤트 활성화
            rtb.ReadOnly = true;                            // 읽기전용
            rtb.BackColor = Color.White;                    // 배경화면 하얀색
            rtb.ScrollBars = RichTextBoxScrollBars.None;    //스크롤바 비활성화
            return rtb;
        }
        private void Rtb_Click(object sender, EventArgs e)
        {
            if (sender is RichTextBox rtb)
                rtb.SelectionStart = 0;
            OpenAccountBookList(sender, e);
        }
        //클릭한 셀의 지출 / 수입 목록을 확인하는 창 열기
        public void OpenAccountBookList(object sender, EventArgs e)
        {
            string date = YearPicker.Text + '/' + (sender as Control).Text.Substring(0, 5);
            AccountBookList acc_list = new AccountBookList(date, formMain);
            acc_list.Show();
            acc_list.FormClosed += CloseAccountBookList;
            //자기 컨트롤 전부 비활성화
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
        }
        //지출 / 수입 리스트 닫을 때 자신의 컨트롤을 전부 활성화
        public void CloseAccountBookList(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }
        }

        private void CalenderMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMain.Show();
            e.Cancel = true;
            this.Hide();
        }
        private void btnPostMonth_Click(object sender, EventArgs e)
        {
            if (MonthPicker.SelectedIndex == 11)
            {
                string yeardate = YearPicker.Text;
                YearPicker.Text = (int.Parse(yeardate) + 1).ToString();
                MonthPicker.SelectedIndex = 0;
            }
            else
            {
                MonthPicker.SelectedIndex++;
            }
        }

        private void btnPreMonth_Click(object sender, EventArgs e)
        {
            if (MonthPicker.SelectedIndex == 0)
            {
                string yeardate = YearPicker.Text;
                YearPicker.Text = (int.Parse(yeardate) - 1).ToString();
                MonthPicker.SelectedIndex = 11;
            }
            else
            {
                MonthPicker.SelectedIndex--;
            }
        }
        private void btnSettle_click(object sender, EventArgs e)
        {
            int Year = Convert.ToInt32(YearPicker.Text);
            int Month = MonthPicker.SelectedIndex + 1;

            //패널 안에 폼 추가
            Panel msPanel = new Panel();
            msPanel.Size = new Size(this.Width, this.Height);

            MonthlySettlement msForm = new MonthlySettlement(this, Year, Month);
            msForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //캘린더 폼 내의 모든 컨트롤을 숨김
            foreach (Control control in this.Controls)
            {
                control.Hide();
            }
            msForm.TopLevel = false;
            msPanel.Controls.Add(msForm);
            this.Controls.Add(msPanel);
            msForm.Show();
            msForm.Dock = DockStyle.Fill;
        }
        //월간정산 버튼 활성화
        private void ActiveSettle()
        {
            //지금 보고 있는 캘린더의 DateTime 객체 반환
            DateTime see = new DateTime(Convert.ToInt32(YearPicker.Text), Convert.ToInt32(MonthPicker.SelectedIndex + 1), 1);

            //현재 날짜를 반환
            DateTime now = DateTime.Now;

            //연도가 크거나, 연도가 같고 월이 클 경우
            if ((now.Year > see.Year) || (now.Year == see.Year && now.Month > see.Month))
            {
                btnSettle.Show(); //보임
            }
            else
            {
                btnSettle.Hide(); //숨김
            }

        }
    }
}