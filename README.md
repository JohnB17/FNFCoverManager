### === CURRENTLY IN BETA ===
This software is currently developed.

---

# Friday Night Funkin Cover Manager
A way to manage all of the covers for your FNF songs

## How to add songs and covers
(A better way to do this is planned)

Included is a template config. This should be placed next to the executable as `fnfcovermanager_config.json`

Just add new elements to the JSON.


### Songs
Songs are organized with two values; Name and Path.

Name: a string of the song name

Path: the path to the folder of the song (e.g. `YourFNFMod\bin\assets\songs\good-song`)

### Covers
Covers have three values; SongName, CoverName, and Path.

SongName: a string of the song name, **NEEDS** to match a song name from the SongDirs array, otherwise the program doesn't know this cover belongs to that song!

CoverName: the name of the cover, something that tells you which cover it is. Use only spaces, letters, and numbers.

Path: the path to the cover file (e.g. `YourCovers\good-song\good-song cover Voices.ogg`)
