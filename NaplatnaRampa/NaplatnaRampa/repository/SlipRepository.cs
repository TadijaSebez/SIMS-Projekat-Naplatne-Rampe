using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class SlipRepository: ISlipRepository
    {
        public IMongoCollection<Slip> collection;

        public SlipRepository()
        {
            collection = Globals.database.GetCollection<Slip>("Slips");
        }

        public List<Slip> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Slip GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Slip slip)
        {
            collection.InsertOne(slip);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Slip slip)
        {
            collection.ReplaceOne(item => item._id == slip._id, slip);

        }
    }
}
