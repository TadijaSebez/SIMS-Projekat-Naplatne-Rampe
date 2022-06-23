using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.model
{
    public class Slip
    {
        public ObjectId _id { get; set; }
        [BsonElement("dateTime")]

        public DateTime dateTime;
        [BsonElement("table")]
        public String table;

        [BsonElement("tollRoadId")]
        public ObjectId tollRoadId { get; set; }



        public Slip(DateTime dateTime, String table, ObjectId tollRoadid)
        {
            this.dateTime = dateTime;
            this.table = table;
            this.tollRoadId = tollRoadId;
        }
    }
}
