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
    public partial class FormMain : Form
    {

        public static string strConn = "Server=ledgerdb.ctsyekhyqkwe.ap-northeast-2.rds.amazonaws.com;Port=3306;Database=ledgerdb;Uid=root;Pwd=rootpass";
        public static MySqlConnection conn = null;
        public FormMain()
        {
            InitializeComponent();
            conn = new MySqlConnection(strConn);
            conn.Open();
            LoadLatestSpend();
        }

        public void LoadLatestSpend()
        {
            Panel panel = new Panel(); // 최근 지출 알림 패널
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.BackColor = Color.WhiteSmoke;
            panel.Size = new Size(ContentLayout.Width - 5, 120);
            ContentLayout.Controls.Add(panel); 

            Label spendTitle = new Label(); // 최근 지출 알림 제목
            spendTitle.Text = "최근 지출 알림";
            spendTitle.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            spendTitle.Size = new Size(panel.Width - 5, 40);
            spendTitle.Padding = new Padding(15, 8, 0, 2);
            panel.Controls.Add(spendTitle);

            Label lineText = new Label(); // 구분선
            lineText.Text = "-------------------------------------------------------------------------------";
            lineText.ForeColor = Color.Gray;
            lineText.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
            lineText.Size = new Size(panel.Width - 5, 30);
            lineText.Padding = new Padding(0, 5, 0, 2);
            lineText.Location = new Point(10, 30);
            panel.Controls.Add(lineText);


            String sql = "select f_name, f_date, f_money, f_cate from tb_spend order by f_date desc limit 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader data = cmd.ExecuteReader();
            data.Read();

            Label date = new Label(); // 지출 날짜
            Label datecontent = new Label(); // 지출 제목, 소비 분야, 지출 금액


            String bufferdate = data["f_date"].ToString(); // 지출 날짜용 레이블
            DateTime datetext = DateTime.Parse(bufferdate);
            date.Text = "일시 : " + datetext.Date.ToString("yyyy-MM-dd");
            date.Font = new Font("맑은 고딕", 11);
            date.Size = new Size(panel.Width - 5, 30);
            date.Padding = new Padding(5, 5, 0, 2);
            date.Location = new Point(10, 55);
            panel.Controls.Add(date);

            // 지출 제목, 소비 분야, 지출 금액용 레이블
            datecontent.Text = "제목 : " + data["f_name"].ToString() + " / 소비 분야 : " +
                data["f_cate"].ToString() + " / 금액 : " + data["f_money"].ToString();
            datecontent.Font = new Font("맑은 고딕", 11);
            datecontent.Size = new Size(panel.Width - 5, 30);
            datecontent.Padding = new Padding(5, 5, 0, 0);
            datecontent.Location = new Point(10, 80);
            panel.Controls.Add(datecontent);

            data.Close();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            CalenderMain calenderMain = new CalenderMain(this);
            calenderMain.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            TreeMain tree = new TreeMain(this);
            tree.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            Analysis anly = new Analysis(this);
            anly.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("개발중입니다.", "경고!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
        }

        private void btnSpendanal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("개발중입니다.", "경고!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            MessageBox.Show("개발중입니다.", "경고!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
        }

        private void btnChallange_Click(object sender, EventArgs e)
        {
            UpperLimit upperLimit = new UpperLimit(this);
            upperLimit.Show();
            this.Hide();
            notifyIcon1.Visible = true;
        }
    }
}
