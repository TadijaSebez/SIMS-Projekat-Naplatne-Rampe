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
        [BsonElement("pocetnaStanica")]
        public ObjectId pocetnaStanicaId { get; set; }                  
        [BsonElement("krajnjaStanica")]
        public ObjectId krajnjaStanicaId { get; set; }
        [BsonElement("kilometri")]
        public float kilometri { get; set; }
      


        public Section(ObjectId pocetna, ObjectId krajnja, float kilometri)
        {
            this._id = ObjectId.GenerateNewId();
            this.pocetnaStanicaId = pocetna;
            this.krajnjaStanicaId = krajnja;
            this.kilometri = kilometri;

        }

    }
}
