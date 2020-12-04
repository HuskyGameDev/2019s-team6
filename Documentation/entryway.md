Entryway
=========
  * This file contains documentation regarding the Grand Entryway. It includes information on scene layout, other system interactions, entryway handler, and tips.
  * NOTE: Some of these links may break if scripts are moved around. You can click *View Raw* and look at where the link previously went. This can help direct you in the right direction. Hopefully
  
Table of Contents
=================

<!--ts-->
   * [Entryway](#entryway)
   * [Table of Contents](#table-of-contents)
   * [Introduction](#introduction)
   * [Entryway Development](#entryway-development)
     * [Scene Layout](#scene-layout)
     * [Level Development Tips](#level-development-tips)
     * [Error Notes](#error-notes)
   * [Additional Developer Information](#additional-developer-information)
     * [Files Changes](#files-changes)
     * [Meaningful Commits](#meaningful-commits)
     * [Where it is Updated](#where-it-is-updated)
<!--te-->

## Introduction
  * The Entryway is a scene which is set up much differently than other rooms within the mansion. It contains multiple Grids which allow it to contain Floor 1 and Floor 2 elements.

## Entryway Development
  * This section includes information to assist with development within or around the Grand Entrway.

### Scene Layout
  * The scene is mostly set up like other scenes according to the Room Development Guide. The only difference is that this scene has multiple Grids since it is connected to both the first and second floors.
  * F1
    * The gameobject F1 contains the entire Grid for Floor 1.
  * F2
    * The gameobejct F2 contains the entire Grid for Floor 2.
  * F1/F2
    * The gameobject F1/F2 contains the Grid for everything shared between Floor 1 and Floor 2. This is so that items on Floor 1 can be seen while walking around Floor 2.
    * NOTE: The stairway script is in the F1/F2 Grid under Doorways. It acts as a trigger. Similar to a doorway without any transition. You can view the [Stairway.cs](https://github.com/HuskyGameDev/2020f-team10/blob/master/LostInMazieMansion/Assets/Scripts/MaziesMansion/Entryway/Stairway.cs) file if you are interested in how it works!
  * NOTE: It is important to place any objects or tiles under the proper Grid so that the scene functions properly.
  
### Level Development Tips
  * Ignore the strange appearance of the scene when you first open it. This is because all Grids are active at once which is necessary for the scene to function properly. Try running the scene. It should appear normal upon running. This is due to the Entrway Handler.
  * The Entryway Handler script is attached to the Player if you need to make any changes.
  * When you go to make changes to a particular floor, deactivate the other Grids. You can do so by going under the gameobject and clicking the check. This will cause the scene to look much more normal and will helping with your understanding of the changes you are making to the scene.
  * Make sure doorways are set on the proper Floor/Grid with the proper naming conventions.
  * NOTE: Keep the player on Floor 1. This is how the handler is set to active the Grids by default. You can change this default behavior, but just realize this is the outcome of running the GrandEntryway scene.
  * NOTE: It is important that you make sure each of the Grids (F1, F2, F1/F2) are active after you are done developing.

### Error Notes
  * If you are having issues or think you make have broken something, do the following check first:
    * Make sure you following the correct room and doorway naming convention that is used throughout the mansion. Failing to do so will break the Entryway Handler.
      * You can find more information in the room development guide
    * If the player isn't loading into the room properly when you are playing the scene in the editor, make sure the player is standing on Floor 1. This is how the handler is set by default. You can change this default behavior, but just realize this is the outcome of running the GrandEntryway scene.
    * Add more notes here as necessary 

## Additional Developer Information 
  * This section contains extra information about how the Entryway and Entryway Handler interacts with the other systems within the game.
  
### Files Changes
  * The majority of the files you are looking for can be found in [this folder](https://github.com/HuskyGameDev/2020f-team10/blob/master/LostInMazieMansion/Assets/Scripts/MaziesMansion/Entryway). However, here are the other files which saw changes in order to implement this system:
    * EntrywayHandler.cs
      * New file. Simply gets both Grids and sets the GameObjects Floor1 and Floor2 accordingly. It then sets the floor the player is on as active and the other it deactivates. If you run the scene from the editor, the default behavior is starting the player on Floor1. The reason this is default is the GrandEntryway scene starts with F1 (F1_F2_GrandEntryway). Check Door.cs or the description below to understand why.
    * Door.cs
      * Made changes. When the player collides with a door, it checks if the doorway starts with F1, F2, or F3. If the target scene does (the scene the player is entering) it sets the floor the player is on accordingly (this is stored in the Player.cs script).
    * Stairway.cs
      * New file. Sets the proper Grid active when the player walks up and down the trigger which is a "doorway" on the stairs. Look at this file in the scripts. It is pretty easy to understand.
    * Player.cs
      * Made changes. Added an enum Location. This file also now stores a Location as a public variable. This variable is edited by the Door.cs script. The the description above to understand how (or visit the script).
  
### Meaningful Commits
  * Major File Changes
    * Oct. 27 - [feat(Entryway): implemented floor handler on room entry](https://github.com/HuskyGameDev/2020f-team10/commit/c9ab3e233fd05baa628a1ceb41803451d758195a)
    * Oct. 14 - [feat(Entryway): Grand Entryway fully functional from F1](https://github.com/HuskyGameDev/2020f-team10/commit/fa098faf7cf07a2d90a6220faac728141303756a)

### Where it is Updated
  * Check out [this file](https://github.com/HuskyGameDev/2020f-team10/blob/master/Documentation/where-is-it-updated.md) for more information. Otherwise, reference the Files Changed or meaningful commits section.
  
