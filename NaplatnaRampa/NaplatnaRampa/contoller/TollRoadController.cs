using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    class TollRoadController
    {
        public ITollRoadRepository tollRoadRepository;
        public TollRoadController()
        {
            this.tollRoadRepository = Globals.container.Resolve<ITollRoadRepository>();
        }

        public TollRoad GetByStationAndNumber(TollStation station, int number)
        {
            return tollRoadRepository.GetByStationAndNumber(station._id, number);
        }
    }
}
