using Ledger;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ledger {
    public partial class EnterAccountBook : Form
    {
        public string date;
        FormMain formMain;
        AccountBookList form_book;
        TreeMain treeMain;
        bool TreeTrigger = false;
        int no;
        string kind;
        LedgerFunc ledgerFunc = new LedgerFunc();
#region INIT
        public EnterAccountBook(AccountBookList _form, string date, FormMain fMain)
        {
            InitializeComponent();
            this.date = date;
            this.form_book = _form;
            this.formMain = fMain;
        }
        public EnterAccountBook(AccountBookList _form, string date, int no, string kind, FormMain fMain)
        {
            //수정을 위하여 창을 열었다
            InitializeComponent();
            this.date = date;
            this.form_book = _form;
            this.no = no;
            this.formMain = fMain;
            if (kind == "지출")
            {
                this.Text = "지출 수정";
                LoadDataFromSpend(no);
                //기존의 추가 버튼을 수정 버튼으로 변경
                btn_Add.Text = "수정";
                btn_Add.Click -= InsertRecordSpend;
                btn_Add.Click += UpdateRecordSpend;
                tabControl1.TabPages[0].Text = "지출 수정";
                tabControl1.TabPages.RemoveAt(1); //수입 태그는 삭제
            }
            else if (kind == "수입")
            {
                this.Text = "수입 수정";
                LoadDataFromIncome(no);
                //기존의 추가 버튼을 수정 버튼으로 변경
                btn_Add2.Text = "수정";
                btn_Add2.Click -= InsertRecordIncome;
                btn_Add2.Click += UpdateRecordIncome;
                tabControl1.TabPages[1].Text = "수입 수정";
                tabControl1.TabPages.RemoveAt(0); //지출 태그는 삭제
            }
        }
        public EnterAccountBook(TreeMain _form, string date, int no, string kind, FormMain fMain) // 누. TreeMain이 들어온 경우
        {
            //수정을 위하여 창을 열었다
            InitializeComponent();
            this.date = date;
            this.treeMain = _form;
            this.TreeTrigger = true;
            this.no = no;
            this.formMain = fMain;
            if (kind == "지출")
            {
                this.Text = "지출 수정";
                LoadDataFromSpend(no);
                //기존의 추가 버튼을 수정 버튼으로 변경
                btn_Add.Text = "수정";
                btn_Add.Click -= InsertRecordSpend;
                btn_Add.Click += UpdateRecordSpend;
                tabControl1.TabPages[0].Text = "지출 수정";
                tabControl1.TabPages.RemoveAt(1); //수입 태그는 삭제
            }
            else if (kind == "수입")
            {
                this.Text = "수입 수정";
                LoadDataFromIncome(no);
                //기존의 추가 버튼을 수정 버튼으로 변경
                btn_Add2.Text = "수정";
                btn_Add2.Click -= InsertRecordIncome;
                btn_Add2.Click += UpdateRecordIncome;
                tabControl1.TabPages[1].Text = "수입 수정";
                tabControl1.TabPages.RemoveAt(0); //지출 태그는 삭제
            }
        }
        #endregion INIT
#region INSERECORDSPEND
        private void InsertRecordSpend(object sender, EventArgs e)
        {
            //지출 테이블에 레코드 추가
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name.Text) || string.IsNullOrWhiteSpace(tbx_Money.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }
            if (tbx_Name.Text.Length >= 20)
            {
                MessageBox.Show("너무 긴 제목, 최대 19자 까지 입니다.");
                return;
            }
            //숫자만 입력받겠다
            Regex regex = new Regex("^[0-9]*$");

            if (!regex.IsMatch(tbx_Money.Text))
            {
                MessageBox.Show("입력이 올바르지 않습니다.");
                return;
            }
            if (tbx_Money.Text.Length > int.MaxValue)
            {
                MessageBox.Show("너무 큰 가격을 입력하였습니다. 최대 21억 4748만 3647미만만 입력 가능합니다.");
                return;
            }
            tbx_Name.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Name.Text);
            tbx_Memo.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Memo.Text);


            string sql = "insert into tb_spend(f_name, f_date, f_money, f_way, f_cate, f_imp, f_text, f_regular, f_id) values('" +
                tbx_Name.Text + "', '" +
                date + "', '" +
                tbx_Money.Text + "', '" +
                GetSelectedItem(pnl_Way).Text + "', '" +
                cmbx_Cate.Text + "', '" +
                (cbx_Imp.Checked ? '1' : '0') + "', '" +
                tbx_Memo.Text + "', '" +
                GetRegularIndex(cbx_RegSpend).ToString() + $"', '{Login.logined_id}')";
            //string sql = "insert into tb_spend values('5', '떢볶이', '2023/9/16', '1000', '카드', '음식', '0', '', '0')";


            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            int n = cmd.ExecuteNonQuery(); //반환(DataSet)이 없는 SQL문
            if (cbx_RegSpend.Checked) // 정기적인경우
            {
                // ParseExact 메서드를 사용하여 지정된 형식의 문자열을 DateTime으로 변환
                DateTime standardTime = DateTime.ParseExact(date, "yyyy/M/d", null); // 기준일
                DateTime destinationTime = DateTime.ParseExact(dtp_spend.Text, "yyyy/MM/dd", null).AddMonths(-1); // 목표일
                int inputTime = n; // 삽입 횟수
                while (standardTime < destinationTime) // 목표일이 기준일보다 과거면 삽입 중단
                {
                    standardTime = standardTime.AddMonths(1); // 격월로 삽입하기위해 1달만 추가

                    sql = "insert into tb_spend(f_name, f_date, f_money, f_way, f_cate, f_imp, f_text, f_regular, f_id) values('" +
                        tbx_Name.Text + "', '" +
                        standardTime.ToString("yyyy/MM/dd") + "', '" + // 격월로 삽입
                        tbx_Money.Text + "', '" +
                        GetSelectedItem(pnl_Way).Text + "', '" +
                        cmbx_Cate.Text + "', '" +
                        (cbx_Imp.Checked ? '1' : '0') + "', '" +
                        tbx_Memo.Text + "', '" +
                        "3" + $"', '{Login.logined_id}')"; // 정기적으로 추가적으로 나온놈들은 3을 나타냄

                    cmd = new MySqlCommand(sql, FormMain.conn);
                    n += cmd.ExecuteNonQuery();
                    inputTime += 1;
                }
                if (inputTime == n) // 삽입횟수와 영향을 받은 행의 갯수가 같다면 추가완료
                {
                    AchClass.GetAchievement(formMain.client, 0);
                    AchClass.GetAchievement(formMain.client, 1);
                    AchClass.GetAchievement(formMain.client, 2);
                    MessageBox.Show("추가완료");
                }
                else
                {
                    MessageBox.Show("추가실패");
                }

            }
            else // 정기적 아닌경우
            {
                if (n == 1)
                {
                    AchClass.GetAchievement(formMain.client, 0);
                    AchClass.GetAchievement(formMain.client, 1);
                    AchClass.GetAchievement(formMain.client, 2);
                    MessageBox.Show("추가완료");
                }
                else
                {
                    MessageBox.Show("추가실패");
                }
            }


            this.Close();
            if (TreeTrigger) // 트리에서 온 경우
            {
                treeMain.AddSpendToPanel();
            }
            else if (!TreeTrigger) // 북리스트에서 온 경우
            {
                form_book.AddSpendToPanel();
            }

        }
        #endregion INSERECORDSPEND
