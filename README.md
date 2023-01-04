# ARSigningAvatar

This is a demo application of the Signing Avatar from TAS (https://www.tas.fee.unicamp.br/). The demo was developed in Unity 2020.3.40f1 for the ThinkReality A3 Smart Glasses and the Motorola Edge+.

## Requirements
- Unity 2020.3.40f1
- Animation Rigging v1.0.3
- Snapdragon Spaces SDK v0.8.1
(https://docs.spaces.qualcomm.com/unity/setup/SetupGuideUnity.html)

## Scene Description
The demo is built on top of the XR Interaction Toolkit sample from Snapdragon Spaces SDK. There are five main components in the Scene: Samples Assets and Interaction handle the Glasses and controller input; UI stores the panel and interactive buttons; the AR camera and canvas for the subtitles are in the AR Session Origin; and talita_qualcomm is the Signing Avatar rigged with the Animation Rigging to control the LookAt function of the avatar's head torwards the camera.

The TalitaController inside the folder Animations specifies animation transitions, triggers, speed, duration, among others. Finally, there are two scripts: one handles the button press events to trigger the corresponding animation, the start of idle animations after few seconds, and the LookAt weigth from the avatar rig; the other script checks which animation is playing and the respective text in English and Portuguese.

## Authors
Rodolfo Luis Tonoli
Ângelo Brandão Benetti
José Mario De Martino