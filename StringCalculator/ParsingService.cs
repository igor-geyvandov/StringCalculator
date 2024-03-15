namespace StringCalculator
{
    public class ParsingService : IParsingService
    {
        public int[] ParseInput(string input, string[] delimiters, int maxNumOfValuesAllowed)
        {
            int[] intValues = { 0 };
            if (!string.IsNullOrEmpty(input))
            {
                string[] strValues = input.Split(delimiters, StringSplitOptions.TrimEntries);
                if (strValues.Length <= maxNumOfValuesAllowed)
                {
                    intValues = Array.ConvertAll(strValues, s => int.TryParse(s, out var i) ? i : 0);
                    
                    int[] negativeIntValues = intValues.Where(v => v < 0).ToArray();
                    if (negativeIntValues.Length > 0)
                    {
                        throw new Exception($"Negative numbers provided: {string.Join(",", negativeIntValues)}");
                    }
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
