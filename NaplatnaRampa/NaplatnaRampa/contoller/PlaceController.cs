using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.model;
using NaplatnaRampa.contoller;
using MongoDB.Bson;
using Autofac;

namespace NaplatnaRampa.contoller 

{
    public class PlaceController
    {
        public PlaceController placeController;

        public PlaceController()
        {
            this.placeController = Globals.container.Resolve<PlaceController>();
        }

        public Place GetById(ObjectId id)
        {
            return placeController.GetById(id);
        }
    }
}
