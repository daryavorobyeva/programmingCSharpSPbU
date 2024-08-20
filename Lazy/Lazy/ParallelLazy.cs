namespace Lazy;

/// <summary>
/// Implementation of the ILazy interface for multi-threaded use.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ParallelLazy<T> : ILazy<T> where T : class
{
    private Func<T>? supplier;
    private T? value;
    private Exception? supplierExeption;
    private object locker = new();

    /// <summary>
    /// Standard lazy object constructor.
    /// </summary>
    /// <param name="func"></param>
    public ParallelLazy(Func<T> func)
    {
        supplier = func;
        value = null;
    }

    /// <inheritdoc cref="ILazy{T}.Get"/>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public T Get()
    {
        lock (locker)
        {
            if (supplierExeption != null)
            {
                throw supplierExeption;
            }

            if (supplier == null)
            {
                throw new ArgumentNullException("Supplier can't be null.");
            }

            if (value == null)
            {
                try
                {
                    value = supplier();
                }
                catch (Exception ex)
                {
                    supplierExeption = ex;
                    Console.WriteLine(ex.Message);
                }
            }

            return value;
        }
    }
}
