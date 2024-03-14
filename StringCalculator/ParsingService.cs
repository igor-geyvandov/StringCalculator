namespace StringCalculator
{
    public class ParsingService : IParsingService
    {
        public int[] ParseInput(string input, int maxNumOfValuesAllowed = 2, string delimiter = ",")
        {
            int[] intValues = { 0 };
            if (!string.IsNullOrEmpty(input))
            {
                string[] strValues = input.Split(delimiter);
                if (strValues.Length <= maxNumOfValuesAllowed)
                {
                    intValues = Array.ConvertAll(strValues, s => int.TryParse(s, out var i) ? i : 0);    
                }
                else
                {
                    throw new Exception("More than 2 numbers were provided");
                }                               
            }
            return intValues;
        }
    }
}
