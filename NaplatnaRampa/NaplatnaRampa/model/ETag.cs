using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static NaplatnaRampa.model.Currency;
using static NaplatnaRampa.model.Vehicle;

namespace NaplatnaRampa.model
{
    class ETag
    {
        public ObjectId _id { get; set; }
        [BsonElement("tipVozila")]
        public VehicleType tipVozila { get; set; }                 
        [BsonElement("stanjeRacuna")]
        public float stanjeRacuna { get; set; }
        [BsonElement("valutaRacuna")]                           // TODO: promjeni kasnije
        public TypeOfCurrency valutaRacuna  { get; set; }
        [BsonElement("driverId")]
        public ObjectId driverId { get; set; }

        public ETag(VehicleType tipVozila, float stanjeRacuna, TypeOfCurrency valutaRacuna, ObjectId driverId) {
            this._id = ObjectId.GenerateNewId();
            this.tipVozila = tipVozila;
            this.stanjeRacuna = stanjeRacuna;
            this.valutaRacuna = valutaRacuna;
            this.driverId = driverId;
        }
    }
}
