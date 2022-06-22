using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface IPlaceRepository
    {
        List<Place> GetAll();
        Place GetById(ObjectId id);
        void Insert(Place place);
        void Delete(ObjectId id);
        void Update(Place place);
    }
}
