using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.model
{
    class Schedule
    {
        public ObjectId _id { get; set; }
        [BsonElement("date")]
        public DateTime date { get; set; }
        [BsonElement("workShift")]
        public WorkShift workShift { get; set; }
        [BsonElement("workerIds")]
        public List<ObjectId> workerIds { get; set; }

        public Schedule(DateTime date, WorkShift workShift, List<ObjectId> workerIds)
        {
            this._id = ObjectId.GenerateNewId();
            this.date = date;
            this.workShift = workShift;
            this.workerIds = workerIds;
        }
    }
}
