# Ares — Project Documentation

## Overview

**Ares** is a two-module project designed for technical assessment purposes:

* **AresUnityDemo**: A Unity-based 3D game featuring a controllable tank and dynamic targets.
* **AresGameInput**: A C++ terminal application that controls the Unity game remotely via UDP commands and receives game statistics.

This architecture simulates external system control and game automation in a modular, scalable environment.

---

## How to Run

### Option 1 — Run via Release (Linux)

1. Download the release from: [https://github.com/lucas-santoro/AresUnityDemo/releases/tag/1.1.0](https://github.com/lucas-santoro/AresUnityDemo/releases/tag/1.1.0)

2. In terminal:

```bash
chmod +x run.sh
./run.sh
```

This script:

* Launches the Unity game (`AresUnityDemo.x86_64`)
* Builds and starts the terminal controller (`AresGameInput`)

If no stats are received at the end of the game, you may need to open the UDP port:

```bash
./open_udp_ports.sh
```

---

### Option 2 — Clone and Run Manually

```bash
git clone https://github.com/lucas-santoro/AresUnityDemo.git
cd AresUnityDemo
```

* Open the `AresUnityDemo` folder in Unity and click Play
* In a separate terminal:

Option A — Using GCC (manual build)

```bash
cd AresGameInput
./compile_gcc.sh
```

Option B — Using CMake

```bash
cd AresGameInput
./compile_cmake.sh
```

---

## AresUnityDemo (Unity Game)

### Scene Setup

The main scene includes:

* A `GameBootstrap` object that holds:

  * `CombinedGameStarter`, `GameManager`, `InputManager`, `TimerService`, `TargetManager`, `SpawnManager`, `PlayerSpawner`, `CommandProcessor`, `GameStatsReporter`
* A menu camera
* A UI Canvas (disabled by default)

### Game Flow

1. The game waits for a `START` command via UDP.
2. Upon receiving it:

   * The UI and main camera are activated
   * The ground, player tank, and targets are spawned
   * A 120-second timer begins
3. The game ends when:

   * The timer runs out
   * All targets are destroyed
   * An `EXIT` command is received
4. Game stats are sent back via UDP to the controlling application.

### Key Components

* **CombinedGameStarter**: Triggers game start from an external source
* **GameManager**: Orchestrates the game lifecycle
* **CommandProcessor**: Translates string commands into in-game actions
* **UDPReceiver**: Listens for control commands on port `9000`
* **GameStatsReporter**: Sends final game stats to port `8089`
* **TimerService**: Tracks match duration and emits events
* **TargetManager**: Tracks the number of active targets
* **TankController**, **TurretController**, **TurretShooter**: Control tank movement and shooting

---

## AresGameInput (C++ Terminal Controller)

### Purpose

A CLI application that sends game control commands via UDP. It reads keyboard input in real time and logs game stats at the end.

### Available Controls

| Key     | Action              | UDP Command     |
| ------- | ------------------- | --------------- |
| `w`     | Move forward        | `MOVE_FORWARD`  |
| `s`     | Move backward       | `MOVE_BACKWARD` |
| `a`     | Move left           | `MOVE_LEFT`     |
| `d`     | Move right          | `MOVE_RIGHT`    |
| `q`     | Rotate turret left  | `ROTATE_LEFT`   |
| `e`     | Rotate turret right | `ROTATE_RIGHT`  |
| `i`     | Elevate turret up   | `ELEVATE_UP`    |
| `k`     | Elevate turret down | `ELEVATE_DOWN`  |
| `space` | Fire projectile     | `FIRE`          |
| `p`     | Start the game      | `START`         |
| `v`     | Exit the game       | `EXIT`          |

### How It Works

* Runs in terminal mode and captures key presses without `Enter`
* Automatically creates a `logs/` directory if it doesn't exist
* Logs every command sent during the session to a timestamped file in `logs/`
* Receives game statistics at the end of the match and appends them to the same log file
* Maps each key to a corresponding string command
* Sends the command to `127.0.0.1:9000` via UDP
* Listens for game stats on port `8089` and logs them to both terminal and file (inside `logs/` folder)

### Build & Run

You can choose between two build options:

#### Option A — Using GCC

```bash
cd AresGameInput
./compile_gcc.sh
```

#### Option B — Using CMake

```bash
cd AresGameInput
./compile_cmake.sh
```

Each script will compile and run the `AresGameInput` executable accordingly.

---

## Communication Flow

| Description           | Sender        | Receiver      | Protocol | Port |
| --------------------- | ------------- | ------------- | -------- | ---- |
| Game control commands | AresGameInput | AresUnityDemo | UDP      | 9000 |
| Game statistics       | AresUnityDemo | AresGameInput | UDP      | 8089 |

---

## Credits

This project was developed for a technical evaluation.
