<p align="center"><img alt="LostInMazieMansion" src="./Art/logo jpg ver.jpg" width="500"/></p>

# Lost in Mazie Mansion

An open source, horror-puzzle game developed within the Husky Game Development Enterprise.

Table of Contents
=================

<!--ts-->
   * [Download](#download)
   * [Husky Game Development](#husky-game-development)
   * [Game Overview](#game-overview)
      * [Trailer](#project-overview)
      * [Rules](#rules)
      * [Game Design Document](#game-design-document)
   * [Project Overview](#project-overview)
      * [Game Architecture](#game-architecture)
      * [Developer Setup](#developer-setup)
      * [Dependencies](#dependencies)
      * [Task Board](#task-board)
<!--te-->

## Download

The Lost In Mazie Mansion 2019 install is available on the Husky Game Development website found [here!](https://huskygames.com/games/?game=lost-in-mazie-mansion) The 2020 install will be available later this year!

  1. Navigate to the download page using [this link](https://huskygames.com/games/?game=lost-in-mazie-mansion) or the link above.
  2. Download the zip file by clicking `Download`.
  3. Make a new directory and drag the zip file into that directory. 
  4. Extract the files from the zip file.
  5. Run the executable file `LostInMazieMansion.exe` to launch the game.
  6. Enjoy!

## Husky Game Development

<p align="center">
  <a href="https://huskygames.com/">
    <img
      alt="Husky Game Development"
      src="./Art/Logo_Bl_1000.png"
      width="200"
    />
  </a>
</p>

Based in Houghton, Michigan, Husky Game Development Enterprise (HGD) has been dedicated to producing experienced game developers since 2004. We focus on using professional development tools to give students a leg up in the industry, such as Unity, Blender, and Wwise.

Our mission is to design and develop games for business, education, and fun. We work as an interdisciplinary, student-run Enterprise that fosters productivity, creativity, and effective business practices. Our members work in small teams of four to six people, exploring a wide variety of video game engines and platforms.

HGD has partnered with sponsoring companies to design games. We also get involved with campus events like BonzAI Brawl - an AI programming competition that anyone can partake in. This exciting annual event takes a full year to organize and is put together with the joint effort of HGD and the Women in Computing Sciences organization.

Check out our website [here!](https://huskygames.com/)

## Game Overview

Lost in Mazie Mansion is a top-down, horror-puzzle game in which the player is trapped within a mansion and must overcome their fears in order to escape. The player quickly realizes that there are indeed residents within the manion; however, these residents may not be living. In order to get out alive, the player must find items and tools throughout the mansion, solve various puzzles to conquer their fears, and eventually escape the mansion.

### Trailer

View our teaser trailer for 2020 [here!](https://youtu.be/gyetVksK51k)

### Rules

The game has a single goal and winning condition - escaping the mansion. Upon going through the entirety of the game’s story and reaching the end, the player will complete the game. Throughout the game, the player will reach several save points, which will allow the player to save their progress leading up to that point. The primary part of the game that impedes this progress is the player’s sanity meter. Various enemies and environmental hazards found throughout the game will cause the player’s sanity meter to decrease. When this sanity meter is fully depleted, the player will be unable to continue, and must restart from their most recent save point. Once the player has completely escaped the mansions, the credits will roll and the playthrough will be complete.

### Game Design Document

Available upon request!

Part of the pre-production process is the game design document, GDD. It is a highly descriptive and living software design document for our game which includes Sprint planning and roles for the upcoming semester. If you are interested in our documentation, reach out!

## Project Overview

Lost in Mazie Mansion is a 2D horror-puzzle game designed within Husky Game Development and created using the [Unity Game Engine](https://unity.com/). Scripting is accomplished though [Unity's Scripting API](https://docs.unity3d.com/ScriptReference/) using C#. This tells our GameObjects and other components how to interact with each other, creating gameplay. Our team utilizes [Inky](https://github.com/inkle/inky) for conditional dialogue and story progress and [FMOD](https://www.fmod.com/) for sound implementation. Using these tools our developers are producing a fun and interactive experience.

### Game Architecture 

- `/Art` - contains art assests and spritesheets 
- `/Audio` - contains audio files and sound effects
- `/Documentation` - contains developer documentation other than design documents which are stored on our Team Drive (Google)
- `/LostInMazieMansion` - Unity project (development)
  - `/Assets` - all of our gameplay assests
    - `/Animation` - animation files
    - `/Art` - sprites and UI artwork
    - `/Dialog` - dialog systems
    - `/Editor Default Resources` - contains FMOD resources
    - `/Fonts` - contains gameplay fonts
    - `/Gizmos` - contains FMOD resources
    - `/Plugins` - contains all plugins (Astar, FMOD, Ink, TextMesh)
    - `/Resources` - other resources
    - `/Scenes` - contains all Unity gameplay scenes
    - `/Scripts` - contains all C# scripts
    - `/Sounds` - contains game sound effects and audio
    - `/Tiles` - contains tile sprites for tile mapping
  - `/Packages` - contains manifest.json (dependencies) 
  - `/ProjectSettings` - settings

### Developer Setup
 
 Instructions on development environment setup.
 
 1. Install Unity Hub 
    - Visit the download page [here](https://unity3d.com/get-unity/download)
    - For more information visit [this page](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html)
 2. Install Unity
    - Unity can be installed using Unity Hub (for current versions) otherwise visit the [Unity download archive](https://unity3d.com/get-unity/download/archive)
    - Find Unity 2019.3.7f1 (the version our team is using)
    - Download and setup within Unity Hub
 3. Clone the Repository 
    -`git clone https://github.com/HuskyGameDev/2020f-team10.git`
 4. Open the Project
    - Open Unity Hub
    - Click open project and location the `/LostInMazieMansion` directory found in the root of this repository
 5. Optional
    - Install Visual Studio or Visual Studio Code [here](https://visualstudio.microsoft.com/)

### Dependencies

All essential dependencies for development purposes are automatically downloaded after installing Unity Hub and the proper version of Unity (See [Developer Setup](#developer-setup))

For more information visit the following pages:
- [Unity Game Engine](https://unity.com/)
- [Inky](https://github.com/inkle/inky) 
- [FMOD](https://www.fmod.com/) 

### Task Board

Visit our task board [here](https://github.com/HuskyGameDev/2020f-team10/projects/1) if you are interested in contributing. 
