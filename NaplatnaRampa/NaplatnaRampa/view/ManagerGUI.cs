using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NaplatnaRampa.model;

namespace NaplatnaRampa.view
{
    public partial class ManagerGUI : Form
    {
        public User loggedUser { get; set; }
        public ManagerGUI(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;



        }
        private void ManagerGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
