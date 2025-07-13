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
- Clone the repository.
- Navigate to the project directory.
- Build the project.

--------------------------------------------------------------

Usage
Once the project is built, you can run the game directly from your terminal.
- To compile and run this code:
    - Save the code as Mastermind.cs (or any .cs file).
    - Open a command prompt or terminal.
    - Navigate to the directory where you saved the file.
    - Compile using the .NET SDK: dotnet build
    - Run the executable: dotnet run
    - You can also test with arguments:
    - dotnet run -- -c 1234 -t 5 (Plays with secret code 1234 and 5 attempts)
    - dotnet run -- -t 7 (Plays with a random code and 7 attempts)
    - dotnet run (Plays with a random code and 10 attempts)

--------------------------------------------------------------

Parse CLI
Command will help determine and overide the secret code and the attempts befor losing the game (use for debug).
 - -c [CODE]: specifies the secret code. If no code is specified, a random code will be generated.
 - -t [ATTEMPTS]: specifies the number of attempts; by default, the player has 10 attempts
