using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    class SectionRepository : ISectionRepository
    {
        public IMongoCollection<Section> collection;
        public IMongoDatabase database;
        public SectionRepository()
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
            this.collection = database.GetCollection<Section>("Sections");
        }

        public List<Section> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Section GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Section driver)
        {
            collection.InsertOne(driver);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Section section)
        {
            collection.ReplaceOne(item => item._id == section._id, section);

        }
    }
}
