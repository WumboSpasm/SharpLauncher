# SharpLauncher for BlueMaxima's Flashpoint
SharpLauncher is an alternative launcher for <a href="https://bluemaxima.org/flashpoint/">BlueMaxima's Flashpoint</a>, a webgame preservation project. It is written in C# (utilizing Windows Forms for its GUI), and serves as a frontend for the <a href="https://github.com/oblivioncth/CLIFp">CLIFp</a> command-line tool.

![launcher_screenshot](https://user-images.githubusercontent.com/58399748/158019657-24b71ee5-e706-4cec-88a9-74d456f95175.png)

## Features
* Faster loading times
* Full access to the Flashpoint database
* Search operators with OR | support
* Favorites and play history tracking
* In-launcher data statistics and management 

Playlists and a log viewer may be added in the future if I feel like it. Curation management features are not planned.

## Prerequisites
* <a href="https://github.com/oblivioncth/CLIFp">CLIFp</a> (ideal location is a `CLIFp` folder within the Flashpoint directory)
* <a href="https://cdn.discordapp.com/attachments/496132309498724391/945863222991392798/filters.json">filters.json</a> (if you want extreme entries to be filtered; must be placed in the same directory as SharpLauncher)

## Special thanks
* <a href="https://github.com/LindirQuenya">LindirQuenya</a> for substantial code contributions, particularly block-based entry loading
* <a href="https://github.com/oblivioncth">oblivioncth</a> for creating CLIFp
* <a href="https://github.com/n0samu">nosamu</a> for being my primary beta tester and cheerleader
* <a href="https://bluemaxima.org/flashpoint/">BlueMaxima's Flashpoint</a> and <a href="https://ruffle.rs/">Ruffle</a> communities for coding assistance and support
