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
    public partial class BossGUI : Form
    {

        public User loggedUser { get; set; }
        public BossGUI(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void BossGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
