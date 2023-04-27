using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223; 

/**
 * <summary>
 * Handles Scoreboard Display, Writing and Reading from files.
 * During Testing in an IDE, the scores.txt does not persist and is available in the bin/debug directly per-run.
 * </summary>
 */
public class ScoreboardHandler {

    private static readonly string FILE_PATH = "scores.txt";
    
    public static void HandleWritingToScoreboard(int score) {
        LogHandler.Print($"You got a score of {score}!");
        LogHandler.Print("Please Input your name to be added to the scoreboard (or enter to skip)");
        LogHandler.PromptLine("Name: ");
        var name = Console.ReadLine();
        if (name != null) {
            WriteToFile(name, score);
        }
    }

    public static void PrintLeaderboard() {
        var leaderboard = GetScoreboard();
        LogHandler.Print(leaderboard.Count().ToString());
        var enumerator = leaderboard.GetEnumerator();
        enumerator.MoveNext();

        LogHandler.Print("---------- LEADERBOARD ---------");
        for (int i = 0; i < leaderboard.Count(); i++) {
            LogHandler.Print($" #{i + 1} Name: {enumerator.Current.Key} - Score: {enumerator.Current.Value}");
        }

        enumerator.Dispose();

        LogHandler.Print(" ");
        LogHandler.PromptLine("Press any key to continue...");
        var line = Console.ReadLine(); // Wait for User Input

        Program.HandleMenu();
    }
    
    private static void WriteToFile(string name, int score) {

        var lines = new List<String>();
        lines.Add($"{name};{score}");
        
        File.WriteAllLines(FILE_PATH, lines);
        
    }

    private static IOrderedEnumerable<KeyValuePair<string, int>> GetScoreboard() {

        var lines = File.ReadAllLines(FILE_PATH);

        var scores = new Dictionary<string, int>();

        foreach (var line in lines) {
            var split = line.Split(";");
            scores.Add(split[0], int.Parse(split[1]));
        }

        return from entry in scores orderby entry.Value select entry;

    }

}