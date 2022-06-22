using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
    class Driver
    {

        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public String name { get; set; }                   // TODO: promjeni kasnije
        [BsonElement("surname")]
        public String surname{ get; set; }
        [BsonElement("tagId")]                           // TODO: promjeni kasnije
        public ObjectId tagId { get; set; }



        public Driver(String name, String surname, ObjectId tagId)
        {
            this._id = ObjectId.GenerateNewId();
            this.name = name;
            this.surname = surname;
            this.tagId = tagId;

        }
    }
}
