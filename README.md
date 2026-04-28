# 25B Phone-Based Psyche Game (2026)

## Project Description
The objective of this project is to improve the accessibility, engagement, and performance of the Survive to Psyche game for mobile users by redesigning its interface, optimizing its assets, introducing new game elements, and ensuring seamless browser-based functionality.

Survive to Psyche (NASA Web-Based Game 15A 2020) was originally created for PCs by students of the Nickel Class, Jacob Greenhalgh, Ryan Hill, Sadman Hossain, Adi Kulkarni, and Samuel Maness. This project introduces Survive to Psyche: Mobile Version. :iphone::sparkles:

### Team Members
Beatriz Antunes, Destiny Cruz, Mustapha Boukhalfa, and Rami Yasin

## File Structure
<details>
<summary>:file_folder: Assets</summary>

<br>All core resources used in the project are stored in the `Assets/` directory. 

`Graphics/` contains the game's visual assets: sprites for spacecraft, meteoroids, UI elements, etc., and animations and Animator controllers.

`Plugins/` contains a custom JavaScript plugin used to enable haptic (vibration) feedback in the WebGL mobile build. 

`Prefabs/`contains the reusable game objects (meteoroids, power-ups, spacecraft, and scoreboard) that serve as templates that can be instantiated during gameplay.

`Scenes/` contains the different game pages, including menus and gameplay environment.

`Scripts/` contains the C# code that controls the behavior of game objects.

`Settings/` contains configuration assets that define project-wide rendering, scene templates, and build settings.

`Sounds/` contains the sound effects and music track files.

 `TextMesh Pro/` contains the resources required for advanced text rendering.
 </details>

<details>
<summary>:file_folder: Packages</summary>
   
<br>The `Packages/` folder manages the project’s external dependencies using Unity’s Package Manager.

**manifest.json**: Lists all packages used in the project and their versions.

**packages-lock.json**: Ensures consistent dependency versions across environments by locking package versions.
 </details>

 <details>
<summary>:file_folder: Project Settings</summary>
   
<br>The `ProjectSettings/` folder contains Unity configuration files that define how the project behaves and runs.

These settings control key systems such as:
- Input configuration
- Graphics and rendering settings
- Physics and collision behavior
- Audio settings
- Build and editor configuration
 </details>
