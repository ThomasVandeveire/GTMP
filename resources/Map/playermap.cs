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

namespace GTMP
{
    class playermap : Script
    {
        public playermap()
        {
            API.consoleOutput("playermap started");
            API.onPlayerConnected += onPlayerConnectHandler;
            API.onPlayerDisconnected += onPlayerDisconnectHandler;
            API.onPlayerDeath += onPlayerDeathHandler;
            API.onPlayerRespawn += onPlayerRespawnHandler;
            List<Client> players = API.getAllPlayers();
            foreach (var p in players)
            {
                
                    Vector3 playerPos = API.getEntityPosition(p);
                    NetHandle blip = API.createBlip(p);
                    API.setBlipName(blip, p.name);
                    API.setBlipPosition(blip, playerPos);
                
            }
        }
        private void onPlayerConnectHandler(Client player)
        {
            Vector3 playerPos = API.getEntityPosition(player);
            NetHandle blip = API.createBlip(player);
            API.setBlipName(blip, player.name);
            API.setBlipPosition(blip, playerPos);
        }

        private void onPlayerRespawnHandler(Client player)
        {
            Vector3 playerPos = API.getEntityPosition(player);
            NetHandle blip = API.createBlip(player);
            API.setBlipName(blip, player.name);
            API.setBlipPosition(blip, playerPos);
        }



        private void onPlayerDisconnectHandler(Client player, string reason)
        {
             List<NetHandle> blips = API.getAllBlips();
            foreach (NetHandle blip in blips)
            {
                string blipname = API.getBlipName(blip);
               if(blipname == player.name)
                {
                    API.deleteEntity(blip);
                }
            }
            
        }


        private void onPlayerDeathHandler(Client player, NetHandle killer, int weapon)
        {
            List<NetHandle> blips = API.getAllBlips();
            foreach (NetHandle blip in blips)
            {
                string blipname = API.getBlipName(blip);
                if (blipname == player.name)
                {
                    API.deleteEntity(blip);
                }
            }

        }


    }
}
