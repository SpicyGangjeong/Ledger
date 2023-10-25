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
using ScottPlot;
using ScottPlot.Drawing.Colormaps;

namespace Ledger
{
    public partial class Analysis : Form
    {
        string[] title = { "분야별 소비 순위", "수단별 소비 순위", "충동별 소비 순위", "날짜별 소비 순위" };
        FormMain formMain;
        MySqlCommand cmd;
        MySqlDataReader data;
        string[] Month = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        int idxMonth = 8;
        double card_Nopulse_Sum = 0;
        double card_Pulse_Sum = 0;
        double card_Sum = 0;
        double cash_Nopulse_Sum = 0;
        double cash_Pulse_Sum = 0;
        double cash_Sum = 0;
        double all_Sum = 0;
        double ImPulseSum = 0;
        double NoImPulseSum = 0;
        public Analysis(FormMain fMain)
        {
            InitializeComponent();
            this.formMain = fMain;
            txtNowMonth.Text = Month[idxMonth];
            button_f_cate_Click(null, null);
        }

        private void button_f_cate_Click(object sender, EventArgs e)
        {
            rbt_GroupBox.Visible = false;
            btnhide();
            formsPlot.Plot.Grid(true);
            formsPlot.Plot.Clear();
            rtbRank.Enabled = false;
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
            rtbRank.Text = "\n\n";
            double sum = dataY.Sum();
            for (int i = 0; i < dataX.Count; i++)
            {
                basictext += string.Concat((i + 1), "위\t");
                basictext += dataX[i].ToString();
                basictext += string.Concat("\t(", Math.Round(dataY[i] / sum * 100, 1), "%)");
                rtbRank.Text += basictext + "\n";
                basictext = "";
            }
            Title.Text = title[0];
        }

        private void button_f_way_Click(object sender, EventArgs e)
        {
            rbt_GroupBox.Visible = true;
            rtbRank.Text = "\n";
            formsPlot.Plot.Clear();
            btnhide();
            Title.Text = title[1];

            string sql = "select * from f_way_analysis";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                switch (data[0].ToString())
                {
                    case "&_합계":
                        all_Sum = Convert.ToDouble(data[3]);
                        break;
                    default:
                        switch (data[1].ToString())
                        {
                            case "&카드_합계":
                                card_Sum = Convert.ToDouble(data[3]);
                                break;
                            case "&현금_합계":
                                cash_Sum = Convert.ToDouble(data[3]);
                                break;
                            default:
                                switch (data[2].ToString())
                                {
                                    case "&카드_비충동_합계":
                                        card_Nopulse_Sum = Convert.ToDouble(data[3]);
                                        break;
                                    case "&카드_충동_합계":
                                        card_Pulse_Sum = Convert.ToDouble(data[3]);
                                        break;
                                    case "&현금_비충동_합계":
                                        cash_Nopulse_Sum = Convert.ToDouble(data[3]);
                                        break;
                                    case "&현금_충동_합계":
                                        cash_Pulse_Sum = Convert.ToDouble(data[3]);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                        }
                        break;
                }
                ImPulseSum = card_Pulse_Sum + cash_Pulse_Sum;
                NoImPulseSum = card_Nopulse_Sum + cash_Nopulse_Sum;
                rtbRank.Text += data[0].ToString() + '\t';
                rtbRank.Text += data[1].ToString() + '\t';
                rtbRank.Text += data[2].ToString() + '\t';
                rtbRank.Text += data[3].ToString() + "\n";
                rtbRank.Text += "충동구매 합계: " + ImPulseSum + "\n";
                rtbRank.Text += "비충동구매 합계: " + NoImPulseSum + "\n";
            }
            data.Close();
            rtbRank.Enabled = true;
            formsPlot.Refresh();
        }

