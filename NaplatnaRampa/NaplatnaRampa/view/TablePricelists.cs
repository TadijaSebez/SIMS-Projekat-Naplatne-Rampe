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
    public partial class TablePricelists : Form
    {
        readonly private PricelistController pricelistController;
        public TablePricelists()
        {
            InitializeComponent();
            pricelistController = Globals.container.Resolve<PricelistController>();
        }

        private void TablePricelists_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Datim pocetka vazenja");
            table.Columns.Add("Broj stavki");
            this.pricelists = pricelistController.Pricelists();
            foreach (Pricelist pricelist in this.pricelists)
            {
                table.Rows.Add(pricelist.validFrom.ToString("dd-MM-yyyy"), pricelist.itemIds.Count);
            }
            gridView.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                index = row.Index;
            }

            if (index != -1)
            {
                TablePricelistItems table = new TablePricelistItems(pricelists[index]);
                table.Show();
            }
        }

        private List<Pricelist> pricelists;

        private void button2_Click(object sender, EventArgs e)
        {
            Pricelist pricelist = pricelistController.GetActive();

            if (pricelist != null)
            {
                TablePricelistItems table = new TablePricelistItems(pricelist);
                table.Show();
            }
            else
            {
                MessageBox.Show("Cena za deonicu nije u sistemu!", "Greška");
            }
        }
    }
}
