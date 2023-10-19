using Ledger;
using MySqlConnector;


namespace Ledger
{

    public partial class CalenderMain : Form
    {
        FormMain formMain;
        public CalenderMain(FormMain _formMain) // FormMain���� ó�� ���� ���
        {
            formMain = _formMain;
            InitializeComponent();
        }
        public CalenderMain(TreeMain tree, FormMain _formMain) // Tree���� ������ �� ���
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
            int startday = (year + (year / 4 - year / 100 + year / 400)) % 7; // ù ��¥ Ȯ��, �Ͽ��� = 0
            if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0))) days[1] = 29; // ���� �Ǵ�
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
            for (int i = 0; i < startday; i++) // ù �� �����ϱ��� ���� ���
            {
                RichTextBox rtb = CreateRichTextBox(Month + "/" + (days[Month - 1] - startday + i + 1), false);
                CalenderPanels.Controls.Add(rtb, i, row);
                col++;
            }
            for (int i = 0; i < days[Month]; i++) // �����Ϻ��� ���ϱ��� ���
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
            for (int i = 0; CalenderPanels.Controls.Count < 49; i++) // ������ĭ���� �޷� ä���
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
            int indexdate = rtb.Text.Length;                // ������ ĳ������
            string sql = "select sum(f_money) \"Money\" from tb_spend where f_date = '" + YearPicker.Text + "/" + text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())                             // ���⳻���� �ִٸ� - spends �߰�
            {
                string spends = data["Money"].ToString();
                if (spends.Length > 0)
                    rtb.Text += "-" + spends;
            }
            data.Close();
            rtb.Text += "\n";

            rtb.Select(indexdate, rtb.Text.Length);         // ù ĳ���������� ���� ĳ���������� ����
            rtb.SelectionColor = System.Drawing.Color.Red;  // �������� �� ����
            rtb.SelectionAlignment = HorizontalAlignment.Right; // �������
            int indexspends = rtb.Text.Length;              // �������� ������ �ε���

            sql = "select sum(f_money) \"Money\" from tb_income where f_date = '" + YearPicker.Text + "/" + text + "'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                string incomes = data["Money"].ToString();
                if (incomes.Length > 0)
                {
                    rtb.Text += "+" + incomes;              // ���Գ����� �ִٸ� color�� ����
                    rtb.Select(indexdate, indexspends);     // �׷��� �ٽ� �������
                    rtb.SelectionColor = System.Drawing.Color.Red;  // ���⳻������ �ٽ� ����������
                    rtb.SelectionAlignment = HorizontalAlignment.Right; // �������
                    rtb.Select(indexspends, rtb.Text.Length);       // ���Գ�������
                    rtb.SelectionColor = System.Drawing.Color.Blue; // ���Գ��� �Ķ�������
                    rtb.SelectionAlignment = HorizontalAlignment.Right; // �������
                }
            }
            data.Close();
            rtb.Dock = DockStyle.Fill;                      // ���� ä��
            rtb.Enabled = able;                             // Ȱ��ȭ ��ȯ
            rtb.Click += Rtb_Click;             // Ŭ�� �̺�Ʈ Ȱ��ȭ
            rtb.ReadOnly = true;                            // �б�����
            rtb.BackColor = Color.White;                    // ���ȭ�� �Ͼ��
            rtb.ScrollBars = RichTextBoxScrollBars.None;    //��ũ�ѹ� ��Ȱ��ȭ
            return rtb;
        }
        private void Rtb_Click(object sender, EventArgs e)
        {
            if (sender is RichTextBox rtb)
                rtb.SelectionStart = 0;
            OpenAccountBookList(sender, e);
        }
        //Ŭ���� ���� ���� / ���� ����� Ȯ���ϴ� â ����
        public void OpenAccountBookList(object sender, EventArgs e)
        {
            string date = YearPicker.Text + '/' + (sender as Control).Text.Substring(0, 5);
            AccountBookList acc_list = new AccountBookList(date, formMain);
            acc_list.Show();
            acc_list.FormClosed += CloseAccountBookList;
            //�ڱ� ��Ʈ�� ���� ��Ȱ��ȭ
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
        }
        //���� / ���� ����Ʈ ���� �� �ڽ��� ��Ʈ���� ���� Ȱ��ȭ
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
                // �� �ߺ� ���� ����
                if (openForm.Name == "TreeMain") // ���� ���� �̸� �˻�
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {   // ���� active ���� �˻�
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X, this.Location.Y);
                    }
                    openForm.Activate();
                    openForm.Show();
                    this.Hide();
                    return;
                }
            }
            TreeMain TreeMain = new TreeMain(this, formMain); // Ʈ���� ���� ����� ������ ������ �Ѱ���.
            TreeMain.Show();
            this.Hide();
        }

        private void btnSwitchCalender_Click(object sender, EventArgs e)
        {
            // �ʿ����
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
                // �� �ߺ� ���� ����
                if (openForm.Name == "Analysis") // ���� ���� �̸� �˻�
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {   // ���� active ���� �˻�
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X, this.Location.Y);
                    }
                    openForm.Activate();
                    openForm.Show();
                    this.Hide();
                    return;
                }
            }
            Analysis Analysis = new Analysis(formMain); // Ʈ���� ���� ����� ������ ������ �Ѱ���.
            Analysis.Show();
            this.Hide();
        }
    }
}