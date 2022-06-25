using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NaplatnaRampa.view
{
    public partial class IncomeReport : Form
    {
        public IncomeReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numDays = 7;
            AllStationReport allStationReport = new AllStationReport(numDays);
            allStationReport.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numDays = 30;
            AllStationReport allStationReport = new AllStationReport(numDays);
            allStationReport.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numDays = 90;
            AllStationReport allStationReport = new AllStationReport(numDays);
            allStationReport.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numDays = 120;
            AllStationReport allStationReport = new AllStationReport(numDays);
            allStationReport.Show();
            //this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int numDays = 365;
            AllStationReport allStationReport = new AllStationReport(numDays);
            allStationReport.Show();
            //this.Hide();
        }

        private void IncomeReport_Load(object sender, EventArgs e)
        {

        }
    }
}
