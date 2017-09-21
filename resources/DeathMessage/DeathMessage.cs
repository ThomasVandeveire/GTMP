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
    public class DeathMessage : Script
    {
        public DeathMessage()
        {
            API.onResourceStart += ResourceStart;
            API.onPlayerDeath += OnPlayerDeathHandler;
        }


        private void ResourceStart()
        {
            API.consoleOutput("Resource Started (Our first script!!!!!)");
        }



        private void OnPlayerDeathHandler(Client player, NetHandle entityKiller, int weapon)
        {
            Client killer = API.getPlayerFromHandle(entityKiller);
            if (killer != null)
            {
				if(killer == player)
				{
					API.sendNotificationToAll(player.name + " died");
					
				}else{
                API.sendNotificationToAll(killer.name + " has killed " + player.name + " with " + API.getPlayerCurrentWeapon(killer).ToString());
                }
            }
            else
            {
                API.sendNotificationToAll(player.name + " died");
            }
        }

    }
}
