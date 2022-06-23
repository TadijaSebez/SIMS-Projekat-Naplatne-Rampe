using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    class SlipController
    {
        public ISlipRepository slipRepository;
        public SlipController()
        {
            this.slipRepository = Globals.container.Resolve<ISlipRepository>();
        }

        public void Save(Slip slip)
        {
            slipRepository.Insert(slip);
        }
    }
}