#region INSERTRECORDINCOME
        private void InsertRecordIncome(object sender, EventArgs e)
        {
            //수입 테이블에 레코드 추가
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name2.Text) || string.IsNullOrWhiteSpace(tbx_Money2.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }
            if (tbx_Name2.Text.Length >= 20)
            {
                MessageBox.Show("너무 긴 제목, 최대 19자 까지 입니다.");
                return;
            }
            //숫자만 입력받겠다
            Regex regex = new Regex("^[0-9]*$");

            if (!regex.IsMatch(tbx_Money2.Text))
            {
                MessageBox.Show("입력이 올바르지 않습니다.");
                return;
            }

            if (tbx_Money2.Text.Length > int.MaxValue)
            {
                MessageBox.Show("너무 큰 가격을 입력하였습니다. 최대 21억 4748만 3647미만만 입력 가능합니다.");
                return;
            }
            tbx_Name.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Name.Text);
            tbx_Memo.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Memo.Text);

            string sql = "insert into tb_income(f_name, f_date, f_money, f_text, f_from, f_regular, f_id) values('" +
                tbx_Name2.Text + "', '" +
                date + "', '" +
                tbx_Money2.Text + "', '" +
                tbx_Memo2.Text + "', '" +
                tbx_From.Text + "', '" +
                GetRegularIndex(cbx_RegIncome).ToString() + $"', '{Login.logined_id}')";
            
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            int n = cmd.ExecuteNonQuery(); //반환(DataSet)이 없는 SQL문
            if (cbx_RegIncome.Checked) // 정기적인경우
            {
                // ParseExact 메서드를 사용하여 지정된 형식의 문자열을 DateTime으로 변환
                DateTime standardTime = DateTime.ParseExact(date, "yyyy/M/d", null); // 기준일
                DateTime destinationTime = DateTime.ParseExact(dtp_income.Text, "yyyy/MM/dd", null).AddMonths(-1); // 목표일
                int inputTime = n; // 삽입 횟수
                while (standardTime < destinationTime) // 목표일이 기준일보다 과거면 삽입 중단
                {
                    standardTime = standardTime.AddMonths(1); // 격월로 삽입하기위해 1달만 추가

                    sql = "insert into tb_income(f_name, f_date, f_money, f_text, f_from, f_regular, f_id) values('" +
                        tbx_Name2.Text + "', '" +
                        standardTime.ToString("yyyy/MM/dd") + "', '" + // 격월로 삽입
                        tbx_Money2.Text + "', '" +
                        tbx_Memo2.Text + "', '" +
                        tbx_From.Text + "', '" +
                        "3" + $"', '{Login.logined_id}')"; // 정기적으로 추가적으로 나온놈들은 3을 나타냄

                    cmd = new MySqlCommand(sql, FormMain.conn);
                    n += cmd.ExecuteNonQuery();
                    inputTime += 1;
                }
                if (inputTime == n) // 삽입횟수와 영향을 받은 행의 갯수가 같다면 추가완료
                {
                    AchClass.GetAchievement(formMain.client, 3);
                    AchClass.GetAchievement(formMain.client, 4);
                    AchClass.GetAchievement(formMain.client, 5);
                    MessageBox.Show("추가완료");
                }
                else
                {
                    MessageBox.Show("추가실패");
                }

            }
            else // 정기적 아닌경우
            {
                if (n == 1)
                {
                    AchClass.GetAchievement(formMain.client, 3);
                    AchClass.GetAchievement(formMain.client, 4);
                    AchClass.GetAchievement(formMain.client, 5);
                    MessageBox.Show("추가완료");
                }
                else
                {
                    MessageBox.Show("추가실패");
                }
            }

            this.Close();
            if (TreeTrigger) // 트리에서 온 경우
            {
                treeMain.AddIncomeToPanel();
            }
            else if (!TreeTrigger) // 북리스트에서 온 경우
            {
                form_book.AddIncomeToPanel();
            }
        }
        #endregion INSERTRECORDINCOME
