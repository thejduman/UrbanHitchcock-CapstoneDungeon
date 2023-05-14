# CyberSecurity Exploration Game

## Table of contents
* [Team Information](#team-information)
* [Repository URL](#repository-url)
* [General info](#general-info)
* [Repository Structure](#repository-structure)
* [Software and Technologies](#software-and-technologies)
* [Setup and Installation Guide](#setup-and-installation-guide)
* [Developer Guide](#developer-guide)
* [Copyright](#copyright)

## Team Information

Team Name: CyberExplorers

Hitchcock, Brian, bkh3@hood.edu
Urban, Julian, jdu1@hood.edu 

## Repository URL

https://github.com/thejduman/UrbanHitchcock-CapstoneDungeon

## General info
This project is a video game that is meant to give the player an explorable environment to discover and learn information regarding Cyber Security
Through the game, players will be quized according to the knowledge they've gathered throughout the world. They will then proceed onwards until eventually
passing all of our "Question Trials" and clearing the game.

## Repository Structure

### Folders

* .vscode A folder meant to hold all the general packages and other libraries for VScode

* Assets - A folder that holds all of our assets. This contains various things, for the scripts, scenes, prefabs, everything within Unity

* Documentation It holds the documentation for this project

* Midterm Project Presentation - holds the presentation material for the midterm

* Packages - Contains all packages utilized for Unity.

* ProjectSettings - Contains all the Project Settings for Unity and tracks them accordingly

* QuizData - Contains the .csv files for the quiz game questions

#### Assets Continued

* Animation: Features the Animation Settings for objects, particularly the player character

* Brackeys/Tiny RPGTown/Tiny RPG forest: Pulled Assets we've obtained

* DialogueData: Objects that were made that contains the template for attaching dialogue to objects within the Unity Editor

* InventoryItems: Like DialogueData, Objects that were made to contain the template for establishing inventory information for objects.

* Plugins: Mainly meant for extablishing the SQL database

* Prefabs: Prefabs are a setting within Unity to maintain a created Asset (Usually game Objects) across Scenes to be cross referenced in multiple states across the game.

* Resources: This was mainly to establish the player character to establish consistency across scenes

* Scenes: Scenes are effectively different pages the game has to run within. They contain all the game objects, interactions and commands for the front end

* Sprites: Sprites used for the game.
	
## Software and Technologies
Project is created with:
* Unity Hub Version 3.4.2
* Unity Editor Version: 2021.3.18f1
* VScode
* SQLite  
* C#


	
## Setup and Installation Guide
To run this project, you will need a Windows computer with DirectX and Microsoft .NET installed. The zip file containing the latest build can be downloaded here: https://github.com/thejduman/UrbanHitchcock-CapstoneDungeon/raw/main/Cybersecurity%20Exploration%20Game%20v.1.1.zip

Once the zip file is downloaded, extract the contents and run UrbanHitchcock-CapstoneDungeon.exe.

To download the source code, either clone it from the repository:

```
$ git clone --main dev --single-branch https://github.com/thejduman/UrbanHitchcock-CapstoneDungeon.git
```

Or Download the Zip File, when you hit Code

When you do, find the folder location (if you downloaded the zip, extract the zip file first)

If you only wish to see and run the build, there is a build folder, where within it there's a file called "UrbanHitchcock-CapstoneDungeon" open that to run the game on your computer.

### Developer Guide

If you wish to make edits, open Unity Hub, once you do, hit Open. Find the folder location of the game and click on it. Then it should automatically open the game in the Unity Editor. 

Once in the editor, you should have a view that shows a hierarchy at the top left corner, a project page at the bottom, an inspecter tab on the right, and a scene/game view in the center.

If you simply wish to run the game within the editor, at the top center of the screen, there is a play button. Click it to run the game in the current scene you are in.

Do note that prior to doing so, click on the Game tab next to scene first, and change the Aspect to 16:9, as the game was made with that resolution in mind.

To create new assets, you can either right click within the hierarchy or right click within assets to create a new object depending on the options available. the only difference is that the former only has it made for that scene, whilst the ladder allows you to use the created asset in multiple scenes for ease of use.

You can drag in these made ojects within the Scene Page and did set up the looks, components, and other aspects in the Inspector Page. 

Scripts also count as a Unity Component. You can create scripts and then attach them to objects to have them perform unique events if set up properly.

The opportunities are endless, but that is the general sense of how Unity works. Experiment!

## Copyright

Any and all copyright information falls according to Unity's Guidelines. 

However, Credit must be given to the creators, and only noncommerical uses of the work are permitted. 

This follows the copyright licensing of CC BY-NC.