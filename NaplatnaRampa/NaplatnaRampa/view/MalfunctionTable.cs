using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.contoller;
namespace NaplatnaRampa.view
{
    public partial class MalfunctionTable : Form
    {
        public MalfunctionController malfunctionController;
        public TollStationController tollStationController;
        public MalfunctionTable()
        {
            InitializeComponent();
            malfunctionController = Globals.container.Resolve<MalfunctionController>();
            tollStationController = Globals.container.Resolve<TollStationController>();
        }

        private void ManufactionTable_Load(object sender, EventArgs e)
        {
            DataTable malfunctionTable = new DataTable();
            malfunctionTable.Columns.Add("Naplatna stanica");
            malfunctionTable.Columns.Add("Uredjaj");
            malfunctionTable.Columns.Add("Opis");
            malfunctionTable.Columns.Add("Datum nastanka kvara");
            malfunctionTable.Columns.Add("Otklonjen kvar");
            malfunctionTable.Columns.Add("Datum popravljanja kvara");
            foreach (Malfunction malfunction in malfunctionController.Malfunctions())
            {
                TollStation tollStation = tollStationController.GetById(malfunction.tollStationId);
                malfunctionTable.Rows.Add(tollStation.name, malfunction.name, malfunction.description, malfunction.dateTimeBegin, malfunction.fixing, malfunction.dateTimeEnd);
            }
            malfunctionGridView.DataSource = malfunctionTable;

        }

        private void malfunctionGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
