using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static NaplatnaRampa.model.Currency;
using static NaplatnaRampa.model.Vehicle;

namespace NaplatnaRampa.model
{
    public class PhysicalPayment : Payment
    {
        public ObjectId _id { get; set; }
        [BsonElement("paid")]
        public float paid;
        [BsonElement("slipId")]
        public ObjectId slipId { get; set; }


        public PhysicalPayment(float price, VehicleType vehicleType, TypeOfCurrency typeOfCurrency, ObjectId tollRoadId,float paid, ObjectId slipId): base(price,vehicleType, typeOfCurrency, tollRoadId)
        {
            this.paid = paid;
            this.slipId = slipId;
        }


    }
}
