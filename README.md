# MastermindGame
A classic console-based Mastermind game implemented in C#.
Guess the secret code and receive feedback on well-placed and misplaced digits!

--------------------------------------------------------------

Features
- Random/ Manual Code Generation: The computer generates a secret code with unique colors if no manual code was provided.
- User Guesses: Players input their guesses for the code.
- Feedback System: Provides feedback on:
    - Well-Placed: Correct color in the correct position.
    - Misplaced: Correct color but in the wrong position.
- Limited Guesses: Players have a set number of attempts to crack the code.
- Win/Loss Condition: Determines if the player successfully guessed the code or ran out of attempts.

--------------------------------------------------------------

Installation

Prerequisites
- To run this game, you'll need the .NET SDK installed on your machine.

Steps
1- Clone the repository.
2- Navigate to the project directory.
3- Build the project.

--------------------------------------------------------------

Usage
Once the project is built, you can run the game directly from your terminal.
- Run the game.
- Follow the on-screen prompts to enter your guesses.

--------------------------------------------------------------

Parse CLI
Command will help determine and overide the secret code and the attempts befor losing the game (use for debug).
 -c [CODE]: specifies the secret code. If no code is specified, a random code will be generated.
 -t [ATTEMPTS]: specifies the number of attempts; by default, the player has 10 attempts
