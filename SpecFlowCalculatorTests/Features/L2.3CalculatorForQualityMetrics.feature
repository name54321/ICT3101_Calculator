Feature: UsingCalculatorForQualityMetrics
  In order to track and measure software quality
  As a system quality engineer
  I want to calculate defect density and Shipped Source Instructions (SSI)

  //lab2.3 part 20
  User Story 1:
  As a system quality engineer, I want to calculate the defect density of the system so that 
  I can measure the quality of the software by understanding the ratio of defects to the system size.
  
  User Story 2:
  As a system quality engineer, I want to calculate the total number of Shipped Source Instructions (SSI) 
  in subsequent releases so that I can track system growth and stability across releases.

  @QualityMetrics
  Scenario: Calculating Defect Density
    Given I have a calculator
    When I enter 10 defects and 1000 source lines of code
    Then the Defect Density result should be 0.01

  @QualityMetrics
  Scenario: Calculating Shipped Source Instructions for successive releases
    Given I have a calculator
    When I enter 1000 shipped source instructions for the first release and 1200 for the second release
    Then the total Shipped Source Instructions for the second release should be 2200
