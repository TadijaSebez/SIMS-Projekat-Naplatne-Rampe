using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.model
{
    class TollStation
    {
        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("placeId")]
        public ObjectId placeId { get; set; }
        [BsonElement("tollRoadIds")]
        public List<ObjectId> tollRoadIds { get; set; }

        public TollStation(string name, ObjectId placeId, List<ObjectId> tollRoadIds)
        {
            this._id = ObjectId.GenerateNewId();
            this.name = name;
            this.placeId = placeId;
            this.tollRoadIds = tollRoadIds;
        }
    }
}
