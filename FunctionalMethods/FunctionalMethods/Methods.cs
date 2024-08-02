namespace Function;

public class FunctionalMethods
{
    /// <summary>
    /// Applies the specified function to each item in the list.
    /// </summary>
    /// <typeparam name="T"> Type of elements in the list. </typeparam>
    /// <typeparam name="R"> The type of the result after applying the mapping. </typeparam>
    /// <param name="list"> The original list with the elements. </param>
    /// <param name="func"> Element transform function. </param>
    /// <returns> List of converted elements of result type. </returns>
    public static List<R> Map<T, R>(List<T> list, Func<T, R> func)
    {
        List<R> result = new List<R>();
        foreach (var item in list)
        {
            result.Add(func(item));
        }

        return result;
    }

    /// <summary>
    /// Filters the elements of the list by the given predicate.
    /// </summary>
    /// <typeparam name="T"> Type of elements in the list. </typeparam>
    /// <param name="list"> The original list with the elements. </param>
    /// <param name="func"> Function that takes a value and returns a bool. </param>
    /// <returns> List of elements whose predicate evaluates to true. </returns>
    public static List<T> Filter<T>(List<T> list, Predicate<T> func)
    {
        List<T> result = new List<T>();
        foreach (var item in list)
        {
            if (func(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    /// <summary>
    /// Accumulates the set value using the passed function by going through the elements of the list.
    /// </summary>
    /// <typeparam name="T"> Type of elements in the list. </typeparam>
    /// <typeparam name="R"> Type of accumulating element. </typeparam>
    /// <param name="list"> The original list with the elements. </param>
    /// <param name="acc"> Element we want to accumulate passing through the list. </param>
    /// <param name="func"> Function of two arguments with a non void return value. </param>
    /// <returns></returns>
    public static R Fold<T, R>(List<T> list, R acc, Func<R, T, R> func)
    {
        var result = acc;
        foreach (var item in list)
        {
            result = func(result, item);
        }
        return result;
    }
}