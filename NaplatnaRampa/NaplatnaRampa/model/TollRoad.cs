using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
    public class TollRoad
    {
        public ObjectId _id { get; set; }
        [BsonElement("number")]
        public int number { get; set; }
        [BsonElement("tollStationId")]
        public ObjectId tollStationId{ get; set; }
        [BsonElement("active")]
        public bool active { get; set; }
        public TollRoad(int number, ObjectId tollStationId)
        {
            this._id = ObjectId.GenerateNewId();
            this.number = number;
            this.tollStationId = tollStationId;

            this.active = true; 
        }
    }
}
