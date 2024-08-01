using StackCalculation;
using StackImplementation;

class Program
{
    static void Main()
    {
        IStack stack = new StackList();

        bool preparing = true;
        while (preparing)
        {
            Console.WriteLine("""
            This is a stack calculator.
            - Enter 1 if you want to use the stack as a Dynamic Array
            - Enter 2 if you want to use the stack as a Linked List
            """
            );
            var stackView = Console.ReadLine();

            switch (stackView)
            {
                case "1":
                    preparing = false;
                    stack = new StackArray();
                    break;

                case "2":
                    preparing = false;
                    break;

                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }
        }

        bool processing = true;
        while (processing)
        {
            Console.WriteLine("""
            Enter a mathematical expression in postfix form with integers (signed and unsigned), 
            characters (+, -, *, /) and numbers are separated by a space:
            """
            );
            var expression = Console.ReadLine();

            try
            {
                var result = StackCalculator.CalculateExpression(expression, stack);
                Console.WriteLine("Result: " + result);
                processing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}