namespace Calculator;

/// <summary>
/// The operations that the calculator calculates.
/// </summary>
public class CalculatorOperations
{
    private static readonly double eps = 1e-3;

    /// <summary>
    /// All available operations.
    /// </summary>
    public enum Operations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        ChangeSign
    }

    /// <summary>
    /// Is the real number equal to zero, taking into account the error.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static bool IsZero(double value) => Math.Abs(value) < eps;

    /// <summary>
    /// Calculates a unary operation.
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="operand"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double Calculate(Operations operation, double operand)
        => operation == Operations.ChangeSign
                     ? -operand
                     : throw new ArgumentException("Unknown operation.");

    /// <summary>
    /// Calculates a binary operation.
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="firstOperand"></param>
    /// <param name="secondOperand"></param>
    /// <returns></returns>
    /// <exception cref="DivideByZeroException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static double Calculate(Operations operation, double firstOperand, double secondOperand)
        => operation switch
        {
            Operations.Addition => firstOperand + secondOperand,
            Operations.Subtraction => firstOperand - secondOperand,
            Operations.Multiplication => firstOperand * secondOperand,
            Operations.Division => IsZero(secondOperand)
                                ? throw new DivideByZeroException()
                                : firstOperand / secondOperand,
            _ => throw new ArgumentException("Unknown operation.")
        };
}