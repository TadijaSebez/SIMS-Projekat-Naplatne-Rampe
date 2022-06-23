using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class ElectronicPaymentRepository : IElectronicPaymentRepository
    {
        public IMongoCollection<ElectronicPayment> collection;

        public IMongoDatabase database;
        public ElectronicPaymentRepository()
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
            this.collection = database.GetCollection<ElectronicPayment>("ElectronicPayments");
        }
        public List<ElectronicPayment> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public ElectronicPayment GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(ElectronicPayment payment)
        {
            collection.InsertOne(payment);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(ElectronicPayment payment)
        {
            collection.ReplaceOne(item => item._id == payment._id, payment);

        }
    }
}
