using Autofac;
using NaplatnaRampa.contoller;
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
    public partial class MalfunctionAllReport : Form
    {
        public MalfunctionController malfunctionController;
        public TollStationController tollStationController;
        public TollRoadController tollRoadController;

        public MalfunctionAllReport()
        {
            InitializeComponent();
            malfunctionController = Globals.container.Resolve<MalfunctionController>();
            tollStationController = Globals.container.Resolve<TollStationController>();
            tollRoadController = Globals.container.Resolve<TollRoadController>();
        }

        private void MalfunctionAllReport_Load(object sender, EventArgs e)
        {
            DataTable malfunctionTable = new DataTable();
            malfunctionTable.Columns.Add("Stanica");
            malfunctionTable.Columns.Add("Broj naplatnog mesta");
            malfunctionTable.Columns.Add("Uredjaj");
            malfunctionTable.Columns.Add("Opis");
            malfunctionTable.Columns.Add("Datum nastanka kvara");
            malfunctionTable.Columns.Add("Otklonjen kvar");
            malfunctionTable.Columns.Add("Datum popravljanja kvara");
            List<Malfunction> allMalfunctions = malfunctionController.Malfunctions();
            allMalfunctions.Sort(delegate (Malfunction x, Malfunction y) { return y.dateTimeBegin.CompareTo(x.dateTimeBegin); });
            foreach (Malfunction malfunction in allMalfunctions)
            {
                TollRoad tollRoad = tollRoadController.GetById(malfunction.tollRoadId);
                TollStation tollStation = tollStationController.GetById(tollRoad.tollStationId);
                malfunctionTable.Rows.Add(tollStation.name, tollRoad.number, malfunction.name, malfunction.description, malfunction.dateTimeBegin, malfunction.fixing, malfunction.dateTimeEnd == DateTime.MaxValue ? "/" : malfunction.dateTimeEnd.ToString());
              
         
            }
            dataGridView1.DataSource = malfunctionTable;

        }
    }
}
