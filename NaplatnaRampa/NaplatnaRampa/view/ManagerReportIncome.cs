using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Autofac;
using MongoDB.Bson;
using NaplatnaRampa.contoller;
using NaplatnaRampa.model;
namespace NaplatnaRampa.view
{
    public partial class ManagerReportIncome : Form
    {
        public PhysicalPaymentController paymentController;
        public TollRoadController tollRoadController;
        public TollStationController tollStationController;
        public ManagerReportIncome()
        {
            InitializeComponent();
            this.paymentController = Globals.container.Resolve<PhysicalPaymentController>();
            this.tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.tollStationController = Globals.container.Resolve<TollStationController>();
        }

        private void ManagerReportIncome_Load(object sender, EventArgs e)
        {
            DataTable tollStationTable = new DataTable();
            tollStationTable.Columns.Add("Stanica");
            tollStationTable.Columns.Add("Prihodi u EUR");
            tollStationTable.Columns.Add("Prihodi u RSD");
            float totalEur = 0;
            float totalRsd = 0;
            foreach(TollStation tollStation in tollStationController.TollStations())
            {
                float priceEur = 0;
                float priceRsd = 0;
                foreach (ObjectId objcetId in tollStation.tollRoadIds) 
                {
                    List<float> prices = paymentController.GetTotalPricePayments(objcetId);
                    priceEur += prices[0];
                    totalEur += prices[0];
                    priceRsd += prices[1];
                    totalRsd += prices[1];

                }
                tollStationTable.Rows.Add(tollStation.name, priceEur, priceRsd);

            }
            dataGridView1.DataSource = tollStationTable;
            labeleur.Text = totalEur.ToString();
            labeldin.Text = totalRsd.ToString();

        }
    }
}
