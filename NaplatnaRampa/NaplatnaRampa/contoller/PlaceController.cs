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
    }
}
