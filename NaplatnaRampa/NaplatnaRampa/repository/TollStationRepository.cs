using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public class TollStationRepository : ITollStationRepository
    {
        public IMongoCollection<TollStation> collection;
        public IMongoDatabase database;
        public TollStationRepository()
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
            this.collection = database.GetCollection<TollStation>("TollStation");
        }
        public List<TollStation> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public TollStation GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(TollStation tollStation)
        {
            collection.InsertOne(tollStation);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(TollStation tollStation)
        {
            collection.ReplaceOne(item => item._id == tollStation._id, tollStation);
        }
    }
}
