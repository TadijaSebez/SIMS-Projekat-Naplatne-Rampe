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
    public partial class BossGUI : Form
    {

        public User loggedUser { get; set; }
        public BossGUI(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            label2.Text = loggedUser.name + " " + loggedUser.surname;
        }

        private void BossGUI_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login(Globals.database);
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IncomeReport incomeReport = new IncomeReport(false);
            incomeReport.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectTollStation tollStation = new SelectTollStation();
            tollStation.Show();
        }
    }
}
