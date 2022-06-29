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


            Thread backgroundThread = new Thread(DetectionSimulation);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
            Application.Run(new Login(Globals.database));

            

     
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
