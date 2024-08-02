namespace Sorting;

public static class Sort
{
    /// <summary>
    /// Sorts an array of integers using a bubble sorting algorithm.
    /// </summary>
    /// <param name="array"></param>
    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    var temporaryVariable = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temporaryVariable;
                }
            }
        }
    }
}
