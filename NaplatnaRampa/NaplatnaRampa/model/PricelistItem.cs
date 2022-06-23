using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.model
{
    public class PricelistItem
    {
        public ObjectId _id { get; set; }
        [BsonElement("vehicleType")]
        public Vehicle.VehicleType vehicleType { get; set; }
        [BsonElement("price")]
        public float price { get; set; }
        [BsonElement("currency")]
        public Currency.TypeOfCurrency currency { get; set; }
        [BsonElement("sectionId")]
        public ObjectId sectionId { get; set; }

        public PricelistItem(Vehicle.VehicleType vehicleType, float price, Currency.TypeOfCurrency currency, ObjectId sectionId)
        {
            this._id = ObjectId.GenerateNewId();
            this.vehicleType = vehicleType;
            this.price = price;
            this.currency = currency;
            this.sectionId = sectionId;
        }
    }
}
