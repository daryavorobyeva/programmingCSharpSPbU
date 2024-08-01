using StackImplementation;

namespace StackCalculation;

public static class StackCalculator
{
    /// <summary>
    /// Calculates the value of an expression using a stack.
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="stack"></param>
    /// <returns>The result of the calculation.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static double CalculateExpression(string expression, IStack stack)
    {
        if (expression == null)
        {
            throw new ArgumentNullException("Expression can`t be null.");
        }

        if (expression.Equals(String.Empty))
        {
            throw new ArgumentException("Expression can`t be empty.");
        }

        var expressionParts = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var expressionPart in expressionParts)
        {
            if (int.TryParse(expressionPart, out var value))
            {
                stack.Push(value);
            }
            else
            {
                var intermediateResult = Operations.Operation(stack.Pop(), stack.Pop(), expressionPart);
                stack.Push(intermediateResult);
            }
        }

        var lastResult = stack.Pop();
        if (stack.IsEmpty())
        {
            return lastResult;
        }

        throw new ArgumentException("The expression was written incorrectly.");
    }
}
