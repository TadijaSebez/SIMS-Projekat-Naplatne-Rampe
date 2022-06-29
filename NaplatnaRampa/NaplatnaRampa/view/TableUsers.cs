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
using MongoDB.Bson;

namespace NaplatnaRampa.view
{
    public partial class TableUsers : Form
    {
        readonly public UserController userController;
        readonly public AddressController addressController;
        readonly public PlaceController placeController;
        public DataTable userTable;
        public TableUsers()
        {
            InitializeComponent();
            userController = Globals.container.Resolve<UserController>();
            addressController = Globals.container.Resolve<AddressController>();
            placeController = Globals.container.Resolve<PlaceController>();
            this.userTable = new DataTable();
        }

       

        private void TableUsers_Load(object sender, EventArgs e)
        {
             
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
                if(user.role != Role.ADMIN)
                {
                    userTable.Rows.Add(user.name, user.surname, user.email, address.street + " " + address.number, place.name, userController.getRoleString(user.role));
                }
               
            }
            usersGridView.DataSource = userTable;
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            AddNewUser addedNewUSer = new AddNewUser();
            addedNewUSer.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int rowindex = usersGridView.CurrentRow.Index;
            string selectedEmail = (string)usersGridView.Rows[rowindex].Cells[2].Value;
            User user = userController.GetUserByEmail(selectedEmail);
            if (usersGridView.Rows[rowindex].Cells[0].Value != null)
            {
                userController.Delete(user._id);
                MessageBox.Show("Korisnik je uspesno obrisan!");
            }
            else
            {
                MessageBox.Show("Korisnik nije izabran!");
                return;

            }

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            int rowindex = usersGridView.CurrentRow.Index;
            string selectedEmail = (string)usersGridView.Rows[rowindex].Cells[2].Value;
            User user = userController.GetUserByEmail(selectedEmail);
            if (usersGridView.Rows[rowindex].Cells[0].Value != null)
            {
                UpdateUser u = new UpdateUser(user);
                u.Show();
            }
            else
            {
                MessageBox.Show("Korisnik nije izabran!");
                return;

            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //refresh
            userTable.Clear();
            foreach (User user in userController.Users())
            {
                Address address = addressController.GetById(user.addressId);
                Place place = placeController.GetById(address.placeId);
                if (user.role != Role.ADMIN)
                {
                    userTable.Rows.Add(user.name, user.surname, user.email, address.street + " " + address.number, place.name, userController.getRoleString(user.role));
                }

            }
            usersGridView.DataSource = userTable;
        }
    }
}

