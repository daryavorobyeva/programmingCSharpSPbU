namespace Sorting.Tests;

[TestClass()]
public class SortTest
{
    [TestMethod()]
    public void BubbleSortTestRegularArray()
    {
        int[] array = { 10, 0, -5, 2, 3, 11, 1, -20 };
        int[] sortedArray = { -20, -5, 0, 1, 2, 3, 10, 11 };

        Sort.BubbleSort(array);

        CollectionAssert.AreEqual(sortedArray, array);  
    }

    [TestMethod()]
    public void BubbleSortTestEmptyArray()
    {
        int[] array = new int[0];
        int[] sortedArray = new int[0];

        Sort.BubbleSort(array);

        CollectionAssert.AreEqual(sortedArray, array);
    }


    [TestMethod()]
    public void BubbleSortTestSortedArray()
    {
        int[] array = { 1, 2, 3 };
        int[] sortedArray = { 1, 2, 3};

        Sort.BubbleSort(array);

        CollectionAssert.AreEqual(sortedArray, array);
    }
}