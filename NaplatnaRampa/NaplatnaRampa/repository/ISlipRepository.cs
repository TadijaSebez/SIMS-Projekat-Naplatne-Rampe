using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface ISlipRepository
    {
        List<Slip> GetAll();
        Slip GetById(ObjectId id);
        void Insert(Slip slip);
        void Delete(ObjectId id);
        void Update(Slip slip);
    }
}
