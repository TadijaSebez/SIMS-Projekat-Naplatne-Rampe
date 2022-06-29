using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Autofac;
using NaplatnaRampa.contoller;
using NaplatnaRampa.model;
namespace NaplatnaRampa.view
{
    public partial class SelectTollStation : Form
    {
        readonly public TollStationController tollStationController;
        readonly public PlaceController placeController;
        public SelectTollStation()
        {
            InitializeComponent();
            tollStationController = Globals.container.Resolve<TollStationController>();
            placeController = Globals.container.Resolve<PlaceController>();
          
        }

        private void SelectTollStation_Load(object sender, EventArgs e)
        {
            DataTable tollStationTable = new DataTable();
            tollStationTable.Columns.Add("NAZIV");
            tollStationTable.Columns.Add("MESTO");
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
            MalfunctionTable malfunctionTable = new MalfunctionTable(tollStation);
            malfunctionTable.Show();
        }
    }
}
