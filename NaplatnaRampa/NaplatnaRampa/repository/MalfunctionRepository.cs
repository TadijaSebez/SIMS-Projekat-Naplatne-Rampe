using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
namespace NaplatnaRampa.repository
{
    public class MalfunctionRepository : IMalfunctionRepository
    {
        public IMongoCollection<Malfunction> collection;

        public IMongoDatabase database;
        public MalfunctionRepository()
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
            this.collection = database.GetCollection<Malfunction>("Malfunctions");
        }
        public List<Malfunction> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Malfunction GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Malfunction malfunction)
        {
            collection.InsertOne(malfunction);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Malfunction malfunction)
        {
            collection.ReplaceOne(item => item._id == malfunction._id, malfunction);

        }
    }
}
