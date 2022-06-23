using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static NaplatnaRampa.model.Currency;
using static NaplatnaRampa.model.Vehicle;

namespace NaplatnaRampa.model
{
    public abstract class Payment
    {
        public ObjectId _id { get; set; }
        [BsonElement("price")]
        public float price { get; set; }
        [BsonElement("vehicleType")]
        public VehicleType VehicleType { get; set; }
        [BsonElement("currency")]
        public TypeOfCurrency currency { get; set; }
        [BsonElement("tollRoadId")]
        public ObjectId tollRoadId { get; set; }
        [BsonElement("dateTime")]
        public DateTime dateTime { get; set; }


        public Payment(float price, VehicleType vehicleType, TypeOfCurrency typeOfCurrency, ObjectId tollRoadId, DateTime dateTime)
        {
            this._id = this._id = ObjectId.GenerateNewId();
            this.price = price;
            this.VehicleType = vehicleType;
            this.currency = currency;
            this.tollRoadId = tollRoadId;
            this.dateTime = dateTime;
        }




    }
}
