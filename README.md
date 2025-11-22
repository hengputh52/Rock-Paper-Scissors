# 🎮 Rock Paper Scissors Game

A classic Rock-Paper-Scissors game built with **Unity** and **C#**. Play against the computer across multiple rounds, track your score, and see who comes out on top!

---

## 📋 Table of Contents

- [Features](#features)
- [Game Architecture](#game-architecture)
- [How to Play](#how-to-play)
- [Project Structure](#project-structure)
- [Installation & Setup](#installation--setup)
- [Controls](#controls)
- [Game Scenes](#game-scenes)
- [Scripts Documentation](#scripts-documentation)
- [Future Enhancements](#future-enhancements)

---

## ✨ Features

- 🎯 **Single Player Gameplay** - Play against the computer AI
- 📊 **Real-time Score Tracking** - Keep track of wins, losses, and draws
- 🎨 **Visual Feedback** - See your choice and the computer's choice displayed as images
- 🎭 **Multiple Game Scenes** - Main Menu, Game Scene, and Game Over screens
- 🔄 **Multiple Rounds** - Play as many rounds as you want
- 📱 **UI-Driven Interface** - Clean and intuitive button-based controls
- 🎲 **Fair Randomization** - Computer makes random choices each round

---

## 🏗️ Game Architecture

### System Design

```
┌─────────────────────────────────────────┐
│         Game Controller (Manager)        │
│  - Manages game logic                    │
│  - Tracks scores                         │
│  - Determines winners                    │
└─────────────────────────────────────────┘
              ↕
    ┌─────────────────────────┐
    │   Scene Management      │
    │ - Main Menu             │
    │ - Game Play             │
    │ - Game Over             │
    └─────────────────────────┘
              ↕
    ┌─────────────────────────┐
    │   UI Input (Buttons)    │
    │ - Rock Button           │
    │ - Paper Button          │
    │ - Scissors Button       │
    │ - End Game Button       │
    └─────────────────────────┘
```

### Core Components

| Component | Role | Type |
|-----------|------|------|
| **GameManager** | Main game logic and state management | MonoBehaviour |
| **ChoiceButton** | Handles button clicks and player input | MonoBehaviour |
| **Scene Manager** | Manages scene transitions | Unity Built-in |
| **UI Canvas** | Displays scores, results, and choices | UI System |

### Game Logic Flow

```
Player Chooses (1=Rock, 2=Paper, 3=Scissors)
           ↓
Computer Makes Random Choice (1-3)
           ↓
Compare: You - Computer
           ↓
┌──────────────┬──────────────┬──────────────┐
0 (DRAW)    1 or -2 (WIN)   Other (LOSE)
           ↓                     ↓              ↓
      Tie Round         Player Point      Computer Point
           ↓                     ↓              ↓
      Update UI         Update Score     Update Score
```

---

## 🎮 How to Play

### Game Rules (Standard Rock-Paper-Scissors)

- **Rock** defeats Scissors (Rock crushes Scissors)
- **Scissors** defeats Paper (Scissors cuts Paper)
- **Paper** defeats Rock (Paper covers Rock)
- Same choice = **Draw**

### Step-by-Step Gameplay

1. **Start Game** - Launch from Main Menu
2. **Choose Your Move** - Click one of three buttons:
   - 🪨 **Rock Button**
   - 📄 **Paper Button**
   - ✂️ **Scissors Button**
3. **View Results** - See:
   - Your choice (left side image)
   - Computer's choice (right side image)
   - Round outcome (Win/Lose/Draw)
   - Updated score
4. **Play Again** - Click any button to play another round
5. **End Game** - Click "End Game" button to finish
6. **View Final Score** - See results on Game Over screen

### Win Conditions

- **Win the Round**: Your choice beats the computer's choice
- **Win the Game**: Have more points than the computer at the end
- **Draw**: Both players have the same score

---

## 📁 Project Structure

```
Rock Paper Scissors/
├── Assets/
│   ├── scripts/
│   │   ├── GameController.cs      # Main game logic & score management
│   │   └── ChoiceButton.cs        # Button input handler
│   ├── Scenes/
│   │   ├── MainMenu.unity         # Main menu scene
│   │   ├── SampleScene.unity      # Main gameplay scene
│   │   └── GameOver.unity         # Game over/results scene
│   ├── rescource/
│   │   └── images/                # Game sprites (Rock, Paper, Scissors)
│   └── TextMesh Pro/              # Text rendering assets
├── .gitignore                     # Git configuration (excludes large files)
├── README.md                      # This file
└── Rock Paper Scissors.sln        # Visual Studio solution
```

---

## 🚀 Installation & Setup

### Prerequisites

- **Unity 2021.3 LTS** or later
- **C# 9.0+**
- Visual Studio or any C# IDE

### Steps to Run

1. **Clone the Repository**
   ```bash
   git clone https://github.com/hengputh52/Rock-Paper-Scissors.git
   cd Rock-Paper-Scissors
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Open"
   - Select the `Rock Paper Scissors` folder

3. **Load the Main Scene**
   - In the Project window, navigate to: `Assets/Scenes/`
   - Double-click `MainMenu.unity` or `SampleScene.unity`

4. **Play the Game**
   - Press the Play button (▶) in Unity Editor
   - Or build and run as standalone executable

---

## 🎮 Controls

| Action | Control |
|--------|---------|
| **Choose Rock** | Click "Rock" Button |
| **Choose Paper** | Click "Paper" Button |
| **Choose Scissors** | Click "Scissors" Button |
| **End Game** | Click "End Game" Button |
| **Play Again** | Click "Play Again" on Game Over Screen |
| **Return to Menu** | Click "Main Menu" on Game Over Screen |

---

## 🎬 Game Scenes

### 1. **Main Menu** (`MainMenu.unity`)
- Starting point of the game
- "Start Game" button to begin
- "Quit" button to exit

### 2. **Gameplay** (`SampleScene.unity`)
- Main game loop scene
- Displays current score (Player vs Computer)
- Three choice buttons (Rock, Paper, Scissors)
- Shows round results
- "End Game" button to finish

### 3. **Game Over** (`GameOver.unity`)
- Displays final scores
- Shows overall winner (Win/Lose/Draw)
- "Play Again" button for new game
- "Main Menu" button to return home

---

## 📜 Scripts Documentation

### GameManager.cs
**Purpose**: Core game logic controller

**Key Methods**:
- `Start()` - Initialize game and reset scores
- `PlayerChoose(int you)` - Process player choice and compare with computer
- `EndGame()` - Calculate final result and load Game Over scene
- `GetSprite(int num)` - Return sprite based on choice number

**Variables**:
```csharp
yourScore, comScore           // Track round scores
finalPlayerScore, finalComputerScore  // Static variables for scene transition
gameResult                     // "WIN", "LOSE", or "DRAW"
```

**Choice Mapping**:
- `1` = Rock
- `2` = Paper
- `3` = Scissors

### ChoiceButton.cs
**Purpose**: Handles button input and triggers game logic

**Key Methods**:
- `Start()` - Find references and add click listener
- `OnButtonClicked()` - Trigger player choice

**Key Variables**:
- `choiceValue` - Button's assigned choice (1, 2, or 3)

---

## 🔮 Future Enhancements

- [ ] Multiplayer (2-player local mode)
- [ ] Online multiplayer support
- [ ] Difficulty levels (Easy, Medium, Hard)
- [ ] Sound effects and background music
- [ ] Enhanced animations and particle effects
- [ ] Player statistics and history
- [ ] Power-ups or special moves
- [ ] Leaderboard system
- [ ] Theme customization
- [ ] Best of N rounds system

---

## 📝 License

This project is open source and available for educational purposes.

---

## 👨‍💻 Author

**hengputh52**  
GitHub: [@hengputh52](https://github.com/hengputh52)

---

## 🤝 Contributing

Contributions are welcome! Feel free to:
- Report bugs
- Suggest new features
- Submit pull requests

---

## 📞 Support

For issues or questions, please open an issue on the [GitHub repository](https://github.com/hengputh52/Rock-Paper-Scissors/issues).

---

**Enjoy playing Rock Paper Scissors! 🎮**
