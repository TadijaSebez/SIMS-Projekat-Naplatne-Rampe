using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class PaymentRepository:IPaymentRepository
    {
        public IMongoCollection<Payment> collection;

        public PaymentRepository()
        {
            collection = Globals.database.GetCollection<Payment>("Payments");
        }

        public List<Payment> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Payment GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Payment payment)
        {
            collection.InsertOne(payment);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Payment payment)
        {
            collection.ReplaceOne(item => item._id == payment._id, payment);

        }
    }
}
