using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ledger {
    public partial class Search : Form {
        DateTime startDT, endDT;
        int money;
        string text, cate;
        public Search() {
            InitializeComponent();
        }

        // 검색
        private void btnSearch_Click(object sender, EventArgs e) {
            //리스트 전부 초기화
            dataGridView1.Rows.Clear();
            string sql = "select f_date, f_name, f_money, f_cate from tb_spend";


            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read()) {
                // 데이터를 테이블에 추가
                dataGridView1.Rows.Add(data["f_date"].ToString().Split()[0], data["f_name"].ToString(),
                    string.Format("{0:#,###}", data["f_money"].ToString()), data["f_cate"].ToString());
            }

            data.Close();


        }

    }
}
