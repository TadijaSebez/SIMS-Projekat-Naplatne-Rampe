using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;

namespace NaplatnaRampa.contoller
{

    public class UserService
    {
        public IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User CheckCredentials(string email, string password)
        {
            return userRepository.CheckCredentials(email, password);
        }

    }
}
