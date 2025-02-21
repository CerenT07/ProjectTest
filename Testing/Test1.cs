using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace CalculatorAppTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = _calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            int result = _calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Multiply_ShouldReturnCorrectProduct()
        {
            int result = _calculator.Multiply(4, 3);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            double result = _calculator.Divide(6, 2);
            Assert.AreEqual(3.0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ShouldThrowException()
        {
            _calculator.Divide(1, 0);
        }
    }
}
