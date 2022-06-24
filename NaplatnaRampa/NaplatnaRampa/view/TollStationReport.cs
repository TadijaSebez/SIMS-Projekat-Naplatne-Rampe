using Autofac;
using NaplatnaRampa.contoller;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NaplatnaRampa.view
{
    public partial class TollStationReport : Form
    {
        readonly public TollStationController tollStationController;
        readonly public PlaceController placeController;
        public TollStationReport()
        {
            InitializeComponent();
            tollStationController = Globals.container.Resolve<TollStationController>();
            placeController = Globals.container.Resolve<PlaceController>();
        }

        private void TollStationReport_Load(object sender, EventArgs e)
        {
            DataTable tollStationTable = new DataTable();
            tollStationTable.Columns.Add("Naziv");
            tollStationTable.Columns.Add("Mesto");
            foreach (TollStation ts in tollStationController.TollStations())
            {
                Place place = placeController.GetById(ts.placeId);
                tollStationTable.Rows.Add(ts.name, place.name);

            }
            dataGridView1.DataSource = tollStationTable;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedTollStationName = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            TollStation tollStation = tollStationController.GetByName(selectedTollStationName);
            MalfunctionTable tr = new MalfunctionTable(tollStation);
            tr.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
