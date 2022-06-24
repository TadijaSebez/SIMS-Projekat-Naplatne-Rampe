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
        public IMalfunctionRepository malfunctionRepository;

        public MalfunctionController()
        {
            this.malfunctionRepository = Globals.container.Resolve<IMalfunctionRepository>();
        }

        public Malfunction GetById(ObjectId id)
        {
            return malfunctionRepository.GetById(id);
        }
    }
}
