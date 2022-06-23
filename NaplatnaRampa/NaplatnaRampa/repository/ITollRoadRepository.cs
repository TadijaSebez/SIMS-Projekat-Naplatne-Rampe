using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    public interface ITollRoadRepository : IRepository<TollRoad>
    {
        TollRoad GetByStationAndNumber(ObjectId stationId, int number);
    }
}
