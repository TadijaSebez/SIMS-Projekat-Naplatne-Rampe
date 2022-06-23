using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;
namespace NaplatnaRampa.contoller
{
    public class ScheduleController
    {
        public IScheduleRepository scheduleRepository;

        public ScheduleController()
        {
            this.scheduleRepository = Globals.container.Resolve<IScheduleRepository>();
        }

        public Schedule GetById(ObjectId id)
        {
            return scheduleRepository.GetById(id);
        }
    }
}
