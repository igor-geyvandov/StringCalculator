namespace StringCalculator
{
    public interface IParsingService
    {
        int[] ParseInput(string input, int maxNumOfValuesAllowed, string delimiter);
    }
}
