using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator = null;
        }

        [TestCase(5, 10, 15)]
        [TestCase(20, 30, 50)]
        [TestCase(100, 200, 300)]
        public void TestAddition(int a, int b, int expected)
        {
            int actual = calculator.Add(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Ignore("Ignored for demonstration")]
        [Test]
        public void IgnoreTest()
        {
        }
    }
}