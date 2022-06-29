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
        public TollRoadController tollRoadController;
        public TollStation tollStationSelected;
        private List<Malfunction> malfunctions;
        public MalfunctionTable(TollStation tollStation)
        {
            InitializeComponent();
            malfunctionController = Globals.container.Resolve<MalfunctionController>();
            tollStationController = Globals.container.Resolve<TollStationController>();
            tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.tollStationSelected = tollStation;
            label2.Text = tollStation.name;
        }

        private void CreateTable()
        {
            this.malfunctions = new List<Malfunction>();

            DataTable malfunctionTable = new DataTable();
            malfunctionTable.Columns.Add("Broj naplatnog mesta");
            malfunctionTable.Columns.Add("Uredjaj");
            malfunctionTable.Columns.Add("Opis");
            malfunctionTable.Columns.Add("Datum nastanka kvara");
            malfunctionTable.Columns.Add("Otklonjen kvar");
            malfunctionTable.Columns.Add("Datum popravljanja kvara");
            
            List<Malfunction> allMalfunctions = malfunctionController.Malfunctions();
            allMalfunctions.Sort(delegate(Malfunction x, Malfunction y) { return y.dateTimeBegin.CompareTo(x.dateTimeBegin); });
            
            foreach (Malfunction malfunction in allMalfunctions)
            {
                TollRoad tollRoad = tollRoadController.GetById(malfunction.tollRoadId);
                TollStation tollStation = tollStationController.GetById(tollRoad.tollStationId);
                if (tollStation.name.Equals(tollStationSelected.name))
                {
                    malfunctionTable.Rows.Add(tollRoad.number, malfunction.name, malfunction.description, malfunction.dateTimeBegin, malfunction.fixing, malfunction.dateTimeEnd == DateTime.MaxValue ? "/" : malfunction.dateTimeEnd.ToString());
                    this.malfunctions.Add(malfunction);
                }

            }
            malfunctionGridView.DataSource = malfunctionTable;
        }

        private void Form1_Closing(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            malfunctionController.RemoveUpdateCallback();
        }
        private void ManufactionTable_Load(object sender, EventArgs e)
        {
            CreateTable();
            malfunctionController.AddUpdateCallback(() => malfunctionGridView.Invoke(new Action(() => CreateTable())));
        }

        private void malfunctionGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;
            foreach (DataGridViewRow row in malfunctionGridView.SelectedRows)
            {
                index = row.Index;
            }

            if (index != -1)
            {
                Malfunction malfunction = malfunctions[index];
                if (!malfunction.fixing)
                {
                    malfunction.fixing = true;
                    malfunction.dateTimeEnd = DateTime.Now;
                    malfunctionController.Update(malfunction);
                    CreateTable();
                }
            }
        }
    }
}
