using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public class AddressRepository : IAddressRepository
    {
        public IMongoCollection<Address> collection;
        public IMongoDatabase database;
        public AddressRepository()
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
            this.collection = database.GetCollection<Address>("Addresses");
        }
        public List<Address> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Address GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Address address)
        {
            collection.InsertOne(address);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Address address)
        {
            collection.ReplaceOne(item => item._id == address._id, address);

        }
    }
}
