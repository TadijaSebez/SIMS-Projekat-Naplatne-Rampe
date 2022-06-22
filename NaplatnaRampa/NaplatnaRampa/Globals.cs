using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MongoDB.Driver;

namespace NaplatnaRampa
{
    internal class Globals
    {
        public static IContainer container;
        public static IMongoDatabase database;
        public static void Load()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ProgramModule>();
            container = containerBuilder.Build();

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://anastasija:anastasija2001@cluster0.tlsbsly.mongodb.net/test");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            database = client.GetDatabase("SIMS");
        }
    }
}
