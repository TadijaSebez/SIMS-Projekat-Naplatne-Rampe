using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface IElectronicPaymentRepository
    {
        List<ElectronicPayment> GetAll();
        ElectronicPayment GetById(ObjectId id);
        void Insert(ElectronicPayment payment);
        void Delete(ObjectId id);
        void Update(ElectronicPayment payment);
    }
}

