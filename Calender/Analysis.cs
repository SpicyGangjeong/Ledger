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
using System.Linq;
using ScottPlot.Ticks.DateTimeTickUnits;

namespace Ledger
{
    public partial class Analysis : Form
    {
        FormMain formMain;
        MySqlCommand cmd;
        MySqlDataReader data;
        public Analysis(FormMain fMain)
        {
            InitializeComponent();
            this.formMain = fMain;

            button_f_cate_Click(null, null);
        }

        private void button_f_cate_Click(object sender, EventArgs e)
        {
            btnhide();
            formsPlot.Plot.Clear();
            List<string> dataX = new List<string>();
            List<double> dataY = new List<double>();
            string sql = "select * from f_cate_analysis";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                string dump = data["f_cate"].ToString();
                dataX.Add(dump);
                dataY.Add(Convert.ToDouble(data["f_money"]));
            }
            data.Close();
            formsPlot.Plot.AddBar(dataY.ToArray());
            formsPlot.Plot.XTicks(dataX.ToArray());
            formsPlot.Refresh();
            string basictext = "";
            rtbRank.Text = "";
            double sum = dataY.Sum();
            for (int i = 0; i < dataX.Count; i++)
            {
                basictext += string.Concat((i + 1), "위\t");
                basictext += dataX[i].ToString();
                basictext += string.Concat("\t(", Math.Round(dataY[i] / sum * 100, 1), "%)");
                rtbRank.Text += basictext + "\n";
                basictext = "";
            }
        }

        private void button_f_way_Click(object sender, EventArgs e)
        {
            btnhide();
        }

        private void button_f_impulse_Click(object sender, EventArgs e)
        {
            btnhide();
        }

        private void button_Days_Click(object sender, EventArgs e)
        {
            btnPostMonth.Enabled = true;
            btnPreMonth.Enabled = true;
            txtNowMonth.Enabled = true;
            txtNowMonth.Text = "09";
            formsPlot.Plot.Clear();
            int year = 2023;
            List<string> dataIncomeX = new List<string>();
            List<string> dataSpendX = new List<string>();
            List<double> dataIncomeY = new List<double>();
            List<double> dataSpendY = new List<double>();
            List<string> barX = new List<string>();
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0))) days[1] = 29; // 윤년 판단
            string sql = "select * from stats_income_analysis";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                dataIncomeX.Add(data["날짜"].ToString().Substring(0, 10));
                dataIncomeY.Add(Convert.ToInt32(data["금액"]));
            }
            data.Close();
            sql = "select * from stats_spend_date";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                dataSpendX.Add(data["f_date"].ToString().Substring(0,10));
                dataSpendY.Add(Convert.ToInt32(data["f_money"]));
            }
            data.Close();
            List<double> dataIncomePosition = new List<double>();
            List<double> dataSpendPosition = new List<double>();
            List<double> basicPosition = new List<double>();
            string today = "";
            string date = "";
            for (int i = 1; i <= days[Convert.ToInt32(txtNowMonth.Text) - 1]; i++)
            {
                if (i < 10)
                {
                    date = "0" + i.ToString();
                }
                else
                {
                    date = i.ToString();
                }
                today = string.Concat(year, "-", txtNowMonth.Text, "-", date);
                barX.Add(today);
                basicPosition.Add(i - 1);
                foreach (string Dday in dataSpendX)
                {
                    if (Dday == today)
                    {
                        dataSpendPosition.Add(Convert.ToDouble(i - 1));
                    }
                }
                foreach (string Dday in dataIncomeX)
                {
                    if (Dday == today)
                    {
                        dataIncomePosition.Add(Convert.ToDouble(i - 1));
                    }
                }
            }
            double[] dataSPY = dataSpendY.ToArray();
            double[] dataICY = dataIncomeY.ToArray();
            double[] dataICY2 = new double[dataICY.Length];
            for(int i = 0; i < dataICY.Length; i++)
                dataICY2[i] = dataSPY[i] + dataICY[i];
            formsPlot.Plot.AddBar(dataICY2, dataIncomePosition.ToArray());
            formsPlot.Plot.AddBar(dataSPY, dataSpendPosition.ToArray());
            formsPlot.Plot.XTicks(basicPosition.ToArray(), barX.ToArray());
            formsPlot.Refresh();
        }
        private void btnhide()
        {
            btnPreMonth.Enabled = false;
            btnPostMonth.Enabled = false;
            txtNowMonth.Enabled = false;
        }
    }
}
