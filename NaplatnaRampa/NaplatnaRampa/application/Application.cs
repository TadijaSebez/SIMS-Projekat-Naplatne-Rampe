using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;

namespace NaplatnaRampa.application
{
    internal class Application
    {
        public static void Main(string[] args)
        {

            UserRepository repo = new UserRepository();
            repo.Insert(new User("Ime", "Prezime", "mejl", "pass", "tel", new Address("ulica", 4, new Place(132, "nesto")._id)._id));
        

        }
    }
}
