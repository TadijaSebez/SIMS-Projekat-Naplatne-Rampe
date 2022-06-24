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
                if(user.role != Role.ADMIN)
                {
                    userTable.Rows.Add(user.name, user.surname, user.email, address.street + " " + address.number, place.name, userController.getRoleString(user.role));
                }
               
            }
            usersGridView.DataSource = userTable;
        }

        private void Update()
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
                if (user.role != Role.ADMIN)
                {
                    userTable.Rows.Add(user.name, user.surname, user.email, address.street + " " + address.number, place.name, userController.getRoleString(user.role));
                }

            }
            usersGridView.DataSource = userTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
             this.usersGridView.Rows.Clear();
            List<User> allAppointments = userController.Users();

            foreach (User appointment in allAppointments)
            {
                DataGridViewRow row = (DataGridViewRow)usersGridView.Rows[0].Clone();

                row.Cells[1].Value = appointment._id;
                row.Cells[2].Value = appointment.name;
                row.Cells[3].Value = appointment.surname;

                usersGridView.Rows.Add(row);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
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
            Update();

        }

        private void button3_Click(object sender, EventArgs e)
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
            Update();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddNewUser addedNewUSer = new AddNewUser();
            addedNewUSer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.usersGridView.Rows.Clear();
            List<User> allAppointments = userController.Users();

            foreach (User appointment in allAppointments)
            {
                DataGridViewRow row = (DataGridViewRow)usersGridView.Rows[0].Clone();

                row.Cells[1].Value = appointment._id;
                row.Cells[2].Value = appointment.name;
                row.Cells[3].Value = appointment.surname;

                usersGridView.Rows.Add(row);

            }

        }
    }
}

