using Autofac;
using MongoDB.Bson;
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
        public IPricelistItemRepository pricelistItemRepository;
        public PricelistController()
        {
            this.pricelistRepository = Globals.container.Resolve<IPricelistRepository>();
            this.pricelistItemRepository = Globals.container.Resolve<IPricelistItemRepository>();
        }

        public List<Pricelist> Pricelists()
        {
            return pricelistRepository.GetAll();
        }

        public Pricelist GetActive()
        {
            Pricelist activePricelist = null;
            foreach (Pricelist pricelist in Pricelists())
            {
                if (pricelist.validFrom < DateTime.Now)
                {
                    if (activePricelist == null || activePricelist.validFrom < pricelist.validFrom)
                        activePricelist = pricelist;
                }
            }
            return activePricelist;
        }

        public PricelistItem GetPriceForSection(Section section, Vehicle.VehicleType vehicleType, Currency.TypeOfCurrency currency)
        {
            Pricelist activePricelist = GetActive();
            if (activePricelist == null)
                return null;
            foreach (ObjectId itemId in activePricelist.itemIds)
            {
                PricelistItem item = pricelistItemRepository.GetById(itemId);
                if (item.sectionId == section._id && item.vehicleType == vehicleType && item.currency == currency)
                    return item;
            }
            return null;
        }
    }
}
