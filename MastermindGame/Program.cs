using MastermindGame;

// default values if no overide from CLI
string secretCode = null;
int attempts = 10;

#region CLI
// Parse CLI.
for (int i = 0; i < args.Length; i++)
{
    switch (args[i])
    {
        case "-c":
            if (i + 1 < args.Length)
            {
                secretCode = args[++i];
                if (!Code.IsCodeValid(secretCode, 4, '8'))
                {
                    Console.WriteLine($"Error: Invalid code specified with -c. Must be 4 distinct digits from '0' to '8'.");
                    return; // Exit if invalid code is provided via argument.
                }
            }
            else
            {
                Console.WriteLine("Error: -c option requires a code value.");
                return;
            }
            break;
        case "-t":
            if (i + 1 < args.Length && int.TryParse(args[++i], out int parsedAttempts) && parsedAttempts > 0)
            {
                attempts = parsedAttempts;
            }
            else
            {
                Console.WriteLine("Error: -t option requires a positive integer for attempts.");
                return;
            }
            break;
        default:
            Console.WriteLine($"Warning: Unknown argument '{args[i]}'.");
            break;
    }
}
#endregion

GameManager gameManager = new GameManager(secretCode, attempts);
gameManager.StartGameLoop();