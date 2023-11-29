using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ledger {
    public partial class AchievementGet : Form {
        public AchievementGet(Image img) {
            InitializeComponent();
            achImage.Image = img;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}
