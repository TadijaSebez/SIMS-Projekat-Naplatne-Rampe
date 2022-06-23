using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public interface IScheduleRepository 
    {
        List<Schedule> GetAll();
        Schedule GetById(ObjectId id);
        void Insert(Schedule chedule);
        void Delete(ObjectId id);
        void Update(Schedule schedule);

    }
}
