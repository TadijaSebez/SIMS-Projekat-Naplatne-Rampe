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
    public partial class TablePricelistItems : Form
    {
        readonly private PricelistItemController pricelistItemController;
        readonly private SectionController sectionController;
        readonly private TollStationController tollStationController;
        private Pricelist pricelist;
        public TablePricelistItems(Pricelist pricelist)
        {
            InitializeComponent();
            pricelistItemController = Globals.container.Resolve<PricelistItemController>();
            sectionController = Globals.container.Resolve<SectionController>();
            tollStationController = Globals.container.Resolve<TollStationController>();
            this.pricelist = pricelist;
        }

        private void TablePricelistItems_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Deonica");
            table.Columns.Add("Tip vozila");
            table.Columns.Add("Iznos");
            table.Columns.Add("Valuta");
            foreach (PricelistItem item in pricelistItemController.PricelistItems(pricelist))
            {
                Section section = sectionController.GetById(item.sectionId);
                TollStation firstStation = tollStationController.GetById(section.firstStationId);
                TollStation secondStation = tollStationController.GetById(section.secondStationId);
                String vehicleTypeStr = "";
                if (item.vehicleType == Vehicle.VehicleType.MOTORCYCLE)
                    vehicleTypeStr = "Motor";
                else if (item.vehicleType == Vehicle.VehicleType.PASSENGER)
                    vehicleTypeStr = "Putničko vozilo";
                else
                    vehicleTypeStr = "Kamion";
                table.Rows.Add(firstStation.name + " - " + secondStation.name, vehicleTypeStr, item.price, item.currency);
            }
            dataGridView1.DataSource = table;
        }
    }
}
