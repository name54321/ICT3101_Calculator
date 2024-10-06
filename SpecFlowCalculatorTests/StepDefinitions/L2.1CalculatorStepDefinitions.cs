using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private readonly CalculatorContext _context;

        // Use context injection to share Calculator and Result between steps
        public UsingCalculatorStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _context.Calculator = new Calculator(); // Initialize the Calculator in the shared context
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("BinaryAddition"))
            {
                _context.Result = _context.Calculator.AddB(p0, p1);
            }
            else
            {
                _context.Result = _context.Calculator.Add(p0, p1);
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.0001));
        }
    }
}
