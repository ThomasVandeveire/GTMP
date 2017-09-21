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
    class ChangeNameCommand : Script
    {

        [Command("changename", GreedyArg = true)]
        public void changeNameCommand(Client player, string name)
        {
           
            API.setPlayerName(player, name);
        }

        [Command("color", GreedyArg =true)]
        public void changeCarColor(Client player, string color)
        {
            if (player.isInVehicle)
            {
                API.setVehiclePrimaryColor(player.vehicle, 204);
            }
        }
    }
}
