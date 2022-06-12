using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            fillListView();
        }

        private void fillListView()
        {
            StaffService staffService = new StaffService();
            List<Staff> users = staffService.GetAllStaffs();
            userListView.Clear();
            userListView.View = View.Details;
            userListView.Columns.Add("Staff ID", 200);
            userListView.Columns.Add("Name", 200);
            foreach (Staff staff in users)
            {
                ListViewItem li = new ListViewItem(staff.Staff_ID.ToString());
                li.SubItems.Add(staff.firstName);
                userListView.Items.Add(li);
            }
        }

        private void inlogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                StaffService staffService = new StaffService();
                int staffID = int.Parse(staffCodeTextBox.Text);
                string salt = staffService.GetSaltByStaffID(staffID);
                string passwordInput = passwordTextBox.Text;
                string hashedPassword = pwHasher.StringHasher(passwordTextBox.Text, salt).Hash;

                Staff loggedInStaffMemeber = staffService.CheckPassword(staffID, hashedPassword);
                if (staffService.CheckIfWaiter(staffID))
                {
                    this.Hide();
                    TableOverview tableOverview = new TableOverview(loggedInStaffMemeber);
                    tableOverview.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("You can't log in on this device please change to the desktop.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong while logging in: " + ex.Message);
            }
        }

        private void userListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(userListView.SelectedItems.Count != 0)
            {
                staffCodeTextBox.Text = userListView.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void staffCodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
