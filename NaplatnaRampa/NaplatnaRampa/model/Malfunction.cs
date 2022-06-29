using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.model
{
    public class Malfunction
    {
        public ObjectId _id { get; set; }
        [BsonElement("tollRoadId")]
        public ObjectId tollRoadId { get; set; }

        [BsonElement("name")]
        public String name { get; set; }
        [BsonElement("description")]
        public String description { get; set; }

        [BsonElement("dateTimeBegin")]
        public DateTime dateTimeBegin { get; set; }



        [BsonElement("fixing")]
        public Boolean fixing { get; set; }

        [BsonElement("dateTimeEnd")]
        public DateTime dateTimeEnd { get; set; }

        public Malfunction(ObjectId tollRoadId, String name, String description, DateTime dateTimeBegin, Boolean fixing, DateTime dateTimeEnd)
        {
            this.tollRoadId = tollRoadId;
            this.name = name;
            this.description = description;
            this.dateTimeBegin = dateTimeBegin;
            this.fixing = fixing;
            this.dateTimeEnd = dateTimeEnd;
        }
       


    }
}
