using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    class DriverRepository : IDriverRepository
    {

        public IMongoCollection<Driver> collection;

        public DriverRepository()
        {
            collection = Globals.database.GetCollection<Driver>("Drivers");
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
