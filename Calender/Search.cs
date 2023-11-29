using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ledger {
    public partial class Search : Form {
        FormMain formMain;
        DateTime startDT, endDT;
        int money;
        string text, cate;
        bool def = true; //아무 필터도 없으면 기본 검색
        const string DatePlaceholder = "yyyyMMdd";
        public Search(FormMain formMain) {
            InitializeComponent();

            InitDateTextBox(tbDateDirect);
            InitDateTextBox(tbDateRange1);
            InitDateTextBox(tbDateRange2);

            pnlDateRange.Hide();
            pnlMoneyRange.Hide();
            this.formMain = formMain;
        }
        //날짜 입력 칸 초기화
        private void InitDateTextBox(TextBox tb) {
            tb.ForeColor = Color.DarkGray;
            tb.Text = DatePlaceholder;
            tb.GotFocus += RemovePlaceholder;
            tb.LostFocus += SetPlaceholder;
        }
        // 검색
        private void btnSearch_Click(object sender, EventArgs e) {
            //리스트 전부 초기화
            dataGridView1.Rows.Clear();
            string sql = "select f_date, f_name, f_money, f_cate from tb_spend where ";
            sql += CheckTextSearch();
            sql += CheckDateSearch();
            sql += CheckMoneySearch();
            sql += CheckCateSearch();
            sql += CheckImpSearch();
            sql += CheckRegSearch();
            sql += $"and f_id = '{Login.logined_id}'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read()) {
                // 데이터를 테이블에 추가
                dataGridView1.Rows.Add(data["f_date"].ToString().Split()[0], data["f_name"].ToString(),
                    string.Format("{0:#,###}", Convert.ToInt32(data["f_money"])), data["f_cate"].ToString());
            }

            data.Close();


        }

        //문자 검색 메소드
        private string CheckTextSearch() {
            string text = tabFilter.TabPages["tabText"].Controls["tbText"].Text;
            string cbxText = GetCheckBoxTextSearch();
            if (cbxText.Equals("both")) {
                return $"(f_name like '%{text}%' or f_text like '%{text}%') ";
            }

            return $"{cbxText} like '%{text}%' ";
        }
        //제목, 내용, 둘다
        private string GetCheckBoxTextSearch() {
            Panel pnl = (Panel)tabFilter.TabPages["tabText"].Controls["pnlText"];
            foreach (RadioButton rbtn in pnl.Controls) {
                if (rbtn.Checked) {
                    switch (rbtn.Text) {
                        case "제목만":
                            return "f_name";
                        case "내용만":
                            return "f_text";
                        case "제목 + 내용":
                            return "both";
                    }
                }
            }
            return "both";
        }
        //날짜 메소드
        private string CheckDateSearch() {
            TabPage tab = tabFilter.TabPages["tabDate"];
            foreach (Control ctrl in tab.Controls) {
                if (ctrl is RadioButton radioButton && radioButton.Checked) {
                    if (radioButton.Text.Equals("날짜 지정")) {
                        //옳은 날짜 형식의 입력이 아닐 경우
                        if (!Regex.IsMatch(tbDateDirect.Text, @"^\d{4}-\d{2}-\d{2}$")) {
                            return "and true ";
                        }
                        return $"and f_date = '{tbDateDirect.Text}' ";
                    }
                    else {
                        //옳은 날짜 형식의 입력이 아닐 경우
                        if (!(Regex.IsMatch(tbDateRange1.Text, @"^\d{4}-\d{2}-\d{2}$") && Regex.IsMatch(tbDateRange2.Text, @"^\d{4}-\d{2}-\d{2}$"))) {
                            return "and true ";
                        }
                        return $"and f_date between '{tbDateRange1.Text}' and '{tbDateRange2.Text}' ";
                    }
                }
            }
            return "and true ";
        }
        //금액 메소드
        private string CheckMoneySearch() {
            TabPage tab = tabFilter.TabPages["tabMoney"];
            foreach (Control ctrl in tab.Controls) {
                if (ctrl is RadioButton radioButton && radioButton.Checked) {
                    if (radioButton.Text.Equals("금액 지정")) {
                        //옳은 금액 형식의 입력이 아닐 경우
                        if (!Regex.IsMatch(tbMoneyDirect.Text, @"^\d{1,3}(,\d{3})*$")) {
                            return "and true ";
                        }
                        return $"and f_money = '{new string(tbMoneyDirect.Text.Where(char.IsDigit).ToArray())}' ";

                    }
                    else {
                        //옳은 금액 형식의 입력이 아닐 경우
                        if (!(Regex.IsMatch(tbMoneyRange1.Text, @"^\d{1,3}(,\d{3})*$") && Regex.IsMatch(tbMoneyRange2.Text, @"^\d{1,3}(,\d{3})*$"))) {
                            return "and true ";
                        }
                        return $"and f_money between '{new string(tbMoneyRange1.Text.Where(char.IsDigit).ToArray())}' and '{new string(tbMoneyRange2.Text.Where(char.IsDigit).ToArray())}' ";
                    }
                }
            }
            return "and true ";
        }
        //소비 분야 메소드
        private string CheckCateSearch() {
            List<string> boxes = new List<string>();
            TabPage tab = tabFilter.TabPages["tabCate"];
            foreach (Control ctrl in tab.Controls) {
                if (ctrl is CheckBox cbx && cbx.Checked) {
                    boxes.Add(cbx.Text);
                }
            }
            if (boxes.Count == 1) {
                return $"and f_cate = '{boxes[0]}' ";
            }
            else if (boxes.Count > 1) {
                string str = $"and f_cate in ('";
                str += string.Join("' , '", boxes) + "') ";
                //MessageBox.Show(str);
                return str;
            }
            return "and false ";
        }
        //충동구매 메소드
        private string CheckImpSearch() {
            Panel pnlImp = (Panel)tabFilter.TabPages["tabImp"].Controls["pnlImp"];
            foreach (RadioButton rbtn in pnlImp.Controls) {
                if (rbtn.Checked) {
                    switch (rbtn.Text) {
                        case "모두":
                            return "and true ";
                        case "충동적":
                            return "and f_imp = '1' ";
                        case "비충동적":
                            return "and f_imp = '0' ";
                    }
                }
            }
            return "and true ";
        }
        //정기 월간 지출 메소드
        private string CheckRegSearch() {
            Panel pnlReg = (Panel)tabFilter.TabPages["tabRegular"].Controls["pnlReg"];
            foreach (RadioButton rbtn in pnlReg.Controls) {
                if (rbtn.Checked) {
                    switch (rbtn.Text) {
                        case "모두":
                            return "and true ";
                        case "매월 정기적":
                            return "and f_regular = '2' ";
                        case "매월 비정기적":
                            return "and f_regular != '2' ";
                    }
                }
            }
            return "and true ";
        }
        //금액 텍스트 박스
        private void PressMoneyBox(object sender, EventArgs args) {
            TextBox textBox = (TextBox)sender;
            string inputText = textBox.Text;

            string numericText = new string(inputText.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(numericText)) {
                return;
            }
            string formattedDate = Convert.ToInt64(numericText) == 0 ? "0" : string.Format("{0:#,###}", Convert.ToInt64(numericText));

            textBox.Text = formattedDate;
            textBox.SelectionStart = textBox.Text.Length;

            if (numericText.Length > 13) {
                textBox.Text = numericText.Substring(0, 13);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        //연월일 텍스트 박스
        private void PressTextBox(object sender, EventArgs args) {
            TextBox textBox = (TextBox)sender;
            string inputText = textBox.Text;

            // 사용자가 입력한 텍스트에서 하이픈을 제외한 숫자만 추출
            string numericText = new string(inputText.Where(char.IsDigit).ToArray());


            // 숫자가 8글자 이상인 경우에만 연도, 월, 일 사이에 하이픈 추가
            if (numericText.Length == 8) {
                string formattedDate = numericText.Insert(4, "-").Insert(7, "-");
                textBox.Text = formattedDate;
                textBox.SelectionStart = textBox.Text.Length;
            }
            else if (numericText.Length > 8) {
                textBox.Text = numericText.Substring(0, 8);
                textBox.SelectionStart = textBox.Text.Length;
            }

        }
        private void RemovePlaceholder(object sender, EventArgs e) {
            TextBox txt = (TextBox)sender;
            //텍스트박스 내용이 사용자가 입력한 값이 아닌 Placeholder일 경우에만, 커서 포커스일때 빈칸으로 만들기
            if (txt.Text == DatePlaceholder) {
                txt.ForeColor = Color.Black; //사용자 입력 진한 글씨
                txt.Text = string.Empty;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e) {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text)) {
                //사용자 입력값이 하나도 없는 경우에 포커스 잃으면 Placeholder 적용해주기
                txt.ForeColor = Color.DarkGray; //Placeholder 흐린 글씨
                txt.Text = DatePlaceholder;
            }
        }
        //날짜 라디오 버튼이 바뀌었을 때
        private void GetChangedDate(object sender, EventArgs e) {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked) {
                // 라디오 버튼의 상태가 변경되었을 때 실행할 코드를 여기에 추가
                if (radioButton.Text.Equals("날짜 지정")) {
                    pnlDateSwitch.Show();
                    pnlDateRange.Hide();
                }
                else if (radioButton.Text.Equals("범위 지정")) {
                    pnlDateSwitch.Hide();
                    pnlDateRange.Show();
                }
            }
        }
        //금액 라디오 버튼이 바뀌었을 때
        private void GetChangedMoney(object sender, EventArgs e) {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked) {
                // 라디오 버튼의 상태가 변경되었을 때 실행할 코드를 여기에 추가
                if (radioButton.Text.Equals("금액 지정")) {
                    pnlMoneyDirect.Show();
                    pnlMoneyRange.Hide();
                }
                else if (radioButton.Text.Equals("범위 지정")) {
                    pnlMoneyDirect.Hide();
                    pnlMoneyRange.Show();
                }
            }
        }
        //소비 분야 전부 선택
        private void btnCheckAll_Click(object sender, EventArgs e) {
            TabPage pnlCate = tabFilter.TabPages["tabCate"];
            foreach (Control ctrl in pnlCate.Controls) {
                if (ctrl is CheckBox cbx) {
                    cbx.Checked = true;
                }
            }
        }
        //소비 분야 전부 해제
        private void btnUncheckAll_Click(object sender, EventArgs e) {
            TabPage pnlCate = tabFilter.TabPages["tabCate"];
            foreach (Control ctrl in pnlCate.Controls) {
                if (ctrl is CheckBox cbx) {
                    cbx.Checked = false;
                }
            }
        }
        //모든 설정 초기화 버튼
        private void btnReset_Click(object sender, EventArgs e) {
            //문자 검색 텍스트 박스 초기화
            tbText.Clear();
            //날짜 검색 텍스트 박스 초기화
            tbDateDirect.Clear();
            tbDateRange1.Clear();
            tbDateRange2.Clear();
            rbtnDateDirect.Checked = true;
            //금액 검색 텍스트 박스 초기화
            tbMoneyDirect.Clear();
            tbMoneyRange1.Clear();
            tbMoneyRange2.Clear();
            rbtnMoneyDirect.Checked = true;
            //소비 분야 전부 체크
            btnCheckAll_Click(null, null);
            //충동구매 검색 모두에 체크
            rbtnImpBoth.Checked = true;
            //매월 정기적 지출 모두에 체크
            rbtnRegBoth.Checked = true;
        }

    }
}
