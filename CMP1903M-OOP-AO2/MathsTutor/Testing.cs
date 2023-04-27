using CMP1903M_A02_2223.AO1;
using CMP1903M_A02_2223.Operators;
using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223; 

public class Testing {

    public static void HandleTests() {

        var card1 = new Card(SuitType.Clubs, 10);
        var card2 = new Card(SuitType.Clubs, 5);
        var card3 = new Card(SuitType.Clubs, 3);

        LogHandler.Print("Basic Tests:");
        // Addition Test:
        HandleBasicTest(card1, card2, OperatorRegistry.ADDITION_OPERATOR, 15);
        HandleBasicTest(card2, card1, OperatorRegistry.ADDITION_OPERATOR, 15);
        
        // Subtraction Tests:
        HandleBasicTest(card1, card2, OperatorRegistry.SUBTRACTION_OPERATOR, 5);
        HandleBasicTest(card2, card1, OperatorRegistry.SUBTRACTION_OPERATOR, -5);
        
        // Division Tests:
        HandleBasicTest(card1, card2, OperatorRegistry.DIVISION_OPERATOR, 2);
        HandleBasicTest(card2, card1, OperatorRegistry.DIVISION_OPERATOR, 0.5);
        
        // Multiplication Tests:
        HandleBasicTest(card1, card2, OperatorRegistry.MULTIPLICATION_OPERATOR, 50);
        HandleBasicTest(card2, card1, OperatorRegistry.MULTIPLICATION_OPERATOR, 50);
        
        LogHandler.Print("BODMAS Tests");
        HandleAdvancedTest("BODMAS + and *", card1, card2, card3, OperatorRegistry.ADDITION_OPERATOR, OperatorRegistry.MULTIPLICATION_OPERATOR, 25);
        HandleAdvancedTest("BODMAS / and -", card1, card2, card3, OperatorRegistry.DIVISION_OPERATOR, OperatorRegistry.SUBTRACTION_OPERATOR, -1);
    }

    private static void HandleBasicTest(Card card1, Card card2, IOperator op, double expected) {
        HandleTest(
            op.ToString(),
            op.GetSolution(card1, card2),
            expected
        );
    }

    private static void HandleAdvancedTest(string testName, Card card1, Card card2, Card card3, IOperator op1, IOperator op2, double expected) {
        HandleTest(
            testName,
            BodmasExpressionHandler.CreateSolution(card1, card2, card3, op1, op2),
            expected
        );
    }

    private static void HandleTest(string testName, double solution, double expected) {
        if (solution == expected) {
            LogHandler.Print($"{testName} Test Successful (expected: {expected}, found: {solution})");
        }
        else {
            LogHandler.Print($"{testName} Test Unsuccessful (expected: {expected}, found: {solution})");
        }
    }
    
}