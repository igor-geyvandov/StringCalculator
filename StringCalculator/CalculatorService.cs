namespace StringCalculator
{
    public class CalculatorService : ICalculatorService
    {
        public int AddNumbers(int[] numbers)
        {
            int sum = 0;
            if (numbers != null)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    sum += numbers[i];
                }
            }
            return sum;
        }
    }
}
