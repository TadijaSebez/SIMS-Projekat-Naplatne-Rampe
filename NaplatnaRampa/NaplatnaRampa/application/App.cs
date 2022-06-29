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
using System.Threading;
using NaplatnaRampa.contoller;

namespace NaplatnaRampa.application
{
    internal class App
    {
        public static void Main(string[] args)
        {    
            Globals.Load();


            // Application.Run(new Login(Globals.database));
           // Application.Run(new TableUsers());
            Thread backgroundThread = new Thread(DetectionSimulation);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();

//            Application.Run(new Login(Globals.database));

            //Application.Run(new TablePricelists());
            //  IPricelistRepository repo = Globals.container.Resolve<IPricelistRepository>();
            //Application.Run(new TablePricelistItems(repo.GetAll()[1]));

            Application.Run(new TollStationTable());
            //Application.Run(new TollStationReport());
            //Application.Run(new IncomeReport());
            //TollStationController tsc = Globals.container.Resolve<TollStationController>();
            //Application.Run(new MalfunctionTable(tsc.GetByName("Inđija")));
        }

    
        private static void DetectionSimulation()
        {
            Random rng = new Random();
            
            MalfunctionController malfunctionController = Globals.container.Resolve<MalfunctionController>();
            
            while (true)
            {
                Thread.Sleep(10 * 1000);
                if (rng.Next(5) == 0) // Chances for failure are 20%
                {
                    malfunctionController.SimulateDetection(rng);
                }
            }
        }
        
    }
   }
