using System;
using System.Collections.Generic;
using System.Net.Mail;
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


        public string  getRoleString(Role role)
        {
            if(role == Role.ADMIN)
            {
                return "Administrator";
            }else if(role == Role.BOSS){
                return "Sef stanice";
            }
            else if(role == Role.MENAGER)
            {
                return "Menadzer";
            }
            else
            {
                return "Referent naplate";
            }

        }

        public bool IsValidEmail (string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void Save(User user)
        {
            userRepository.Insert(user);
        }


    }
}
