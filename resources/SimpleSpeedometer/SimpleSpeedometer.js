		var g_menu = API.createMenu("Banner", "Subtitle", 0, 0, 6);
g_menu.ResetKey(menuControl.Back);

for (var i = 0; i < 20; i++) {
	g_menu.AddItem(API.createMenuItem("Item " + i, "Description " + i));
}

g_menu.OnItemSelect.connect(function(sender, item, index) {
	API.sendChatMessage("You selected: ~g~" + item.Text);

	API.showCursor(false);
	g_menu.Visible = false;
});

API.onServerEventTrigger.connect(function(name, args) {
	if (name == "OPEN_MENU") {
		API.showCursor(true);
		g_menu.Visible = true;
	}
});


API.onResourceStart.connect(function(){
		var res = API.getScreenResolution();
		var speed = 30;
	var string = "Speed: " + speed * 3.6 + " km/h";	
		API.addTextElement("Example text\nScale 1, Font 1", 600.0, 200.0, 1.0, 0, 255, 0, 255, 1, -1);	


    });

API.onResourceStop.connect(function(){
	
	
});

API.onUpdate.connect(function(){
	var player = API.getLocalPlayer();
	var inVeh = API.isPlayerInAnyVehicle(player)
	API.drawMenu(g_menu);
	/* 
		if(inVeh)
		{
			
			var car = API.getPlayerVehicle(player);
			var health = API.getVehicleHealth(car);
			var velocity = API.getEntityVelocity(car);
			var speed = Math.sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y + velocity.Z * velocity.Z);
			var kmh = speed * 3.6;
			
			
		} */
	
    
	
	
});