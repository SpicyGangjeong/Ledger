using MySqlConnector;
using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Ledger
{
    public partial class MonthlySettlement : Form
    {
        int year, month;
        Form originalForm;
        int[] cost_array = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        string costText;
        bool drawCost = false;
        public MonthlySettlement(Form originalForm, int year, int month)
        {
            this.year = year;
            this.month = month;
            this.originalForm = originalForm;
            this.DoubleBuffered = true;
            InitializeComponent();
            pnlChart.Paint += DrawChartMonthlyCategory;
            pnlRank.Paint += DrawRankMonthly;
            pnlDetailed.Paint += DrawDetailed;
        }

        private void DrawChartMonthlyCategory(object sender, PaintEventArgs e)
        {
            string sql = "select f_cate, sum(f_money) from tb_spend where year(f_date) = " + year.ToString(); 
            sql += " and month(f_date) = " + month.ToString() + " group by f_cate";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();

            Dictionary<String, int> dict = new Dictionary<string, int>();
            string[] categories = { "식사", "여가", "간식", "주거", "미용", "저축", "교통", "주식", "의료", "게임", "기타" };
            string[] colors = { "#FF5733", "#4287f5", "#ffad29", "#56d440", "#c642f5", "#33d6ff", "#ff33ac", "#33ff68", "#a833ff", "#ff3362", "#3e3e3e" };
            // 딕셔너리 추가
            foreach (string category in categories)
            {
                dict.Add(category, 0);
            }

            //총합이 담긴 변수
            int sum_all = 0;

            while (data.Read())
            {
                // 딕셔너리에 해당 카테고리의 총 금액 합계 추가
                dict[data["f_cate"].ToString()] = Convert.ToInt32(data["sum(f_money)"]);
                sum_all += Convert.ToInt32(data["sum(f_money)"]);
            }
            data.Close();
            foreach (string key in dict.Keys)
            {
                for(int i = 0; i < 11; i += 1)
                {
                    if (categories[i] == key)
                    {
                        cost_array[i] = dict[key];
                        break;
                    }
                }
            }

            //지출이 있는 경우만
            if (sum_all > 0)
            {
                Graphics g = e.Graphics;

                //선을 그리기 위한 펜
                Pen pen = new Pen(Color.Black);
                pen.Width = 3;
                g.DrawLine(pen, new Point(70, 410), new Point(836, 410)); //수평 선

                //격자 그릴거야
                pen.Color = ColorTranslator.FromHtml("#b3b3b3");
                pen.Width = 1;
                Font ft = new Font("Arial1", 8);

                //격자 간 간격
                //가장 비율이 높은 카테고리의 수치를 알아내서 10의 배수만큼 올림 치기 하면 됨.
                int pad = 40;
                int max_n = 0;
                for (int i = 0; i < categories.Length; i++)
                {
                    double ratio_double = 100.0 * (Convert.ToDouble(dict[categories[i]]) / Convert.ToDouble(sum_all));
                    int ratio_int = Convert.ToInt32(ratio_double);
                    int roundedNumber = Convert.ToInt32((ratio_int == 0) ? 10.0 : Math.Ceiling(ratio_int / 10.0) * 10) / 10;
                    if (max_n < roundedNumber)
                    {
                        pad = 400 / roundedNumber;
                        max_n = roundedNumber;
                    }
                }
                //pad = 40;
                //max_n = 10;
                for (int i = 0; i < max_n; i++)
                {
                    g.DrawString(((max_n - i) * 10).ToString(), ft, Brushes.Black, new Point(42, 3 + (i * pad)));
                    g.DrawLine(pen, new Point(71, 10 + (i * pad)), new Point(835, 10 + (i * pad)));
                }
                for (int i = 0; i < categories.Length; i++)
                {
                    double ratio_double = 100.0 * (Convert.ToDouble(dict[categories[i]]) / Convert.ToDouble(sum_all));
                    int ratio_int = Convert.ToInt32(ratio_double);
                    int start_y = 410 - (ratio_int * (400 / (max_n * 10)));
                    int height = ratio_int * (400 / (max_n * 10));

                    //막대 그래프 그림
                    SolidBrush sb = new SolidBrush(ColorTranslator.FromHtml(colors[i]));
                    g.FillRectangle(sb, new Rectangle(90 + (i * 68), start_y, 47, height));
                    //레이블
                    ft = new Font("Arial1", 8, FontStyle.Bold);
                    g.DrawString(categories[i], ft, sb, new Point(97 + (i * 68), 420));
                    //수치
                    ft = new Font("Arial1", 10);
                    SizeF textSize = g.MeasureString(cost_array[i].ToString("#,###"), ft);
                    int x = Convert.ToInt32(textSize.Width / 2.0);

                    g.DrawString(cost_array[i].ToString("#,###"), ft, sb, new Point(97 + (i * 68) - x + 17, start_y - 20));


                }
            }
        }

        private void DrawRankMonthly(object sender, PaintEventArgs e)
        {
            string sql = "select f_cate, sum(f_money) from tb_spend where year(f_date) = " + year.ToString();
            sql += " and month(f_date) = " + month.ToString() + " group by f_cate";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();

            Dictionary<String, int> dict = new Dictionary<string, int>();
            string[] categories = { "식사", "여가", "간식", "주거", "미용", "저축", "교통", "주식", "의료", "게임", "기타" };

            // 딕셔너리 추가
            foreach (string category in categories)
            {
                dict.Add(category, 0);
            }

            //총합이 담긴 변수
            int sum_all = 0;

            while (data.Read())
            {
                // 딕셔너리에 해당 카테고리의 총 금액 합계 추가
                dict[data["f_cate"].ToString()] = Convert.ToInt32(data["sum(f_money)"]);
                sum_all += Convert.ToInt32(data["sum(f_money)"]);
            }
            data.Close();

            //리소스 폴더에서 폰트 불러오기
            byte[] fontbyte = Properties.Resources.NPSfont_regular;

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontbyte.Length);
            Marshal.Copy(fontbyte, 0, fontPtr, fontbyte.Length);

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddMemoryFont(fontPtr, fontbyte.Length);

            if (sum_all > 0)
            {
                // scores 배열을 내림차순으로 정렬하고 해당 인덱스를 추적
                int[] ratios = new int[categories.Length];


                for (int i = 0; i < categories.Length; i++)
                {
                    double ratio_double = 100.0 * (Convert.ToDouble(dict[categories[i]]) / Convert.ToDouble(sum_all));
                    int ratio_int = Convert.ToInt32(ratio_double);
                    ratios[i] = ratio_int;
                }
                var sortedIndices = Enumerable.Range(0, ratios.Length).OrderByDescending(i => ratios[i]).ToArray();
                //비율이 높은 순으로 정렬
                // 정렬된 순서에 따라 categories 배열을 재배열
                string[] sortedCategories = new string[categories.Length];
                for (int i = 0; i < categories.Length; i++)
                {
                    sortedCategories[i] = categories[sortedIndices[i]];
                }
                Array.Sort(ratios);
                Array.Reverse(ratios);

                //그릴거야
                Graphics g = e.Graphics;

                Font ft = new Font(fontCollection.Families[0], 20, FontStyle.Bold);
                g.DrawString(month.ToString() + "월 분야별 소비 순위", ft, Brushes.Black, new Point(25, 20));

                ft = new Font(fontCollection.Families[0], 12, FontStyle.Bold);
                g.DrawString("1위 " + sortedCategories[0] + "(" + ratios[0].ToString() + "%)", ft, Brushes.Black, new Point(110, 80));
                g.DrawString("2위 " + sortedCategories[1] + "(" + ratios[1].ToString() + "%)", ft, Brushes.Black, new Point(110, 110));
                g.DrawString("3위 " + sortedCategories[2] + "(" + ratios[2].ToString() + "%)", ft, Brushes.Black, new Point(110, 140));

                ft = new Font(fontCollection.Families[0], 12);
                g.DrawString("현재 \"" + sortedCategories[0] + "\"에", ft, Brushes.Black, new Point(115, 190));
                g.DrawString("가장 많은 소비를 하셨습니다.", ft, Brushes.Black, new Point(60, 220));

            }
            else
            {
                Graphics g = e.Graphics;
                Font ft = new Font(fontCollection.Families[0], 20, FontStyle.Bold);
                g.DrawString("소비 내역이 없습니다.", ft, Brushes.Black, new Point(20, 110));

            }
            //폰트 메모리 해체
            Marshal.FreeCoTaskMem(fontPtr);
        }

        private void DrawDetailed(object sender, PaintEventArgs e)
        {
            int biggest_cost = 0;
            string biggest_date = "";
            //돈을 가장 많이 사용한 날의 비용
            string sql = "select month(f_date), day(f_date), sum(f_money) from tb_spend where year(f_date) = " + year.ToString();
            sql += " and month(f_date) = " + month.ToString() + " group by f_date order by sum(f_money) desc limit 1";

            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();

            
            if (data.HasRows) {
                data.Read();
                biggest_cost = Convert.ToInt32(data["sum(f_money)"]);
                biggest_date = data["month(f_date)"].ToString() + "월 " + data["day(f_date)"].ToString() + "일";
            }
            
            data.Close();

            //지출이 없다는 뜻이므로 더 이상의 처리 없이 함수를 빠져나옴.
            if (biggest_cost == 0)
            {
                return;
            }

            //총 지출량
            sql = "select sum(f_money) from tb_spend where year(f_date) = " + year.ToString();
            sql += " and month(f_date) = " + month.ToString();
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();

            data.Read();
            int all_cost = 0;
            all_cost = Convert.ToInt32(data["sum(f_money)"]);
            data.Close();

            //충동구매 비율
            sql = "select (count(f_no) / (select count(f_no) from tb_spend where year(f_date) = " + year.ToString() + " and month(f_date) = ";
            sql += month.ToString() + ")) as imp_ratio ";
            sql += "from tb_spend where month(f_date) = " + month.ToString() + " and f_imp = 1";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();

            data.Read();
            double imp_ratio = 0;
            imp_ratio = Convert.ToDouble(data["imp_ratio"]) * 100.0;
            data.Close();

            //정기지출로 쓴 총 금액
            sql = "select sum(f_money) from tb_spend where year(f_date) = " + year.ToString() + " and month(f_date) = " + month.ToString() + " and f_regular = 2";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();

            data.Read();
            int sum_regular = 0;
            sum_regular += Convert.ToInt32(data["sum(f_money)"]);
            data.Close();

            //카드, 현금 사용 비율
            sql = "select(sum(case when f_way = '카드' then 1 else 0 end) / count(f_no)) as card_ratio, ";
            sql += "(sum(case when f_way = '현금(계좌이체 포함)' then 1 else 0 end) / count(f_no)) as cash_ratio ";
            sql += "from tb_spend where year(f_date) = " + year.ToString() + " and month(f_date) = " + month.ToString();
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();

            data.Read();
            double card_ratio = Convert.ToDouble(data["card_ratio"]) * 100.0;
            double cash_ratio = Convert.ToDouble(data["cash_ratio"]) * 100.0;
            data.Close();

            //리소스 폴더에서 폰트 불러오기
            byte[] fontbyte = Properties.Resources.NPSfont_regular;

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontbyte.Length);
            Marshal.Copy(fontbyte, 0, fontPtr, fontbyte.Length);

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddMemoryFont(fontPtr, fontbyte.Length);

            //출력
            Graphics g = e.Graphics;

            Font ft = new Font(fontCollection.Families[0], 13);

            string str_all = "이번 달은 총 " + all_cost.ToString("#,###") + "원 쓰셨습니다.";
            g.DrawString(str_all, ft, Brushes.Black, new Point(20, 20));

            string str_imp = (imp_ratio == 0.0) ? "충동구매가 없습니다." :
                string.Format("충동구매 횟수 비율은 {0:0.00}% 입니다.", imp_ratio);
            g.DrawString(str_imp, ft, Brushes.Black, new Point(20, 60));

            g.DrawString(string.Format("가장 많이 쓴 날은 {0}로, {1:0,000}원 입니다.", biggest_date, biggest_cost),
                ft, Brushes.Black, new Point(20, 100));

            string str_reg = (sum_regular == 0) ? "이번 달 정기 지출이 없습니다." :
                string.Format("정기지출로 {0:0,000}원을 소비하셨습니다.", sum_regular);
            g.DrawString(str_reg, ft, Brushes.Black, new Point(20, 140));
            string str_way = string.Format("현금 비율은 {0:0.00}%, 카드 비율은 {1:0.00} %입니다.",
                cash_ratio, card_ratio);
            g.DrawString(str_way, ft, Brushes.Black, new Point(20, 180));

            //폰트 메모리 해체
            Marshal.FreeCoTaskMem(fontPtr);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach(Control control in originalForm.Controls)
            {
                control.Show();
            }
            this.Close();
        }
    }
}
