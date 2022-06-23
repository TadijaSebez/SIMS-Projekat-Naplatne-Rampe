using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public class PlaceRepository: IPlaceRepository
    {
        public IMongoCollection<Place> collection;

        public IMongoDatabase database;
        public PlaceRepository()
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
            this.collection = database.GetCollection<Place>("Places");
        }

        public List<Place> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Place GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Place place)
        {
            collection.InsertOne(place);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Place place)
        {
            collection.ReplaceOne(item => item._id == place._id, place);

        }
    }
}
