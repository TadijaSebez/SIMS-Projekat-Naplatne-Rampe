using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;

namespace NaplatnaRampa.contoller
{

    public class UserController
    {
        public IUserRepository userRepository;

        public UserController()
        {
            this.userRepository = Globals.container.Resolve<IUserRepository>();
        }
        public User CheckCredentials(string email, string password)
        {
            return userRepository.CheckCredentials(email, password);
        }


        public List<User> Users()
        {
            return userRepository.GetAll();
        } 

    }
}
