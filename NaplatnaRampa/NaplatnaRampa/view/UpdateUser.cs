using Autofac;
using NaplatnaRampa.contoller;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NaplatnaRampa.view
{
    public partial class UpdateUser : Form
    {

        public UserController userController;
        public PlaceController placeController;
        public AddressController addressController;
        public User selectedUser { get; set; }
        public UpdateUser(User selectedUser)
        {
            this.selectedUser = selectedUser;
            InitializeComponent();
            userController = Globals.container.Resolve<UserController>();
            placeController = Globals.container.Resolve<PlaceController>();
            addressController = Globals.container.Resolve<AddressController>();
            label11.Text = selectedUser.email;
            textBox1.Text = selectedUser.name;
            textBox2.Text = selectedUser.surname;
            textBox4.Text = selectedUser.password;
            textBox5.Text = selectedUser.password;
            Address a = addressController.GetById(selectedUser.addressId);
            textBox6.Text = a.street;
            Place p = placeController.GetById(a.placeId);
            textBox7.Text = p.name;
            textBox8.Text = selectedUser.phone;
            textBox10.Text = a.number.ToString();
            comboBox1.SelectedIndex = userController.indexOfRoleComboBox(selectedUser.role);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String checkName = textBox1.Text.Trim();
            bool result = checkName.Any(x => !char.IsLetter(x));
            if (result || checkName.Equals(""))
            {
                MessageBox.Show("Samo slova sme da sadrži ime!", "Greška");
                return;
            }
            String checkSurname = textBox2.Text.Trim();
            bool result1 = checkSurname.Any(y => !char.IsLetter(y));
            if (result1 || (checkSurname.Equals("")))
            {
                MessageBox.Show("Samo slova sme da sadrži prezime!", "Greška");
                return;
            }
           
            String password = textBox4.Text.Trim();
            String checkPassword = textBox5.Text.Trim();
            if ((password.Equals("")) || (checkPassword.Equals("")))
            {
                MessageBox.Show("Unesite lozinku!", "Greška");
                return;
            }
            if (!password.Equals(checkPassword))
            {
                MessageBox.Show("Lozinke se ne poklapaju!!", "Greška");
                return;
            }

            String checkStreet = textBox6.Text.Trim();
            if (checkStreet.Equals(""))
            {
                MessageBox.Show("Unesite ulicu!", "Greška");
                return;

            }
            int tryInt;
            String number = textBox10.Text.Trim();
            if (!int.TryParse(number, out tryInt))
            {
                MessageBox.Show("Niste dobro uneli broj!", "Greška");
                return;
            }
            String place = textBox7.Text.Trim();
            if (place.Equals(""))
            {
                MessageBox.Show("Niste uneli mesto!", "Greška!");
                return;
            }
            if (!(placeController.CheckPlaceExist(place)))
            {
                MessageBox.Show("Uneto mesto ne postoji!", "Greška");
                return;
            }

            String phone = textBox8.Text.Trim();
            if (phone.Equals(""))
            {
                MessageBox.Show("Niste uneli telefon!", "Greška!");
                return;
            }
            String checkRole = comboBox1.Text;
            Role role;
            if (checkRole.Equals("Šef stanice"))
            {
                role = Role.BOSS;
            }
            else if (checkRole.Equals("Referent naplate"))
            {
                role = Role.CHARGEER;
            }
            else if (checkRole.Equals("Menadžer"))
            {
                role = Role.MENAGER;
            }
            else
            {
                MessageBox.Show("Niste izabrali ulogu!", "Greška");
                return;

            }

            selectedUser.name = checkName;
            selectedUser.surname = checkSurname;
            selectedUser.password = password;
            selectedUser.role = role;
            Address address = addressController.GetById(selectedUser.addressId);
            address.number = int.Parse(number);
            Place placeN = placeController.GetPlaceByName(place);
            address.placeId = placeN._id;
            selectedUser.addressId = address._id;
            addressController.Update(address);
            userController.Update(selectedUser);
            MessageBox.Show("Uspešno ste izmenili korisnika!", "Obaveštenje");
            return;
            
            


           


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void UpdateUser_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
