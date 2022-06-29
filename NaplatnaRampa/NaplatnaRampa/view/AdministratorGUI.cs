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
    public partial class AdministratorGui : Form
    {
        public User user;
        public AdministratorGui(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = user.name + " " + user.surname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableUsers t = new TableUsers();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login(Globals.database);
            l.Show();
        }
    }
}
