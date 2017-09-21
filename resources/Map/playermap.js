API.onUpdate.connect(function () {
    var players = API.getStreamedPlayers();
    API.sendNotification("Length: " + players.Length);
    for (var i = 0; i < players.Length + 1; i++)
    {
        API.sendNotification("Player: " + players[i]);
        //var location = API.getEntityPosition(player);
        //var blip = API.createBlip();
        //API.setBlipName(blip, player.name);

    }
    

})