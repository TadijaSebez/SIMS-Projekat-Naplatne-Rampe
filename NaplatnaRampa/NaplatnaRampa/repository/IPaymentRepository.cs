using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface IPaymentRepository
    {
        List<Payment> GetAll();
        Payment GetById(ObjectId id);
        void Insert(Payment payment);
        void Delete(ObjectId id);
        void Update(Payment payment);
    }
}
