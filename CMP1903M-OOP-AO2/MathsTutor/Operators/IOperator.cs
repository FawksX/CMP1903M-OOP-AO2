using CMP1903M_A02_2223.AO1;

namespace CMP1903M_A02_2223.Operators; 

/**
 * <summary>
 * Represents an "Operation" which can occur between two numbers.
 * <see cref="AdditionOperator"/>
 * <see cref="DivisionOperator"/>
 * <see cref="MultiplicationOperator"/>
 * <see cref="SubtractionOperator"/>
 * </summary>
 */
public interface IOperator {

    /**
     * <summary>
     * Gets the solution of the operation being performed on two cards as a Double (rounded to 1dp), for example:
     * If card1= 10 and card2= 5, and this is the Multiplication Card, it will return 50.
     * </summary>
     */
    double GetSolution(Card card1, Card card2);

}