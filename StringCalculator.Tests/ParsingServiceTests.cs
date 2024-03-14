using StringCalculator;
using System.ComponentModel;

namespace StringCalculator.Tests
{
    [TestClass]
    public class ParsingServiceTests
    {
        [TestMethod]
        [DataRow("", new int[] { 0 }, DisplayName = "'' = []")]
        [DataRow("1", new int[] { 1 }, DisplayName = "'1' = [1]")]
        [DataRow("\n", new int[] { 0 }, DisplayName = "'\n' = [0]")]
        [DataRow("abc", new int[] { 0 }, DisplayName = "'abc' = [0]")]
        [DataRow(" ", new int[] { 0 }, DisplayName = "' ' = [0]")]
        [DataRow("   ", new int[] { 0 }, DisplayName = "'   ' = [0]")]
        [DataRow(" - ", new int[] { 0 }, DisplayName = "' - ' = [0]")]
        [DataRow("  ,  ", new int[] { 0, 0 }, DisplayName = "'  ,  ' = [0,0]")]
        [DataRow("-,*", new int[] { 0, 0 }, DisplayName = "'-,*' = [0,0]")]
        [DataRow("1,0", new int[] { 1, 0 }, DisplayName = "'1,0' = [1,0]")]
        [DataRow("1,2", new int[] { 1, 2 }, DisplayName = "'1,2' = [1,2]")]
        [DataRow("1,a", new int[] { 1, 0 }, DisplayName = "'1,a' = [1,0]")]
        [DataRow("1,aaa", new int[] { 1, 0 }, DisplayName = "'1,aaa' = [1,0]")]
        [DataRow("1,???", new int[] { 1, 0 }, DisplayName = "'1,???' = [1, 0]")]
        public void ParsingService_Returns_SumOfValues(string input, int[] expected)
        {
            const int maxNumOfValuesAllowed = 2;
            ParsingService service = new ParsingService();
            CollectionAssert.AreEqual(expected, service.ParseInput(input, maxNumOfValuesAllowed));
        }


        [TestMethod]
        [DataRow("1,2,3", DisplayName = "'1,2,3' = exception thrown")]
        [DataRow("1,2,3,4,5,6,7,8,9", DisplayName = "'1,2,3,4,5,6,7,8,9' = exception thrown")]
        [DataRow("a,b,c", DisplayName = "'a,b,c' = exception thrown")]
        [DataRow(" ,-,?", DisplayName = "' ,-,?' = exception thrown")]
        public void ParsingService_Throws_Exception(string input)
        {
            const int maxNumOfValuesAllowed = 2;
            ParsingService service = new ParsingService();
            Assert.ThrowsException<Exception>(() => service.ParseInput(input, maxNumOfValuesAllowed));
        }
    }
}