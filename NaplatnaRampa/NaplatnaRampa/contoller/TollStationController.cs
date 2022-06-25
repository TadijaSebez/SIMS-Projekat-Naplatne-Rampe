using Autofac;
using MongoDB.Bson;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    public class TollStationController
    {
        public ITollStationRepository tollStationRepository;
        public TollStationController()
        {
            this.tollStationRepository = Globals.container.Resolve<ITollStationRepository>();
        }

        public List<TollStation> TollStations()
        {
            return tollStationRepository.GetAll();
        }

        public TollStation GetById(ObjectId id)
        {
            return tollStationRepository.GetById(id);
        }

        public TollStation GetByName(string name)
        {
            return tollStationRepository.GetByName(name);
        }

        public void Delete(ObjectId id)
        {

            tollStationRepository.Delete(id);

        }


        public TollStation GetRandom(Random rng)
        {
            List<TollStation> allStations = TollStations();
            return allStations[rng.Next(allStations.Count)];
        }


        public void Insert(TollStation tollStation) {
            tollStationRepository.Insert(tollStation);
        
        }


        public void Update(TollStation tollStation) {

            tollStationRepository.Update(tollStation);
        }
    }

}
