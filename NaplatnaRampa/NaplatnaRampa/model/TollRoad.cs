using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
     class TollRoad
    {
        public ObjectId _id { get; set; }
        [BsonElement("tollStationId")]
        public ObjectId tollStationId{ get; set; }
       
        public TollRoad(ObjectId tollStationId)
        {
            this._id = ObjectId.GenerateNewId();
            this.tollStationId = tollStationId;
        }
    }
}
}