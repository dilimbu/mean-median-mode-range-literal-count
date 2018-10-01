using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MeanMedianModeRangeAndLiteralCount.UnitTests
{
    [TestFixture()]
    public class CalculatorTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4)]
        [TestCase(new int[] { 0 }, 0)]
        public void Mean_whenCalled_ReturnMeanOf(int[] array, int expectedResult)
        {
            var calculator = new Calculator(array);
            var result = calculator.Mean();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4)]
        [TestCase(new int[] { 0 }, 0)]
        public void Median_WhenCalled_ReturnMedianOf(int[] array, int expectedResult)
        {
            var calculator = new Calculator(array);
            var result = calculator.Median();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 13, 45, 99, 0, 0, 0, 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -1)]
        [TestCase(new int[] { 0 }, 0)]
        public void Mode_WhenCalled_ReturnModeOf(int[] array, int expectedResult)
        {
            var calculator = new Calculator(array);
            var result = calculator.Mode();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6)]
        [TestCase(new int[] { 0 }, 0)]
        public void Range_WhenCalled_ReturnRangeOf(int[] array, int expectedResult)
        {
            var calculator = new Calculator(array);
            var result = calculator.Range();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //[Test]
        //[TestCase("thisis a samplestring")]
        //public void CountOccurrence_WhenCalled_ReturnCountOfEachChar(string word, int[] expectedResult)
        //{
        //    var calculator = new Calculator();
        //    var result = calculator.CountOccurrence(word);
        //    Assert.That(result, Is.EqualTo(expectedResult));
        //}

        [Test]
        public void CountOccurrenceUsingDictionary_WhenCalled_ReturnCountOfEachChar()
        {
            Dictionary<char, int> expectedResult = new Dictionary<char, int> { { 'a', 2 }, { 'e', 1 }, { 'g', 1 }, { 'h', 1 },
                { 'i', 3 }, { 'l', 1 }, { 'm', 1 }, { 'n', 1 }, { 'p', 1 }, { 'r', 1 }, { 's', 4 }, { 't', 2 } };
            var calculator = new Calculator();
            var result = calculator.CountOccurrenceUsingDictionary("thisis a samplestring");
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
    }
}
