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
    class Passenger : Script
    {
        public Passenger()
        {
            API.onPlayerEnterVehicle += onPlayerEnterHandler;
            API.onPlayerExitVehicle += onPlayerExitHandler;
        }

        private void onPlayerEnterHandler(Client player, NetHandle vehicle)
        {
            VehicleHash car = API.vehicleNameToModel(vehicle.GetType().ToString());
            float Occupants = API.getVehicleMaxOccupants(car);
            Client[] occupants = API.getVehicleOccupants(vehicle);
            
            if (occupants.Count() < Occupants)
            {
                API.sendNotificationToPlayer(player, "#Occupants: " + occupants.Count());
                API.setPlayerIntoVehicle(player, vehicle, occupants.Count() - 2);
            }
            
        }


        private void onPlayerExitHandler(Client player, NetHandle vehicle)
        {
            Client[] occupants = API.getVehicleOccupants(vehicle);
            for(int i = 0; i<occupants.Count(); i++ )
            {
                
                if (occupants[i] == player)
                {
                    occupants[i].delete();
                }
            }
        }

    }
}