        private void button_Days_Click(object sender, EventArgs e)
        {
            rbt_GroupBox.Visible = false;
            formsPlot.Plot.Grid(true);
            rtbRank.Text = "\n\n";
            btnPostMonth.Enabled = true;
            btnPreMonth.Enabled = true;
            txtNowMonth.Enabled = true;
            btnPreMonth.Show();
            btnPostMonth.Show();
            txtNowMonth.Show();
            txtNowMonth.Text = Month[idxMonth];
            formsPlot.Plot.Clear();
            int year = 2023;
            rtbRank.Enabled = false;
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
                dataSpendX.Add(data["f_date"].ToString().Substring(0, 10));
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
            for (int i = 0; i < dataICY.Length; i++)
                dataICY2[i] = dataSPY[i] + dataICY[i];
            formsPlot.Plot.AddBar(dataICY2, dataIncomePosition.ToArray());
            formsPlot.Plot.AddBar(dataSPY, dataSpendPosition.ToArray());
            formsPlot.Plot.XTicks(basicPosition.ToArray(), barX.ToArray());
            formsPlot.Refresh();
            Title.Text = title[3];
            int maxsIndex = 0;
            double maxsValue = dataSpendY[0];
            for (int i = 1; i < dataSpendY.Count; i++)
            {
                if (dataSpendY[i] > maxsValue)
                {
                    maxsValue = dataSpendY[i];
                    maxsIndex = i;
                }
            }
            int maxiIndex = 0;
            double maxiValue = dataIncomeY[0];
            for (int i = 1; i < dataIncomeY.Count; i++)
            {
                if (dataIncomeY[i] > maxiValue)
                {
                    maxiValue = dataIncomeY[i];
                    maxiIndex = i;
                }
            }
            string basictext = "";
            rtbRank.Text = "\n\n";
            basictext += "제일 많은 소비날짜 = " + dataSpendX[maxsIndex] + "\n";
            basictext += "소비 금액 = " + maxsValue + "\n\n";
            basictext += "제일 많은 수입날짜 = " + dataIncomeX[maxiIndex] + "\n";
            basictext += "수입 금액 = " + maxiValue + "\n";
            rtbRank.Text += basictext;
        }
        private void btnhide()
        {
            btnPreMonth.Hide();
            btnPostMonth.Hide();
            txtNowMonth.Hide();
        }

        private void Analysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMain.Dispose();
        }

        private void btnPostMonth_Click(object sender, EventArgs e)
        {
            if (idxMonth == 0)
            {
                idxMonth = 11;
            }
            else
            {
                idxMonth--;
            }
            button_Days_Click(sender, e);
        }

        private void btnPreMonth_Click(object sender, EventArgs e)
        {

            if (idxMonth == 11)
            {
                idxMonth = 1;
            }
            else
            {
                idxMonth++;
            }
            button_Days_Click(sender, e);
        }
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox[] checkBoxes = { cbCash_Sum, cbCash_ImpulseSum, cbCash_NoImpulseSum, cbCard_Sum, cbCard_ImpulseSum, cbCard_NoImpulseSum, cbImPulse_Sum, cbNoImpulseSum };
            double[] readValues = { cash_Sum, cash_Pulse_Sum, cash_Nopulse_Sum, card_Sum, card_Pulse_Sum, card_Nopulse_Sum, ImPulseSum, NoImPulseSum };
            string[] labels = { "cash_Sum", "cash_ImPulse_Sum", "cash_No Impulse_Sum", "card_Sum", "card_ImPulse_Sum", "card_No Impulse_Sum", "ImPulseSum", "NoImPulseSum" };
            List<double> showValues = new List<double>();
            List<string> showLabels = new List<string>();
            int check = 0;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    check += 1;
                    showValues.Add(readValues[i]);
                    showLabels.Add(labels[i]);
                }
            }
            formsPlot.Plot.Clear();
            if (check != 0)
            {
                var plt = new ScottPlot.Plot(600, 400);
                var pie = plt.AddPie(showValues.ToArray());
                pie.SliceLabels = showLabels.ToArray();
                pie.SliceLabelPosition = 0.3;
                pie.ShowPercentages = true;
                pie.ShowLabels = true;
                formsPlot.Plot.Add(pie);
                formsPlot.Plot.Grid(false);
                double[] positions = { 0 };
                string[] xlabel = { "0" };
                formsPlot.Plot.XTicks(positions, xlabel);
            }
            formsPlot.Refresh();
        }
    }
}
