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
   public class UserRepository: IUserRepository
    {
        public IMongoCollection<User> collection;
        public IMongoDatabase database;
        public UserRepository()
        {
            GetDatabase();
            GetCollection();

        }
        public void GetDatabase()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://anastasija:anastasija2001@cluster0.tlsbsly.mongodb.net/test");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            this.database = client.GetDatabase("SIMS");
        }
        public void GetCollection()
        {
            this.collection = database.GetCollection<User>("Users");
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

        public User CheckCredentials(string email, string password)
        {
            return collection.Find(item => item.password == password & item.email == email).FirstOrDefault();

        }


    }
}
