# Boter, Kaas en Eieren
This repository contains the Unity Project for the "Boter, Kaas en Eieren" game.

The game can be played on [Itch.io](https://stefanstegeman.itch.io/boter-kaas-eieren). Full Screen can be selected at the bottom right next to "BKE".
![game view](ReadMeAssets/GameView.png)

# Table of Contents
1. [Installing](#installing)
2. [Structure](#structure)
    1. [Folder Structure](#folder-structure)
    2. [Editor Structure](#editor-structure)
3. [Managers](#managers)
    1. [AudioManager](#audio-manager)
    2. [CanvasManager](#canvas-manager)
    3. [GridManager](#grid-manager)

# Installing #
It is rather easy to install and open this Unity Project in the Unity Editor.
*Make sure you have atleast the Unity editor of 2020.3.23f1 or higher!*
1. Clone this Git repository.
2. In the UnityHub, click: **Add**
3. Select the folder **BKE** inside of the cloned repository.
4. Click on the newly added project **BKE** inside of the Unity Hub

# Structure #
## Folder Structure ##
The folder structure of the [Assets](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets) folder.

- [3D models](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/3D%20Models)
- [Audio](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Audio)
    - [Music](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Audio/Music)
    - [SFX](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Audio/SFX)
- [Fonts](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Fonts)
    - [Blokeds](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Fonts/Blokeds)
    - [Regikan](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Fonts/Regikan)
- [Input](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Input)
- [Materials](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Materials)
- [Packages](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Packages)
- [Prefabs](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Prefabs)
- [Scenes](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Scenes)
- [Scripts](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Scripts/)
    - [Grid](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Scripts/Grid)
    - [Shape](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Scripts/Shape)
    - [UI](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Scripts/UI)
- [Textures](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/Textures)
- [URP](https://github.com/StefanStegeman/BKE/tree/main/BKE/Assets/URP)

## Editor structure ##
### **Canvas** ###
---
The Canvas contains multiple different GameObjects. All of these GameObjects are a different window / screen.
All of these windows are a *UIElement* which is getting managed by the [CanvasManager](#canvas-manager) script.

![CanvasStructure](ReadMeAssets\CanvasStructure.png)

The different windows all have their own elements. These elements are prefixed which makes it easier to know what each and every element is.
| Type | Prefix |
| ---- | -- |
| Text | T_ |
| Button | B_ |
| Image | I_ |
| Slider | S_ |

![CanvasWindowStructure](ReadMeAssets\CanvasWindowStructure.png)
### **Grid** ###
---
The Grid exists of two different GameObjects: The walls and the ShapeHolders.
![Grid structure](ReadMeAssets\GridStructure.png)

The walls are simply the visual 3D models which make up the shape of the grid. (4 manipulated cubes)
The ShapeHolders are, as the name implies, the places where the shapes will be placed on. The grid contains 3 rows of ShapeHolders: 
- Top Row
- Middle Row
- Bottom Row

Each and every row contains 3 ShapeHolders which makes it a 3x3 grid. All ShapeHolders contain a Box Collider and a MeshFilter.

![Grid scene view](ReadMeAssets\GridSceneView.png)
# Managers #
## Audio Manager ##
## Canvas Manager ##
## Grid Manager ##