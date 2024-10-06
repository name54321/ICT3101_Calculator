Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's failures and failure intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this
  // lab2.2 part 18


  @Reliability
  Scenario: Calculating Failure Intensity
    Given I have a calculator
    When I have entered 0.1, 200, and 50 into the calculator and press Failure Intensity
    Then the Failure Intensity result should be 0.09


@Reliability
Scenario: Calculating Expected Number of Failures
  Given I have a calculator
  When I have entered 0.5, 100, and 50 into the calculator and press Expected Failures
  Then the Expected Number of Failures result should be 22

