![icon](https://micro-artwork.github.io/images/projects/xi2ds/icon.png)

# XInput to Dualshock 4 (XI2DS)

The XI2DS is designed to run and control Play Station Remote Play(PSRP) using Xbox(or XInput) controllers(XC) instead of DualShock4(DS4) controllers on Windows. Although it is considered to be able to recognize and map up to 4 controllers, PSRP only accepts one controller input, so only the first connected controller can be recognized.

Unfortunately, for some unknown reason, the touchpad press may not work in some games.

It was developed for personal use, so I haven't been able to test many cases.  After hundreds of hours of play, no major problems were found, but if find problems, I will try to fix bugs.



## Features

### Map XInput to Dualshock 4

XC and DS4 have near similar function buttons (e.g. D-Pads, start(option), analog sticks, bumpers, triggers and face buttons) and their buttons can be mapped directly. However SHARE, PS Home and Touchpad Press buttons of DS4 are mapped by XC's button combinations.

XC's select(or View) button is not mapped and used only for combinations.

|Combinations|Select + Letf Bumper|Select + Right Bumper|Select + Start|
|-|-|-|-|
|DS4 Mapping|Share|Touchpad Press|PS Home|


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

5. Play games on PSRP

When click close the application, go to tray instead of termination. If want termination compeletly, use exit on menu.

![](https://micro-artwork.github.io/images/projects/xi2ds/xi2ds_6.png)

## Demo

![](https://micro-artwork.github.io/images/projects/xi2ds/demo.gif)
https://youtu.be/bRIGUEyhO0w
