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
            SetControls();
        }
        public ConfirmOrderUI(string question)
        {
            InitializeComponent();
            SetControls(question);
        }
        private void SetControls()
        {
            ReturnButton.DialogResult = DialogResult.Yes;
            DenyButton.DialogResult = DialogResult.No;
        }
        private void SetControls(string question)
        {
            ConfirmButton.DialogResult = DialogResult.Yes;
            DenyButton.DialogResult = DialogResult.No;
            labelQuestion.Visible = true;
            labelQuestion.Text = question.ToUpper();
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
