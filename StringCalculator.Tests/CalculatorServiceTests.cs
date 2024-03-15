using StringCalculator;
using System.ComponentModel;

namespace StringCalculator.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        [DataRow(new int[] {}, 0, DisplayName = "[] = 0")]
        [DataRow(new int[] { 1 }, 1, DisplayName = "[1] = 1")]
        [DataRow(new int[] { 0, 0 }, 0, DisplayName = "[0,0] = 0")]
        [DataRow(new int[] { 1, 0 }, 1, DisplayName = "[1,0] = 1")]
        [DataRow(new int[] { 1, 2 }, 3, DisplayName = "[1,2] = 3")]
        [DataRow(new int[] { 1, 2, 3 }, 6, DisplayName = "[1,2,3] = 6")]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 78, DisplayName = "[1,2,3,4,5,6,7,8,9,10,11,12] = 78")]        
        public void CalculatorService_Returns_SumOfValues(int[] numbers, int expected)
        { 
            CalculatorService service = new CalculatorService();
            Assert.AreEqual(expected, service.AddNumbers(numbers));
        }
    }
}