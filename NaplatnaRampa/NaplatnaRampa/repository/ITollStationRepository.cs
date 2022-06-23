using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface ITollStationRepository
    {
        List<TollStation> GetAll();
        TollStation GetById(ObjectId id);
        void Insert(TollStation tollStation);
        void Delete(ObjectId id);
        void Update(TollStation tollStation);
    }
}
