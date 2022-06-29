using Autofac;
using MongoDB.Bson;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    public class SectionController
    {
        public ISectionRepository sectionRepository;
        public SectionController()
        {
            this.sectionRepository = Globals.container.Resolve<ISectionRepository>();
        }

        public List<Section> Sections()
        {
            return sectionRepository.GetAll();
        }

        public Section GetById(ObjectId id)
        {
            return sectionRepository.GetById(id);
        }

        public Section GetByStations(TollStation firstStation, TollStation secondStation)
        {
            return sectionRepository.GetByStations(firstStation._id, secondStation._id);
        }
    }
}
