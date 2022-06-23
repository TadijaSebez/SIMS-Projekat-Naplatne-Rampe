using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
    public class Address
    {
        public ObjectId _id { get; set; }
        [BsonElement("street")]
        public String street { get; set; }
        [BsonElement("number")]
        public int number { get; set; }
        [BsonElement("placeId")]
        public ObjectId placeId { get; set; }


        public Address(String street, int number, ObjectId placeId ) {
            this._id = this._id = ObjectId.GenerateNewId();
            this.street = street;
            this.number = number;
            this.placeId = placeId;
        }

    }
}
