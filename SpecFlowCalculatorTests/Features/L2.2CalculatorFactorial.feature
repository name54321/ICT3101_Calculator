Feature: UsingCalculatorFactorial
  In order to calculate factorials
  As a math enthusiast
  I want to use my calculator to find factorials

  lab2.2 part 16
  @Factorial
  Scenario: Calculate normal factorial
    Given I have a calculator
    When I have entered 5 into the calculator and press factorial
    Then the factorial result should be 120

  @Factorial
  Scenario: Calculate factorial of zero
    Given I have a calculator
    When I have entered 0 into the calculator and press factorial
    Then the factorial result should be 1
