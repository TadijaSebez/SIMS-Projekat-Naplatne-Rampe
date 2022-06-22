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

        public ElectronicPaymentRepository()
        {
            collection = Globals.database.GetCollection<ElectronicPayment>("ElectronicPayments");
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
