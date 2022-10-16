# BetterProjectileOrigin

![Image](https://i.imgur.com/buuPQel.png)


Okay, so this mod may be a bit unnecessary but the idea got stuck in my head so I made it mostly to see if it was possible.
If you find it useful I suggest you look into the https://steamcommunity.com/sharedfiles/filedetails/?id=2034896549]Gunplay-mod if you want more features. 

In the vanilla game all projectiles shot by pawns originates from the center of the pawn, not from the weapon they are holding. The game dont know where on a weapon the projectile "should" spawn as the weapons are just textures. Ordinarily this is probably close enough but when using mods like https://steamcommunity.com/sharedfiles/filedetails/?id=867467808]Camera+ however, it can look a bit wierd when zoomed in. 

So this mod scans all weapons at game-start, finds the last non-transparent pixel in their texture, assuming that is where the projectile should spawn. It then modifies the start-point for projectile to that spot instead of at the center of the pawn. Should work when using the https://steamcommunity.com/sharedfiles/filedetails/?id=1628211313]Dual Wield mod as well.

Technically this will affect the combat ever so slightly, since the projectile path will be shorter depending on the length of the weapon. I dont think this will have any noticable impact however, but report if you see anything strange.

Hopefully someone will find this mod useful!

Thank you to the https://steamcommunity.com/sharedfiles/filedetails/?id=2840633013]Projectile Offset Framework by Profilgate that put the idea in my head from the start.
	
![Image](https://i.imgur.com/O0IIlYj.png)

Since modding is just a hobby for me I expect no donations to keep modding. If you still want to show your support you can gift me anything from my https://store.steampowered.com/wishlist/id/Mlie]Wishlist or buy me a cup of tea.

https://ko-fi.com/G2G55DDYD]![Image](https://i.imgur.com/Utx6OIH.png)


![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using https://steamcommunity.com/workshop/filedetails/?id=818773962]HugsLib and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.




