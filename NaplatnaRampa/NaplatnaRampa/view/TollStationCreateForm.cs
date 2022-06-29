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
    public partial class TollStationCreateForm : Form
    {

        public PlaceController placeController;
        readonly public TollStationController tollStationController;
        public TollStationCreateForm()
        {
            InitializeComponent();
            this.placeController = Globals.container.Resolve<PlaceController>();
            tollStationController = Globals.container.Resolve<TollStationController>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String placeName = textBox2.Text;
            Random rnd = new Random();
            int num = rnd.Next();
            Place p = new Place(num, placeName);
            placeController.Insert(p);
            List<ObjectId> tollroads = new List<ObjectId>();
            TollStation tollStation = new TollStation(name, p._id, tollroads);
            tollStationController.Insert(tollStation);
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TollStationCreateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
