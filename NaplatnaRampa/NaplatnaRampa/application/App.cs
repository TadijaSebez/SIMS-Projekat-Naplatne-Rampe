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
using Autofac;

namespace NaplatnaRampa.application
{
    internal class App
    {
        public static void Main(string[] args)
        {
            Globals.Load();

           // Application.Run(new Login(Globals.database));
            //Application.Run(new TableUsers());
            //Application.Run(new TablePricelists());
          //  IPricelistRepository repo = Globals.container.Resolve<IPricelistRepository>();
            //Application.Run(new TablePricelistItems(repo.GetAll()[1]));
             Application.Run(new TollStationTable());
       }
    }
}
