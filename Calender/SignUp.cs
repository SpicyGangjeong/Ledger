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
    public partial class SignUp : Form
    {
        Login login;
        public SignUp(Login login)
        {
            this.login = login;
            InitializeComponent();
        }
    }
}
