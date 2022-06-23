using MongoDB.Bson;
using NaplatnaRampa.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.repository
{
    public interface IUserRepository : IRepository<User>
    {

        public User CheckCredentials(string email, string password);

    }
}
