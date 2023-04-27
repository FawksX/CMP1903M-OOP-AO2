namespace CMP1903M_A02_2223.Util; 

public class LogHandler {

    public static void Print(string message) {
        Console.WriteLine(message);
    }

    public static void Print(params string[] message) {
        foreach (var s in message) {
            Print(s);
        }
    }

    public static void PromptLine(string message) {
        Console.Write(message);
    }
    
}