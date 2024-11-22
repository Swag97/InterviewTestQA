using InterviewTestQA.InterviewTestAutomation;
using NUnit.Framework.Legacy;

namespace InterviewTestQA
{
    /* public class CalculatorTest
     {
         [Test]
         public void Test1()
         {

         }
     }*/
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        // Test for Addition
        [Test]
        [TestCase(5, 3, 8)]
        [TestCase(-5, -3, -8)]
        [TestCase(-5, 3, -2)]
        [TestCase(0, 0, 0)]
        public void Addition(int a, int b, int expected)
        {
            double result = _calculator.Add(a, b);
            ClassicAssert.AreEqual(expected, result);
        }

        // Test for Subtraction
        [Test]
        [TestCase(5, 3, 2)]
        [TestCase(-5, -3, -2)]
        [TestCase(-5, 3, -8)]
        [TestCase(0, 0, 0)]
        public void Subtraction(int a, int b, int expected)
        {
            double result = _calculator.Subtract(a, b);
            ClassicAssert.AreEqual(expected, result);
        }

        // Test for Multiplication
        [Test]
        [TestCase(5, 3, 15)]
        [TestCase(-5, -3, 15)]
        [TestCase(-5, 3, -15)]
        [TestCase(0, 5, 0)]
        public void Multiplication(int a, int b, int expected)
        {
            double result = _calculator.Multiply(a, b);
            ClassicAssert.AreEqual(expected, result);
        }

        // Test for Division
        [Test]
        [TestCase(6, 3, 2)]
        [TestCase(-6, -3, 2)]
        [TestCase(-6, 3, -2)]
        [TestCase(0, 5, 0)]
        public void Division(int a, int b, int expected)
        {
            double result = _calculator.Divide(a, b);
            ClassicAssert.AreEqual(expected, result);
        }
      
        // Test for Division by Zero
        [Test]
        public void Divide_ByZero()
        {
            
            ClassicAssert.Throws<ArgumentException>(() => _calculator.Divide(5, 0));
        }

        [Test]
        [TestCase(2, 4)]
        [TestCase(-9, 81)]
        [TestCase(0, 0)]
        public void Square(int a, int expected)
        {
            double result = _calculator.Square(a);
            ClassicAssert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(64, 8)]
        [TestCase(81, 9)]
        [TestCase(0, 0)]
        public void SquareRoot(int a, int expected)
        {
            double result = _calculator.SquareRoot(a);
            ClassicAssert.AreEqual(expected, result);
        }
        [Test]
        public void SquareRootOfNegativeNumber()
        {

            ClassicAssert.Throws<ArgumentException>(() => _calculator.SquareRoot(-9));
        }
    }
}