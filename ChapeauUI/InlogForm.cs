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
    public partial class InlogForm : Form
    {
        public InlogForm()
        {
            InitializeComponent();
        }

        private void inlogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OwnerForm ownerForm = new OwnerForm();
                ownerForm.Show();
                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                StaffService staffService = new StaffService();
                int staffID = int.Parse(IDnummerTextBox.Text);
                string salt = staffService.GetSaltByStaffID(staffID);
                string passwordInput = passwordTextBox.Text;
                string hashedPassword = pwHasher.StringHasher("password", "asdfecf").Hash;

                //string hashedPassword = pwHasher.StringHasher(passwordInput, salt).Hash;
                //byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
                //HashWithSaltResult hashedPassword = pwHasher.HashWithSalt("password", saltBytes, SHA512.Create());
                Staff loggedInStaffMemeber = staffService.CheckPassword(staffID, hashedPassword);
                if(loggedInStaffMemeber != null)
                {
                    MessageBox.Show("Logged in");
                }
                else
                {
                    MessageBox.Show("not logged in " + hashedPassword + "salt: " + salt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while logging in: " + ex.Message);
            }
        }
    }
}
