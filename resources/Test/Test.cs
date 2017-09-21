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
    class Test : Script
    {
        public Test(Client player)
        {
            API.onPlayerEnterVehicle += onPlayerEnterVehicle;
            
        }

        private void onPlayerEnterVehicle(Client player, NetHandle vehicle)
        {
            
            PedHash model = API.pedNameToModel("Abigail");
            Vector3 pos = API.getEntityPosition(player);
            for (int i = 0; i < 10; i++)
            {
                API.createPed(model, pos, 0);
            }
            
            
           
        }

    }
}
