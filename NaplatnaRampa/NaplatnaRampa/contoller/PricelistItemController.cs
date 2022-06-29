using Autofac;
using MongoDB.Bson;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    class PricelistItemController
    {
        public IPricelistItemRepository pricelistItemRepository;
        public PricelistItemController()
        {
            this.pricelistItemRepository = Globals.container.Resolve<IPricelistItemRepository>();
        }

        public List<PricelistItem> PricelistItems()
        {
            return pricelistItemRepository.GetAll();
        }

        public List<PricelistItem> PricelistItems(Pricelist pricelist)
        {
            return pricelistItemRepository.GetItems(pricelist.itemIds);
        }
    }
}
