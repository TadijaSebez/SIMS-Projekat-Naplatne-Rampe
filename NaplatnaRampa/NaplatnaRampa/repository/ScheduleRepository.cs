using MongoDB.Bson;
using MongoDB.Driver;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    class ScheduleRepository : IScheduleRepository
    {
        public IMongoCollection<Schedule> collection;

        public ScheduleRepository()
        {
            this.collection = Globals.database.GetCollection<Schedule>("Schedules");
        }

        public List<Schedule> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public Schedule GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Insert(Schedule schedule)
        {
            collection.InsertOne(schedule);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(Schedule schedule)
        {
            collection.ReplaceOne(item => item._id == schedule._id, schedule);
        }
    }
}
