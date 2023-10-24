using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1Yura;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace TestReplaceUnaryPlusMinus
{
    [TestClass]
    public class TestReplaceUnaryPlusMinus
    {
        private static IEnumerable<object[]> TestData()
        {
            try
            {
                XElement xmlData = XElement.Load("TestData.xml");

                var testCases = from testCase in xmlData.Elements("TestCase")
                                select new object[]
                                {
                                    GetElementValueOrNull(testCase.Element("Input")),
                                    GetElementValueOrNull(testCase.Element("ExpectedResult"))
                                };

                return testCases;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to load test data from XML. Exception: {ex.Message}");
                return Enumerable.Empty<object[]>();
            }
        }

        private static string GetElementValueOrNull(XElement element)
        {
            return element != null && !string.IsNullOrWhiteSpace(element.Value) ? element.Value : null;
        }




        [TestMethod]
        [DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        public void ReplaceUnaryPlusMinus_WithXmlData_ShouldReturnExpectedResult(string input, string expectedResult)
        {
            if (input == "null")
            {
                input = null;
            }
            if (expectedResult == "null")
            {
                expectedResult = null;
            }
            try
            {
                // Act
                string result = Calculator.ReplaceUnaryPlusMinus(input);

                // Assert
                Assert.AreEqual(expectedResult, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed for input '{input}' with exception: {ex.Message}");
            }
        }
    }
}
