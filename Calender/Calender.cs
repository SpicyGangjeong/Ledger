namespace Calender
{
    public partial class CalenderMain : Form
    {
        public CalenderMain()
        {
            InitializeComponent();

        }

        private void CalenderMain_Load(object sender, EventArgs e)
        {
            MonthPicker.SelectedIndex = 2;
            YearMonthDisplayer.Text = YearPicker.Text + "_" + MonthPicker.Text;
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

            for (int i = 0; CalenderPanels.Controls.Count < 49; i++)
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
            YearMonthDisplayer.Text = YearPicker.Text + "_" + MonthPicker.Text;
            Calc_day();
        }

        public RichTextBox CreateRichTextBox(string text, bool able = true)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Text = text;
            rtb.Dock = DockStyle.Fill;
            rtb.Enabled = able;
            rtb.DoubleClick += Rtb_DoubleClick;
            return rtb;
        }

        private void Rtb_DoubleClick(object? sender, EventArgs e)
        {
            ((RichTextBox)sender).Text = "1234567";
        }
    }
}