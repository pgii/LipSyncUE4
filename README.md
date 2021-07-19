# Concept project lip sync for Genesis 8 in Unreal Engine using morph targets

Upd:
1. The expressions template has been moved to a separate json file (Settings/ExpressionTemplate.json)
2. Added the ability to create a track without an audio file
3. Redesigned interface
4. Implemented debug mode, for viewing in Unreal Engine in real time
5. Added the ability to change the length of the track (only works when there is no audio file)
6. Minor changes in the code. 

https://youtu.be/AFBuQ8ah9ng

Used plugin: https://github.com/getnamo/udp-ue4

Download from this page https://github.com/getnamo/udp-ue4/releases and put the Plugins folder from archive in to the root of your project.

Upd: Added Phoneme Duration.
```
{"AI", 5.0f}, {"E", 4.5f}, {"U", 4.0f}, {"O", 4.0f}, {"TH", 2.0f}, {"FV", 2.5f}, {"L", 3.0f}, {"MBP", 1.5f}, {"WQ", 4.0f}
```

Upd: Added the ability to generate phonemes based on words. (Preston Blair)

Upd: Removed the use of the JSON plugin in Unread Engine.


https://youtu.be/NMTRQBfOoqE

https://youtu.be/4L-_ZwWEvLE

![alt text](https://github.com/pgii/LipSyncUE4/blob/master/Screenshots/Screenshot01.jpg)

![alt text](https://github.com/pgii/LipSyncUE4/blob/master/Screenshots/Screenshot02.jpg)

Special thanks to Oliver Salzburg https://github.com/oliversalzburg for his project https://github.com/oliversalzburg/TimeBeam, with reduced the development time to a couple of weeks.
