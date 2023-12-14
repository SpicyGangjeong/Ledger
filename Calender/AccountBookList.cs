using Ledger;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ledger {
    public partial class AccountBookList : Form {
        FormMain formMain;
        public string date;
        public AccountBookList(string date, FormMain fMain) {
            InitializeComponent();
            CenterToParent();
            this.date = date; //해당 리스트는 몇월 몇일의 리스트인가
            this.lb_Date.Text = this.date; //날짜 레이블의 값을 설정
            this.formMain = fMain;
        }
        public void LoadSpendDatabase(string date) {
            //지출 테이블에서 인자로 받은 날짜에 존재하는 레코드를 추출합니다.
            string sql = "select * from tb_spend where f_date = '" + date + $"' and f_id = '{Login.logined_id}'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read()) {
                //데이터를 지출 패널 내에 패널 형태로 추가
                //패널안에 텍스트와 가격, 수정, 삭제 버튼이 들어간다.
                Panel pnl = new Panel(); //패널 생성
                pnl.BorderStyle = BorderStyle.Fixed3D; //외곽선 추가
                pnl.Size = new Size(flpnl_Spend.Width - 30, 60);

                Label lb_name = new Label(); //이름 레이블
                Label lb_money = new Label(); //가격 레이블
                Button btn_edit = new Button(); //수정 버튼
                Button btn_delete = new Button(); //삭제 버튼

                pnl.Controls.Add(lb_name); //패널에 이름 레이블 추가
                pnl.Controls.Add(lb_money); //패널에 가격 레이블 추가
                pnl.Controls.Add(btn_edit); //패널에 수정 버튼 추가
                pnl.Controls.Add(btn_delete); //패널에 삭제 버튼 추가
                btn_edit.BringToFront(); // 수정버튼 앞으로
                btn_delete.BringToFront(); // 삭제버튼 앞으로
                flpnl_Spend.Controls.Add(pnl);

                if (pnl.Bottom > flpnl_Spend.ClientSize.Height) {
                    flpnl_Spend.AutoScroll = true;
                }
                //이름 레이블
                Font ft = new Font(lb_name.Font.Name, 10);
                lb_name.Font = ft; //폰트 크기
                lb_name.Text = data["f_name"].ToString(); //레이블 값은 제목
                lb_name.Top = 4;
                lb_name.Size = new Size(220, 22);
                //가격 레이블
                lb_money.Font = ft;
                lb_money.Top = (lb_money.Parent.Height) - (lb_money.Height) - 6; //위치
                lb_money.Text = "-" + string.Format("{0:#,###}", data["f_money"]); //레이블 값은 가격
                lb_money.ForeColor = Color.Red; //색상은 빨간색
                //수정 버튼
                btn_edit.ImageList = imageList1; //이미지 리스트 선택
                btn_edit.ImageIndex = 0; //이미지 인덱스 선택
                btn_edit.Size = new Size(36, 36); //크기 조정
                btn_edit.Left = (btn_edit.Parent.Width) - (btn_edit.Width * 2) - 10; //위치 조정
                btn_edit.Top = (btn_edit.Parent.Height - btn_edit.Height) / 2 - 1; //위치 조정
                btn_edit.Click += OpenUpdateAccount(Convert.ToInt32(data["f_no"]), "지출"); //수정 버튼 누를 시, 해당 f_no의 레코드를 수정하는 이벤트 발생

                //삭제 버튼
                btn_delete.ImageList = imageList1; //이미지 리스트 선택
                btn_delete.ImageIndex = 1; //이미지 인덱스 선택
                btn_delete.Size = new Size(36, 36); //크기 조정
                btn_delete.Left = (btn_delete.Parent.Width) - (btn_delete.Width) - 10; //위치 조정
                btn_delete.Top = (btn_delete.Parent.Height - btn_delete.Height) / 2 - 1; //위치 조정
                btn_delete.Click += DeleteRecordSpend(Convert.ToInt32(data["f_no"])); //삭제 버튼 누를 시, 해당 f_no의 레코드를 제거하는 이벤트 발생

            }
            data.Close();

        }
        public void LoadIncomeDatabase(string date) {
            //수입 테이블에서 인자로 받은 날짜에 존재하는 레코드를 추출합니다.
            string sql = "select * from tb_income where f_date = '" + date + $"' and f_id = '{Login.logined_id}'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read()) {
                //데이터를 수입 패널 내에 패널 형태로 추가
                //패널안에 텍스트와 가격, 수정, 삭제 버튼이 들어간다.
                Panel pnl = new Panel(); //패널 생성
                pnl.BorderStyle = BorderStyle.Fixed3D; //외곽선 추가
                pnl.Size = new Size(flpnl_Income.Width - 30, 60);

                Label lb_name = new Label(); //이름 레이블
                Label lb_money = new Label(); //가격 레이블
                Button btn_edit = new Button(); //수정 버튼
                Button btn_delete = new Button(); //삭제 버튼

                pnl.Controls.Add(lb_name); //패널에 이름 레이블 추가
                pnl.Controls.Add(lb_money); //패널에 가격 레이블 추가
                pnl.Controls.Add(btn_edit); //패널에 수정 버튼 추가
                pnl.Controls.Add(btn_delete); //패널에 삭제 버튼 추가
                btn_edit.BringToFront(); // 수정버튼 앞으로
                btn_delete.BringToFront(); // 삭제버튼 앞으로
                flpnl_Income.Controls.Add(pnl);

                if (pnl.Bottom > flpnl_Income.ClientSize.Height) {
                    flpnl_Income.AutoScroll = true;
                }
                //이름 레이블
                Font ft = new Font(lb_name.Font.Name, 10);
                lb_name.Font = ft; //폰트 크기
                lb_name.Text = data["f_name"].ToString(); //레이블 값은 제목
                lb_name.Top = 4;
                lb_name.Size = new Size(220, 22);
                //가격 레이블
                lb_money.Font = ft;
                lb_money.Top = (lb_money.Parent.Height) - (lb_money.Height) - 6; //위치
                lb_money.Text = "+" + string.Format("{0:#,###}", data["f_money"]); //레이블 값은 가격
                lb_money.ForeColor = Color.Blue; //색상은 빨간색
                //수정 버튼
                btn_edit.ImageList = imageList1; //이미지 리스트 선택
                btn_edit.ImageIndex = 0; //이미지 인덱스 선택
                btn_edit.Size = new Size(36, 36); //크기 조정
                btn_edit.Left = (btn_edit.Parent.Width) - (btn_edit.Width * 2) - 10; //위치 조정
                btn_edit.Top = (btn_edit.Parent.Height - btn_edit.Height) / 2 - 1; //위치 조정
                btn_edit.Click += OpenUpdateAccount(Convert.ToInt32(data["f_no"]), "수입"); //수정 버튼 누를 시, 해당 f_no의 레코드를 수정하는 이벤트 발생

                //삭제 버튼
                btn_delete.ImageList = imageList1; //이미지 리스트 선택
                btn_delete.ImageIndex = 1; //이미지 인덱스 선택
                btn_delete.Size = new Size(36, 36); //크기 조정
                btn_delete.Left = (btn_delete.Parent.Width) - (btn_delete.Width) - 10; //위치 조정
                btn_delete.Top = (btn_delete.Parent.Height - btn_delete.Height) / 2 - 1; //위치 조정
                btn_delete.Click += DeleteRecordIncome(Convert.ToInt32(data["f_no"])); //삭제 버튼 누를 시, 해당 f_no의 레코드를 제거하는 이벤트 발생

            }
            data.Close();

        }
        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e) {
            EnterAccountBook acc_book = new EnterAccountBook(this, date, formMain);
            acc_book.ShowDialog(); //창을 모달 형식으로 생성
        }

        public void AccountBookList_Load(object sender, EventArgs e) {
            //지출 / 수입 테이블 리스트 생성시, 데이터베이스에서 데이터 로드
            AddSpendToPanel();
            AddIncomeToPanel();
        }
        private EventHandler DeleteRecordSpend(int no) {
            //삭제 버튼 누를 시, 해당 넘버를 가진 레코드를 제거
            return (sender, e) => {
                string sql = "delete from tb_spend where f_no = '" + no.ToString() + $"' and f_id = '{Login.logined_id}'";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                int n = cmd.ExecuteNonQuery();
                if (n == 1) {
                    MessageBox.Show("삭제 완료");
                }
                else {
                    MessageBox.Show("삭제 실패");
                }
                AddSpendToPanel();
            };
        }
        private EventHandler DeleteRecordIncome(int no) {
            //삭제 버튼 누를 시, 해당 넘버를 가진 레코드를 제거
            return (sender, e) => {
                string sql = "delete from tb_income where f_no = '" + no.ToString() + $"' and f_id = '{Login.logined_id}'";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                int n = cmd.ExecuteNonQuery();
                if (n == 1) {
                    MessageBox.Show("삭제 완료");
                }
                else {
                    MessageBox.Show("삭제 실패");
                }
                AddIncomeToPanel();
            };
        }
        private EventHandler OpenUpdateAccount(int no, string kind) {
            //수정 버튼 누를 시, 해당 넘버를 가진 레코드를 수정하는 창을 생성
            return (sender, e) => {
                EnterAccountBook acc_book = new EnterAccountBook(this, date, no, kind, formMain);
                acc_book.ShowDialog(); //창을 모달 형식으로 생성
            };
        }
        public void AddSpendToPanel() {
            flpnl_Spend.Controls.Clear(); //지출 패널을 먼저 초기화하고...
            LoadSpendDatabase(date); //데이터베이스에서 지출 레코드를 불러옵니다.
        }
        public void AddIncomeToPanel() {
            flpnl_Income.Controls.Clear(); //지출 패널을 먼저 초기화하고...
            LoadIncomeDatabase(date); //데이터베이스에서 지출 레코드를 불러옵니다.
        }
    }
}
