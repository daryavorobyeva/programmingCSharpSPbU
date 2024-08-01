namespace StackImplementation;

public interface IStack
{
    /// <summary>
    /// Adds an element with the current value to the top of the stack.
    /// </summary>
    /// <param name="value"></param>
    public void Push(double value);

    /// <summary>
    /// Removes an element from the top of the stack.
    /// </summary>
    /// <returns>The value of the deleted element.</returns>
    public double Pop();

    /// <summary>
    /// Checks if the stack is empty.
    /// </summary>
    /// <returns>True if empty, false if not empty.</returns>
    public bool IsEmpty();
}