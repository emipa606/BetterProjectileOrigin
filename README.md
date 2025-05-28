# [Better Projectile Origin](https://steamcommunity.com/sharedfiles/filedetails/?id=2843040075)

![Image](https://i.imgur.com/iCj5o7O.png)

Okay, so this mod may be a bit unnecessary but the idea got stuck in my head so I made it mostly to see if it was possible.
If you find it useful I suggest you look into the [Gunplay](https://steamcommunity.com/sharedfiles/filedetails/?id=2034896549)-mod if you want more features. 

In the vanilla game all projectiles shot by pawns originates from the center of the pawn, not from the weapon they are holding. The game dont know where on a weapon the projectile "should" spawn as the weapons are just textures. Ordinarily this is probably close enough but when using mods like [Camera+](https://steamcommunity.com/sharedfiles/filedetails/?id=867467808) however, it can look a bit wierd when zoomed in. 

So this mod scans all weapons at game-start, finds the last non-transparent pixel in their texture, assuming that is where the projectile should spawn. It then modifies the start-point for projectile to that spot instead of at the center of the pawn. Should work when using the [Dual Wield](https://steamcommunity.com/sharedfiles/filedetails/?id=1628211313) mod as well.

Technically this will affect the combat ever so slightly, since the projectile path will be shorter depending on the length of the weapon. I dont think this will have any noticable impact however, but report if you see anything strange.

Hopefully someone will find this mod useful!

Thank you to the [Projectile Offset Framework](https://steamcommunity.com/sharedfiles/filedetails/?id=2840633013) by Profilgate that put the idea in my head from the start.
	
![Image](https://i.imgur.com/Ds0rBAD.png)

Since modding is just a hobby for me I expect no donations to keep modding. If you still want to show your support you can gift me anything from my [Wishlist](https://store.steampowered.com/wishlist/id/Mlie) or buy me a cup of tea.

[![Image](https://i.imgur.com/VWG0yff.png)](https://ko-fi.com/G2G55DDYD)

![Image](https://i.imgur.com/5xwDG6H.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using [HugsLib](https://steamcommunity.com/workshop/filedetails/?id=818773962) or the standalone [Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404) and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods

 

[![Image](https://img.shields.io/github/v/release/emipa606/BetterProjectileOrigin?label=latest%20version&style=plastic&labelColor=0070cd&color=white)](https://steamcommunity.com/sharedfiles/filedetails/changelog/2843040075) | tags: realism
