using System.Security.Cryptography;

namespace Itransition3
{
    class Program
    {
        // Function to validate the user input
        static bool InputValidator(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Please input an odd number (>=3) of strings.");
                return false;
            }
            else if (!args.Distinct().Count().Equals(args.Length))
            {
                Console.WriteLine("All the words must be different from each other.");
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            // Run the program provided that the user inputs a correct line of strings
            if (InputValidator(args))
            {
                // Create instances for classes Crypto, Rules, and Table
                Crypto crypto = new Crypto();
                Rules rules = new Rules(args.Length);
                Table table = new Table(args);

                // Generate a random 32-character long key
                Console.WriteLine("HMAC: " + crypto.GenerateKey());

                // Generate a SHA3 HMAC of computer's move
                int compMove = RandomNumberGenerator.GetInt32(args.Length);
                string computerHMAC = crypto.ComputerHMAC(args[compMove]);

                // Showing the menu
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("{0}- {1}", i + 1, args[i]);
                }
                Console.WriteLine("0- exit\n?- help");
                Console.Write("Enter your move: ");
                string? userInput = Console.ReadLine();

                // Handling special commands
                if (userInput == "?")
                {
                    // Show help menu
                    Console.WriteLine("Help menu...");
                    table.ShowTable();
                }
                else
                {
                    // Attempt to parse user input as an integer
                    if (int.TryParse(userInput, out int userMove))
                    {
                        // Showing the results
                        if (userMove > 0 && userMove <= args.Length)
                        {
                            Console.WriteLine("Your move: {0}", args[userMove - 1]);
                            Console.WriteLine("Computer's move: {0}", args[compMove]);
                            
                            // Identifying the winner
                            Result result = rules.identifyWinner(userMove - 1, compMove);
                            switch (result)
                            {
                                case Result.Win:
                                    Console.WriteLine("YOU WON!");
                                    break;
                                case Result.Draw:
                                    Console.WriteLine("DRAW!");
                                    break;
                                default:
                                    Console.WriteLine("YOU LOSE!");
                                    break;
                            }
                            Console.WriteLine("HMAC key: " + computerHMAC);
                        }
                        else if (userMove == 0)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            // Show an error message and an example on how to play the game
                            Console.WriteLine("Invalid move. Please enter a number between 0 and {0}.", args.Length);
                        }
                    }
                    else
                    {
                        // Show an error message if the input is not a valid integer
                        Console.WriteLine("Invalid input. Please enter a valid number or '?' for help.");
                    }
                }
            }
        }
    }
}
