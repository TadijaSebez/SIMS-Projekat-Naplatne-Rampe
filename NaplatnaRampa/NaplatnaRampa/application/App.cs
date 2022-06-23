using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using NaplatnaRampa.view;
using System.Windows.Forms;

namespace NaplatnaRampa.application
{
    internal class App
    {
        public static void Main(string[] args)
        {
            Globals.Load();

         //   UserRepository repo = new UserRepository();
           // repo.Insert(new User("Ime", "Prezime", "mejl", "pass", "tel", new Address("ulica", 4, new Place(132, "nesto")._id)._id));
            
           // Login login = new Login();
            Application.Run(new Login(Globals.database));
        }
    }
}
