using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class UsingCalculatorAvailabilitySteps
    {
        private readonly CalculatorContext _context;
        private string _operationType; // Store the operation type

        public UsingCalculatorAvailabilitySteps(CalculatorContext context)
        {
            _context = context;  // Inject CalculatorContext to share the same instance
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndPressMTBF(double totalTime, double failures)
        {
            _context.Result = _context.Calculator.MTBF(totalTime, failures);  // Store result in shared context
            _operationType = "MTBF"; // Store operation type
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndPressAvailability(double uptime, double downtime)
        {
            _context.Result = _context.Calculator.Availability(uptime, downtime);  // Store result in shared context
            _operationType = "Availability"; // Store operation type
        }

        [Then(@"the (MTBF|Availability) result should be (.*)")]
        public void ThenTheResultShouldBe(string operationType, string expectedResult)
        {
            // Check if operation matches the one executed
            Assert.That(_operationType, Is.EqualTo(operationType), $"Expected {operationType} but got {_operationType}");

            // Handle the case where the expected result is Infinity
            if (expectedResult == "Infinity")
            {
                Assert.That(_context.Result, Is.EqualTo(double.PositiveInfinity), $"Expected result is Infinity for {operationType}");
            }
            else
            {
                double expectedDouble;

                // If the operation is Availability and the expected result includes %, remove the % for parsing
                if (operationType == "Availability" && expectedResult.EndsWith("%"))
                {
                    expectedResult = expectedResult.Replace("%", "");
                }

                expectedDouble = double.Parse(expectedResult);

                if (operationType == "MTBF")
                {
                    // For MTBF, compare the result normally
                    Assert.That(_context.Result, Is.EqualTo(expectedDouble).Within(0.01), $"Expected {expectedDouble} but got {_context.Result} for MTBF");
                }
                else if (operationType == "Availability")
                {
                    // For Availability, compare the result as a percentage and format output with %
                    Assert.That(_context.Result, Is.EqualTo(expectedDouble).Within(0.05), $"Expected {expectedDouble}% but got {_context.Result}% for Availability");
                }
            }
        }

    }
}
