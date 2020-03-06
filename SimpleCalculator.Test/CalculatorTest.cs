using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestCalculate_SimpleAddion_CorrectResult()
        {

            var calculator = new Calculator();
            double result = calculator.Calculate("2 + 43");
            Assert.AreEqual(45.0, result);
        }

        [TestMethod]
        public void TestCalculate_SimpleDoubleAddition_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("2.56 + 1.98");

            Assert.AreEqual(4.54, result);

        }

        [TestMethod]
        public void TestCalculate_SimpleDoubleSubtraction_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("2.56 - 1.98");

            Assert.AreEqual(0.58, result);

        }

        [TestMethod]
        public void TestCalculate_AdditionOfNegativeNumbers_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("-5 + -9");

            Assert.AreEqual(-14.0, result);
        }

        [TestMethod]
        public void TestCalculate_SubtractionOfNegativeNumbers_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("-7 - -15.4 + 21");

            Assert.AreEqual(29.4, result);
        }

        [TestMethod]
        public void TestCalculate_AdditionWithFirstNegativeNumber_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("-14 + 7");

            Assert.AreEqual(-7.0, result);
        }

        [TestMethod]
        public void TestCalculate_SimpleMultiplication_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("5 * 2.5");

            Assert.AreEqual(12.5, result);
        }

        [TestMethod]
        public void TestCalculate_SimpleNegativeMultiplication_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("-2.5 * - 6");

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestCalculate_ComplexTerm_WrongResultBecauseNoMultiDivisionBeforeAdditionSubtraction()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("-25.5 / 5 - 0.9 * -3 - 18");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCalculate_SimpleNegativeDivision_CorrectResult()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("-25.5 / 5");
            Assert.AreEqual(-5.1, result);
        }

        [TestMethod]
        public void TestCalculate_DivisionToNull_Infinite()
        {
            var calculator = new Calculator();

            double result = calculator.Calculate("25.5 / 0");
            Assert.IsTrue(double.IsPositiveInfinity(result));
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestCalculate_WrongTerm_ZeroResult()
        {
            var calculator = new Calculator();
            calculator.Calculate("25.5 + ");
        }
    }
}
