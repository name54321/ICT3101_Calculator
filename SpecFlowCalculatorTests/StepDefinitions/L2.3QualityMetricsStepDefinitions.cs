using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class QualityMetricsStepDefinitions
    {
        private readonly CalculatorContext _context;

        public QualityMetricsStepDefinitions(CalculatorContext context)
        {
            _context = context;  // Share the same context
        }

        [When(@"I enter (.*) defects and (.*) source lines of code")]
        public void WhenIEnterDefectsAndSourceLinesOfCode(double defects, double sourceLinesOfCode)
        {
            _context.Result = _context.Calculator.CalculateDefectDensity(defects, sourceLinesOfCode);
        }

        [Then(@"the Defect Density result should be (.*)")]
        public void ThenTheDefectDensityResultShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.01),
                        $"Expected {expectedResult} but got {_context.Result} for Defect Density");
        }
    }
}
