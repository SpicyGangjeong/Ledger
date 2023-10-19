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
        public CalenderMain(TreeMain tree, FormMain _formMain) // Tree에서 생성될 때 사용
        {
            formMain = _formMain;
            InitializeComponent();
        }

        private void CalenderMain_Load(object sender, EventArgs e)
        {
            MonthPicker.SelectedIndex = 8;
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
            if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0))) days[1] = 29; // 윤년 판단
            else days[1] = 28;

            for (int i = 0; i < Month; i++)
            {
                startday += days[i];
            }
            startday = startday % 7;
            Filling(startday, Month, days);
        }
        private void Filling(int startday, int Month, int[] days)
        {
            while (CalenderPanels.Controls.Count > 7)
            {
                CalenderPanels.Controls[7].Dispose();
            }
            int row = 1;
            int col = 0;
            for (int i = 0; i < startday; i++) // 첫 주 시작일까지 공백 출력
            {
                RichTextBox rtb = CreateRichTextBox(Month + "/" + (days[Month - 1] - startday + i + 1), false);
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
                RichTextBox rtb = CreateRichTextBox((Month + 1) + "/" + (i + 1));
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
                RichTextBox rtb = CreateRichTextBox((Month + 2) + "/" + (i + 1), false);
                CalenderPanels.Controls.Add(rtb, col, row);
                col++;
            }

        }
        private void MonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNowMonth.Text = MonthPicker.Text;
            Calc_day();
        }

        public RichTextBox CreateRichTextBox(string text, bool able = true)
        {
            RichTextBox rtb = new RichTextBox();

            rtb.Text = text + "\n\n";
            int indexdate = rtb.Text.Length;                // 마지막 캐럿지점
            string sql = "select sum(f_money) \"Money\" from tb_spend where f_date = '" + YearPicker.Text + "/" + text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())                             // 지출내용이 있다면 - spends 추가
            {
                string spends = data["Money"].ToString();
                if (spends.Length > 0)
                    rtb.Text += "-" + spends;
            }
            data.Close();
            rtb.Text += "\n";

            rtb.Select(indexdate, rtb.Text.Length);         // 첫 캐럿지점부터 현재 캐럿지점까지 선택
            rtb.SelectionColor = System.Drawing.Color.Red;  // 선택지점 색 변경
            rtb.SelectionAlignment = HorizontalAlignment.Right; // 우로정렬
            int indexspends = rtb.Text.Length;              // 지출지점 마지막 인덱스

            sql = "select sum(f_money) \"Money\" from tb_income where f_date = '" + YearPicker.Text + "/" + text + "'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                string incomes = data["Money"].ToString();
                if (incomes.Length > 0)
                {
                    rtb.Text += "+" + incomes;              // 수입내역이 있다면 color가 깨짐
                    rtb.Select(indexdate, indexspends);     // 그래서 다시 만들어줌
                    rtb.SelectionColor = System.Drawing.Color.Red;  // 지출내역부터 다시 빨간색으로
                    rtb.SelectionAlignment = HorizontalAlignment.Right; // 우로정렬
                    rtb.Select(indexspends, rtb.Text.Length);       // 수입내역선택
                    rtb.SelectionColor = System.Drawing.Color.Blue; // 수입내역 파란색으로
                    rtb.SelectionAlignment = HorizontalAlignment.Right; // 우로정렬
                }
            }
            data.Close();
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
            formMain.Dispose();
        }
        private void btnPostMonth_Click(object sender, EventArgs e)
        {
            MonthPicker.SelectedIndex++;
        }

        private void btnPreMonth_Click(object sender, EventArgs e)
        {
            MonthPicker.SelectedIndex--;
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
            TreeMain TreeMain = new TreeMain(this, formMain); // 트리뷰 폼을 만들고 기존의 값들을 넘겨줌.
            TreeMain.Show();
            this.Hide();
        }

        private void btnSwitchCalender_Click(object sender, EventArgs e)
        {
            // 필요없음
        }

        private void btnSwitchUpper_Click(object sender, EventArgs e)
        {
            UpperLimit upperForm = new UpperLimit(formMain);
            upperForm.Show();
            this.Hide();
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