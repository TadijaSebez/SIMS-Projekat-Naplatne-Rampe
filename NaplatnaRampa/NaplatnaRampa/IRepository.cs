using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace NaplatnaRampa
{
     public interface IRepository<TEntity>
    {
        void GetCollection();
        void GetDatabase();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(ObjectId id);

        List<TEntity> GetAll();
        TEntity GetById(ObjectId id);

     
    }
}
