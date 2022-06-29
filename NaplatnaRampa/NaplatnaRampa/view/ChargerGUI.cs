using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Autofac;
using NaplatnaRampa.contoller;
using NaplatnaRampa.model;

namespace NaplatnaRampa.view
{
    public partial class ChargerGUI : Form
    {
        public User loggedUser { get; set; }
        readonly private TollStationController tollStationController;
        readonly private TollRoadController tollRoadController;
        readonly private SectionController sectionController;
        readonly private PricelistController pricelistController;
        readonly private SlipController slipController;
        readonly private PhysicalPaymentController physicalPaymentController;
        readonly private MalfunctionController malfunctionController;

        private Random rng;

        private bool selectedVehicleType;
        private Vehicle.VehicleType vehicleType;

        private bool selectedCurrency;
        private Currency.TypeOfCurrency currency;

        private bool calculatedPrice;
        private TollStation slipTollStation;
        private TollRoad slipTollRoad;
        private DateTime slipDateTime;
        private string slipTables;
        private DateTime paymentDateTime;

        private bool selectedWorkPlace;
        private TollStation workTollStation;
        private TollRoad workTollRoad;
        
        private Section section;
        private PricelistItem pricelistItem;

        public ChargerGUI(User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.vehicleType = Vehicle.VehicleType.PASSENGER;
            this.currency = Currency.TypeOfCurrency.RSD;

            this.rng = new Random();

            this.tollStationController = Globals.container.Resolve<TollStationController>();
            this.tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.sectionController = Globals.container.Resolve<SectionController>();
            this.pricelistController = Globals.container.Resolve<PricelistController>();
            this.slipController = Globals.container.Resolve<SlipController>();
            this.physicalPaymentController = Globals.container.Resolve<PhysicalPaymentController>();
            this.malfunctionController = Globals.container.Resolve<MalfunctionController>();

            this.calculatedPrice = false;
            this.selectedWorkPlace = false;
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            this.vehicleType = Vehicle.VehicleType.MOTORCYCLE;
            selectedVehicleType = true;
            
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button1.FlatAppearance.BorderSize = 4;
            
            button2.FlatStyle = FlatStyle.Standard;
            button3.FlatStyle = FlatStyle.Standard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.vehicleType = Vehicle.VehicleType.PASSENGER;
            selectedVehicleType = true;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button2.FlatAppearance.BorderSize = 4;

            button1.FlatStyle = FlatStyle.Standard;
            button3.FlatStyle = FlatStyle.Standard;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.vehicleType = Vehicle.VehicleType.TRUCK;
            selectedVehicleType = true;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button3.FlatAppearance.BorderSize = 4;

            button1.FlatStyle = FlatStyle.Standard;
            button2.FlatStyle = FlatStyle.Standard;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.currency = Currency.TypeOfCurrency.RSD;
            selectedCurrency = true;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button4.FlatAppearance.BorderSize = 4;

            button5.FlatStyle = FlatStyle.Standard;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.currency = Currency.TypeOfCurrency.EUR;
            selectedCurrency = true;

            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            button5.FlatAppearance.BorderSize = 4;

            button4.FlatStyle = FlatStyle.Standard;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.calculatedPrice = false;

            if (!selectedVehicleType)
            {
                MessageBox.Show("Niste izabrali tip vozila!");
                return;
            }

            if (!selectedCurrency)
            {
                MessageBox.Show("Niste izabrali valutu!");
                return;
            }

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

            section = sectionController.GetByStations(slipTollStation, workTollStation);
            if (section == null) 
            {
                MessageBox.Show("Deonica " + slipTollStationStr + " - " + workTollStation.name + " ne postoji u sistemu!", "Greška");
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

            slipTollStationTextBox.Enabled = false;
            slipTollRoadNumberTextBox.Enabled = false;
            slipTimeTextBox.Enabled = false;
            slipTablesTextBox.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            button7.Enabled = false;

            button6.Enabled = true;
            paidAmountTextBox.Enabled = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!calculatedPrice)
                return;

            float paidAmount;
            if (!float.TryParse(paidAmountTextBox.Text.Trim(), out paidAmount))
            {
                MessageBox.Show("Greška u parsiranju uplaćene vrednosti!", "Greška");
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

            button6.Enabled = false;
            paidAmountTextBox.Enabled = false;

            if (speed > 130.0f)
            {
                MessageBox.Show("Uspešno ste izvršili naplatu! Prekoračenje brzine! Prosečna brzina je " + speed + " km/h", "Upozorenje");
            }
            else
            {
                MessageBox.Show("Uspešno ste izvršili naplatu! Prosečna brzina vozila je " + speed + " km/h", "Obaveštenje");
            }

            Thread backgroundThread = new Thread(StateChanges);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();

        }

        private void StateChanges()
        {
            stateLabel.Invoke(new Action(() => stateLabel.Text = "Rampa se podiže"));
            Thread.Sleep(2000);
            stateLabel.Invoke(new Action(() => stateLabel.Text = "Rampa je podignuta"));
            Thread.Sleep((rng.Next(6) + 3) * 1000);
            stateLabel.Invoke(new Action(() => stateLabel.Text = "Rampa se spušta"));
            Thread.Sleep(2000);
            stateLabel.Invoke(new Action(() => stateLabel.Text = "Rampa je spuštena"));

            slipTollStationTextBox.Invoke(new Action(() => slipTollStationTextBox.Text = ""));
            slipTollStationTextBox.Invoke(new Action(() => slipTollStationTextBox.Enabled = true));
            slipTollRoadNumberTextBox.Invoke(new Action(() => slipTollRoadNumberTextBox.Text = ""));
            slipTollRoadNumberTextBox.Invoke(new Action(() => slipTollRoadNumberTextBox.Enabled = true));
            slipTimeTextBox.Invoke(new Action(() => slipTimeTextBox.Text = ""));
            slipTimeTextBox.Invoke(new Action(() => slipTimeTextBox.Enabled = true));
            slipTablesTextBox.Invoke(new Action(() => slipTablesTextBox.Text = ""));
            slipTablesTextBox.Invoke(new Action(() => slipTablesTextBox.Enabled = true));

            selectedVehicleType = false;
            button1.Invoke(new Action(() => button1.FlatStyle = FlatStyle.Standard));
            button1.Invoke(new Action(() => button1.Enabled = true));
            button2.Invoke(new Action(() => button2.FlatStyle = FlatStyle.Standard));
            button2.Invoke(new Action(() => button2.Enabled = true));
            button3.Invoke(new Action(() => button3.FlatStyle = FlatStyle.Standard));
            button3.Invoke(new Action(() => button3.Enabled = true));

            selectedCurrency = false;
            button4.Invoke(new Action(() => button4.FlatStyle = FlatStyle.Standard));
            button4.Invoke(new Action(() => button4.Enabled = true));
            button5.Invoke(new Action(() => button5.FlatStyle = FlatStyle.Standard));
            button5.Invoke(new Action(() => button5.Enabled = true));

            calculatedPrice = false;
            priceTextBox.Invoke(new Action(() => priceTextBox.Text = ""));
            changeTextBox.Invoke(new Action(() => changeTextBox.Text = ""));
            paidAmountTextBox.Invoke(new Action(() => paidAmountTextBox.Text = ""));

            button7.Invoke(new Action(() => button7.Enabled = true));
        }

        private void ChargerGUI_Load(object sender, EventArgs e)
        {
            slipTollStationTextBox.Enabled = false;
            slipTollRoadNumberTextBox.Enabled = false;
            slipTimeTextBox.Enabled = false;
            slipTablesTextBox.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            button7.Enabled = false;
            
            paidAmountTextBox.Enabled = false;
            button6.Enabled = false;
        }

        private void slipTollStationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void slipTollRoadNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
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

            if (malfunctionController.IsInMalfunction(workTollStation))
            {
                stateLabel.Text = "U kvaru";
            }
            else
            {
                stateLabel.Text = "Rampa je spuštena";

                selectedWorkPlace = true;
                tollStationTextBox.Enabled = false;
                tollRoadNumberTextBox.Enabled = false;
                button8.Enabled = false;


                slipTollStationTextBox.Enabled = true;
                slipTollRoadNumberTextBox.Enabled = true;
                slipTimeTextBox.Enabled = true;
                slipTablesTextBox.Enabled = true;

                selectedVehicleType = false;
                button1.Enabled = true;
                button1.FlatStyle = FlatStyle.Standard;
                button2.Enabled = true;
                button2.FlatStyle = FlatStyle.Standard;
                button3.Enabled = true;
                button3.FlatStyle = FlatStyle.Standard;

                selectedCurrency = false;
                button4.Enabled = true;
                button4.FlatStyle = FlatStyle.Standard;
                button5.Enabled = true;
                button5.FlatStyle = FlatStyle.Standard;

                button7.Enabled = true;
            }
        }
    }
}
