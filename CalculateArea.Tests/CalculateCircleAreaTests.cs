using NUnit.Framework;
using System;
namespace CalculateArea.Tests
{
    internal class CalculateCircleAreaTests
    {
        [TestCase(Math.PI, 1)]
        [TestCase(31.0062, 3.14159)]
        [TestCase(0.0003, 0.01)]
        public void TestCalculateCircleAreaByRadius(double expectedArea, double radius)
        {
            Assert.AreEqual(expectedArea, Library.Calculator.CalculateCircleAreaByRadius(radius), 0.01);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void TestCalculateCircleAreaWhenRadiusIsLessOrEqualZero(double radius)
        {
            Assert.Throws<ArgumentException>(() => Library.Calculator.CalculateCircleAreaByRadius(radius));
        }
    }
}