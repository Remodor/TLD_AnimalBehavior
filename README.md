# Animal Behavior for *The Long Dark*

This is a mod for **The Long Dark** by Hinterland Studio, Inc.

It includes [TweakRabbits](https://github.com/ds5678/TweakRabbits) and [DetectionRange](https://github.com/ds5678/DetectionRange) ported by [ds5678](https://github.com/ds5678) and originally made by [AlexTheRegent](https://github.com/AlexTheRegent).
**Special thanks** to both for all their contributions!

These mods are obsolete and have to be **removed** in order to use this mod!

## Description

The default animal behavior were to easy in my opinion and not really challenging. Especially rabbits needed a lot of tweaking. Besides adding many new options, like a fleeing duration, bleed out modifier, wolf behavior on aiming, etc., I also wanted to improve [DetectionRange](https://github.com/ds5678/DetectionRange) and [TweakRabbits](https://github.com/ds5678/TweakRabbits). Instead of having multiple animal behavior mods, with the permission of [ds5678](https://github.com/ds5678) I decided to include all animal mods polished and enhanced into this one.

## Settings

There are many new settings in the *Mod Options*:

- Special Behavior
  - Wolf Stalking Behavior When Aiming

    _The stalking behavior from wolves when the player aims at them._
    - Attack Probability

      _The probability for an attack every time it is checked._
    - Attack Probability Interval

      _The duration between each probability check in seconds. The first one is when you begin to aim._
  - Wolf Holding Ground Behavior When Aiming

    _The behavior from threatening wolves when the player is near a fire and aims at them._
    - Choose Wolves

      _Choose wolves to apply the changes. When applied to timberwolves they will also flee when you fire a gun and they are holding ground._
    - Direct Aim Accuracy

      _How close you have to aim you crosshair on a wolf to trigger fleeing._
    - Flee Probability

      _The probability for fleeing every time it is checked._
    - Flee Probability Interval

      _The duration between each probability check in seconds_
  - Rabbit Stun
  
    _The rabbit behavior when hit by a stone. The stun duration can be changed in the rabbits section (except when you choose random)._
    - Kill On Hit Probability

      _The probability to instantly kill the rabbit._
    - Maximum Stun Duration

      _The maximum stun duration when set to random. This overrides the stun duration in the rabbits section._
    - Minimum Stun Duration

      _The minimum stun duration when set to random. This overrides the stun duration in the rabbits section._
- Animal Bleeding
  - Bleed Out Modifier

      _The bleed out time is very dependent on what the player uses, on which animal and where it is being hit. This modifier will be multiplied to the final bleed out duration for arrows, bullets and flare gun shells (Not wolf struggle!). A common bleed out duration is 60 INGAME minutes, higher modifier means longer._
  - Stackable Bleeding

      _If you want stackable bleeding. If an animal is hit multiple times bleeding will get accumulated. Also applies to wolf struggle. Wolf struggle multiplier should get set accordingly. E.g. Two hits with: Duration1 = 60, Duration2 = 90 -> Final duration = 36_  
  - Wolf Struggle

      _"This modifier will be multiplied to the final bleed out duration for wolf struggle. The default is 12 INGAME minutes for a knife. If used together with stackable bleeding, this should be set pretty high as you hit the wolf around 10 times, e.g. 20._
  - Blood Drop Lifetime
  
      _Specify the lifetime of blood drops in hours. The oldest one will also disappear when the maximum amount of decals is reached. This is mostly the case if you don't increase the number of decals._
    - Lifetime - Blizzard/ Heavy Snow/ High Winds
	
	  _Lets you specify the respective lifetimes under special conditions._
  - Maximum Decals (Reload Required)
  
      *Specify the maximum amount of decals. These are: Player blood, animal blood, ice cracks, bullet decals. The oldest one will disappear when the maximum amount of decals is reached. Keep in mind, they need to be computed and may affect FPS! However, I had no problems even with 1000.*
- Animal Stats (Applied After Reload)
  - Wolf

    _Apply custom values to wolves. Note: also affects wolves' detection of rabbits and deer. The values are also modified with the two values for \"Wildlife Detection Range\"/ \"Wildlife Smell Range\" which can be seen when creating a custom survival game. Medium represents the set __Vanilla__ value. Only smell range will get changed with a different difficulty. Detection range is constant except when set otherwise._
    - Smell Range

      _How far it can smell the player while carrying meat._
    - Begin Charging Range

      _How far it will start charging at you when stalking._
    - Detection Range

      _How far it can see._
    - Hear Range

      _How far it can hear the player walk._
    - Detection Range While Feeding

      _How far it can see while it is feeding._
    - Hear Range While Feeding

      _How far it can hear the player walk while it is feeding._
    - Flee Duration

      _The minimum flee duration in seconds._
  - Timberwolf

    _All values accordingly._
    - Smell Range
    - Detection Range
    - Hear Range
    - Detection Range While Feeding
    - Hear Range While Feeding
    - Flee Duration

  - Deer

    _All values accordingly._
    - Detection Range
    - Hear Range
    - Flee Duration
  - Moose

    _All values accordingly._
    - Detection Range
    - Hear Range
    - Flee Duration
  - Rabbit

    _All values accordingly._
    - Detection Range
    - Hear Range
    - Flee Duration
    - Stun Duration

      _The stun duration in seconds when hit with a stone. Overridden when random is chosen._
  - Bear

    _All values accordingly._
    - Smell Range
    - Begin Charging Range
    - Detection Range
    - Hear Range
    - Flee Duration
	- Ignore Flares
	
	  *Currently flares are very strong. This setting will let bears ignore held flares.*
	- Ignore Marine Flares
	
	  *This setting will let bears ignore held marine flares.*

## Installation

1. If you haven't done so already, install [MelonLoader](https://github.com/LavaGang/MelonLoader/releases) v0.2.7.4+
2. If you haven't done so already, install [ModSettings](https://github.com/zeobviouslyfakeacc/ModSettings/releases) v1.7+
3. Download the latest version of `AnimalBehavior.dll` from the [releases](https://github.com/Remodor/TLD_AnimalBehavior/releases) page
4. Move `AnimalBehavior.dll` into the *Mods* folder of your *The Long Dark* installation directory

### Uninstallation

The mod can always be uninstalled. Just delete the `AnimalBehavior.dll` from the *Mods* folder.

## Modding Discord Server

If you have any questions/ suggestions or you just wanna say *"Thank you!"* visit the **[TLD Modding Discord Server](https://discord.gg/nb2jQez)** server!
