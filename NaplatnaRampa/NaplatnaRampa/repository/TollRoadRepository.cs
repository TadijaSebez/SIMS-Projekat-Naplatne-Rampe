using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    class TollRoadRepository : ITollRoadRepository
    {

        public IMongoCollection<TollRoad> collection;

        public TollRoadRepository()
        {
            collection = Globals.database.GetCollection<TollRoad>("TollRoads");
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
