﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Postman.Repository;
using Postman.Models;
using Postman.App.Authentication.Login;
namespace Postman.App.Authentication.Register
{
    public partial class Register : Form
    {
        UserRepository userRepo = new UserRepository();
        public Register()
        {
            InitializeComponent();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void signupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Login login = new Login.Login ();
            login.Show();

            if (CheckNull(fullnameText) && CheckNull(passwordText) && CheckNull(phoneText) && CheckNull(emailText) && CheckNull(confirmPasswordText))
            {

                if (!String.Equals(confirmPasswordText.Text,  passwordText.Text))
                {
                    return;
                }
                Console.WriteLine("Hello world", riderRadio.Checked , marchentRadio.Checked);
                if (riderRadio.Checked || marchentRadio.Checked)
                {
                    User user = new User()
                    {
                        email = emailText.Text,
                        password = passwordText.Text,
                        phone = phoneText.Text,
                        name = fullnameText.Text,
                        userRole = riderRadio.Checked ? "rider" : marchentRadio.Checked ? "marchent" : ""
                    };
                    try
                    {
                        Console.WriteLine("Creating data");
                            userRepo.RegisterUser(user);
                    } catch(Exception err)
                    {
                        Console.WriteLine("Error: " + err.Message);
                    }
                    if ( == true)
                    {
                        MessageBox.Show("Login Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else it
                    {
                        MessageBox.Show("Login Field", "Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    .Close();
                }
                else
                {
                    MessageBox.Show("Fill the Field", " Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        private bool CheckNull(Guna2TextBox box)
        {
            return !String.IsNullOrEmpty(box.Text);
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void fullnameText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fullnameText.Text))
            {
                fullnameText.Focus();
                errorProvider1.SetError(this.fullnameText, "Fill The Field");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void emailText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailText.Text))
            {
                emailText.Focus();
                errorProvider2.SetError(this.emailText, "Fill The Field");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordText.Text))
            {
                passwordText.Focus();
                errorProvider3.SetError(this.passwordText, "Fill The Field");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void confirmPasswordText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(confirmPasswordText.Text))
            {
                confirmPasswordText.Focus();
                errorProvider4.SetError(this.confirmPasswordText, "Fill The Field");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void phoneText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phoneText.Text))
            {
                phoneText.Focus();
                errorProvider5.SetError(this.confirmPasswordText, "Fill The Field");
            }
            else
            {
                errorProvider5.Clear();
            }
        }
        
    }
}