using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.ArrayExtensions;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;
using GrandTheftMultiplayer.Shared;



namespace BasicMessage
{
    class JoinMessage : Script
    {
        public JoinMessage()
        {
            API.onPlayerConnected += onPlayerJoinHandler;
        }
        private void onPlayerJoinHandler(Client player)
        {
            API.consoleOutput("JoinMessage is working");
            API.sendNotificationToAll(player.name + " joined");
			Vector3 playerPos = API.getEntityPosition(player);
            NetHandle blip = API.createBlip(player);
            API.setBlipPosition(blip, playerPos);
        }

    }
}
