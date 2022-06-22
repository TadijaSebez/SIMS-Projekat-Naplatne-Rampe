using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;

namespace NaplatnaRampa.repository
{
    class SectionRepository : ISectionRepository
    {
        public IMongoCollection<Section> collection;

        public SectionRepository()
        {
            collection = Globals.database.GetCollection<Section>("Sections");
        }

        public List<Section> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Section GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Section driver)
        {
            collection.InsertOne(driver);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Section section)
        {
            collection.ReplaceOne(item => item._id == section._id, section);

        }
    }
}
