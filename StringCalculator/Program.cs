using Microsoft.Extensions.DependencyInjection;
using StringCalculator;
public class Program
{
    public static void Main(string[] args)
    {
        const int MAX_NUM_OF_VALUES_ALLOWED = 2;
        const string VALUE_DELIMITER = ",";

        var serviceProvider = new ServiceCollection()
            .AddSingleton<IParsingService, ParsingService>()
            .AddSingleton<ICalculatorService, CalculatorService>()
            .BuildServiceProvider();

        IParsingService? parsingService = serviceProvider.GetService<IParsingService>();
        ICalculatorService? calculatorService = serviceProvider.GetService<ICalculatorService>();

        if (parsingService != null && calculatorService != null)
        {
            Console.WriteLine("Hello, I am a calculator that only supports an Add operation given a single formatted string :)");            
            while (true)
            {
                Console.WriteLine(Environment.NewLine + $"Enter {MAX_NUM_OF_VALUES_ALLOWED} numbers using '{VALUE_DELIMITER}' delimiter...");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    int[] intValues = parsingService.ParseInput(input, MAX_NUM_OF_VALUES_ALLOWED, VALUE_DELIMITER);
                    int result = calculatorService.AddNumbers(intValues);
                    Console.WriteLine($"{string.Join(" + ", intValues)} = {result}");
                }
            }
        }
        Console.WriteLine(Environment.NewLine + "Press enter to quit...");
        Console.ReadLine();
    }
}