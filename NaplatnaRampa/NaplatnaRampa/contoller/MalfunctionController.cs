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
        private TollRoadController tollRoadController;
        private TollStationController tollStationController;
        private List<Action> callbackFunctions;

        public MalfunctionController()
        {
            this.malfunctionRepository = Globals.container.Resolve<IMalfunctionRepository>();
            this.tollRoadController = Globals.container.Resolve<TollRoadController>();
            this.tollStationController = Globals.container.Resolve<TollStationController>();
            this.callbackFunctions = new List<Action>();
        }

        public void AddUpdateCallback(Action function)
        {
            callbackFunctions.Add(function);
        }

        private void Updated()
        {
            foreach (Action function in callbackFunctions)
            {
                function();
            }
        }

        public Malfunction GetById(ObjectId id)
        {
            return malfunctionRepository.GetById(id);
        }


        public List<Malfunction> Malfunctions()
        {
            return malfunctionRepository.GetAll();

        }
        public void Save(Malfunction malfunction)
        {
            malfunctionRepository.Insert(malfunction);
            Updated();
        }

        public void Update(Malfunction malfunction)
        {
            malfunctionRepository.Update(malfunction);
            Updated();
        }

        public bool IsInMalfunction(TollRoad road)
        {
            foreach (Malfunction malfunction in malfunctionRepository.GetAll())
            {
                if (malfunction.tollRoadId == road._id)
                {
                    if (malfunction.fixing == false)
                        return true;
                }
            }
            return false;
        }

        public void SimulateDetection(Random rng)
        {
            TollRoad tollRoad = tollRoadController.GetRandom(rng);
            TollStation tollStation = tollStationController.GetById(tollRoad.tollStationId);

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
            DateTime endDateTime = DateTime.MaxValue;

            string description = "Sistem je detektovao kvar na uredjaju "
                + name + " na mestu broj " + tollRoad.number + " na naplatnoj stanici " + tollStation.name + ".";

            Malfunction malfunction = new Malfunction(tollRoad._id, name, description, beginDateTime, false, endDateTime);
            malfunctionRepository.Insert(malfunction);
            Updated();
        }
    }
}
