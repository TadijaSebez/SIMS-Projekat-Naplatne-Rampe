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
    public partial class ManagerGUI : Form
    {
        public User loggedUser { get; set; }
        public ManagerGUI(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            label2.Text = loggedUser.name + " " + loggedUser.surname;



        }
        private void ManagerGUI_Load(object sender, EventArgs e)
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
            MalfunctionAllReport malfunctionAll = new MalfunctionAllReport();
            malfunctionAll.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            IncomeReport incomeReport = new IncomeReport(true);
            incomeReport.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TablePricelists p = new TablePricelists();
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TollStationTable t = new TollStationTable();
            t.Show();
        }
    }
}
