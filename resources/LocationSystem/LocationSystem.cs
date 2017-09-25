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
using System.Data;
using System.Xml.Serialization;
using System.IO;

namespace GTMP
{
    class LocationSystem : Script
    {
        public LocationSystem()
        {
            API.onPlayerConnected += sendToLastLocationHandler;
            API.onPlayerDisconnected += saveLastLocationHandler;
            API.onPlayerExitVehicle += openParachuteHandler;
        }

        private void sendToLastLocationHandler(Client player)
        {
            DataTable data = API.exported.database.executeQueryWithResult("SELECT * FROM `accounts` WHERE `account` = '" + player.name + "'");
            string posX = data.Rows[0]["lastlocationX"].ToString();
            string posY = data.Rows[0]["lastlocationY"].ToString();
            string posZ = data.Rows[0]["lastlocationZ"].ToString();
            string car = data.Rows[0]["vehicle"].ToString();
            
            string color1 = data.Rows[0]["color1"].ToString();
            string color2 = data.Rows[0]["color2"].ToString();
            string rotX = data.Rows[0]["lastrotationX"].ToString();
            string rotY = data.Rows[0]["lastrotationY"].ToString();
            string rotZ = data.Rows[0]["lastrotationZ"].ToString();
            if (posX != "")
            {
                //API.sendNotificationToPlayer(player, "X: " + float.Parse(posX) + " Y: " + float.Parse(posY) + " Z: " + float.Parse(posZ));
                Vector3 position = new Vector3(float.Parse(posX), float.Parse(posY), float.Parse(posZ));
                Vector3 rotation = new Vector3(float.Parse(rotX), float.Parse(rotY), float.Parse(rotZ));
                player.position = position;
                player.rotation = rotation;
                if (car != null)
                {
                    //int color1r = Int32.Parse(color1.Substring(0, 3));
                    //int color1g = Int32.Parse(color1.Substring(3, 3));
                    //int color1b = Int32.Parse(color1.Substring(6, 3));
                    //int color1a = Int32.Parse(color1.Substring(9, 3));

                    //int color2r = Int32.Parse(color2.Substring(0, 3));
                    //int color2g = Int32.Parse(color2.Substring(3, 3));
                    //int color2b = Int32.Parse(color2.Substring(6, 3));
                    //int color2a = Int32.Parse(color2.Substring(9, 3));


                    //Color c1 = new Color(color1r, color1g, color1b, color1a);
                    //Color c2 = new Color(color2r, color2g, color2b, color2a);


                    //VehicleHash vehicle = API.vehicleNameToModel(car);
                    //Vehicle v =  API.createVehicle(vehicle, player.position, player.rotation, 0, 0);
                    //API.sendNotificationToPlayer(player, "TEST");
                    //API.setVehicleCustomPrimaryColor(v, color1r, color1g, color1b);
                    //API.setVehicleCustomSecondaryColor(v, color2r, color2g, color2b);
                    //Vehicle testVehicle = API.fromJson(car);
                    //API.setPlayerIntoVehicle(player, testVehicle, -1);
                }
                
            }
            else
            {
                Vector3 position = new Vector3(249.7704, 218.9983, 105.3873);
                player.position = position;
            }
        }

        private void saveLastLocationHandler(Client player, string reason)
        {
            Vector3 position = API.getEntityPosition(player);
            Vector3 rotation = API.getEntityRotation(player);
            if (player.isInVehicle) {
                Vehicle veh = player.vehicle;
                
                //string v = API.toJson(API.createObject(veh.model, veh.position, veh.rotation));
                //API.consoleOutput(v + "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Color c1 = player.vehicle.customPrimaryColor;
                Color c2 = player.vehicle.customSecondaryColor;
                string color1 = c1.red.ToString("000")+ c1.green.ToString("000") + c1.blue.ToString("000") + c1.alpha.ToString("000");
                string color2 = c2.red.ToString("000") + c2.green.ToString("000") + c2.blue.ToString("000") + c2.alpha.ToString("000");
                string[] data = new[] { "test value", "value2"  };
                API.toJson(data);
                API.exported.database.executeQuery("UPDATE `accounts` SET `lastlocationX` = '" + position.X + "', `lastlocationY` = '" + position.Y + "', `lastlocationZ` = '" + position.Z + "', `vehicle` = '" + player.vehicle + "', color1 = '" + color1 + "', color2 = '" + color2 + "', `lastrotationX` = '" + rotation.X + "', `lastrotationY` = '" + rotation.Y + "', `lastrotationZ` = '" + rotation.Z + "' WHERE `account` = '" + player.name + "'");
                API.deleteEntity(player.vehicle);
            }
            else
            {
                API.exported.database.executeQuery("UPDATE `accounts` SET `lastlocationX` = '" + position.X + "', `lastlocationY` = '" + position.Y + "', `lastlocationZ` = '" + position.Z + "', `vehicle` = null, color1 = null, color2 = null, `lastrotationX` = '" + rotation.X + "', `lastrotationY` = '" + rotation.Y + "', `lastrotationZ` = '" + rotation.Z + "' WHERE `account` = '" + player.name + "'");

            }
        }

        private void openParachuteHandler(Client player, NetHandle vehicle)
        {
            Vehicle v = API.getEntityFromHandle<Vehicle>(vehicle);
            if (API.getVehicleClassName(v.Class) == "Planes" || API.getVehicleClassName(v.Class) == "Helicopters") {
                WeaponHash para = API.weaponNameToModel("Parachute");
                API.givePlayerWeapon(player, para, 0, true, true);

            }

         
            
            
            

        }

    }
}
