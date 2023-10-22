# Dank Dungeons

A simple dungeon game written in Python, then ported to C# (for Windows Forms) and C++!

Excluding the C# Discord version, all three versions for desktop are available in this repo.

## Installation

### Python

No libaries used. No compiling needed. Just simply run the `dankdungeons.py` file on console.

### C#

Open the solution file (`KassDungeonGUI.sln`) in Visual Studio 2015 or higher.

### C++

Simple plug and play. Include the following files into the C++ project.

* `dd_main.cpp`
* `dd_gamedate.cpp`
* `dd_util.cpp`
* `dankdungeons.h`

## How to Play

You are exploring a dungeon with infinite rooms, randomly finding items and enemy encounters in an endless quest. You run through the dungeon, until your character dies.

Aim for the highest score, based on the floor and your character's level. Your high score is recorded on `dd_gamesave.sav`.

### Input

You input by numbers only. The program closses by any other type of input in the C++ version.

### Exploration Mode

```
Floor 1
HP: 10/10 | MP: 10/10 | LVL. 1
----------
The path splits into 5...
Which path I should take?
---
0 - Discard Item [Elixir]
1 - Hot Hallway
2 - Bland Engine Room
3 - Bland Atrium
4 - Colorful Atrium
5 - Stinky Kitchen
Input: 2
```

You are given multiple choices on which path to take. Randomly, you will find items that you can pick up, but however, you can only have one item at a time. You can discard an item anytime, if it's needed.

If you find a staircase, you will advance to the next floor. The types of items and monsters that can be encountered will also increase in variety. 

Monster encounters are determined by the room you choose.

### Battle Mode

```
Floor 7
HP: 48/49 | MP: 44/49 | LVL. 5
----------
I casted my magic!
Dark Mage took 10 damage!
---
Dark Mage attacked!
I took 1 damage!
---
Dark Mage
HP: 10/20
1 - Attack
2 - Magic
3 - Use Item [Elixir]
4 - Escape
Input: 3
```

You fight against a monster, in a simple battle scene. You will always attack before the monster.

There are 4 different types of actions in battles.

* **Attack:** Attack the enemy, damage is based on your level.
* **Magic:** Attack with magic, gives 2x damage to the enemy. Costs 5 MP.
* **Use Item:** Consumes an item. See below for item effects.
* **Escape:** Escape from the fight, with a 50% chance of success.

If you defeat a monster, you gain EXP to be able to level up. Your HP and MP will be fully restored, upon level ups.

### Items

* **Potion:** Recovers 10 HP.
* **Elixir:** Recovers 10 MP.
* **Sword:** Damages the enemy by 3x damage.
* **Smoke Ball:** Guaranteed escape from battle.
* **Stronger Potion:** Recovers 30 HP.
* **Stronger Elixir:** Recovers 30 MP.
* **Stronger Sword:** Damages the enemy by 5x damage.
* **Death Sword:** Instantly kills the enemy, regardless of the remaining HP. Kass, however, is immune to this.

You can receive more item variety depending on how far you progress throughout the dungeon floors.