using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MongoDB.Driver;
using NaplatnaRampa.contoller;
using NaplatnaRampa.model;

namespace NaplatnaRampa.view
{
    public class LoginFunction
    {
        public UserController userController;
        IMongoDatabase database;


        public LoginFunction(IMongoDatabase db)
        {
            this.userController = Globals.container.Resolve<UserController>();
            this.database = db;
        }

        public bool Validate(String email, string password) {

            User loggedUser = userController.CheckCredentials(email, password);

            if (loggedUser != null)
            {
                return true;

            }
            return false;

        }


        public void SuccessfulLogin(User loggedUser)
        {
            if (loggedUser.role == Role.MENAGER)
            {

                ManagerGUI managerGUI = new ManagerGUI(loggedUser);
                managerGUI.Show();

            }
            else if (loggedUser.role == Role.ADMIN)
            {

                AdministratorGUI adminGui = new AdministratorGUI(loggedUser);

                adminGui.Show();

            }

            else if (loggedUser.role == Role.BOSS)
            {
                BossGUI bossGUI = new BossGUI(loggedUser);
                bossGUI.Show();

            }
            else if (loggedUser.role == Role.CHARGEER)
            {
                ChargerGUI chargerGUI = new ChargerGUI(loggedUser);
                chargerGUI.Show();
            }


        }


    }
}
