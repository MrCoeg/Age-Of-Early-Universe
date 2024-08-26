# 🌌 Age of Early Universe

**Age of Early Universe** is a hack-and-slash game built in Unity over one month for a competition. The game features a character capable of transforming into different elemental forms, each with unique abilities, weapons, and combat styles. This project demonstrates the use of advanced programming principles such as **State Machine architecture** for handling complex combo systems and character states.

## 📜 Table of Contents
- [Overview](#-overview)
- [Team](#-team)
- [Technical Details](#-technical-details)
- [Development Progress](#-development-progress)
- [Game Architecture](#-game-architecture)
  - [State Machine Design](#-state-machine-design)
  - [Combo System](#-combo-system)
- [State Machine Implementation](#-state-machine-implementation)
- [Future Development](#-future-development)
- [Snipped Code](#-snipped-code)
[Overview](./Charachter/readme.md#snipping-code)
## 📖 Overview
**Age of Early Universe** focuses on dynamic character transformations, hack-and-slash combat, and a combo system that allows players to perform seamless attacks both on land and in mid-air. The player can transform into various elemental forms, each with unique weapons, abilities, and roles in combat (offense, defense, utility, and buffer).

### 🎮 Genre
- Hack-and-Slash
- Combo-based combat
- 
### 🎮 Video Project
[![Age Of Early Universe](https://i.ytimg.com/vi/uiTUVgD3rjQ/hqdefault.jpg?sqp=-oaymwE2CNACELwBSFXyq4qpAygIARUAAIhCGAFwAcABBvABAfgB_AmAAtAFigIMCAAQARgTIFkofzAP&rs=AOn4CLAE1S_m4NKAEUoaZi-UNsCxHvGrKw)](https://www.youtube.com/watch?v=uiTUVgD3rjQ)

## 👥 Team
- **Tegar Cahya Bayu Siregar** – Lead Developer (Unity, Game Programming)
- **Muhammad Fikri** – Character and Asset Artist
- **Siti Meliza Maulani** – Environment and UI Artist
- **Taro Dev** - Giving nice movement script

## 🛠 Technical Details
- **Engine**: Unity 2021
- **Design Patterns**: State Machine for handling character transformations, attacks, and ability states.
- **Scriptable Object**: Scriptable object is used as in-game database as it featuring the easyness of transporting data inter-scene independently 
- **Optimization Techniques**: Use of Unity’s Animator Controller combined with a custom state management system for performance optimization.

### ⚔️ Gameplay Mechanics:
- **Transformations**: Tied to distinct weapon types, with each transformation possessing its own combo system.
- **Elemental Abilities**: Provide unique stat boosts or special effects depending on the current form.

## 🚧 Development Progress
The project is currently in a prototype phase with the following features implemented:

- **Fire Transformation**: Complete with scythe weapon and a focus on rapid, multi-hit combos.
- **Core Combat System**: Includes land-based and aerial combos, allowing the player to chain attacks for maximum damage output.
- **State Machine System**: Developed to handle character actions, elemental transformations, and ability cooldowns.
- **Character Animation**: Integrated via Unity’s Animator Controller, with blend trees for smooth transitions between combo states.

### 🔑 Key Elements
- **Fire Transformation**:
  - **Weapon**: Scythe
  - **Combo Focus**: Rapid, multiple attacks in both ground and air combos.
  - **Role**: Offense-focused, utilizing fast attack chains.

- **Combat System**:
  - **State-driven**: Each transformation and action is handled using a State Machine, simplifying the complexity of various combat interactions.
  - **Combo Chaining**: Land-based and aerial attacks can be chained together seamlessly, providing fluid gameplay.

## 🏗 Game Architecture

### 🎛 State Machine Design
The core of the game is built on a **State Machine architecture** to manage:

- **Character States**: Idle, Attacking, Defending, Transforming.
- **Elemental Forms**: Each elemental transformation is treated as a separate state, enabling easy expansion of new forms in the future.
- **Combat States**: The State Machine controls the transitions between combo attacks, aerial combat, and ability use.

The State Machine allows for:
- **Flexibility**: Easily add new states (e.g., new transformations or combat actions).
- **Maintainability**: Clear separation of concerns between states for better debugging and enhancement.
- **Control**: Smooth transitions between states, ensuring responsiveness in gameplay.

### 🌀 Combo System
The combo system is handled using:

- **State Transitions**: Combos are implemented through state transitions, which enable chaining attacks based on user input and timing.
- **Animator Controller**: Unity’s Animator Controller manages the blending of animations, while the State Machine handles the logical side of transitions.

## 🖥 State Machine Implementation
The State Machine is implemented to manage the following aspects:

- **Character Actions**: Each action (attack, transform, ability) is represented as a state.
- **Transitions**: Conditions for transitioning between states (e.g., finishing an attack combo or switching transformations) are managed to ensure fluidity.
- **Combos**: The combo system uses the State Machine to track the player’s input and chain attacks based on timing, leading to dynamic ground and air combat.
- **Buffs and Abilities**: Some elemental forms can apply buffs or trigger special abilities, each handled by their respective states.

The system uses:
- **Abstract Base State**: All states inherit from a base abstract class that defines shared properties (e.g., transitions, animation triggers).
- **Derived States**: Specific states (e.g., `AttackState`, `TransformState`) manage the unique behavior for each transformation or action

## 🚀 Future Development
We plan to expand the game further by:
- Adding more elemental transformations with distinct weapons and abilities.
- Enhancing the combo system to include more advanced mid-air combos and ground interactions.
- Implementing defensive and utility elemental forms.
- Optimizing gameplay mechanics for smoother performance and responsiveness.
- Adding more enemy types and levels.
