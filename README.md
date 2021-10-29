![icon](https://micro-artwork.github.io/images/projects/xi2ds/icon.png)

# XInput to Dualshock 4 (XI2DS)

The XI2DS is designed to run and control Play Station Remote Play(PSRP) using Xbox(or XInput) controllers(XC) instead of DualShock4(DS4) controllers on Windows. Although it is considered to be able to recognize and map up to 4 controllers, PSRP only accepts one controller input, so only the first connected controller can be recognized.

Unfortunately, for some unknown reason, the touchpad press may not work in some games.

It was developed for personal use, so I haven't been able to test many cases.  After hundreds of hours of play, no major problems were found, but if find problems, I will try to fix bugs.

## Requirements for running
* .NET 5.0 runtime or Higher (https://dotnet.microsoft.com/download/dotnet/5.0)
* Windows 10
* ViGEmBus 1.17.333 (https://github.com/ViGEm/ViGEmBus/releases/tag/setup-v1.17.333)

## Features

### Map XInput to Dualshock 4

XC and DS4 have near similar function buttons (e.g. D-Pads, start(option), analog sticks, bumpers, triggers and face buttons) and their buttons can be mapped directly. However SHARE, PS Home and Touchpad Press buttons of DS4 are mapped by XC's button combinations.

XC's select(or View) button is not mapped and used only for combinations.

|Combinations|DS4 Mapping|
|-|-|
|Select + Left Bumper|Share|
|Select + Right Bumper|Touchpad Press|
|Select + Start|PS Home|


### Support Force Feedback

If play a game that supports force feedback, XC can be vibrated.


### Indicate XC Battery(or Connection) Status

Display XC's battery level(wireless only) or wired status. Additionally, The battery level is not detailed, it will be displayed as mid for most of time. If indicate low, need to charging or replacing. And if connect a controller, will not diaplay status immediately. After any buttons input, it will be displayed.



## How to use
It is very simple to use!

1. Download and install ViGEm bus driver (https://github.com/ViGEm/ViGEmBus/releases)

2. Download and excute XI2DS

![](https://micro-artwork.github.io/images/projects/xi2ds/xi2ds_1.png)

3. Connect a controller

![](https://micro-artwork.github.io/images/projects/xi2ds/xi2ds_3.png)

4. Click 'DS4 Connect' Button

![](https://micro-artwork.github.io/images/projects/xi2ds/xi2ds_4.png)

5. Play

When click close button on application, go to tray without termination. If want termination completely, use Exit on menu.

![](https://micro-artwork.github.io/images/projects/xi2ds/xi2ds_6.png)

## Demo

![](https://micro-artwork.github.io/images/projects/xi2ds/demo.gif)

https://youtu.be/bRIGUEyhO0w

Note: You can check controller state on https://gamepad-tester.com/
