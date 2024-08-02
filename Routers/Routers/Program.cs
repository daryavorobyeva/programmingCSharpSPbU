using Routers;
using Routers.Exceptions;

class Program
{
    public static int Main(string[] args)
    {
        if (args[0] == "-help")
        {
            Console.WriteLine("""
        This program is for generating the optimal configuration of routers for a given network topology.

        To use:
        dotnet run [input file path] [output file path]

        Input file format:
        routerNumber: linkedRouterNumber (throughput), ...

        """);

            return 0;
        }

        if (args.Length < 2)
        {
            Console.WriteLine("Invalid format.");
            Console.WriteLine("For help use: dotnet run -help");

            return 0;
        }

        if (!File.Exists(args[0]) || !File.Exists(args[1]))
        {
            Console.WriteLine("You entered not existing file.");
            Console.WriteLine("For help use: dotnet run -help");

            return 0;
        }

        var topology = File.ReadAllText(args[0]);

        try
        {
            var configuration = TopologyConfiguration.BuildClearTopology(topology);
            File.WriteAllText(args[1], configuration);

            Console.WriteLine("The topology of the router network is built.");

            return 0;
        }
        catch (TopologyNotConnectedException ex)
        {
            Console.Error.WriteLine(ex.Message);
            Console.WriteLine("For help use: dotnet run -help");

            return 1;
        }
        catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("For help use: dotnet run -help");

            return 1;
        }
    }
}