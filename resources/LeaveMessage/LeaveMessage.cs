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
    class LeaveMessage : Script
    {
        public LeaveMessage()
        {
            API.onPlayerDisconnected += onPlayerLeaveHandler;
        }
        private void onPlayerLeaveHandler(Client player, string reason)
        {
            API.sendNotificationToAll(player.name + " left");
        }
    }
}
