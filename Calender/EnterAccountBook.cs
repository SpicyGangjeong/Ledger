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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ledger
{
    public partial class EnterAccountBook : Form
    {
        public string date;
        FormMain formMain;
        AccountBookList form_book;
        TreeMain treeMain;
        bool TreeTrigger = false;
        int no;
        string kind;
        public EnterAccountBook(string date, FormMain fMain)
        {
            InitializeComponent();
            this.date = date;
            this.formMain = fMain;
        }
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
        private void InsertRecordSpend(object sender, EventArgs e)
        {
            //지출 테이블에 레코드 추가
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name.Text) || string.IsNullOrWhiteSpace(tbx_Money.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }


            string sql = "insert into tb_spend values('" +
                GetNewSpendNo().ToString() + "', '" +
                tbx_Name.Text + "', '" +
                date + "', '" +
                tbx_Money.Text + "', '" +
                GetSelectedItem(pnl_Way).Text + "', '" +
                cmbx_Cate.Text + "', '" +
                (cbx_Imp.Checked ? '1' : '0') + "', '" +
                tbx_Memo.Text + "', '" +
                GetRegularIndex(pnl_Regular).ToString() + "')";
            //string sql = "insert into tb_spend values('5', '떢볶이', '2023/9/16', '1000', '카드', '음식', '0', '', '0')";

            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            int n = cmd.ExecuteNonQuery(); //반환(DataSet)이 없는 SQL문
            if (n == 1)
            {
                MessageBox.Show("추가완료");
            }
            else
            {
                MessageBox.Show("추가실패");
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
        private void InsertRecordIncome(object sender, EventArgs e)
        {
            //수입 테이블에 레코드 추가
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name2.Text) || string.IsNullOrWhiteSpace(tbx_Money2.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }


            string sql = "insert into tb_income values('" +
                GetNewIncomeNo().ToString() + "', '" +
                tbx_Name2.Text + "', '" +
                date + "', '" +
                tbx_Money2.Text + "', '" +
                tbx_Memo2.Text + "', '" +
                tbx_From.Text + "', '" +
                GetRegularIndex(pnl_Regular2).ToString() + "')";

            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            int n = cmd.ExecuteNonQuery(); //반환(DataSet)이 없는 SQL문
            if (n == 1)
            {
                MessageBox.Show("추가완료");
            }
            else
            {
                MessageBox.Show("추가실패");
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
        private void UpdateRecordSpend(object sender, EventArgs e)
        {
            //지출 테이블에 레코드 수정
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name.Text) || string.IsNullOrWhiteSpace(tbx_Money.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }
            string sql = "update tb_spend set f_name = '" +
                tbx_Name.Text + "', f_way = '" +
                GetSelectedItem(pnl_Way).Text + "', f_money = '" +
                tbx_Money.Text + "', f_cate = '" +
                cmbx_Cate.Text + "', f_imp = '" +
                (cbx_Imp.Checked ? '1' : '0') + "', f_text = '" +
                tbx_Memo.Text + "', f_regular = '" +
                GetRegularIndex(pnl_Regular).ToString() + "' where f_no = '" + no + "';";

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
        private void UpdateRecordIncome(object sender, EventArgs e)
        {
            //수입 테이블에 레코드 수정
            //필수 입력란에 입력을 하지 않은 경우

            if (string.IsNullOrWhiteSpace(tbx_Name2.Text) || string.IsNullOrWhiteSpace(tbx_Money2.Text))
            {
                MessageBox.Show("제목 또는 가격을 입력하지 않았습니다.");
                return;
            }
            string sql = "update tb_income set f_name = '" +
                tbx_Name2.Text + "', f_money = '" +
                tbx_Money2.Text + "', f_from = '" +
                tbx_From.Text + "', f_text = '" +
                tbx_Memo2.Text + "', f_regular = '" +
                GetRegularIndex(pnl_Regular2).ToString() + "' where f_no = '" + no + "';";

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
        private int GetRegularIndex(Control control)
        {
            //0 : 정기지출 아님, 1 : 매주정기, 2 : 매달정기, 3 : 매년정기
            int ret = 0; //아무것도 체크 안했으면 정기지출이 아님.
            foreach (RadioButton rbtn in control.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text)
                    {
                        case "매주":
                            ret = 1;
                            break;
                        case "매달":
                            ret = 2;
                            break;
                        case "매년":
                            ret = 3;
                            break;
                    }
                }
            }
            return ret;
        }
        private void SetRegularIndex(Control control, int no)
        {
            //정기지출이 아니라면 빠져나옴
            if (no == 0) { return; }
            //해당 컨트롤 내의 라디오 버튼중, 인자 no와 매칭되는 버튼이 있다면 체크 
            foreach (RadioButton rbtn in control.Controls)
            {
                switch (no)
                {
                    case 1:
                        if (rbtn.Text == "매주")
                        {
                            rbtn.Checked = true;
                        }
                        break;
                    case 2:
                        if (rbtn.Text == "매달")
                        {
                            rbtn.Checked = true;
                        }
                        break;
                    case 3:
                        if (rbtn.Text == "매년")
                        {
                            rbtn.Checked = true;
                        }
                        break;
                }
            }
        }
        private int GetNewSpendNo()
        {
            //f_no를 배정하기 위해서, 지출 테이블에서 가장 높은 f_no의 값을 불러온다.
            string query = "select f_no from tb_spend order by f_no desc limit 1"; //쿼리 작성. f_no을 내림차순으로 정렬하여 가장 먼저 오는놈 꺼내
            MySqlCommand cmd = new MySqlCommand(query, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            int no = 1; //초기값은 1
            while (data.Read())
            {
                no = Convert.ToInt32(data["f_no"]) + 1; //가장 높은 f_no에서 1을 더함.
            }
            data.Close();
            return no;
        }
        private int GetNewIncomeNo()
        {
            //f_no를 배정하기 위해서, 수입 테이블에서 가장 높은 f_no의 값을 불러온다.
            string query = "select f_no from tb_income order by f_no desc limit 1"; //쿼리 작성. f_no을 내림차순으로 정렬하여 가장 먼저 오는놈 꺼내
            MySqlCommand cmd = new MySqlCommand(query, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            int no = 1; //초기값은 1
            while (data.Read())
            {
                no = Convert.ToInt32(data["f_no"]) + 1; //가장 높은 f_no에서 1을 더함.
            }
            data.Close();
            return no;
        }
        private void LoadDataFromSpend(int no)
        {
            //인자값과 동일한 f_no를 가지는 레코드를 추출하여 각 컨트롤에 대입
            string sql = "select * from tb_spend where f_no = '" + no.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                tbx_Name.Text = data["f_name"].ToString();
                SetSelectedItem(pnl_Way, data["f_way"].ToString());
                tbx_Money.Text = data["f_money"].ToString();
                cmbx_Cate.Text = data["f_cate"].ToString();
                cbx_Imp.Checked = (Convert.ToInt32(data["f_imp"]) == 0) ? false : true; //1인 경우에만 충동구매 체크
                SetRegularIndex(pnl_Regular, Convert.ToInt32(data["f_regular"]));
                tbx_Memo.Text = data["f_text"].ToString();
            }
            data.Close();
        }
        private void LoadDataFromIncome(int no)
        {
            //인자값과 동일한 f_no를 가지는 레코드를 추출하여 각 컨트롤에 대입
            string sql = "select * from tb_income where f_no = '" + no.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                tbx_Name2.Text = data["f_name"].ToString();
                tbx_Money2.Text = data["f_money"].ToString();
                tbx_From.Text = data["f_from"].ToString();
                SetRegularIndex(pnl_Regular2, Convert.ToInt32(data["f_regular"]));
                tbx_Memo2.Text = data["f_text"].ToString();
            }
            data.Close();
        }
    }
}
