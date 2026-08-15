# 🎮 The Avengers: Endless Fire

A 2D action shooting game developed in **C# Windows Forms** using **Object-Oriented Programming (OOP)** principles. Players choose from a roster of iconic Avengers and battle increasingly powerful villains in an endless survival-style experience.

---

## 📖 About the Project

**The Avengers: Endless Fire** is a desktop game developed as part of a second-semester Object-Oriented Programming project at the **Department of Computer Science, University of Engineering and Technology (UET) Lahore**.

The game allows players to select one of five Avengers and fight against legendary Marvel villains. As villains are defeated, stronger enemies appear with enhanced abilities, creating an infinite progression system that continuously increases the challenge. Health packs spawn throughout the game to help players survive longer and achieve higher scores.

---

## 🎯 Game Objective

The objective of the game is to survive as long as possible, defeat increasingly powerful villains, and achieve the highest score.

Players can:

* Defeat villains to advance through levels
* Collect health packs to restore health
* Avoid enemy attacks
* Improve their score by defeating enemies and collecting health pickups

---

## 🦸 Playable Heroes

Players can choose from the following Avengers before starting the game:

| Hero            | Play Style                          |
| --------------- | ----------------------------------- |
| Iron Man        | Balanced all-rounder                |
| Captain America | High health, moderate stats         |
| Thor            | Heavy hitter with strong attacks    |
| Hulk            | Tank with highest health and damage |
| Spider-Man      | Fastest hero with agile movement    |

Each hero has unique values for speed, health, damage, and firing rate, encouraging different gameplay strategies.

---

## 🦹 Villains

The game features four iconic villains:

* Thanos
* Ultron
* Venom
* Doctor Doom

A random villain appears in each level. Every new level increases the villain's speed, health, damage, and firing capabilities, resulting in endless difficulty progression.

---

## 🎮 Controls

| Key      | Action                   |
| -------- | ------------------------ |
| ↑ ↓ ← →  | Move Hero                |
| Spacebar | Attack / Fire Projectile |

---

## ✨ Features

### Character Selection System

Choose from five unique Avengers, each with different strengths and weaknesses.

### Endless Progression

Every defeated villain is replaced with a stronger version, creating unlimited levels and increasing difficulty.

### Health Pickup System

Health packs spawn randomly during gameplay and restore health while rewarding bonus points.

### Collision Detection

The game handles multiple collision types including:

* Hero attacks vs Villains
* Villain attacks vs Hero
* Projectile vs Projectile interactions
* Hero vs Health Pack interactions

### Score System

Players earn:

* +100 points for defeating villains
* +50 points for collecting health packs

### Dynamic Difficulty Scaling

Enemy attributes increase every level, making gameplay progressively more challenging.

---

## 🏗️ Object-Oriented Design

This project was designed to strengthen practical understanding of Object-Oriented Programming concepts.

### Concepts Applied

* Inheritance
* Polymorphism
* Abstraction
* Interfaces
* Encapsulation
* Event-Driven Programming
* Game Loop Architecture
* Collision Management

---

## 📂 Project Structure

```text
Game
│
├── enums
│   ├── Characters.cs
│   └── directions.cs
│
├── GameObjects
│   ├── GameObject.cs
│   ├── Character.cs
│   ├── Hero.cs
│   ├── Villain.cs
│   ├── AttackingObject.cs
│   └── HealthObject.cs
│
├── GamePlay
│   ├── GameBL.cs
│   ├── GameObjectsRepository.cs
│   ├── VillainSpawner.cs
│   └── HealthPickupSpawner.cs
│
├── Interfaces
│   ├── IAttackable.cs
│   ├── IDamageable.cs
│   ├── IHealable.cs
│   └── IScoreable.cs
│
├── Managers
│   ├── InputManager.cs
│   └── CollisionManager.cs
│
└── UI
    ├── Main.cs
    ├── GameMenu.cs
    ├── CharacterSelection.cs
    └── GamePlay.cs
```

---

## 🛠️ Technologies Used

* C#
* .NET Framework
* Windows Forms
* Object-Oriented Programming (OOP)
* EZInput Library

---

## 🚀 Learning Outcomes

Through this project, I gained hands-on experience with:

* Designing scalable object-oriented systems
* Managing real-time game states
* Implementing collision detection mechanisms
* Building reusable classes and interfaces
* Developing event-driven desktop applications
* Applying software engineering principles in a practical project

---

## 👨‍💻 Author

**Saad Mahmood**
BS Computer Science
Department of Computer Science
University of Engineering and Technology (UET) Lahore

---

## 🙏 Acknowledgements

Special thanks to the faculty of the Department of Computer Science, UET Lahore, for providing the guidance and learning environment that made this project possible.

---

⭐ If you found this project interesting, consider giving it a star on GitHub.
