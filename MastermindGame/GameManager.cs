using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MastermindGame
{
    internal class GameManager
    {
        private Code secretCode;

        // code/input control.
        private char[] acceptedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        private char maxAcceptedChar = '8';
        private char minAcceptedChar = '0';

        // game track
        private int maxAttempts;
        private int attemptsLeft;
        private int currentRound = 1;
        private int wellPlacedPieces = 0;
        private int misplacedPieces = 0;
        private bool playerGuessedCorrect;

        public GameManager(string _seretCodeValu = "", int _maxAttempts = 10, int _secretCodeLength = 4)
        {
            maxAttempts = _maxAttempts;
            attemptsLeft = maxAttempts;

            if (Code.IsCodeValid(_seretCodeValu, _secretCodeLength, maxAcceptedChar, minAcceptedChar))
            {
                secretCode = new Code(_secretCodeLength, _seretCodeValu);
            }
            else
            {
                secretCode = new Code(_secretCodeLength, Code.GenerateRandomCode(_secretCodeLength, acceptedChars));
            }
        }

        public void StartGameLoop()
        {
            DisplayGameWelcomeScreen();

            while (attemptsLeft > 0 && !playerGuessedCorrect)
            {
                PlayRound();
            }

            if (playerGuessedCorrect)
            {
                DisplayWinningScreen();
            }
            else
            {
                DisplayLosingScreen();
            }
        }

        private void PlayRound()
        {
            DisplayRoundWelcomeScreen();

            // loop until the player input a valid code.
            string playerGuess = ReadLineWithEOFCheck();
            while (!Code.IsCodeValid(playerGuess, secretCode.length, maxAcceptedChar))
            {
                Console.WriteLine("Wrong input!");
                playerGuess = ReadLineWithEOFCheck();
            }

            ProcessGuessResult(playerGuess);
        }

        private void ProcessGuessResult(string playerGuessToProcess)
        {
            if (playerGuessToProcess == secretCode.value)
            {
                playerGuessedCorrect = true;
            }
            else
            {
                UpdatePlacementTrack(4, playerGuessToProcess, secretCode.value);
                DisplayHints();
                UpdateGameState();
            }
        }

        private void UpdatePlacementTrack(int desiredCodeLength, string guessedCode, string secretCode)
        {
            Code.ProcessPlacedPieces(desiredCodeLength, guessedCode, secretCode, out wellPlacedPieces, out misplacedPieces);
        }

        private void UpdateGameState()
        {
            currentRound++;
            attemptsLeft--;
        }

        private string ReadLineWithEOFCheck()
        {
            if (Console.In.Peek() == -1)
            {
                return null;
            }

            return Console.ReadLine();
        }

        #region screens
        private void DisplayGameWelcomeScreen()
        {        
            Console.WriteLine("Will you find the secret code? \nPlease enter a valid guess");
            //enable for console debug.
            //Console.WriteLine("Secret code is: " + secretCode.value);
        }

        private void DisplayRoundWelcomeScreen()
        {
            Console.WriteLine("---");
            Console.WriteLine($"Round {currentRound}");
        }

        private void DisplayWinningScreen()
        {
            Console.WriteLine("Congratz! You did it!");
        }

        private void DisplayLosingScreen()
        {
            Console.WriteLine("You lost! Better luck next time!");
        }

        private void DisplayHints()
        {
            Console.WriteLine("Well placed pieces: " + wellPlacedPieces.ToString() + "\nMisplaced pieces: " + misplacedPieces.ToString());
        }
        #endregion
    }
}
