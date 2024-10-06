using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class UsingCalculatorReliabilitySteps
    {
        private readonly CalculatorContext _context;

        //lab2.2 part 18
        public UsingCalculatorReliabilitySteps(CalculatorContext context)
        {
            _context = context;  // Inject CalculatorContext to share the same instance
        }

        [When(@"I have entered (.*), (.*) and (.*) into the calculator and press Failure Intensity")]
        public void WhenIHaveEnteredAndPressFailureIntensity(double lambda0, double mu0, double time)
        {
            _context.Result = _context.Calculator.CalculateFailureIntensity(lambda0, mu0, time);
        }

        [When(@"I have entered (.*), (.*) and (.*) into the calculator and press Expected Failures")]
        public void WhenIHaveEnteredAndPressExpectedFailures(double lambda0, double mu0, double time)
        {
            _context.Result = _context.Calculator.CalculateExpectedFailures(lambda0, mu0, time);
        }

        [Then(@"the (Failure Intensity|Expected Number of Failures) result should be (.*)")]
        public void ThenTheResultShouldBe(string operationType, double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.01),
                $"Expected {expectedResult} but got {_context.Result} for {operationType}");
        }

    }
}
