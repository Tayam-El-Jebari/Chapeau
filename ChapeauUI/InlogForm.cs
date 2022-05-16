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
                StaffService staffService = new StaffService();
                int staffID = int.Parse(IDnummerTextBox.Text);
                string salt = staffService.GetSaltByStaffID(staffID);
                string passwordInput = passwordTextBox.Text;
                string hashedPassword = StringHasher(passwordInput, salt).Hash.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while logging in: " + ex.Message);
            }
        }
        private HashWithSaltResult StringHasher(string hash, string salt)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            int timesToHash = 100;
            HashWithSaltResult hashWithSalt = pwHasher.HashWithSalt(hash, saltBytes, SHA512.Create());

            for (int i = 0; i < timesToHash; i++)
            {
                hashWithSalt = pwHasher.HashWithSalt(hashWithSalt.Hash, saltBytes, SHA512.Create());
            }
            return hashWithSalt;
        }
    }
}
