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
        public bool allStation;
        public IncomeReport(bool all)
        {
            InitializeComponent();
            this.allStation = all;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numDays = 7;
            if (allStation == false)
            {
                AllStationReport allStationReport = new AllStationReport(numDays);
                allStationReport.Show();
            }
            else
            {
                ManagerReportIncome managerReportIncome = new ManagerReportIncome(numDays);
                managerReportIncome.Show();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numDays = 30;
            if (allStation == false)
            {
                AllStationReport allStationReport = new AllStationReport(numDays);
                allStationReport.Show();
            }
            else
            {
                ManagerReportIncome managerReportIncome = new ManagerReportIncome(numDays);
                managerReportIncome.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numDays = 90;
            if (allStation == false)
            {
                AllStationReport allStationReport = new AllStationReport(numDays);
                allStationReport.Show();
            }
            else
            {
                ManagerReportIncome managerReportIncome = new ManagerReportIncome(numDays);
                managerReportIncome.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numDays = 120;
            if (allStation == false)
            {
                AllStationReport allStationReport = new AllStationReport(numDays);
                allStationReport.Show();
            }
            else
            {
                ManagerReportIncome managerReportIncome = new ManagerReportIncome(numDays);
                managerReportIncome.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int numDays = 365;
            if (allStation == false)
            {
                AllStationReport allStationReport = new AllStationReport(numDays);
                allStationReport.Show();
            }
            else
            {
                ManagerReportIncome managerReportIncome = new ManagerReportIncome(numDays);
                managerReportIncome.Show();
            }
        }

        private void IncomeReport_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
