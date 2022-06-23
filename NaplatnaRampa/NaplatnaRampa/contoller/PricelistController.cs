using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    class PricelistController
    {
        public IPricelistRepository pricelistRepository;
        public PricelistController()
        {
            this.pricelistRepository = Globals.container.Resolve<IPricelistRepository>();
        }

        public List<Pricelist> Pricelists()
        {
            return pricelistRepository.GetAll();
        }
    }
}
