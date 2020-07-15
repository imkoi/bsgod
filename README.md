# BSGOD by Koi
BSGOD is first multi-hack for Blockstorm game.
Current hacks:
- Aim hack
- Wall hack
- Speed hack
- Fly hack
- Recoil hack

### How to get BSGod.dll
Fastest way - download [latest release](https://github.com/imkoi/bsgod/releases)

Or build it by yourself :)
1. Open BSGod.csproj in Visual Studio
2. Add reference to UnityEngine.dll from "BlockstormFolder"\Blockstorm_Data\Managed\
3. Add reference to Assembly-CSharp.dll from "BlockstormFolder"\Blockstorm_Data\Managed\
4. Build solution
5. Inject BSGod.dll and press Insert key to show BSGOD gui

### How to inject hack
To inject hack you can use [SharpMonoInjector](https://github.com/warbler/SharpMonoInjector)
Next steps:
- Run game
- Move BSGod.dll to SharpMonoInjector folder
- Open Command Prompt
- Write commands:
	1. cd "Path_to_SharpMonoInjector"
	2. smi.exe inject -p Blockstorm -a BSGod.dll -n BSGod -c Injector -m Inject
- Done!

### About code and code style :)
There are no code style at all, code writted on c# 2.0, because the game still use unity 4.5.5...
Also this cheat was writted in one day, so i didnt try to optimize it at all

### Screenshots
![Hack GUI](https://github.com/imkoi/bsgod/blob/master/Screenshots/hack_menu.png)
![Fly Hack](https://github.com/imkoi/bsgod/blob/master/Screenshots/fly_hack.png)
![Wall Hack](https://github.com/imkoi/bsgod/blob/master/Screenshots/hack_wh.png)
![Aim Hack](https://github.com/imkoi/bsgod/blob/master/Screenshots/aim.png)
