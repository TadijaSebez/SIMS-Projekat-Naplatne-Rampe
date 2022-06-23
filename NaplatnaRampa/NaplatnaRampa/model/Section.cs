using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
    class Section
    {

        public ObjectId _id { get; set; }
        [BsonElement("firstStationId")]
        public ObjectId firstStationId { get; set; }                  
        [BsonElement("secondStationId")]
        public ObjectId secondStationId { get; set; }
        [BsonElement("distance")]
        public float distance { get; set; }

        public Section(ObjectId firstStationId, ObjectId secondStationId, float distance)
        {
            this._id = ObjectId.GenerateNewId();
            this.firstStationId = firstStationId;
            this.secondStationId = secondStationId;
            this.distance = distance;
        }
    }
}
