using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
    public class Place
    {
        public ObjectId _id { get; set; }
        [BsonElement("ptt")]
        public int ptt { get; set; }
        [BsonElement("name")]
        public String name { get; set; }


        public Place(int ptt, String name) {
            this._id = this._id = ObjectId.GenerateNewId();
            this.ptt = ptt;
            this.name = name;
        
        }



    }
}
