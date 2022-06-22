using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class PlaceRepository: IPlaceRepository
    {
        public IMongoCollection<Place> collection;

        public PlaceRepository()
        {
            collection = Globals.database.GetCollection<Place>("Places");
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
