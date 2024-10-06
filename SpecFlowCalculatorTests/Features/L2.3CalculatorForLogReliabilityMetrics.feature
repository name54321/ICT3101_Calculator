Feature: UsingCalculatorForReliabilityMetrics
  In order to predict the reliability of a system
  As a system quality engineer
  I want to calculate failure intensity and expected number of failures using the Musa Logarithmic model

  //lab2.3 part 20
  User Story 3:
  As a system quality engineer, I want to use the Musa Logarithmic model to calculate the 
  current failure intensity so that I can predict the likelihood of future system failures over time.
  
  User Story 4:
  As a system quality engineer, I want to calculate the number of expected failures using the 
  Musa Logarithmic model so that I can understand how reliable the system will be over time.



  lab 2.3 part 22 and 23 

  @LogReliability
  Scenario: Calculating Log Musa Failure Intensity
    Given I have a calculator
    When I have entered 0.02, 100, and 50 into the calculator and press Log Musa Failure Intensity
    Then the Log Musa Failure Intensity result should be 0.0196

  @LogReliability
  Scenario: Calculating Log Musa Expected Number of Failures
    Given I have a calculator
  When I have entered 0.05, 200, and 100 into the calculator and press Log Musa Expected Failures
  Then the Log Musa Expected Number of Failures result should be 4.94