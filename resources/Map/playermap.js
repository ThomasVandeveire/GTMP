

API.onResourceStart.connect(function () {
    var Blips = API.getAllBlips;
    
    var player = API.getLocalPlayer;
    API.sendNotification(player.name);

    for (var b in Blips)
    {
        var blipName = API.getBlipName(b)
        if (blipname == player.name);
        API.deleteEntity(b);

    }

})