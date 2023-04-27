using CMP1903M_A02_2223.AO1;
using CMP1903M_A02_2223.Operators;
using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223.Game;

public class EasyGame : AbstractGame {
    
    public override void RunGame(int score) {
        Pack.Reset();
        Pack.ShuffleCardPack(Sorts.FISHER_YATES_SHUFFLE);
        var card1 = Pack.deal();
        var card2 = Pack.deal();

        var mathsOperator = OperatorRegistry.Random();

        LogHandler.PromptLine($"[{card1.value}] [{mathsOperator}] [{card2.value}] = ");
        var solution = mathsOperator.GetSolution(card1, card2);

        var input = double.Parse(Console.ReadLine());

        var rightAnswer = input == solution;
        if (rightAnswer) {
            LogHandler.Print("You inputted the correct answer!");
            rightAnswer = true;
        }
        else {
            LogHandler.Print($"Uh oh! Thats not right, the answer is {solution}");
        }

        HandleRoundOver(score, rightAnswer);
    }
}