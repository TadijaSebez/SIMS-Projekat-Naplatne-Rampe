using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    interface ISectionRepository : IRepository<Section>
    {
        Section GetByStations(ObjectId firstSectionId, ObjectId secondSectionId);
    }
}
