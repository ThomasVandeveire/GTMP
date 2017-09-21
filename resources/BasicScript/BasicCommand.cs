using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using GrandTheftMultiplayer.Server.ArrayExtensions;


namespace BasicScript
{
    public class BasicCommand: Script
    {
       public BasicCommand()
        {
            API.onResourceStart += MyScriptStart;
        }

        private void MyScriptStart()
        {
            API.consoleOutput("BITCH PLEASE");
        }
    }
}
