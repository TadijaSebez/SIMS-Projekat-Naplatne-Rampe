using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    internal class UserRepository
    {
        public IMongoCollection<User> collection;

        public UserRepository()
        {
            collection = Globals.database.GetCollection<User>("Users");
        }

        public List<User> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public User GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(User user)
        {
            collection.InsertOne(user);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(User user)
        {
            collection.ReplaceOne(item => item._id == user._id, user);

        }
    }
}
