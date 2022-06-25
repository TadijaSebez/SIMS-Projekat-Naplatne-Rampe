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
    public partial class TollRoadAddForm : Form
    {

        readonly public TollRoadController tollRoadController;
        readonly public TollStationController tollStationController;
        public TollStation tollStation;
       
        public TollRoadAddForm(TollStation tollStation)
        {
            InitializeComponent();
            this.tollStation = tollStation;
            tollStationController = Globals.container.Resolve<TollStationController>();
            tollRoadController = Globals.container.Resolve<TollRoadController>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String broj = textBox1.Text;
            int brojMjesta = int.Parse(broj);
            TollRoad tr = new TollRoad(brojMjesta, tollStation._id);
            tollRoadController.Insert(tr);
            tollStation.tollRoadIds.Add(tr._id);
            tollStationController.Update(tollStation);
            MessageBox.Show("NAPLATNO MJESTO JE USPJESNO DODATO!");
            this.Hide();
        }

     

        private void TollRoadAddForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
