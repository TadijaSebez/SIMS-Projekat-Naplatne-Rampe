using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Autofac;
using MongoDB.Bson;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;

namespace NaplatnaRampa.contoller
{

    public class UserController
    {
        public IUserRepository userRepository; 
        private List<Action> callbackFunctions;

        public UserController()
        {
            this.userRepository = Globals.container.Resolve<IUserRepository>();
            this.callbackFunctions = new List<Action>();
        }

        public void AddUpdateCallback(Action function)
        {
            callbackFunctions.Add(function);
        }

        private void Updated()
        {
            foreach (Action function in callbackFunctions)
            {
                function();
            }
        }
        public User CheckCredentials(string email, string password)
        {
            return userRepository.CheckCredentials(email, password);
        }


        public List<User> Users()
        {
            return userRepository.GetAll();
        }


        public void Delete(ObjectId id)
        {
            userRepository.Delete(id);
            Updated();
        }
        public User GetUserById(ObjectId id)
        {
            return userRepository.GetById(id);
        }
        public string getRoleString(Role role)
        {
            if (role == Role.ADMIN)
            {
                return "Administrator";
            } else if (role == Role.BOSS) {
                return "Sef stanice";
            }
            else if (role == Role.MENAGER)
            {
                return "Menadzer";
            }
            else
            {
                return "Referent naplate";
            }

        }

        public User GetUserByEmail(string email)
        {
            foreach(User user in userRepository.GetAll())
            {
                if (user.email.Equals(email))
                {
                    return user;
                }
            }
            return null;
        }

        public int indexOfRoleComboBox(Role role)
        {
            if(role == Role.CHARGEER)
            {
                return 2;
            }else if(role == Role.MENAGER)
            {
                return 1;
            }
            else
            {
                return 0;
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
            Updated();
        }

        public void Update(User user)
        {
            userRepository.Update(user);
            Updated();
        }


    }
}
