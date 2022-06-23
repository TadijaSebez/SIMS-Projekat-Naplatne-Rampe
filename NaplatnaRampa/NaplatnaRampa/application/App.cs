using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using NaplatnaRampa.view;
using System.Windows.Forms;
using MongoDB.Bson;

namespace NaplatnaRampa.application
{
    internal class App
    {
        public static void Main(string[] args)
        {
            Globals.Load();

            Application.Run(new Login(Globals.database));
            //Application.Run(new TableUsers());
        }
    }
}
