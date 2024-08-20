namespace Task;

/// <summary>
/// Represents a task class with the result type TResult.
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface IMyTask<TResult>
{
    public TResult? Result { get; }

    public bool IsCompleted { get; }

    public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult?, TNewResult> continueFunction);
}
