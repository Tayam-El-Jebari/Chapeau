using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void startForHandheldbtn_Click(object sender, EventArgs e)
        {
            LogInForm inlogForm = new LogInForm();
            this.Hide();
            inlogForm.ShowDialog();
            this.Show();
        }

        private void startAsDesktopbts_Click(object sender, EventArgs e)
        {
            LogInDesktop logInDesktop = new LogInDesktop();
            this.Hide();
            logInDesktop.ShowDialog();
            this.Show();
        }
    }
}
