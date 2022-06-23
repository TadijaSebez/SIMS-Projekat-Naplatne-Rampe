using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;
namespace NaplatnaRampa.contoller
{
    public class SlipController
    {
        public ISlipRepository slipRepository;

        public SlipController()
        {
            this.slipRepository = Globals.container.Resolve<ISlipRepository>();
        }

        public Slip GetById(ObjectId id)
        {
            return slipRepository.GetById(id);
        }
    }
}
