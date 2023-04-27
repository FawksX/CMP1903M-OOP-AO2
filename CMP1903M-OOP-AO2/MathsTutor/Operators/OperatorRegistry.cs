using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223.Operators; 

/**
 * <summary>
 * A Utility class designed to hold onto all Operator instances - We also have some utility methods for retrieving
 * all, or a random Operation for the game.
 * </summary>
 */
public class OperatorRegistry {

    public static readonly IOperator ADDITION_OPERATOR = new AdditionOperator();
    public static readonly IOperator DIVISION_OPERATOR = new DivisionOperator();
    public static readonly IOperator MULTIPLICATION_OPERATOR = new MultiplicationOperator();
    public static readonly IOperator SUBTRACTION_OPERATOR = new SubtractionOperator();

    private static readonly List<IOperator> OPERATOR_REGISTRY = new();

    static OperatorRegistry() {
        Register(ADDITION_OPERATOR);
        Register(DIVISION_OPERATOR);
        Register(MULTIPLICATION_OPERATOR);
        Register(SUBTRACTION_OPERATOR);
    }

    private static void Register(IOperator iop) {
        OPERATOR_REGISTRY.Add(iop);
    }

    public static List<IOperator> All() {
        return OPERATOR_REGISTRY;
    }

    public static IOperator Random() {
        var number = Constants.RANDOM.Next(0, OPERATOR_REGISTRY.Count -1);
        return All()[number];
    }

}