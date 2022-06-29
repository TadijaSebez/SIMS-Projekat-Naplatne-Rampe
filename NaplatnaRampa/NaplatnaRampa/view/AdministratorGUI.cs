using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NaplatnaRampa.model;

namespace NaplatnaRampa.view
{
    public partial class AdministratorGUI : Form
    {

        public User loggedUser { get; set; }
        public AdministratorGUI(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            label2.Text = loggedUser.name + " " + loggedUser.surname;
        }

        private void AdministratorGUI_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableUsers table = new TableUsers();
            table.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login(Globals.database);
            login.Show();
        }
    }
}
