using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;

namespace NaplatnaRampa.contoller
{
    public class DriverController
    {
        public IDriverRepository driverRepository;

        public DriverController()
        {
            this.driverRepository = Globals.container.Resolve<IDriverRepository>();
        }

        public Driver GetById(ObjectId id)
        {
            return driverRepository.GetById(id);
        }
    }
}
