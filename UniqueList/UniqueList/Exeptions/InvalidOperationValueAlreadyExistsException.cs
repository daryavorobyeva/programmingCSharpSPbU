namespace UniqueList.Exeptions;

/// <summary>
/// Exception for a unique list if the value is already contained.
/// </summary>
public class InvalidOperationValueAlreadyExistsException : InvalidOperationException
{
    public InvalidOperationValueAlreadyExistsException()
    {
    }

    public InvalidOperationValueAlreadyExistsException(string message) : base(message)
    {
    }
}
