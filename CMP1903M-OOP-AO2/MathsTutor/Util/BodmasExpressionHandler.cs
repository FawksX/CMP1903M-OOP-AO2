using System.Data;
using System.Linq.Expressions;
using CMP1903M_A02_2223.AO1;
using CMP1903M_A02_2223.Operators;

namespace CMP1903M_A02_2223.Util; 

/**
 * <summary>
 * A Simple BODMAS Expression Handler. This will take three cards and two operators and find a solution.
 * </summary>
 */
public class BodmasExpressionHandler {

    public static double CreateSolution(Card card1, Card card2, Card card3, IOperator operator1, IOperator operator2) {

        var dataTable = new DataTable();
        var v = dataTable.Compute($"{card1.value} {operator1} {card2.value} {operator2} {card3.value}", "");
        
        return Double.Round(double.Parse(v.ToString()), 1); // 1DP
    }
    
}