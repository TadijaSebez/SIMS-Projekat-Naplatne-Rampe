using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public interface ITollStationRepository : IRepository<TollStation>
    {
        List<TollStation> GetAll();
        TollStation GetById(ObjectId id);
        TollStation GetByName(string name);
        void Insert(TollStation tollStation);
        void Delete(ObjectId id);
        void Update(TollStation tollStation);
    }
}
