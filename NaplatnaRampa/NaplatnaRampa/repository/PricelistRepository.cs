using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public class PricelistRepository : IPricelistRepository
    {
        public IMongoCollection<Pricelist> collection;

        public PricelistRepository()
        {
            this.collection = Globals.database.GetCollection<Pricelist>("Pricelists");
        }

        public List<Pricelist> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Pricelist GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Pricelist pricelist)
        {
            collection.InsertOne(pricelist);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Pricelist pricelist)
        {
            collection.ReplaceOne(item => item._id == pricelist._id, pricelist);
        }
    }
}
