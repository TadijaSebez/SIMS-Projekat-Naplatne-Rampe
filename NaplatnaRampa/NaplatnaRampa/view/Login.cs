using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.view
{
    public partial class Login : Form
    {

        public LoginFunction function;
        public User loggedUser;
        public Login(IMongoDatabase db)
        {
            this.function = new LoginFunction(db);
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool loginStatus = function.Validate(emailBox1.Text, lozinkaBox2.Text);
            if (!loginStatus)
            {
                statusLabel.Text = "NEISPRAVNA KOMBINACIJA!";
                statusLabel.Visible = true;
            }
            else {
                this.loggedUser = function.userService.CheckCredentials(emailBox1.Text, lozinkaBox2.Text);
                statusLabel.Visible = false;
                this.Hide();

                function.SuccessfulLogin(loggedUser);

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
