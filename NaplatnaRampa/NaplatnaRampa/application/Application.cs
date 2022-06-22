using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaplatnaRampa.application
{
    internal class Application
    {
        static void Main(string[] args)
        {
           

         
            Application.Run(new LoginGUI(Globals.database));
        }
    }
}
