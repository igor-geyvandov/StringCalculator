namespace StringCalculator
{
    public interface IParsingService
    {
        int[] ParseInput(string input, string[] delimiters, int maxNumOfValuesAllowed);
    }
}
