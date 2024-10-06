using System;
using TechTalk.SpecFlow;
using NUnit.Framework;  // Ensure NUnit framework is imported

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class UsingCalculatorDivisionStepDefinitions
    {
        private readonly Calculator _calculator;
        private double _result;
        private bool _divisionByZeroError;

        // Constructor to inject the Calculator instance
        public UsingCalculatorDivisionStepDefinitions(Calculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(double num1, double num2)
        {
            try
            {
                // Perform division and catch division by zero errors
                _result = _calculator.Divide(num1, num2);
                _divisionByZeroError = false;
            }
            catch (ArgumentException ex) when (ex.Message == "Cannot divide by zero.")
            {
                _divisionByZeroError = true;
                _result = double.PositiveInfinity;  // Handle division by zero result
            }
            catch (ArgumentException ex) when (ex.Message == "Both values are zero.")
            {
                _divisionByZeroError = true;
                _result = double.NaN;  // Handle 0/0 case
            }
        }

        [Then(@"the division result should be (.*)")]
        public void ThenTheDivisionResultShouldBe(double expectedResult)
        {
            if (_divisionByZeroError)
            {
                // Check for NaN result when division is indeterminate
                Assert.That(double.IsNaN(_result), Is.True, "Expected NaN result for indeterminate form.");
            }
            else
            {
                // Check the division result for valid cases
                Assert.That(_result, Is.EqualTo(expectedResult), "The division result is not as expected.");
            }
        }

        [Then(@"the division result equals positive_infinity")]
        public void ThenTheDivisionResultEqualsPositive_Infinity()
        {
            // Check if the result is positive infinity
            Assert.That(_result, Is.EqualTo(double.PositiveInfinity), "The division result is not positive infinity.");
        }
    }
}
