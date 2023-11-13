using Microsoft.VisualBasic;
using MySqlConnector;
using System;
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
    public partial class TreeMain : Form
    {

        FormMain formMain;
        public string date;
        public TreeMain(FormMain formMain) // 처음 FormMain에서 생성될 때 사용됨
        {
            InitializeComponent();
            this.formMain = formMain;
        }
        public void InitializeTree()
        {
            string sql = "select distinct substr(f_date, 1, 4) \"YEAR\" from tb_spend " +
                "union select distinct substr(f_date, 1, 4) \"YEAR\" from tb_income";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            //////////////////////////
            // 노드 이름
            // 년 노드 : Y + Text
            // 월 노드 : M + Text
            // 일 노드 : D + Text
            ///////////////////////////
            while (data.Read())
            {
                TreeNode node = new TreeNode();
                node.Text = data["YEAR"].ToString();
                node.Name = "Y" + node.Text;
                node.ImageIndex = 0;
                IOTree.Nodes.Add(node);
            }
            data.Close();
        }


        private void TreeMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            formMain.Show();
        }

        private void TreeMain_Load(object sender, EventArgs e)
        {
            MonthPicker.SelectedIndex = 8;
            InitializeTree();

        }

        private void IOTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode Node = IOTree.SelectedNode;
            string sql;

            // Year 노드 클릭한 경우
            if (Node.Name.Substring(0, 1) == "Y")
            {
                Node.Nodes.Clear();
                sql = "select distinct substr(f_date, 6, 2) \"MONTH\" from tb_spend where substr(f_date, 1, 4) = " + Node.Text +
                    " union select distinct substr(f_date, 6, 2) \"MONTH\" from tb_income where substr(f_date, 1, 4) = " + Node.Text + " order by Month asc";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    TreeNode nodeMonth = new TreeNode();
                    nodeMonth.ImageIndex = 0;
                    nodeMonth.Text = data["MONTH"].ToString();
                    nodeMonth.Name = "M" + nodeMonth.Text;
                    Node.Nodes.Add(nodeMonth);
                }
                data.Close();
                Node.ImageIndex = 1;
                Node.Expand();
            }
            // Month 노드 클릭한 경우
            else if (Node.Name.Substring(0, 1) == "M")
            {
                Node.Nodes.Clear();
                sql = "select distinct substr(f_date, 9, 2) \"DATE\" from tb_spend where substr(f_date, 1, 4) = " + Node.Parent.Text + " and substr(f_date, 6, 2) =" + Node.Text +
                    " union select distinct substr(f_date, 9, 2) \"DATE\" from tb_income where substr(f_date, 1, 4) = " + Node.Parent.Text + " and substr(f_date, 6, 2) =" + Node.Text + " order by DATE asc";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    TreeNode nodeDate = new TreeNode();
                    nodeDate.ImageIndex = 0;
                    nodeDate.Text = data["DATE"].ToString();
                    nodeDate.Name = "D" + nodeDate.Text;
                    Node.Nodes.Add(nodeDate);
                }
                data.Close();
                Node.ImageIndex = 1;
                foreach (TreeNode node in Node.Parent.Nodes)
                {
                    if (node.IsExpanded == true)
                    {
                        node.Collapse();
                    }
                }
                Node.Expand();
            }
            // 날짜 노드를 클릭한 경우
            else if (Node.Name.Substring(0, 1) == "D")
            {
                date = Node.Parent.Parent.Text + '/' + Node.Parent.Text + '/' + Node.Text;
                AddIncomeToPanel();
                AddSpendToPanel();
            }
        }
        #region 패널추가 코드

        public void LoadSpendDatabase(string date)
        {
            //지출 테이블에서 인자로 받은 날짜에 존재하는 레코드를 추출합니다.
            string sql = "select * from tb_spend where f_date = '" + date + "'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                //데이터를 지출 패널 내에 패널 형태로 추가
                //패널안에 텍스트와 가격, 수정, 삭제 버튼이 들어간다.
                Panel pnl = new Panel(); //패널 생성
                pnl.BorderStyle = BorderStyle.Fixed3D; //외곽선 추가
                pnl.Size = new Size(flpnl_Spend.Width - 5, 60);

                Label lb_name = new Label(); //이름 레이블
                Label lb_money = new Label(); //가격 레이블
                Button btn_edit = new Button(); //수정 버튼
                Button btn_delete = new Button(); //삭제 버튼

                pnl.Controls.Add(lb_name); //패널에 이름 레이블 추가
                pnl.Controls.Add(lb_money); //패널에 가격 레이블 추가
                pnl.Controls.Add(btn_edit); //패널에 수정 버튼 추가
                pnl.Controls.Add(btn_delete); //패널에 삭제 버튼 추가
                flpnl_Spend.Controls.Add(pnl);
                //이름 레이블
                Font ft = new Font(lb_name.Font.Name, 10);
                lb_name.Font = ft; //폰트 크기
                lb_name.Text = data["f_name"].ToString(); //레이블 값은 제목
                lb_name.Top = 4;
                //가격 레이블
                lb_money.Font = ft;
                lb_money.Top = (lb_money.Parent.Height) - (lb_money.Height) - 6; //위치
                lb_money.Text = "-" + data["f_money"].ToString(); //레이블 값은 가격
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
        public void LoadIncomeDatabase(string date)
        {
            //수입 테이블에서 인자로 받은 날짜에 존재하는 레코드를 추출합니다.
            string sql = "select * from tb_income where f_date = '" + date + "'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                //데이터를 수입 패널 내에 패널 형태로 추가
                //패널안에 텍스트와 가격, 수정, 삭제 버튼이 들어간다.
                Panel pnl = new Panel(); //패널 생성
                pnl.BorderStyle = BorderStyle.Fixed3D; //외곽선 추가
                pnl.Size = new Size(flpnl_Spend.Width - 5, 60);

                Label lb_name = new Label(); //이름 레이블
                Label lb_money = new Label(); //가격 레이블
                Button btn_edit = new Button(); //수정 버튼
                Button btn_delete = new Button(); //삭제 버튼

                pnl.Controls.Add(lb_name); //패널에 이름 레이블 추가
                pnl.Controls.Add(lb_money); //패널에 가격 레이블 추가
                pnl.Controls.Add(btn_edit); //패널에 수정 버튼 추가
                pnl.Controls.Add(btn_delete); //패널에 삭제 버튼 추가
                flpnl_Income.Controls.Add(pnl);
                //이름 레이블
                Font ft = new Font(lb_name.Font.Name, 10);
                lb_name.Font = ft; //폰트 크기
                lb_name.Text = data["f_name"].ToString(); //레이블 값은 제목
                lb_name.Top = 4;
                //가격 레이블
                lb_money.Font = ft;
                lb_money.Top = (lb_money.Parent.Height) - (lb_money.Height) - 6; //위치
                lb_money.Text = "+" + data["f_money"].ToString(); //레이블 값은 가격
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
        private EventHandler DeleteRecordSpend(int no)
        {
            //삭제 버튼 누를 시, 해당 넘버를 가진 레코드를 제거
            return (sender, e) =>
            {
                string sql = "delete from tb_spend where f_no = '" + no.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    MessageBox.Show("삭제 완료");
                }
                else
                {
                    MessageBox.Show("삭제 실패");
                }
                AddSpendToPanel();
            };
        }
        private EventHandler DeleteRecordIncome(int no)
        {
            //삭제 버튼 누를 시, 해당 넘버를 가진 레코드를 제거
            return (sender, e) =>
            {
                string sql = "delete from tb_income where f_no = '" + no.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    MessageBox.Show("삭제 완료");
                }
                else
                {
                    MessageBox.Show("삭제 실패");
                }
                AddIncomeToPanel();
            };
        }
        public void AddSpendToPanel()
        {
            flpnl_Spend.Controls.Clear(); //지출 패널을 먼저 초기화하고...
            LoadSpendDatabase(date); //데이터베이스에서 지출 레코드를 불러옵니다.
        }
        public void AddIncomeToPanel()
        {
            flpnl_Income.Controls.Clear(); //지출 패널을 먼저 초기화하고...
            LoadIncomeDatabase(date); //데이터베이스에서 지출 레코드를 불러옵니다.
        }
        private EventHandler OpenUpdateAccount(int no, string kind)
        {
            //수정 버튼 누를 시, 해당 넘버를 가진 레코드를 수정하는 창을 생성
            return (sender, e) =>
            {
                EnterAccountBook acc_book = new EnterAccountBook(this, date, no, kind, formMain);
                acc_book.ShowDialog(); //창을 모달 형식으로 생성
            };
        }

        #endregion 패널추가 종료
        private void IOTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode node = IOTree.SelectedNode;
            node.ImageIndex = 0;
        }
    }
}
