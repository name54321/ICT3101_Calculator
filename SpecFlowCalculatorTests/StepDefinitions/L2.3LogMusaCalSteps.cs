using Gherkin.CucumberMessages.Types;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Drawing;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class UsingCalculatorLogMusaSteps
    {
        private readonly CalculatorContext _context;

        public UsingCalculatorLogMusaSteps(CalculatorContext context)
        {
            _context = context;  // Inject CalculatorContext to share the same instance
        }

        [When(@"I have entered (.*), (.*) and (.*) into the calculator and press Log Musa Failure Intensity")]
        public void WhenIHaveEnteredAndPressLogMusaFailureIntensity(double lambda0, double v0, double time)
        {
            _context.Result = _context.Calculator.CalculateLogMusaFailureIntensity(lambda0, v0, time);
        }

        [When(@"I have entered (.*), (.*) and (.*) into the calculator and press Log Musa Expected Failures")]
        public void WhenIHaveEnteredAndPressLogMusaExpectedFailures(double lambda0, double v0, double time)
        {
            _context.Result = _context.Calculator.CalculateLogMusaExpectedFailures(lambda0, v0, time);
        }

        [Then(@"the (Log Musa Failure Intensity|Log Musa Expected Number of Failures) result should be (.*)")]
        public void ThenTheLogMusaResultShouldBe(string operationType, double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.01),
                $"Expected {expectedResult} but got {_context.Result} for {operationType}");
        }
    }
}

//23.In using the BDD process to develop the new functions(and corresponding functionality)
//what were some of the issues you faced? How did you resolve them to get things running?
//    Handling Zero Division Errors in Defect Density Calculation:
//Issue: If the source lines of code entered were zero, it caused a division-by-zero exception.
//Resolution: Added a check to throw an informative ArgumentException when source lines of code are zero.

//Granular Testing for Musa Logarithmic Model:
//Issue: Getting floating-point inaccuracies when dealing with small numbers in exponential functions.
//Resolution: Implemented.Within(0.01) tolerances in the SpecFlow tests to allow for small discrepancies.

//Making Gherkin Scenarios Readable for Clients:
//Issue: Initial Gherkin scenarios used technical terms (like "lambda0" and "mu0"), which were unclear to stakeholders.
//Resolution: Modified the Gherkin scenarios to use more client-friendly terms like "initial failure intensity" and "hours of operation."

//Specifying the Use of the Same Calculator Context Across Tests:
//Issue: Without shared context, the calculator would reset between scenarios.
//Resolution: Used context injection (CalculatorContext) to persist the calculator state across multiple steps and scenarios.