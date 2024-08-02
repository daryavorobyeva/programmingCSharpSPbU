namespace UniqueList.Exeptions;

/// <summary>
/// You cannot delete an item that does not exist.
/// </summary>
public class InvalidRemoveOperationException : InvalidOperationException
{
    public InvalidRemoveOperationException()
    {
    }

    public InvalidRemoveOperationException(string message) : base(message)
    {
    }
}
