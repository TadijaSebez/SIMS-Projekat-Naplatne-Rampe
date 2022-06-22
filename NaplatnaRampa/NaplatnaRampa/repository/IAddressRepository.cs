using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface IAddressRepository
    {
        List<Address> GetAll();
        Address GetById(ObjectId id);
        void Insert(Address address);
        void Delete(ObjectId id);
        void Update(Address address);
    }
}
