namespace Lazy;

/// <summary>
/// Setting a T type element using lazy calculation.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ILazy<out T>
{
    /// <summary>
    /// Get a type T element using lazy calculation.
    /// </summary>
    /// <returns></returns>
    T Get();
}
