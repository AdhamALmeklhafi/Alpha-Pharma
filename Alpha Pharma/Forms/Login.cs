﻿using System;
using System.Windows.Forms;
using Alpha_Pharma.Classes;

namespace Alpha_Pharma.Forms
{
    public partial class Login : Form
    {
        public static string UserName { get; set; }
        public static DateTime startSession { get; set; }

        private User user = new User();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Mini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void but_enter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_UserName.Text))
            {
                if (!string.IsNullOrEmpty(txb_Pass.Text))
                {
                    string type_user = user.loginChecker(txb_UserName.Text, txb_Pass.Text);

                    startSession = DateTime.Now;

                    if (type_user == "Manager")
                    {
                        this.Hide();
                        new Loading().ShowDialog();
                        new Manager().Show();
                    }
                    else if (type_user == "Admin")
                    {
                        this.Hide();
                        new Loading().ShowDialog();
                        MessageBox.Show(type_user);
                    }
                    else if (type_user == "Employee")
                    {
                        this.Hide();
                        new Loading().ShowDialog();
                        new Employee().Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Inforamtion !", "Try Again");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Password!","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    txb_Pass.Focus();
                }
            }
            else if (!string.IsNullOrEmpty(txb_Pass.Text))
            {
                MessageBox.Show("Please Enter the Username!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txb_UserName.Focus();
            }
            else
            {
                MessageBox.Show("Please Enter the Username and Password!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txb_UserName.Focus();
            }
        }

       
    }
}
