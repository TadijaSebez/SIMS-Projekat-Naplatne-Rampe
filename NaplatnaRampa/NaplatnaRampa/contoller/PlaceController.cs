using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.model;
using NaplatnaRampa.contoller;
using MongoDB.Bson;
using Autofac;
using NaplatnaRampa.repository;

namespace NaplatnaRampa.contoller 

{
    public class PlaceController
    {
        public IPlaceRepository placeRepository;

        public PlaceController()
        {
            this.placeRepository = Globals.container.Resolve<IPlaceRepository>();
        }

        public Place GetById(ObjectId id)
        {
            return placeRepository.GetById(id);
        }

        public bool CheckPlaceExist(String namePlace)
        {
            foreach(Place place in placeRepository.GetAll())
            {
                if (place.name.Equals(namePlace))
                {
                    return true;
                }
            }
            return false;
        }

        public Place GetByName(string name)
        {
            return placeRepository.GetByName(name);
        }


    }
}