#region UPDATERECORDSPEND
        private void UpdateRecordSpend(object sender, EventArgs e)
        {
            if (cbx_RegSpend.Checked)
            {
                MessageBox.Show("정기적 처리는 삭제만 가능합니다.");
                return;
            }
            //지출 테이블에 레코드 수정
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name.Text) || string.IsNullOrWhiteSpace(tbx_Money.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }
            if (tbx_Name.Text.Length >= 20)
            {
                MessageBox.Show("너무 긴 제목, 최대 19자 까지 입니다.");
                return;
            }
            //숫자만 입력받겠다
            Regex regex = new Regex("^[0-9]*$");

            if (!regex.IsMatch(tbx_Money.Text))
            {
                MessageBox.Show("입력이 올바르지 않습니다.");
                return;
            }
            if (tbx_Money.Text.Length > int.MaxValue)
            {
                MessageBox.Show("너무 큰 가격을 입력하였습니다. 최대 21억 4748만 3647미만만 입력 가능합니다.");
                return;
            }
            tbx_Name.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Name.Text);
            tbx_Memo.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Memo.Text);
            string sql = "update tb_spend set f_name = '" +
                tbx_Name.Text + "', f_way = '" +
                GetSelectedItem(pnl_Way).Text + "', f_money = '" +
                tbx_Money.Text + "', f_cate = '" +
                cmbx_Cate.Text + "', f_imp = '" +
                (cbx_Imp.Checked ? '1' : '0') + "', f_text = '" +
                tbx_Memo.Text + "', f_regular = '" +
                GetRegularIndex(cbx_RegSpend).ToString() + "' where f_no = '" + no + $"' and f_id = '{Login.logined_id}';";

            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            int n = cmd.ExecuteNonQuery(); //반환(DataSet)이 없는 SQL문
            if (n == 1)
            {
                MessageBox.Show("수정완료");
            }
            else
            {
                MessageBox.Show("수정실패");
            }
            this.Close();
            if (TreeTrigger) // 트리에서 온 경우
            {
                treeMain.AddSpendToPanel();
            }
            else if (!TreeTrigger) // 북리스트에서 온 경우
            {
                form_book.AddSpendToPanel();
            }
        }
        #endregion UPDATERECORDSPEND
