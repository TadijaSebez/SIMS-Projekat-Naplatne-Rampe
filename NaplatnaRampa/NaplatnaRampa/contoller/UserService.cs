using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;

namespace NaplatnaRampa.contoller
{

    public class UserService
    {
        public IUserRepository userRepository;

        public UserService()
        {
            this.userRepository = Globals.container.Resolve<IUserRepository>();
        }
        public User CheckCredentials(string email, string password)
        {
            return userRepository.CheckCredentials(email, password);
        }

    }
}
