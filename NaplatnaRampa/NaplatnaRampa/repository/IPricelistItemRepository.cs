using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public interface IPricelistItemRepository
    {
        List<PricelistItem> GetAll();
        PricelistItem GetById(ObjectId id);
        List<PricelistItem> GetItems(List<ObjectId> ids);
        void Insert(PricelistItem pricelistItem);
        void Delete(ObjectId id);
        void Update(PricelistItem pricelistItem);
    }
}