#region UPDATERECORDINCOME
        private void UpdateRecordIncome(object sender, EventArgs e)
        {
            if (cbx_RegIncome.Checked)
            {
                MessageBox.Show("정기적 처리는 삭제만 가능합니다.");
                return;
            }
            //수입 테이블에 레코드 수정
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name2.Text) || string.IsNullOrWhiteSpace(tbx_Money2.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }
            if (tbx_Name2.Text.Length >= 20)
            {
                MessageBox.Show("너무 긴 제목, 최대 19자 까지 입니다.");
                return;
            }
            //숫자만 입력받겠다
            Regex regex = new Regex("^[0-9]*$");

            if (!regex.IsMatch(tbx_Money2.Text))
            {
                MessageBox.Show("입력이 올바르지 않습니다.");
                return;
            }
            if (tbx_Money2.Text.Length > int.MaxValue)
            {
                MessageBox.Show("너무 큰 가격을 입력하였습니다. 최대 21억 4748만 3647미만만 입력 가능합니다.");
                return;
            }
            tbx_Name2.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Name.Text);
            tbx_Memo2.Text = ledgerFunc.replaceQuotetoSlashQuote(tbx_Memo.Text);
            string sql = "update tb_income set f_name = '" +
                tbx_Name2.Text + "', f_money = '" +
                tbx_Money2.Text + "', f_from = '" +
                tbx_From.Text + "', f_text = '" +
                tbx_Memo2.Text + "', f_regular = '" +
                GetRegularIndex(cbx_RegIncome).ToString() + "' where f_no = '" + no + $"' and f_id = '{Login.logined_id}';";

            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            int n = cmd.ExecuteNonQuery(); //반환(DataSet)이 없는 SQL문
            if (n == 1)
            {
                MessageBox.Show("수정완료");
            }
            else
            {
                MessageBox.Show("수정실패");
            }
            this.Close();
            if (TreeTrigger) // 트리에서 온 경우
            {
                treeMain.AddIncomeToPanel();
            }
            else if (!TreeTrigger) // 북리스트에서 온 경우
            {
                form_book.AddIncomeToPanel();
            }
        }
        #endregion UPDATERECORDINCOME
        private Control GetSelectedItem(Control control)
        {
            //해당 컨트롤 내의 자식 컨트롤중에서 체크되어있는 라디오 버튼 객체 하나를 반환
            foreach (RadioButton rbtn in control.Controls)
            {
                if (rbtn.Checked)
                {
                    return rbtn;
                }
            }
            return null;
        }
        private void SetSelectedItem(Control control, string text)
        {
            //해당 컨트롤 내의 자식 컨트롤중에서 인자값과 같은 텍스트를 지닌 라디오버튼을 체크
            foreach (RadioButton rbtn in control.Controls)
            {
                if (rbtn.Text.Equals(text))
                {
                    rbtn.Checked = true;
                    break;
                }
            }
        }
        private int GetRegularIndex(CheckBox cbx)
        {
            //0 : 정기지출 아님, 2 : 매달 정기
            if (cbx.Checked)
            {
                return 2;
            }
            return 0;
        }
        private void SetRegularIndex(CheckBox cbx, int no)
        {
            if (no == 0)
            {
                return;
            }
            cbx.Checked = true;
        }

        private void LoadDataFromSpend(int no)
        {
            //인자값과 동일한 f_no를 가지는 레코드를 추출하여 각 컨트롤에 대입
            string sql = "select * from tb_spend where f_no = '" + no.ToString() + $"' and f_id = '{Login.logined_id}'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                tbx_Name.Text = data["f_name"].ToString();
                SetSelectedItem(pnl_Way, data["f_way"].ToString());
                tbx_Money.Text = data["f_money"].ToString();
                cmbx_Cate.Text = data["f_cate"].ToString();
                cbx_Imp.Checked = (Convert.ToInt32(data["f_imp"]) == 0) ? false : true; //1인 경우에만 충동구매 체크
                SetRegularIndex(cbx_RegSpend, Convert.ToInt32(data["f_regular"]));
                tbx_Memo.Text = data["f_text"].ToString();
            }
            data.Close();
        }
        private void LoadDataFromIncome(int no)
        {
            //인자값과 동일한 f_no를 가지는 레코드를 추출하여 각 컨트롤에 대입
            string sql = "select * from tb_income where f_no = '" + no.ToString() + $"' and f_id = '{Login.logined_id}'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                tbx_Name2.Text = data["f_name"].ToString();
                tbx_Money2.Text = data["f_money"].ToString();
                tbx_From.Text = data["f_from"].ToString();
                SetRegularIndex(cbx_RegIncome, Convert.ToInt32(data["f_regular"]));
                tbx_Memo2.Text = data["f_text"].ToString();
            }
            data.Close();
        }
        private void cbx_Reg_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as Control).Name == "cbx_RegSpend")
            {
                if (cbx_RegSpend.Checked)
                {
                    dtp_spend.Enabled = true;
                    dtp_spend.Visible = true;
                }
                else
                {
                    dtp_spend.Enabled = false;
                    dtp_spend.Visible = false;
                }
            }
            else if ((sender as Control).Name == "cbx_RegIncome")
            {
                if (cbx_RegIncome.Checked)
                {
                    dtp_income.Enabled = true;
                    dtp_income.Visible = true;
                }
                else
                {
                    dtp_income.Enabled = false;
                    dtp_income.Visible = false;
                }
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool rbtnChanged = false; //미필수 라디오 버튼을 만들기 위한 변수
        private void rbtnRegularChanged(object sender, EventArgs e)
        {
            //미필수 라디오 버튼을 만들기 위한 함수
            rbtnChanged = true;
        }
        private void rbtnRegularClick(object sender, EventArgs e)
        {
            //미필수 라디오 버튼을 만들기 위한 함수
            RadioButton rbtn = sender as RadioButton;
            if (!rbtnChanged)
            {
                rbtn.Checked = false;
            }
            rbtnChanged = false;
        }
    }
}
