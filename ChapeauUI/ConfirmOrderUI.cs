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
    public partial class ConfirmOrderUI : Form
    {
        public ConfirmOrderUI()
        {
            InitializeComponent();
            ReturnButton.DialogResult = DialogResult.Yes;
            DenyButton.DialogResult = DialogResult.No;
        }
        public ConfirmOrderUI(string question)
        {
            InitializeComponent();
            ConfirmButton.DialogResult = DialogResult.Yes;
            DenyButton.DialogResult = DialogResult.No;
            labelQuestion.Visible = true;
            labelQuestion.Text = question.ToUpper();
        }
        public ConfirmOrderUI(string question, DialogResult dialogResult)
        {
            InitializeComponent();
            labelQuestion.Text = question.ToUpper();
            labelQuestion.Visible = true;
            ReturnButton.DialogResult = DialogResult.OK;
            DenyButton.Hide();
            ConfirmButton.Hide();
            ReturnButton.Show();
        }


        private void DenyButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DenyButton.Visible = false;
            ConfirmButton.Visible = false;
            ReturnButton.Visible = true;
            labelOrderConfirmed.Visible = true;
        }
    }
}
