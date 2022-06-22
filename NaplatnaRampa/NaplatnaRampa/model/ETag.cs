using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
    class ETag
    {
        public ObjectId _id { get; set; }
        [BsonElement("tipVozila")]
        public String tipVozila { get; set; }                 
        [BsonElement("stanjeRacuna")]
        public float stanjeRacuna { get; set; }
        [BsonElement("valutaRacuna")]                           // TODO: promjeni kasnije
        public String valutaRacuna  { get; set; }
        [BsonElement("driverId")]
        public ObjectId driverId { get; set; }

        public ETag(String tipVozila, float stanjeRacuna, String valutaRacuna, ObjectId driverId) {
            this._id = ObjectId.GenerateNewId();
            this.tipVozila = tipVozila;
            this.stanjeRacuna = stanjeRacuna;
            this.valutaRacuna = valutaRacuna;
            this.driverId = driverId;
        }
    }
}
