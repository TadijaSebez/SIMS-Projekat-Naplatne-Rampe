using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaplatnaRampa.model
{
    class User
    {
        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public String name { get; set; }
        [BsonElement("surname")]
        public String surname { get; set; }
        [BsonElement("email")]
        public String email { get; set; }
        [BsonElement("password")]
        public  String password { get; set; }
        [BsonElement("phone")]
        public String phone { get; set; }
        [BsonElement("addressId")]
        public ObjectId addressId;



        public User(string name, string surname, string email, string password, string phone, ObjectId addressId)
        {
            this._id = ObjectId.GenerateNewId();
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.addressId = addressId;
        }
    }

}
