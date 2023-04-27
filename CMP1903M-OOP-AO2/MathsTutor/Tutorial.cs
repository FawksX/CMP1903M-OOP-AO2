using CMP1903M_A02_2223.AO1;
using CMP1903M_A02_2223.Operators;
using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223; 

/**
 * <summary>
 * Handles the Tutorial Menu, where it shows random examples of the program running each time.
 * </summary>
 */
public class Tutorial {
    
    public static void HandleInstructions() {
        
        LogHandler.Print(
            "",
            "------------------------",
            "Help Menu - MathsTutor",
            "MathsTutor is a simple program to improve your Mental Maths Skills",
            "When playing, the steps are as follows:",
            "Two Number Cards are Dealt to the user with a Maths Operation",
            "Enter the solution to the problem to win!",
            "Note: All answers are rounded to 1 decimal place, if applicable",
            " ",
            "Examples:"
        );

        for (int i = 0; i < 3; i++) {
            GenerateExample();
        }
        
        LogHandler.Print("");

        LogHandler.PromptLine("Click Any Button to return to the Main Menu...");
        var line = Console.ReadLine(); // Wait for User Input
        
        Program.HandleMenu();

    }

    private static void GenerateExample() {
        
        Pack.Reset();
        Pack.ShuffleCardPack(Sorts.FISHER_YATES_SHUFFLE);
        var card1 = Pack.deal();
        var card2 = Pack.deal();

        var mathsOperator = OperatorRegistry.Random();
        
        var solution = mathsOperator.GetSolution(card1, card2);
        var roundedSolution = Double.Round(solution, 1);
        
        LogHandler.Print($"[{card1.value}] [{mathsOperator}] [{card2.value}] = {roundedSolution}");
    }
    
}