using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public interface IPricelistRepository
    {
        List<Pricelist> GetAll();
        Pricelist GetById(ObjectId id);
        void Insert(Pricelist pricelist);
        void Delete(ObjectId id);
        void Update(Pricelist pricelist);
    }
}
