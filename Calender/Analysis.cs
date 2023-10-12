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

namespace Ledger
{
    public partial class Analysis : Form
    {
        FormMain formMain;
        List<string> dataX = new List<string>();
        List<double> dataY = new List<double>();
        public Analysis(FormMain fMain)
        {
            InitializeComponent();
            this.formMain = fMain;

            button_f_cate_Click(null, null);
        }

        private void button_f_cate_Click(object sender, EventArgs e)
        {
            string sql = "select * from f_cate_analysis";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                string dump = data["f_cate"].ToString();
                dataX.Add(dump);
                dataY.Add(Convert.ToDouble(data["f_money"]));
            }
            formsPlot.Plot.AddBar(dataY.ToArray());
            formsPlot.Plot.XTicks(dataX.ToArray());
            formsPlot.Refresh();
            string basictext = "";
            double sum = dataY.Sum();
            for (int i = 0; i < dataX.Count; i++)
            {
                basictext += string.Concat((i + 1), "위\t");
                basictext += dataX[i].ToString();
                basictext += string.Concat("\t(", Math.Round(dataY[i]/sum*100, 1), "%)");
                rtbRank.Text += basictext +"\n";
                basictext = "";
            }
        }

        private void button_f_way_Click(object sender, EventArgs e)
        {

        }

        private void button_f_impulse_Click(object sender, EventArgs e)
        {

        }

        private void button_stats_Click(object sender, EventArgs e)
        {

        }
    }
}
