using Autofac;
using NaplatnaRampa.contoller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NaplatnaRampa.model;

namespace NaplatnaRampa.view
{
    public partial class AddNewUser : Form
    {
        public UserController userController;
        public PlaceController placeController;
        public AddressController addressController;
        public AddNewUser()
        {
            InitializeComponent();
            userController = Globals.container.Resolve<UserController>();
            placeController = Globals.container.Resolve<PlaceController>();
            addressController = Globals.container.Resolve<AddressController>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String checkName = nameTextBox.Text.Trim();
            bool result = checkName.Any(x => !char.IsLetter(x));
            if (result || checkName.Equals(""))
            {
                MessageBox.Show("Samo slova sme da sadrži ime!", "Greška");
                return;
            }
            String checkSurname = surnameTextBox.Text.Trim();
            bool result1 = checkSurname.Any(y => !char.IsLetter(y));
            if (result1 || (checkSurname.Equals("")))
            {
                MessageBox.Show("Samo slova sme da sadrži prezime!", "Greška");
                return;
            }
            String checkEmail = emailTextBox.Text.Trim();
            if (checkEmail.Equals(""))
            {
                MessageBox.Show("Niste uneli email!", "Greška!");
                return;
            }
            if (!userController.IsValidEmail(checkEmail))
            {
                MessageBox.Show("Email nije validan!", "Greška");
                return;
            }
            foreach(User user in userController.Users())
            {
                if (user.email.Equals(checkEmail))
                {
                    MessageBox.Show("Korisnik sa ovim emailom već postoji!", "Greška");
                    return;
                }

            }
            String password = passwordTextBox.Text.Trim();
            String checkPassword = checkPasswordTextBox.Text.Trim();
            if ((password.Equals("")) || (checkPassword.Equals("")))
            {
                MessageBox.Show("Unesite lozinku!", "Greška");
                return;
            }
            if (!password.Equals(checkPassword)){
                MessageBox.Show("Lozinke se ne poklapaju!!", "Greška");
                return;
            }

            String checkStreet = streetTextBox.Text.Trim();
            if (checkStreet.Equals(""))
            {
                MessageBox.Show("Unesite ulicu!", "Greška");
                return;

            }
            int tryInt;
            String number = numberTextBox.Text.Trim();
            if (!int.TryParse(number, out tryInt))
            {
                MessageBox.Show("Niste dobro uneli broj!", "Greška");
                return;
            }
            String place = placeTextBox.Text.Trim();
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

            String phone = phoneTextBox.Text.Trim();
            if (phone.Equals("")) {
                MessageBox.Show("Niste uneli telefon!", "Greška!");
                return;
            }
             String checkRole= comboBox1.Text;
            Role role;
            if (checkRole.Equals("Šef stanice"))
            {
                role = Role.BOSS;
            }else if (checkRole.Equals("Referent naplate"))
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
            
            Address address = new Address(checkStreet, int.Parse(number), placeController.GetByName(place)._id);
            addressController.Save(address);
            User newUser = new User(checkName, checkSurname, checkEmail, password, phone, address._id, role);
            userController.Save(newUser);
            MessageBox.Show("Uspešno ste dodali korisnika", "Obaveštenje");

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void streetTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
