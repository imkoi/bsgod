# BSGOD
BSGOD is multi-hack for Blockstorm game.
Current hacks:
- Aim hack
- Wall hack
- Speed hack
- Fly hack
- Recoil hack

### How to get BSGod.dll
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
	2. smi.exe inject -p Blockstorm -a BSGod.dll -n BSGod -c BsGodInjector -m Inject
- Done!