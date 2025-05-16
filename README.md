# AresUnityDemo — Project Documentation

## Overview

AresUnityDemo is a Unity prototype that simulates a 3D environment featuring a controllable tank and dynamic targets. The scene remains inactive until the player initiates the game.

## Scene Setup

The scene starts empty and contains:

* A GameBootstrap object with:

  * CombinedGameStarter, GameManager, InputManager, TimerService, TargetManager, SpawnManager, PlayerSpawner
* Main camera
* A UI canvas (initially disabled)

## Core Logic (Scripts/Core)

### CombinedGameStarter

* Waits for any key press or external signal to start the game
* Disables menu camera, enables UI, and triggers OnGameStart

### GameManager

* Handles game start, timeout, and all-targets-destroyed events
* On game start:

  * Enables player control
  * Spawns terrain, player, and targets
  * Starts the timer
* Ends the game by disabling input and showing a message

### InputManager

* Singleton that enables or disables user input

### TimerService

* 120-second countdown
* Emits OnTimerTick with remaining time
* Emits OnTimerFinished when time is up

## Interfaces (Scripts/Interfaces)

* IGameStarter: Triggers game start
* IDrive: Defines movement behavior
* IShooter: Defines shooting behavior
* ITurretAim: Aims turret towards a direction
* IMovementPattern: Defines target movement logic

## Player (Scripts/Player)

### TankController

* Reads Vertical and Horizontal input axes
* Sends input to a class implementing IDrive

### TankDrive

* Implements movement and yaw rotation based on speed parameters

### TurretController

* Rotates turret 360° and clamps barrel pitch between -10° and 60° with smoothing

### TurretShooter

* Listens for mouse click, spawns projectile, and applies force

## Targets (Scripts/Targets)

### Target

* Registers with TargetManager
* Calls its IMovementPattern on update

### TargetInitializer

* Randomizes target scale on start

### Projectile

* Destroys itself after 5 seconds or on collision with a Target

### Movement Patterns

* HorizontalMovement: Sine-based oscillation along X or Z
* CircularMovement: Rotates around a center point with vertical oscillation
* SineWaveMovement: Moves forward with lateral and vertical sinusoidal movement

## Managers

### SpawnManager

* Spawns a configurable number of targets at random positions and heights

### PlayerSpawner

* Instantiates the player prefab at a defined position

### TargetManager

* Tracks the number of active targets
* Emits OnAliveCountChanged and OnAllTargetsKilled

## UI (Scripts/UI)

* AliveCountUI: Updates target count on screen
* TimerUI: Displays countdown and Game Over message

## How to Run - Unity

1. Open the initial GameScene in the Unity Editor
2. Press Play
3. Press any key to start the game
4. Move the tank using WASD, aim with the mouse, shoot with left click
5. Game ends after 2 minutes or when all targets are destroyed

## How to Run - Linux

1. Download and extract the zip file to a folder of your choice

2. Open a terminal in the extracted folder

3. Make the game executable:

   ```bash
   chmod +x AresUnityDemo.x86_64
   ```

4. Run the game:

   ```bash
   ./AresUnityDemo.x86_64
   ```

5. Press any key to start the game

6. Move the tank using WASD, aim with the mouse, shoot with left click

7. Game ends after 2 minutes or when all targets are destroyed

---

This project was developed for a technical assessment.
