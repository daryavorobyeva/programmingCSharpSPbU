namespace StackImplementation;

public class StackArray : IStack
{
    private List<double> stack;

    public StackArray()
    {
        stack = new List<double>();
    }

    public void Push(double value)
    {
        stack.Add(value);
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't pop, the stack is empty.");
        }

        var lastElement = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);

        return lastElement;
    }

    public bool IsEmpty()
    {
        return stack.Count == 0;
    }
}