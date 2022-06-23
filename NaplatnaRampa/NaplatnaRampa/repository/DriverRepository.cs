using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    public class DriverRepository : IDriverRepository
    {

        public IMongoCollection<Driver> collection;

        public IMongoDatabase database;
        public DriverRepository()
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
            this.collection = database.GetCollection<Driver>("Drivers");
        }
        public List<Driver> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Driver GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Driver driver)
        {
            collection.InsertOne(driver);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Driver driver)
        {
            collection.ReplaceOne(item => item._id == driver._id, driver);

        }
    }
}
