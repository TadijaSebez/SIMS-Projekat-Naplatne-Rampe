using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace NaplatnaRampa
{
    internal interface IRepository<TEntity>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(ObjectId id);

        List<TEntity> GetAll();
        TEntity GetById(ObjectId id);

     
    }
}
