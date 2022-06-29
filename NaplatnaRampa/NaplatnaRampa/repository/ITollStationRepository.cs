using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public interface ITollStationRepository : IRepository<TollStation>
    {
       
        TollStation GetByName(string name);
    }
}
