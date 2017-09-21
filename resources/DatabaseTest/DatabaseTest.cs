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
using System.Data.SqlClient;


namespace GTMP
{
    class DatabaseTest : Script
    {
        public DatabaseTest()
        {
            SqlConnection myConnection = new SqlConnection("user id=root;password=VNetFlamoes:server=localhost;Trusted_Connection=yest;database=GTMP;connection timeout=30");
            try
            {
                myConnection.Open();
                API.sendNotificationToAll("Success");
            }
            catch (Exception e)
            {
                API.sendNotificationToAll("Error");
            }
            
        }
    }
}
