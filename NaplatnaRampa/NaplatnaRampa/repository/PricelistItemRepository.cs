using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class PricelistItemRepository : IPricelistItemRepository
    {
        public IMongoCollection<PricelistItem> collection;

        public PricelistItemRepository()
        {
            this.collection = Globals.database.GetCollection<PricelistItem>("PricelistItems");
        }

        public List<PricelistItem> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public PricelistItem GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public List<PricelistItem> GetItems(List<ObjectId> ids)
        {
            return collection.Find(item => ids.Contains(item._id)).ToList();
        }

        public void Insert(PricelistItem pricelistItem)
        {
            collection.InsertOne(pricelistItem);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(PricelistItem pricelistItem)
        {
            collection.ReplaceOne(item => item._id == pricelistItem._id, pricelistItem);
        }
    }
}
