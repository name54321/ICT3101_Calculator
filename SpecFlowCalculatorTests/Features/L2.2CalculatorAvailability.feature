Feature: UsingCalculatorAvailability
 In order to calculate MTBF and Availability
 As someone who struggles with math
 I want to be able to use my calculator to do this

@Availability
Scenario: Calculating MTBF
  Given I have a calculator
  When I have entered 100 and 5 into the calculator and press MTBF
  Then the MTBF result should be 20

@Availability
Scenario: Calculating Availability
  Given I have a calculator
  When I have entered 100 and 2 into the calculator and press Availability
  Then the Availability result should be 98%

@Availability
Scenario: Calculating MTBF with no failures
  Given I have a calculator
  When I have entered 100 and 0 into the calculator and press MTBF
  Then the MTBF result should be Infinity

@Availability
Scenario: Calculating MTBF with more failures
  Given I have a calculator
  When I have entered 1000 and 50 into the calculator and press MTBF
  Then the MTBF result should be 20

@Availability
Scenario: Calculating Availability with zero downtime
  Given I have a calculator
  When I have entered 100 and 0 into the calculator and press Availability
  Then the Availability result should be 100%
