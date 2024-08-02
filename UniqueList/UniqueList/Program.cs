using UniqueList;
using UniqueList.Exceptions;

class Program
{
    public static void Main()
    {
        var uniqueList = new SimpleUniqueList();

        var processing = true;
        while (processing)
        {
            var choosingText = """
        Choose action:
        1. exit
        2. add the element to list
        3. remove the element from list
        4. replace the element at position to a new element
        """;

            Console.WriteLine(choosingText);

            int action;
            while (!int.TryParse(Console.ReadLine(), out action) || action > 4 || action < 1)
            {
                Console.WriteLine("Wrong input!");
                Console.WriteLine(choosingText);
            }


            switch (action)
            {
                case 1:
                    processing = false;
                    break;

                case 2:

                    Console.WriteLine("Enter the element value (int): ");

                    int value;
                    while (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("Wrong input!");
                        Console.WriteLine("Enter the element value (int): ");
                    }

                    try
                    {
                        uniqueList.Add(value);
                    }
                    catch (InvalidOperationValueAlreadyExistsException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 3:
                    try
                    {
                        uniqueList.Remove();
                    }
                    catch (InvalidRemoveOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 4:
                    Console.WriteLine("Enter the element value (int): ");

                    while (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("Wrong input!");
                        Console.WriteLine("Enter the element value (int): ");
                    }

                    Console.WriteLine("Enter position of replacing element: ");

                    int position;
                    while (!int.TryParse(Console.ReadLine(), out position))
                    {
                        Console.WriteLine("Wrong input!");
                        Console.WriteLine("Enter position of replacing element: ");
                    }

                    uniqueList.Replace(value, position);

                    break;
            }
        }
    }
}
