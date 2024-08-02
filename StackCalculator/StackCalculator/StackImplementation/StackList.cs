namespace StackImplementation;

public class StackList : IStack
{

    private LinkedList<double> stack;

    public StackList()
    {
        stack = new LinkedList<double>();
    }

    public void Push(double value)
    {
        stack.AddLast(value);
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't pop, the stack is empty.");
        }

        var lastElement = stack.Last.Value;
        stack.RemoveLast();

        return lastElement;
    }

    public bool IsEmpty()
    {
        return stack.Count == 0;
    }
}