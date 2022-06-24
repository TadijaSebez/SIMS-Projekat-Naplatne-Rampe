using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Place GetByName(string name);
    }
}
