namespace StackCalculation;

public static class Operations
{
    private static double eps = 1e-8;

    /// <summary>
    /// Computes a binary operation between two double operands.
    /// </summary>
    /// <param name="firstValue"></param>
    /// <param name="secondValue"></param>
    /// <param name="binaryOperator"></param>
    /// <returns>The result of the operation (double).</returns>
    /// <exception cref="DivideByZeroException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static double Operation(double firstValue, double secondValue, string binaryOperator)
    {
        switch (binaryOperator)
        {
            case "+":
                return firstValue + secondValue;

            case "-":
                return secondValue - firstValue;

            case "*":
                return firstValue * secondValue;

            case "/":
                if (Math.Abs(firstValue) < eps)
                {
                    throw new DivideByZeroException("Сan't be divided by zero.");
                }
                return secondValue / firstValue;

            default:
                throw new InvalidOperationException("Incorrect character.");
        }
    }
}
