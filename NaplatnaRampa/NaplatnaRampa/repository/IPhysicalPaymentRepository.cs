using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface IPhysicalPaymentRepository
    {
        List<PhysicalPayment> GetAll();
        PhysicalPayment GetById(ObjectId id);
        void Insert(PhysicalPayment payment);
        void Delete(ObjectId id);
        void Update(PhysicalPayment payment);
    }
}
