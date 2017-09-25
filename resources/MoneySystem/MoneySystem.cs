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

namespace GTMP
{
    class MoneySystem : Script
    {
        public MoneySystem()
        {
            API.onPlayerConnected += PlayerDatabaseConnectHandler;
            //API.exported.database.executeQuery("INSERT INTO `accounts` (`id`, `money`, `account`) VALUES ('2', '10000', 'testuser');");
           
        }

        [Command("pay", GreedyArg = true)]
        public void giveMoneyCommand(Client player, string name, string money)
        {
            double amount = Double.Parse(money);
            Client receiver = API.getPlayerFromName(name);
            if (receiver != null)
            {
                DataTable dataSender = API.exported.database.executeQueryWithResult("SELECT `money` FROM accounts WHERE `account` = '" + player.name + "'");
                DataTable dataReceiver = API.exported.database.executeQueryWithResult("SELECT `money` FROM accounts WHERE `account` = '" + name + "'");
                string amountSender = dataSender.Rows[0]["money"].ToString();
                string amountReceiver = dataReceiver.Rows[0]["money"].ToString();
                double amountSend = Double.Parse(amountSender);
                double amountReceiv = Double.Parse(amountReceiver);

                if (amount > amountSend)
                {
                    API.sendChatMessageToPlayer(player, "You can't afford that!");
                }
                else if (amount > 0)
                {
                    amountSend -= amount;
                    amountReceiv += amount;
                    API.exported.database.executeQuery("UPDATE `accounts` SET `money` = '" + amountSend + "' WHERE `account` = '" + player.name + "'");
                    API.exported.database.executeQuery("UPDATE `accounts` SET `money` = '" + amountReceiv + "' WHERE `account` = '" + name + "'");
                    API.sendChatMessageToPlayer(receiver, "You have received " + amount + " euro from " + player.name);
                    API.sendChatMessageToPlayer(player, "You payed " + name + " " + amount + " euro");
                }
                else
                {
                    API.sendChatMessageToPlayer(player, "The given number is too small");
                }

            }
            else
            {
                API.sendChatMessageToPlayer(player, "player '"+ name + "' not found, the given player might not be online or doesn't exist");
            }

        }


        [Command("money")]
        public void moneyCommand(Client player)
        {
            DataTable data = API.exported.database.executeQueryWithResult("SELECT `money` FROM accounts WHERE `account` = '" + player.name + "'");
            string amount = data.Rows[0]["money"].ToString();
            API.sendChatMessageToPlayer(player, "Your balance is: €" + amount);

        }


        private void PlayerDatabaseConnectHandler(Client player)
        {
            
            bool existence = CheckExistence(player.name);
            if (existence)
            {
                API.sendNotificationToPlayer(player, "Welcome back!");
            }
            else{
                API.sendNotificationToPlayer(player, "Welcome!");
                API.exported.database.executeQuery("INSERT INTO `accounts` (`money`, `account`) VALUES ('0', '" + player.name +"' );");

            }


        }
        

        private bool CheckExistence(string name)
        {
                DataTable data = API.exported.database.executeQueryWithResult("SELECT COUNT(*) AS AANTAL FROM accounts WHERE account = '" + name + "';");
            foreach (DataRow r in data.Rows)
            {
                
                string aantal = r["AANTAL"].ToString();
                if (aantal.Equals("0"))
                {
                    return false;
                }
                else {
                    return true;
                }

            }

            return false;
            



        }



    }
}
