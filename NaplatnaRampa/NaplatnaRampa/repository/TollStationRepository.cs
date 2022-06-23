using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class TollStationRepository : ITollStationRepository
    {
        public IMongoCollection<TollStation> collection;
        
        public TollStationRepository()
        {
            this.collection = Globals.database.GetCollection<TollStation>("TollStations");
        }
        
        public List<TollStation> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public TollStation GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public TollStation GetByName(string name)
        {
            return collection.Find(item => item.name == name).FirstOrDefault();
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
