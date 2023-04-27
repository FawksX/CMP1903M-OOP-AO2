using CMP1903M_A02_2223.Game;
using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223;

/**
 * CMP1903 Object Oriented Programming - Assessment 2
 * Author: Oliver Whitehead (26435141)
 * Date: 26/04/2023
 */
class Program {
    
    public static void Main(string[] args) {
        // Handle Tests before running the Program.
        Testing.HandleTests();

        LogHandler.Print($"Welcome to MathsTutor v{Constants.Version}");

        // Entrypoint into the program.
        HandleMenu();
    }

    /**
     * <summary>
     * Handles the main game Menu. This allows the player to select between
     * Instructions, Run Application, Quit and Leaderboard
     * </summary>
     */
    public static void HandleMenu() {
        void PrintError() {
            LogHandler.Print("You must input a valid option (1, 2, 3).");
            LogHandler.PromptLine("Enter an Option: ");
        }

        LogHandler.Print(
            "------------------------",
            "Maths Tutor - Main Menu",
            "Please Select an option:",
            " ",
            "1. Application Instructions",
            "2. Run Application (2 cards, 1 point per right answer)",
            "3. Run Application (3 cards, 2 points per right answer)",
            "4. Quit Application",
            "5. Leaderboard"
        );

        LogHandler.PromptLine("Enter an Option: ");

        while (true) {
            try {
                var number = int.Parse(Console.ReadLine());
                switch (number) {
                    case 1: {
                        Tutorial.HandleInstructions();
                        return;
                    }
                    case 2: {
                        GameRegistry.EASY_GAME.RunGame();
                        return;
                    }
                    case 3: {
                        GameRegistry.ADVANCED_GAME.RunGame();
                        return;
                    }
                    case 4: {
                        QuitApplication();
                        return;
                    }
                    case 5: {
                        ScoreboardHandler.PrintLeaderboard();
                        return;
                    }
                    default:
                        PrintError();
                        continue;
                }
            }
            catch (Exception exception) {
                LogHandler.Print(exception.Message);
                PrintError();
            }
        }
    }

    private static void QuitApplication() {
        LogHandler.Print($"Shutting Down MathsTutor v{Constants.Version}...");
        Environment.Exit(0);
    }
}