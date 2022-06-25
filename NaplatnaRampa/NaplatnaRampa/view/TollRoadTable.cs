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
        public DataTable tollRoadTable;
        public TollRoadTable(TollStation tollStation)
        {
            InitializeComponent();
            tollStationController = Globals.container.Resolve<TollStationController>();
            tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.tollStation = tollStation;
            this.tollRoadTable = new DataTable();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TollRoadTable_Load(object sender, EventArgs e)
        {
            label3.Text = tollStation.name.ToUpper();
         
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
            TollRoadAddForm tollRoadAddForm = new TollRoadAddForm(tollStation);
            tollRoadAddForm.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tollRoadTable.Clear();
            List<TollRoad> tollRoadList = new List<TollRoad>();
            foreach (ObjectId o in tollStation.tollRoadIds)
            {
                tollRoadList.Add(tollRoadController.GetById(o));

            }
            foreach (TollRoad tr in tollRoadList)
            {
                if (tr.active)
                {
                    tollRoadTable.Rows.Add(tr.number, "AKTIVNA");
                }
                else
                {
                    tollRoadTable.Rows.Add(tr.number, "DEAKTIVIRANA");
                }
            }
            dataGridView1.DataSource = tollRoadTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedTollRoadNumber = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            int num = int.Parse(selectedTollRoadNumber);
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
                label5.Visible = false;
                TollRoad tollRoadForDelete = tollRoadController.GetByStationAndNumber(tollStation, num);
                tollRoadForDelete.active = false;
                tollRoadController.Update(tollRoadForDelete);

                MessageBox.Show("NAPLATNO MJESTO JE USPJESNO DEATKIVIRANO!");
             //   dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                label5.Text = "NISTE IZABRALI NAPLATNU STANICU!";
                label5.Visible = true;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedTollRoadNumber = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            int num = int.Parse(selectedTollRoadNumber);
            TollRoad tollRoad = tollRoadController.GetByStationAndNumber(tollStation, num);
            TollRoadEditForm tollRoadEditForm = new TollRoadEditForm(tollRoad, tollStation);
            tollRoadEditForm.ShowDialog();
        }
    }
}
