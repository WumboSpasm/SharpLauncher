# SharpLauncher for BlueMaxima's Flashpoint
SharpLauncher is an alternative launcher for [BlueMaxima's Flashpoint](https://bluemaxima.org/flashpoint/), a webgame preservation project. It is written in C# (utilizing Windows Forms for its GUI), and serves as a frontend for the [CLIFp](https://github.com/oblivioncth/CLIFp) command-line tool.

![Screenshot](https://user-images.githubusercontent.com/58399748/207768750-81197560-3cf8-4ec4-b283-0146fd1202aa.png)

## Features
* Faster loading times
* Significantly smaller file size (3MB vs. ~300MB)
* Full access to the Flashpoint database
* Search operators with OR | support
* Favorites and play history tracking
* In-launcher data statistics and management

Playlists and a log viewer may be added in the future if I feel like it. Curation management features are not planned.

## Prerequisites
* [CLIFp](https://github.com/oblivioncth/CLIFp) (ideal location is a `CLIFp` folder within the Flashpoint directory)
* [sharpFilters.json](https://cdn.discordapp.com/attachments/516027726851735632/1060433416199360584/sharpFilters.json) (if you want extreme entries to be filtered; must be placed in the same directory as SharpLauncher)
* `e_sqlite3.dll` (must be placed in the same directory as SharpLauncher; can be retrieved from `SQLitePCLRaw.lib.e_sqlite3` package)

## Special thanks
* [LindirQuenya](https://github.com/LindirQuenya) for substantial code contributions, particularly block-based entry loading
* [oblivioncth](https://github.com/oblivioncth) for creating CLIFp
* [nosamu](https://github.com/n0samu) for being my primary beta tester and cheerleader
* [BlueMaxima's Flashpoint](https://bluemaxima.org/flashpoint/) and [Ruffle](https://ruffle.rs/) communities for coding assistance and support
