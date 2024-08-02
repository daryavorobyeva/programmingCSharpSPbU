using Sorting;

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of the array: ");
        int size = -1;
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.WriteLine("You entered the wrong size, it must be a positive number.");
            Console.Write("Enter the size of the array: ");
        }

        Console.WriteLine("Enter array elements (integers): ");
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Invalid value");
            }
        }

        Sort.BubbleSort(array);

        Console.Write("Sorted array: ");
        for (int i = 0; i < size; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}