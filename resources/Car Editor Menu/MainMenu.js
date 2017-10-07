/// <reference path="types-gt-mp/Definitions/index.d.ts" />
var menuPool = null;
API.onKeyDown.connect(function (Player, args) {
    if (args.KeyCode == Keys.E && !API.isChatOpen()) {
        menuPool = API.getMenuPool();
        var menu = API.createMenu("Test", 0, 0, 6);
        var item1 = API.createMenuItem("Item1", "");
        var item2 = API.createMenuItem("Item2", "");
        item1.Activated.connect(function (menu, item) {
            API.sendChatMessage("You clicked on first item!");
        });
        menu.AddItem(item1);
        menu.AddItem(item2);
        menuPool.Add(menu);
        menu.Visible = true;
    }
});
API.onUpdate.connect(function () {
    if (menuPool != null) {
        menuPool.ProcessMenus();
    }
});
//# sourceMappingURL=MainMenu.js.map