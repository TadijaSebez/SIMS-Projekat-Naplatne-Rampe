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
    public partial class TollStationTable : Form
    {

        readonly public TollStationController tollStationController;
        readonly public PlaceController placeController;
        public DataTable tollStationTable;
        public TollStationTable()
        {
            InitializeComponent();
            tollStationController = Globals.container.Resolve<TollStationController>();
            placeController = Globals.container.Resolve<PlaceController>();
            this.tollStationTable = new DataTable();
        }


        private void TollStationCRUD_Load(object sender, EventArgs e)
        {
            tollStationController.AddUpdateCallback(RefreshTable);
            tollStationTable.Columns.Add("NAZIV");
            tollStationTable.Columns.Add("MJESTO");
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
            TollRoadTable tr = new TollRoadTable(tollStation);
            tr.Show();
        }

        private void button1_Click(object sender, EventArgs e)      // add
        {
            TollStationCreateForm t = new TollStationCreateForm();
            t.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tollStationTable.Clear();
            foreach (TollStation ts in tollStationController.TollStations())
            {
                Place place = placeController.GetById(ts.placeId);
                tollStationTable.Rows.Add(ts.name, place.name);

            }
            dataGridView1.DataSource = tollStationTable;

        }

        public void RefreshTable()
        {
            tollStationTable.Clear();
            foreach (TollStation ts in tollStationController.TollStations())
            {
                Place place = placeController.GetById(ts.placeId);
                tollStationTable.Rows.Add(ts.name, place.name);

            }
            dataGridView1.DataSource = tollStationTable;
        }


        /*
        private void button2_Click(object sender, EventArgs e)         // delete OVO JE ZA KIKUUU !!!!
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedTollStationName = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
                TollStation tollStationForDelete = tollStationController.GetByName(selectedTollStationName);
                tollStationController.Delete(tollStationForDelete._id);
                MessageBox.Show("NAPLATNA STANICA JE USPJESNO OBRISANA!");
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                messageLabel.Text = "NISTE IZABRALI NAPLATNU STANICU!";
                messageLabel.Visible = true;

            }

            

        }

        private void updateTable() {
            this.dataGridView1.Rows.Clear();
            List<TollStation> tollStations = tollStationController.TollStations();
            DataTable tollStationTable = new DataTable();
            foreach (TollStation ts in tollStations) {
                Place place = placeController.GetById(ts.placeId);
                tollStationTable.Rows.Add(ts.name, place.name);

            }
            dataGridView1.DataSource = tollStationTable;


        }

        private void Edit_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedTollStationName = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
             //   Appointment apointment = appointmentService.GetById(new ObjectId(selectedAppointmentId));
              //  UpdateAppointment changdeAppointmentDateTimeForm = new UpdateAppointment(apointment);
              //  changdeAppointmentDateTimeForm.Show();
            }
            else
            {
               // messageLabel.Text = "Appointment is not selected!";
               // messageLabel.Visible = true;

            }
        }
    }
        */

    }
}
