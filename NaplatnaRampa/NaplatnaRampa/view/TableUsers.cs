using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.contoller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NaplatnaRampa.view
{
    public partial class TableUsers : Form
    {
        readonly public UserController userController;
        readonly public AddressController addressController;
        readonly public PlaceController placeController;
        public TableUsers()
        {
            InitializeComponent();
            userController = Globals.container.Resolve<UserController>();
            addressController = Globals.container.Resolve<AddressController>();
            placeController = Globals.container.Resolve<PlaceController>();
        }

       

        private void TableUsers_Load(object sender, EventArgs e)
        {
             DataTable userTable = new DataTable();
            userTable.Columns.Add("Ime");
            userTable.Columns.Add("Prezime");
            userTable.Columns.Add("Email");
            userTable.Columns.Add("Adresa");
            userTable.Columns.Add("Mesto");
            userTable.Columns.Add("Uloga");
            foreach (User user in userController.Users())
            {
                Address address = addressController.GetById(user.addressId);
                Place place = placeController.GetById(address.placeId);
                userTable.Rows.Add(user.name, user.surname, user.email, address.street + " " + address.number, place.name, userController.getRoleString(user.role));
            }
            usersGridView.DataSource = userTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

