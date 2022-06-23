using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NaplatnaRampa.contoller;
using NaplatnaRampa.repository;

namespace NaplatnaRampa
{
    internal class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().AsSelf();
        }
        }
}
