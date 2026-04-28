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

 ## How to Open 
#### Step 1: Open Unity Hub. 
Ensure that Unity Editor (version 6000.2.10f1) **with WebGL Build Support** is installed.
 <img width="1919" height="1027" alt="screenshot1" src="https://github.com/user-attachments/assets/2a1164d1-f18a-40f5-b2df-a11c1fe5d123" />
#### Step 2: Clone the Repository. 
Clone the project to your local machine:
```bash
git clone https://github.com/MissionToPsyche-Platinum/platinum_25b_phone_game-psb.git
```
#### Step 3: Add the project to Unity Hub.
In Unity Hub, click Add. From the drop-down, select **Add project from disk**. Select the project's root folder on your machine and add. 
<img width="1914" height="936" alt="image" src="https://github.com/user-attachments/assets/55f79e1b-0a7e-439c-947f-3ff0cdf68b0a" />
#### Step 4: Open the project.
Click the project in Unity Hub and wait for Unity to import all assets (this may take a few minutes).
<img width="1918" height="928" alt="screenshot-project" src="https://github.com/user-attachments/assets/19886f45-faa0-4caf-b274-e73f32c21347" />
#### Step 5: View a game page.
In Unity, in the Project view, navigate to `Assets/Scenes` to open the different game pages, like How To Play. 
<img width="1919" height="1031" alt="image" src="https://github.com/user-attachments/assets/c3b0c75a-a61b-45af-bc2d-6930bef290d9" />




 
