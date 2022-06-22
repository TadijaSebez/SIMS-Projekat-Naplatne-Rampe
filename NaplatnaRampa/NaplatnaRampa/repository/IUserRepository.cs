using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    interface IUserRepository
    {
        List<User> GetAll();
        User GetById(ObjectId id);
        void Insert(User user);
        void Delete(ObjectId id);
        void Update(User user);

    }
}
