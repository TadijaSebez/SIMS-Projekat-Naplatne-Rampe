
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    class TagRepository : ITagRepository
    { 

        public IMongoCollection<ETag> collection;

        public TagRepository()
        {
            collection = Globals.database.GetCollection<ETag>("Tags");
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
