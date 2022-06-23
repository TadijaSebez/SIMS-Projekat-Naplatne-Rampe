using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NaplatnaRampa.contoller
{
    public class TagController
    {
        public ITagRepository tagRepository;

        public TagController()
        {
            this.tagRepository = Globals.container.Resolve<ITagRepository>();
        }

        public ETag GetById(ObjectId id)
        {
            return tagRepository.GetById(id);
        }

    }
}
