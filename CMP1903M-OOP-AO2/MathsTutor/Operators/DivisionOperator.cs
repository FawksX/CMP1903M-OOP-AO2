using CMP1903M_A02_2223.AO1;

namespace CMP1903M_A02_2223.Operators; 

public class DivisionOperator : IOperator {
    
    public override string ToString() {
        return "/";
    }

    public double GetSolution(Card card1, Card card2) {
        return Double.Round(card1.value / (double) card2.value, 1); // prevent loss of fraction
    }
    
}