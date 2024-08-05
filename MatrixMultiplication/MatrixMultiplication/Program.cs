using MatrixMultiplication;

class Program
{
    public static int Main(string[] args)
    {
        if (args.Length == 0 || args[0] == "-help")
        {
            Console.WriteLine("""

              Matrix multiplication using parallel computing.

              Multiply matrices from files to file:
              dotnet run [first matrix file path] [second matrix file path] [result matrix file path]
              (If the path contains spaces -> enclose it in quotes)
              """);

            return 0;
        }

        if (args.Length == 3)
        {
            try
            {
                var firstMatrix = MatrixParsing.ParseFileToMatrix(args[0]);
                var secondMatrix = MatrixParsing.ParseFileToMatrix(args[1]);

                var resultMatrix = MultiplicationOfTwoMatrices.Multiplication(firstMatrix, secondMatrix);
                MatrixParsing.WriteInFile(args[2], resultMatrix);

                return 0;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No such file.");
                Console.WriteLine("For help use: dotnet run -help");

                return 1;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The dimensions of the matrices do not allow to multiply them.");
                Console.WriteLine("For help use: dotnet run -help");

                return 1;
            }
        }

        else
        {
            Console.WriteLine("Unknown path.");
            Console.WriteLine("For help use: dotnet run -help");

            return 1;
        }
    }
}