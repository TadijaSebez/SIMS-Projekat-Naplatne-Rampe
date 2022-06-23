using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public class SlipRepository: ISlipRepository
    {
        public IMongoCollection<Slip> collection;

        public IMongoDatabase database;
        public SlipRepository()
        {
            GetDatabase();
            GetCollection();

        }
        public void GetDatabase()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://anastasija:anastasija2001@cluster0.tlsbsly.mongodb.net/test");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            this.database = client.GetDatabase("SIMS");
        }
        public void GetCollection()
        {
            this.collection = database.GetCollection<Slip>("Slips");
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
