using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class PhysicalPaymentRepository : IPhysicalPaymentRepository
    {
        public IMongoCollection<PhysicalPayment> collection;

        public PhysicalPaymentRepository()
        {
            collection = Globals.database.GetCollection<PhysicalPayment>("PhysicalPayments");
        }

        public List<PhysicalPayment> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public PhysicalPayment GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(PhysicalPayment payment)
        {
            collection.InsertOne(payment);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(PhysicalPayment payment)
        {
            collection.ReplaceOne(item => item._id == payment._id, payment);

        }
    }
}
