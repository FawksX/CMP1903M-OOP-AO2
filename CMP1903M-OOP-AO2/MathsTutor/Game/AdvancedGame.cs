using CMP1903M_A02_2223.AO1;
using CMP1903M_A02_2223.Operators;
using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223.Game;

public class AdvancedGame : AbstractGame {
    
    public override void RunGame(int score) {

        Pack.Reset();
        Pack.ShuffleCardPack(Sorts.FISHER_YATES_SHUFFLE);
        var card1 = Pack.deal();
        var card2 = Pack.deal();
        var card3 = Pack.deal();

        var mathsOperator1 = OperatorRegistry.Random();
        var mathsOperator2 = OperatorRegistry.Random();

        LogHandler.PromptLine(
            $"[{card1.value}] [{mathsOperator1}] [{card2.value}] [{mathsOperator2}] [{card3.value}] = ");
        var solution = BodmasExpressionHandler.CreateSolution(card1, card2, card3, mathsOperator1, mathsOperator2);

        var input = double.Parse(Console.ReadLine());

        var rightAnswer = input == solution;
        if (rightAnswer) {
            LogHandler.Print("You inputted the correct answer!");
        }
        else {
            LogHandler.Print($"Uh oh! Thats not right, the answer is {solution}");
        }

        HandleRoundOver(score, rightAnswer);

    }
}