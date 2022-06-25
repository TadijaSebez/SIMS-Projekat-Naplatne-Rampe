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
        public PaymentController paymentController;
        public TollRoadController tollRoadController;
        public TollStationController tollStationController;
 
        public ReportTollRoad(TollStation tollStation, List<Payment> payments)
        {
            InitializeComponent();
            this.tollStation = tollStation;
            this.payments = payments;
            this.paymentController = Globals.container.Resolve<PaymentController>();
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
            tollStationTable.Columns.Add("Prihodi");
            float totalprice = 0;
            foreach(ObjectId roadId in tollStation.tollRoadIds)
            {
                float priceRoad = 0;
                TollRoad tollRoad = tollRoadController.GetById(roadId);
                foreach(Payment payment in payments)
                {
                    if (payment.tollRoadId.Equals(roadId))
                    {
                        priceRoad += payment.price;
                        totalprice += payment.price;
                    } 
                }
                tollStationTable.Rows.Add(tollRoad.number, priceRoad);

            }
           
            dataGridView1.DataSource = tollStationTable;
            label3.Text = totalprice.ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = tollStation.name;
        }
    }
}
