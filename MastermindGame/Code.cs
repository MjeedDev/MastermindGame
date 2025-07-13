using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MastermindGame
{
    internal class Code
    {
        public int length;
        public string value;


        public Code(int _codeLength, string _codeValue)
        {
            this.length = _codeLength;
            this.value = _codeValue;
        }

        public static bool IsCodeValid(string codeToCheck, int desiredCodeLength, char maxAcceptedChar = '8', char minAcceptedChar = '0')
        {
            if (string.IsNullOrEmpty(codeToCheck)) return false;
            if (codeToCheck.Length != desiredCodeLength) return false;

            foreach (char c in codeToCheck)
            {
                if (c < minAcceptedChar ||  c > maxAcceptedChar)
                {
                    return false;
                }
            }

            if (codeToCheck.Distinct().Count() != desiredCodeLength)
            {
                return false;
            }

            return true;
        }

        public static string GenerateRandomCode(int desiredCodeLength, char[] acceptedChars)
        {
            Random random = new Random();
            List<char> pieces = new List<char>(acceptedChars);
            char[] randomCode = new char[desiredCodeLength];

            for (int i = 0; i < desiredCodeLength; i++)
            {
                int index = random.Next(pieces.Count);
                randomCode[i] = pieces[index];
                pieces.RemoveAt(index);
            }

            return new string(randomCode);
        }

        public static void ProcessPlacedPieces(int desiredCodeLength, string guessedCode, string secretCode, out int outWellPlaced, out int outMisplaced)
        {
            int wellPlaced = 0;
            int misplaced = 0;

            bool[] secretUsed = new bool[desiredCodeLength];
            bool[] guessUsed = new bool[desiredCodeLength];

            for (int i = 0; i < desiredCodeLength; i++)
            {
                if (secretCode[i] == guessedCode[i])
                {
                    wellPlaced++;
                    secretUsed[i] = true;
                    guessUsed[i] = true;
                }
            }

            for (int i = 0; i < desiredCodeLength; i++)
            {
                if (!guessUsed[i])
                {
                    for (int j = 0; j < desiredCodeLength; j++)
                    {
                        if (!secretUsed[j] && guessedCode[i] == secretCode[j])
                        {
                            misplaced++;
                            secretUsed[j] = true;
                            break;
                        }
                    }
                }
            }

            outWellPlaced = wellPlaced;
            outMisplaced = misplaced;
        }        
    }
}
