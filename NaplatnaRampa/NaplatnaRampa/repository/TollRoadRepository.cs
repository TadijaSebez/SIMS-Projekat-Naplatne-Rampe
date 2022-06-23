using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    public class TollRoadRepository : ITollRoadRepository
    {

        public IMongoCollection<TollRoad> collection;
        public IMongoDatabase database;
        public TollRoadRepository()
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
            this.collection = database.GetCollection<TollRoad>("TollRoads");
        }
        public List<TollRoad> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public TollRoad GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(TollRoad tollBooth)
        {
            collection.InsertOne(tollBooth);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(TollRoad tollroad)
        {
            collection.ReplaceOne(item => item._id == tollroad._id, tollroad);

        }
    }
}
