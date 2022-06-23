using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static NaplatnaRampa.model.Currency;
using static NaplatnaRampa.model.Vehicle;

namespace NaplatnaRampa.model
{
    public class ElectronicPayment: Payment
    {
        [BsonElement("readTagId")]
        public ObjectId readTagId { get; set; }


        public ElectronicPayment(float price, VehicleType vehicleType, TypeOfCurrency typeOfCurrency, ObjectId tollRoadId, DateTime dateTime, ObjectId readTagId): 
            base(price, vehicleType, typeOfCurrency, tollRoadId, dateTime)
        {
            this.readTagId = readTagId;
        }
    }
}
