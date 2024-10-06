using NUnit.Framework;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorFactorialStepDefinitions
    {
        private readonly CalculatorContext _context;

        //lab 2.2 part 16
        public UsingCalculatorFactorialStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) into the calculator and press factorial")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressFactorial(int value)
        {
            _context.Result = _context.Calculator.Factorial(value);
        }

        [Then(@"the factorial result should be (.*)")]
        public void ThenTheFactorialResultShouldBe(int expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.0001));
        }
    }
}