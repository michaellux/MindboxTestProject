using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea.Tests
{
    internal class CalculateTriangleAreaTests
    {
        [TestCase(0.433013, 1, 1, 1)]
        [TestCase(0, 4, 2, 2)]
        [TestCase(10.547851, 6.4, 3.3, 7.34)]
        public void TestCalculateTriangleAreaBySides(double expectedArea, double a, double b, double c)
        {
            Assert.AreEqual(expectedArea, Library.Calculator.CalculateTriangleAreaBySides(a, b, c), 0.000001);
        }

        [TestCase(true, 9, 40, 41)]
        [TestCase(true, 5, 12, 13)]
        [TestCase(true, 10, 24, 26)]
        public void TestCheckTriangleIsRight(bool expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CheckTriangleIsRight(a, b, c));
        }

        [TestCase(false, 32, 42, 62)]
        [TestCase(false, 8, 8, 8)]
        [TestCase(false, 5, 5, 3)]
        public void TestCheckTriangleIsNotRight(bool expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CheckTriangleIsRight(a, b, c));
        }

        [TestCaseSource(nameof(SideValues))]
        public void TestDefineSideValues(ValueTuple<double, ValueTuple<double, double>> expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.DefineSideValues(a, b, c));
        }
        public static IEnumerable<TestCaseData> SideValues
        {
            get
            {
                yield return new TestCaseData((3.0, (2.0, 1.0)), 3.0, 2.0, 1.0);
                yield return new TestCaseData((2.0, (0.0, 1.0)), 0.0, 2.0, 1.0);
                yield return new TestCaseData((3.0, (1.0, 2.0)), 1.0, 2.0, 3.0);
                yield return new TestCaseData((2.0, (2.0, 2.0)), 2.0, 2.0, 2.0);
            }
        }

        [TestCase(3, 2, 3)]
        [TestCase(12.5, 5, 5)]
        [TestCase(1, 2, 1)]
        public void TestRightTriangleArea(double expected, double a, double b)
        {
            Assert.AreEqual(expected, Library.Calculator.CalculateRightTriangleArea(a, b));
        }

        [TestCase(2.904738, 2, 3, 4)]
        [TestCase(1.807656, 1.03, 4.6, 4.012)]
        [TestCase(13.63589, 6, 6, 5)]
        public void TestTriangleAreaByHeronFormula(double expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CalculateTriangleAreaByHeronFormula(a, b, c), 0.000001);
        }

        [TestCase(3.5, 3, 2, 2)]
        [TestCase(3.45, 1.2, 3.4, 2.3)]
        [TestCase(35.5, 15, 24, 32)]
        public void TestCalculateTriangleSemiperimeter(double expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CalculateTriangleSemiperimeter(a, b, c), 0.000001);
        }

        [TestCase(false, 0, -1, 6)]
        [TestCase(false,-1, 2, 3)]
        [TestCase(false, int.MinValue, int.MaxValue, 6)]
        [TestCase(true, 2, 4, 5)]
        public void TestCheckSidesValuesIsPositive(bool expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CheckSidesValuesIsPositive(a, b, c));
        }

        [TestCase(true, 2, 2, 2)]
        [TestCase(true, 1, 2, 2)]
        [TestCase(true, 5, 23, 22)]
        public void TestCheckRealTriangleSuccess(bool expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CheckRealTriangle(a, b, c));
        }

        [TestCase(false, 4, 2, 2)]
        [TestCase(false, 3, 3, 6)]
        [TestCase(false, 2, 22, 4)]
        public void TestCheckRealTriangleFail(bool expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CheckRealTriangle(a, b, c));
        }

        [TestCase(true, 3.5, 3.5, 7)]
        [TestCase(true, 3, 6, 3)]
        [TestCase(true, 10, 5, 5)]
        [TestCase(false, 21, 22, 3)]
        [TestCase(false, 2, 22, 3)]
        public void TestCheckDegenerateTriangle(bool expected, double a, double b, double c)
        {
            Assert.AreEqual(expected, Library.Calculator.CheckDegenerateTriangle(a, b, c));
        }
    }
}
