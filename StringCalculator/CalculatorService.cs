namespace StringCalculator
{
    public class CalculatorService : ICalculatorService
    {
        public int AddNumbers(int[] numbers)
        {
            return numbers != null && numbers.Length > 0 ? numbers.Sum() : 0;
        }
    }
}
