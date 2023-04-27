using CMP1903M_A02_2223.AO1;

namespace CMP1903M_A02_2223.Operators;

public class AdditionOperator : IOperator {
    
    public override string ToString() {
        return "+";
    }

    public double GetSolution(Card card1, Card card2) {
        return Double.Round(card1.value + card2.value, 1);
    }
    
}