using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ledger {
    public partial class Achievement : Form {
        Dictionary<string, Dictionary<string, string>> achNodeValues;
        FormMain formMain;
        public Achievement(FormMain formMain) {
            InitializeComponent();
            this.formMain = formMain;
            achNodeValues = Fireb.GetAchNodeValues(formMain.client);
            AddPanels();
            LeftPanel.Paint += DrawLeftPanel;
        }
        private void AddPanels() {
            for (int i = 0; i < 20; i++) {
                InitPanel(i);
            }
        }
        private void InitPanel(int index) {
            Panel pnl = new Panel();
            pnl.Size = new Size(545, 125);
            pnl.Paint += DrawAchPanel;
            pnl.Tag = index;
            FlowPanel.Controls.Add(pnl);
        }
        private void DrawAchPanel(object sender, PaintEventArgs e) {
            int index = Convert.ToInt32((sender as Panel).Tag);
            Graphics g = e.Graphics;
            //패널 이미지
            g.DrawImage(Properties.Resources.AchPanel, new Point(0, 0));
            //업적 이미지
            g.DrawImage(Properties.Resources.ResourceManager.GetObject($"Ach{index}") as Image, new Point(15, 15));
            //업적 프레임
            g.DrawImage(Properties.Resources.AchFrame, new Point(15, 15));

            //리소스 폴더에서 폰트 불러오기
            byte[] fontbyte = Properties.Resources.NPSfont_regular;

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontbyte.Length);
            Marshal.Copy(fontbyte, 0, fontPtr, fontbyte.Length);

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddMemoryFont(fontPtr, fontbyte.Length);
            Font ft = new Font(fontCollection.Families[0], 18);

            //업적명
            DrawOutlineText(g, AchClass.achName[index], ft, Brushes.White, Brushes.DarkSlateGray, 2, new Point(120, 30), 2);
            //획득 조건
            ft = new Font(fontCollection.Families[0], 10);
            DrawOutlineText(g, AchClass.achText[index], ft, Brushes.White, Brushes.Gray, 2, new Point(120, 80), 2);

            //현황
            DrawOutlineText(g, $"{achNodeValues[$"ach{index}"]["cnt"]} / {AchClass.achMaxCount[index]}", ft, Brushes.White, Brushes.Gray, 2, new Point(490, 100), 2);


            g.Dispose();
            //폰트 메모리 해체
            Marshal.FreeCoTaskMem(fontPtr);
        }
        private void DrawLeftPanel(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            //패널 이미지
            g.DrawImage(Properties.Resources.AchPanel2, new Point(0, 0));
            //아이콘 이미지
            g.DrawImage(Properties.Resources.ach_pic, new Rectangle(47, 150, 150, 150));

            //리소스 폴더에서 폰트 불러오기
            byte[] fontbyte = Properties.Resources.NPSfont_regular;

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontbyte.Length);
            Marshal.Copy(fontbyte, 0, fontPtr, fontbyte.Length);

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddMemoryFont(fontPtr, fontbyte.Length);
            Font ft = new Font(fontCollection.Families[0], 15);

            //현황
            int cnt = 0;
            for (int i = 0; i < 20; i++) {
                if (achNodeValues[$"ach{i}"]["get"] == "1") {
                    cnt++;
                }
            }
            DrawOutlineText(g, cnt.ToString("D2") + " / 20", ft, Brushes.White, Brushes.DarkSlateGray, 2, new Point(75, 310), 2);

            g.Dispose();
            //폰트 메모리 해체
            Marshal.FreeCoTaskMem(fontPtr);

        }
        //외곽선있는 텍스트 그리기
        private void DrawOutlineText(Graphics g, string text, Font font, Brush textColor, Brush outlineColor, int outlineWidth, PointF location, int precision) {
            g.DrawString(text, font, outlineColor, location.X - outlineWidth, location.Y - outlineWidth);
            g.DrawString(text, font, outlineColor, location.X + outlineWidth, location.Y - outlineWidth);
            g.DrawString(text, font, outlineColor, location.X - outlineWidth, location.Y + outlineWidth);
            g.DrawString(text, font, outlineColor, location.X + outlineWidth, location.Y + outlineWidth);
            if (precision > 0) {
                g.DrawString(text, font, outlineColor, location.X - outlineWidth, location.Y);
                g.DrawString(text, font, outlineColor, location.X + outlineWidth, location.Y);
                g.DrawString(text, font, outlineColor, location.X, location.Y - outlineWidth);
                g.DrawString(text, font, outlineColor, location.X, location.Y + outlineWidth);
            }
            if (precision > 1) {
                g.DrawString(text, font, outlineColor, location.X - outlineWidth, location.Y + outlineWidth / 2);
                g.DrawString(text, font, outlineColor, location.X + outlineWidth, location.Y + outlineWidth / 2);
                g.DrawString(text, font, outlineColor, location.X - outlineWidth, location.Y - outlineWidth / 2);
                g.DrawString(text, font, outlineColor, location.X + outlineWidth, location.Y - outlineWidth / 2);
                g.DrawString(text, font, outlineColor, location.X - outlineWidth / 2, location.Y - outlineWidth);
                g.DrawString(text, font, outlineColor, location.X - outlineWidth / 2, location.Y + outlineWidth);
                g.DrawString(text, font, outlineColor, location.X + outlineWidth / 2, location.Y - outlineWidth);
                g.DrawString(text, font, outlineColor, location.X + outlineWidth / 2, location.Y + outlineWidth);
            }
            g.DrawString(text, font, textColor, location);
        }
    }
}
