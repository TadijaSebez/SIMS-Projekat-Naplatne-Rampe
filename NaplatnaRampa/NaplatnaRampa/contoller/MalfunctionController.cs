using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MongoDB.Bson;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;

namespace NaplatnaRampa.contoller
{
    public class MalfunctionController
    {
        private IMalfunctionRepository malfunctionRepository;
        private TollStationController tollStationController;

        public MalfunctionController()
        {
            this.malfunctionRepository = Globals.container.Resolve<IMalfunctionRepository>();
            this.tollStationController = Globals.container.Resolve<TollStationController>();
        }

        public Malfunction GetById(ObjectId id)
        {
            return malfunctionRepository.GetById(id);
        }

        public void Save(Malfunction malfunction)
        {
            malfunctionRepository.Insert(malfunction);
        }

        public void SimulateDetection(Random rng)
        {
            TollStation tollStation = tollStationController.GetRandom(rng);

            List<string> possibleNames = new List<string>
            {
                "Čitač taga",
                "Čitač tablice",
                "Rampa"
            };

            string name = possibleNames[rng.Next(possibleNames.Count)];

            DateTime beginDateTime = DateTime.Now;
            int hours = rng.Next(100);
            int minutes = rng.Next(60);
            int seconds = rng.Next(60);
            TimeSpan deltaTime = new TimeSpan(hours, minutes, seconds);
            DateTime endDateTime = beginDateTime + deltaTime;

            string description = "[" + beginDateTime.ToString() + "]: " + "Sistem je detektovao kvar na uredjaju "
                + name + " na naplatnoj stanici " + tollStation.name + ".";

            Malfunction malfunction = new Malfunction(tollStation._id, name, description, beginDateTime, false, endDateTime);
            malfunctionRepository.Insert(malfunction);
        }
    }
}
