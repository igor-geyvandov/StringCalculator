namespace StringCalculator
{
    public interface IParsingService
    {
        int[] ParseInput(string input, char[] delimiters, int maxNumOfValuesAllowed);
    }
}
