using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.model
{
    public class Pricelist
    {
        public ObjectId _id { get; set; }
        [BsonElement("validFrom")]
        public DateTime validFrom { get; set; }
        [BsonElement("itemIds")]
        public List<ObjectId> itemIds { get; set; }

        public Pricelist(DateTime validFrom, List<ObjectId> itemIds)
        {
            this._id = ObjectId.GenerateNewId();
            this.validFrom = validFrom;
            this.itemIds = itemIds;
        }
    }
}
