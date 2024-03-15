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
        [DataRow("1\n2", new int[] { 1, 2 }, DisplayName = "'1\n2' = [1, 2]")]
        public void ParsingService_Returns_Numbers_With_Constrain(string input, int[] expected)
        {
            int maxNumOfValuesAllowed = 2;
            string[] delimiters = [",", "\n"];
            ParsingService service = new();
            CollectionAssert.AreEqual(expected, service.ParseInput(input, delimiters, maxNumOfValuesAllowed));
        }

        [TestMethod]
        [DataRow("1,2,3", DisplayName = "'1,2,3' = exception thrown")]
        [DataRow("1,2,3,4,5,6,7,8,9", DisplayName = "'1,2,3,4,5,6,7,8,9' = exception thrown")]
        [DataRow("a,b,c", DisplayName = "'a,b,c' = exception thrown")]
        [DataRow(" ,-,?", DisplayName = "' ,-,?' = exception thrown")]
        public void ParsingService_Throws_Exception_When_Constrain_Exceeded(string input)
        {
            const int maxNumOfValuesAllowed = 2;
            string[] delimiters = [",", "\n"];
            ParsingService service = new();
            Assert.ThrowsException<Exception>(() => service.ParseInput(input, delimiters, maxNumOfValuesAllowed));
        }

        [TestMethod]
        [DataRow("1,-2,3", DisplayName = "'1,-2,3' = exception thrown")]
        [DataRow("1,-2,3,4\n5,6,-7,8,9", DisplayName = "'1,-2,3,4\n5,6,-7,8,9' = exception thrown")]
        public void ParsingService_Throws_Exception_When_Negative_Numbers_Provided(string input)
        {
            const int maxNumOfValuesAllowed = int.MaxValue;
            string[] delimiters = [",", "\n"];
            ParsingService service = new();
            Assert.ThrowsException<Exception>(() => service.ParseInput(input, delimiters, maxNumOfValuesAllowed));
        }

        [TestMethod]
        [DataRow("1,2,3,4", new int[] { 1,2,3,4 }, DisplayName = "'1,2,3,4' = [1,2,3,4]")]
        [DataRow("1,2,3,4,5,6,7,8,9,10", new int[] { 1,2,3,4,5,6,7,8,9,10 }, DisplayName = "'1,2,3,4,5,6,7,8,9,10' = [1,2,3,4,5,6,7,8,9,10]")]
        [DataRow("1,2,a,4,5,6,7,$,9,10", new int[] { 1, 2, 0, 4, 5, 6, 7, 0, 9, 10 }, DisplayName = "'1,2,a,4,5,6,7,$,9,10' = [1,2,0,4,5,6,7,0,9,10]")]
        [DataRow("1\n2,3", new int[] { 1, 2, 3 }, DisplayName = "'1\n2,3' = [1, 2, 3]")]
        [DataRow("1\n2,3,4\n5", new int[] { 1, 2, 3, 4, 5 }, DisplayName = "'1\n2,3,4\n5' = [1, 2, 3, 4, 5]")]
        public void ParsingService_Returns_Numbers_Without_Constrain(string input, int[] expected)
        {
            const int maxNumOfValuesAllowed = int.MaxValue;
            string[] delimiters = [",", "\n"];
            ParsingService service = new();
            CollectionAssert.AreEqual(expected, service.ParseInput(input, delimiters, maxNumOfValuesAllowed));
        }

        [TestMethod]
        [DataRow("1,2,1001,4", new int[] { 1, 2, 0, 4 }, DisplayName = "'1,2,1001,4' = [1,2,0,4]")]
        [DataRow("1,2\n1001,4", new int[] { 1, 2, 0, 4 }, DisplayName = "'1,2\n1001,4' = [1,2,0,4]")]
        [DataRow("1,2\n1001,20000,5,999", new int[] { 1, 2, 0, 0, 5, 999 }, DisplayName = "'1,2\n1001,20000,5,999' = [1,2,0,0,5,999]")]
        public void ParsingService_Returns_Numbers_While_Invalidating_Large_Numbers(string input, int[] expected)
        {
            const int maxNumOfValuesAllowed = int.MaxValue;
            string[] delimiters = [",", "\n"];
            ParsingService service = new();
            CollectionAssert.AreEqual(expected, service.ParseInput(input, delimiters, maxNumOfValuesAllowed));
        }
    }
}