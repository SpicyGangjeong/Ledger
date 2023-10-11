using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
        //챌린지 진행 중의 인터페이스를 로드해옵니다.
        private void LoadChallengeInterface()
        {
            //텍스트 파일이 존재할 경우에만 실행
            if (File.Exists(path))
            {
                //플로우 레이아웃 패널 생성
                FlowLayoutPanel flpnlDate = new FlowLayoutPanel();
                flpnlDate.Dock = DockStyle.Fill;

                

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

                List<string> tf = new List<string>();

                for (int i = 0; i < diff_start_to_today.Days + 1; i++)
                {
                    tf.Add(sr.ReadLine());
                }
                sr.Close();

                pnlNoChallenge.Hide(); //지출 챌린지 없음 패널은 숨김
                pnlBottom.Show(); //하단 패널은 보임
                lbText1.Text = "시작일 : " + startDate;
                lbText2.Text = "종료일 : " + endDate;
                
                
                lbD_Day.Text = diff.Days.ToString() + "일";
                lbText4.Text = "초기 금액 : " + string.Format("{0:#,###}", money) + "원";

                //잔여 금액
                int left_money = money;
                //권장 금액
                int rec_money = money;

                //DB에 접근
                string sql = "select f_date, sum(f_money) \"f_money\" from tb_spend where f_date between '" + startDate 
                    + "' and '" + today + "' and f_date != '" + today + "' group by f_date order by f_date";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                MySqlDataReader data = cmd.ExecuteReader();
                MySqlDataReader[] datas = new MySqlDataReader[diff_start_to_today.Days+1];
                DateTime tempTime = DateTime.Parse(startDate);
                while (data.Read())
                {
                    DateTime tempNow = Convert.ToDateTime(data["f_date"]);
                    TimeSpan tempSpan = tempTime.Date - tempNow.Date;
                    datas[tempSpan.Days] = data;
                    datas.Append(data);
                    MessageBox.Show(data["f_date"].ToString() + ", " + data["f_money"].ToString());
                }
                for(int i = 0; i < diff_start_to_today.Days + 1; i++)
                {

                }
                for (int i = 0; i < datas.Length; i++)
                {
                    if (datas[i] != null) //인덱스에 data가 존재하면
                    {

                        //MessageBox.Show(i + ", " + datas[i].ToString());
                    } else //존재하지 않으면 ()
                    {

                    }
                }




                /*
                //DB에 접근
                //지출 테이블에서 시작일부터 오늘 전까지의 레코드를 받아옵니다.
                string sql = "select f_date, f_money from tb_spend where f_date between '" + startDate + "' and '" + today + "' and f_date != '" + today + "'";
                MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    int used_money = Convert.ToInt32(data["f_money"]);
                    left_money -= used_money;
                }
                lbText5.Text = "잔여금액 : " + string.Format("{0:#,####}원", left_money);
                int rec_money = left_money / (diff.Days + 1);
                lbText6.Text = "금일 권장액 : " + string.Format("{0:#,####}원", Convert.ToInt32(rec_money));
                */
                data.Close();
                pnlCenter.Controls.Add(flpnlDate);
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
            for(int i = 0; i < diff.Days + 1; i++)
            {
                sw.WriteLine('-');
            }
            sw.Close();
            //챌린지 인터페이스를 로드합니다.
            LoadChallengeInterface();
        }
    }
}
