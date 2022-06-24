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
    public partial class TollRoadTable : Form
    {

        readonly public TollStationController tollStationController;
        readonly public TollRoadController tollRoadController;
        public TollStation tollStation;
        public TollRoadTable(TollStation tollStation)
        {
            InitializeComponent();
            tollStationController = Globals.container.Resolve<TollStationController>();
            tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.tollStation = tollStation;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TollRoadTable_Load(object sender, EventArgs e)
        {
            label3.Text = tollStation.name.ToUpper();
            DataTable tollRoadTable = new DataTable();
            tollRoadTable.Columns.Add("BROJ NAPLATNOG MJESTA");
            tollRoadTable.Columns.Add("AKTIVNOST");
            List<TollRoad> tollRoadList = new List<TollRoad>();
            foreach (ObjectId o in tollStation.tollRoadIds) {
                tollRoadList.Add(tollRoadController.GetById(o));
            
            }
            foreach (TollRoad tr in tollRoadList)
            {
                if (tr.active) {
                    tollRoadTable.Rows.Add(tr.number, "AKTIVNA");
                }
                else
                {
                    tollRoadTable.Rows.Add(tr.number, "DEAKTIVIRANA");
                }
            }
            dataGridView1.DataSource = tollRoadTable;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TollRoadAddForm tollRoadAddForm = new TollRoadAddForm();

        }
    }
}
