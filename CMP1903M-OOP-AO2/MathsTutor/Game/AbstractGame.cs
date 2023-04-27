using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223.Game; 

/**
 * <summary>
 * AbstractGame Class
 * This is a class which represents a Game which can be ran. In our case, Easy our advanced Games.
 * All Game instances are held in <see cref="GameRegistry"/>.
 * <see cref="EasyGame"/>
 * <see cref="AdvancedGame"/>
 * </summary>
 */
public abstract class AbstractGame {

    /**
     * <summary>
     * Runs the game as a new instance
     * </summary>
     */
    public void RunGame() => RunGame(0);
    
    /**
     * <summary>
     * Runs a new operator scene using the new score of the user, defined in <see cref="HandleRoundOver"/>.
     * This is implemented individually based on the game, as you can have either two or three card games.
     * </summary>
     */
    public abstract void RunGame(int score);
    
    /**
     * <summary>
     * Prints the error associated with not picking a valid option in the round over screen.
     * </summary>
     */
    private void PrintError() {
        LogHandler.Print("You must input a valid option (1, 2).");
        LogHandler.PromptLine("Enter an Option: ");
    }
    
    /**
     * <summary>
     * Handles a round being over - Allowing the user to continue playing (Re-Deal), or Access the Main Menu.
     * This is also where the user can optionally join the leaderboard for the game, which is stored in scores.txt.
     * </summary>
     */
    protected void HandleRoundOver(int score, bool rightAnswer) {
        
        LogHandler.Print(
            "------------------------",
            "Please Select an option:",
            " ",
            "1. Re-Deal",
            "2. Main Menu"
        );

        LogHandler.PromptLine("Enter an Option: ");

        while (true) {
            try {
                var number = int.Parse(Console.ReadLine());
                var newScore = rightAnswer ? score + 2 : score;
                switch (number) {
                    case 1: {
                        RunGame(newScore);
                        return;
                    }
                    case 2: {
                        if (newScore != 0) {
                            ScoreboardHandler.HandleWritingToScoreboard(newScore);
                        }

                        Program.HandleMenu();
                        return;
                    }
                    default:
                        PrintError();
                        continue;
                }
            }
            catch (Exception exception) {
                PrintError();
            }
        }
        
    }

}