
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    public class TagRepository : ITagRepository
    { 

        public IMongoCollection<ETag> collection;
        public IMongoDatabase database;
        public TagRepository()
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
            this.collection = database.GetCollection<ETag>("ETags");
        }
        public List<ETag> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public ETag GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(ETag tag)
        {
            collection.InsertOne(tag);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(ETag tag)
        {
            collection.ReplaceOne(item => item._id == tag._id, tag);

        }
    }
}
