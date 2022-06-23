using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;
namespace NaplatnaRampa.contoller
{
    public class TollRoadController
    {
        public ITollRoadRepository tollRoadRepository;

        public TollRoadController()
        {
            this.tollRoadRepository = Globals.container.Resolve<ITollRoadRepository>();
        }

        public TollRoad GetById(ObjectId id)
        {
            return tollRoadRepository.GetById(id);
        }
    }
}
