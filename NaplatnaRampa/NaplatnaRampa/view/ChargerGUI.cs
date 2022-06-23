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
    public partial class ChargerGUI : Form
    {
        public User loggedUser { get; set; }
        public ChargerGUI(User loggedUser)
        {

            this.loggedUser = loggedUser;
            InitializeComponent();
        }

        private void ChargerGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
