using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NaplatnaRampa.contoller;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;

namespace NaplatnaRampa.view
{
    public partial class ReportTollRoad : Form
    {
        public TollStation tollStation;
        public List<Payment> payments;
        public PhysicalPaymentController paymentController;
        public TollRoadController tollRoadController;
        public TollStationController tollStationController;
 
        public ReportTollRoad(TollStation tollStation, List<Payment> payments)
        {
            InitializeComponent();
            this.tollStation = tollStation;
            this.payments = payments;
            label2.Text = tollStation.name;
            this.paymentController = Globals.container.Resolve<PhysicalPaymentController>();
            this.tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.tollStationController = Globals.container.Resolve<TollStationController>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReportTollRoad_Load(object sender, EventArgs e)
        {
            DataTable tollStationTable = new DataTable();
            tollStationTable.Columns.Add("Broj naplatnog mesta");
            tollStationTable.Columns.Add("Prihodi u EUR");
            tollStationTable.Columns.Add("Prihodi u RSD");
            float totalpriceEur = 0;
            float totalpriceRsd = 0;
            foreach (ObjectId roadId in tollStation.tollRoadIds)
            {
                float priceRoadEur = 0;
                float priceRoadRsd = 0;
                TollRoad tollRoad = tollRoadController.GetById(roadId);
                foreach(Payment payment in payments)
                {
                    if (payment.tollRoadId.Equals(roadId))
                    {
                       if (payment.currency == Currency.TypeOfCurrency.EUR)
                        {
                            priceRoadEur += payment.price;
                            totalpriceEur += payment.price;
                        }
                        else
                        {
                            priceRoadRsd += payment.price;
                            totalpriceRsd += payment.price;
                        }
                    } 
                }
                tollStationTable.Rows.Add(tollRoad.number, priceRoadEur, priceRoadRsd);

            }
           
            dataGridView1.DataSource = tollStationTable;
            label3.Text = totalpriceRsd.ToString() + "RSD " + totalpriceEur.ToString() + "EUR";

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
