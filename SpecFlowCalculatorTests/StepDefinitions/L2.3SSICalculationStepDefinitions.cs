using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class SSICalculationStepDefinitions
    {
        private readonly CalculatorContext _context;

        public SSICalculationStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I enter (.*) shipped source instructions for the first release and (.*) for the second release")]
        public void WhenIEnterSSIForFirstAndSecondRelease(double firstRelease, double secondRelease)
        {
            _context.Result = _context.Calculator.CalculateShippedSourceInstructions(firstRelease, secondRelease);
        }

        [Then(@"the total Shipped Source Instructions for the second release should be (.*)")]
        public void ThenTheTotalSSIForSecondReleaseShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult),
                        $"Expected {expectedResult} but got {_context.Result} for Shipped Source Instructions");
        }
    }
}
