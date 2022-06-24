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
    public partial class ChargerGUI : Form
    {
        public User loggedUser { get; set; }
        private Vehicle.VehicleType vehicleType;
        private Currency.TypeOfCurrency currency;
        readonly private TollStationController tollStationController;
        readonly private TollRoadController tollRoadController;
        readonly private SectionController sectionController;
        readonly private PricelistController pricelistController;
        readonly private SlipController slipController;
        readonly private PhysicalPaymentController physicalPaymentController;
        
        private bool calculatedPrice;
        private TollStation slipTollStation;
        private TollRoad slipTollRoad;
        private DateTime slipDateTime;
        private string slipTables;
        private DateTime paymentDateTime;
        private TollStation workTollStation;
        private TollRoad workTollRoad;
        private Section section;
        private PricelistItem pricelistItem;

        public ChargerGUI(User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.vehicleType = Vehicle.VehicleType.PASSENGER;
            this.currency = Currency.TypeOfCurrency.RSD;

            this.tollStationController = Globals.container.Resolve<TollStationController>();
            this.tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.sectionController = Globals.container.Resolve<SectionController>();
            this.pricelistController = Globals.container.Resolve<PricelistController>();
            this.slipController = Globals.container.Resolve<SlipController>();
            this.physicalPaymentController = Globals.container.Resolve<PhysicalPaymentController>();

            this.calculatedPrice = false;
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            this.vehicleType = Vehicle.VehicleType.MOTORCYCLE;
            
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button1.FlatAppearance.BorderSize = 4;
            
            button2.FlatStyle = FlatStyle.Standard;
            button3.FlatStyle = FlatStyle.Standard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.vehicleType = Vehicle.VehicleType.PASSENGER;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button2.FlatAppearance.BorderSize = 4;

            button1.FlatStyle = FlatStyle.Standard;
            button3.FlatStyle = FlatStyle.Standard;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.vehicleType = Vehicle.VehicleType.TRUCK;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button3.FlatAppearance.BorderSize = 4;

            button1.FlatStyle = FlatStyle.Standard;
            button2.FlatStyle = FlatStyle.Standard;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.currency = Currency.TypeOfCurrency.RSD;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button4.FlatAppearance.BorderSize = 4;

            button5.FlatStyle = FlatStyle.Standard;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.currency = Currency.TypeOfCurrency.EUR;

            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button5.FlatAppearance.BorderSize = 4;

            button4.FlatStyle = FlatStyle.Standard;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.calculatedPrice = false;

            string slipTollStationStr = slipTollStationTextBox.Text.Trim();
            slipTollStation = tollStationController.GetByName(slipTollStationStr);
            if (slipTollStation == null)
            {
                MessageBox.Show("Naplatna stanica " + slipTollStationStr + " ne postoji!", "Greška");
                return;
            }

            int slipTollRoadNumber;
            if (!int.TryParse(tollRoadNumberTextBox.Text, out slipTollRoadNumber))
            {
                MessageBox.Show("Broj naplatnog mesta ne postoji!", "Greška");
                return;
            }
            slipTollRoad = tollRoadController.GetByStationAndNumber(slipTollStation, slipTollRoadNumber);
            if (slipTollRoad == null)
            {
                MessageBox.Show("Broj naplatnog mesta ne postoji!", "Greška");
                return;
            }

            string dateTimeStr = slipTimeTextBox.Text.Trim();
            bool ok = DateTime.TryParseExact(dateTimeStr, "dd-MM-yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out slipDateTime);
            if (!ok)
            {
                MessageBox.Show("Datum i vreme ulaska " + dateTimeStr + " nisu validni!", "Greška");
                return;
            }
            slipTables = slipTablesTextBox.Text;

            paymentDateTime = DateTime.Now;
            if (slipDateTime > paymentDateTime)
            {
                MessageBox.Show("Datum i vreme na slipu ne mogu biti u budućnosti!", "Greška");
                return;
            }

            string tollStationStr = tollStationTextBox.Text;
            workTollStation = tollStationController.GetByName(tollStationStr);
            if (workTollStation == null) 
            {
                MessageBox.Show("Naplatna stanica " + tollStationStr + " ne postoji!", "Greška");
                return;
            }

            int tollRoadNumber;
            if (!int.TryParse(tollRoadNumberTextBox.Text, out tollRoadNumber))
            {
                MessageBox.Show("Broj naplatnog mesta ne postoji!", "Greška");
                return;
            }
            workTollRoad = tollRoadController.GetByStationAndNumber(workTollStation, tollRoadNumber);
            if (workTollRoad == null)
            {
                MessageBox.Show("Broj naplatnog mesta ne postoji!", "Greška");
                return;
            }

            section = sectionController.GetByStations(slipTollStation, workTollStation);
            if (section == null) 
            {
                MessageBox.Show("Deonica " + slipTollStationStr + " - " + tollStationStr + " ne postoji u sistemu!", "Greška");
                return;
            }

            pricelistItem = pricelistController.GetPriceForSection(section, vehicleType, currency);
            if (pricelistItem == null)
            {
                MessageBox.Show("Cena za deonicu nije u sistemu!", "Greška");
                return;
            }

            priceTextBox.Text = pricelistItem.price.ToString();
            this.calculatedPrice = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!calculatedPrice)
                return;

            float paidAmount;
            if (!float.TryParse(paidAmountTextBox.Text.Trim(), out paidAmount))
            {
                MessageBox.Show("Cena za deonicu nije u sistemu!", "Greška");
                return;
            }

            if (paidAmount < pricelistItem.price)
            {
                MessageBox.Show("Uplaćeno je manje od cene!", "Greška");
                return;
            }

            changeTextBox.Text = (paidAmount - pricelistItem.price).ToString();

            Slip slip = new Slip(slipDateTime, slipTables, slipTollRoad._id);
            slipController.Save(slip);
            PhysicalPayment payment = new PhysicalPayment(pricelistItem.price, vehicleType, currency, workTollRoad._id, paymentDateTime, paidAmount, slip._id);
            physicalPaymentController.Save(payment);

            TimeSpan duration = paymentDateTime - slipDateTime;
            float hours = (float)duration.TotalHours;
            float speed = section.distance / hours;

            if (speed > 130.0f)
            {
                MessageBox.Show("Prekoračenje brzine! " + speed + " km/h", "Upozorenje");
            }
        }

        private void ChargerGUI_Load(object sender, EventArgs e)
        {

        }

        private void slipTollStationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void slipTollRoadNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
