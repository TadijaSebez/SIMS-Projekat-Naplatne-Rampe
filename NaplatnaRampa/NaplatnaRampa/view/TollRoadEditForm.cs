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
    public partial class TollRoadEditForm : Form
    {

        public TollRoad tollRoad;
        public TollStation tollstation;
        public TollRoadController tollRoadController;
        public TollRoadEditForm(TollRoad tollRoad, TollStation tollstation)
        {
            InitializeComponent();
            this.tollRoad = tollRoad;
            this.tollstation = tollstation;
            tollRoadController = Globals.container.Resolve<TollRoadController>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String broj = textBox1.Text;
            int brojMjesta = int.Parse(broj);
            tollRoad.number = brojMjesta;
            tollRoadController.Update(tollRoad);
            MessageBox.Show("NAPLATNO MJESTO JE USPJESNO AZURIRANO!");
            this.Hide();

        }

        private void TollRoadEditForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
