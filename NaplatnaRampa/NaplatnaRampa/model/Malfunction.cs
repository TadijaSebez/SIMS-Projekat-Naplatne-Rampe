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
        [BsonElement("name")]
        public String name { get; set; }
        [BsonElement("description")]
        public String description { get; set; }

        [BsonElement("dateTime")]
        public DateTime dateTime { get; set; }



        [BsonElement("fixing")]
        public Boolean fixing { get; set; }


        public Malfunction(String name, String description, DateTime dateTime, Boolean fixing)
        {
            this.name = name;
            this.description = description;
            this.dateTime = dateTime;
            this.fixing = fixing;
        }
       


    }
}
