using System.Text;
using TechTalk.SpecFlow.CommonModels;

public class Calculator
{
    public Calculator() { }
    public double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value
                                    // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = Add(num1, num2);
                break;
            case "b":
                // Call binary addition
                result = AddB(num1, num2);
                break;
            case "s":
                result = Subtract(num1, num2);
                break;
            case "m":
                result = Multiply(num1, num2);
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                result = Divide(num1, num2);
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
    public double Add(double num1, double num2)
    {
        return (num1 + num2);
    }

    public double AddB(double num1, double num2)
    {
        // Convert numbers to strings
        string strNum1 = num1.ToString();
        string strNum2 = num2.ToString();

        // Check if the inputs are binary numbers
        bool isBinary1 = IsBinary(strNum1);
        bool isBinary2 = IsBinary(strNum2);

        if (isBinary1 && isBinary2)
        {
            // Perform binary string concatenation
            string result = strNum1 + strNum2;
            // Convert the result to decimal
            return ConvertBinaryStringToDecimal(result);
        }
        else
        {
            // For decimal addition
            return num1 + num2;
        }
    }

    private bool IsBinary(string value)
    {
        // Check if the string consists only of '0' and '1'
        return value.All(c => c == '0' || c == '1');
    }

    private double ConvertBinaryStringToDecimal(string binaryString)
    {
        // Convert the binary string to a decimal number
        if (string.IsNullOrEmpty(binaryString))
            return 0;
        return Convert.ToInt32(binaryString, 2);
    }



    public double Subtract(double num1, double num2)
    {
        return (num1 - num2);
    }
    public double Multiply(double num1, double num2)
    {
        return (num1 * num2);
    }
    public double Divide(double num1, double num2)
    {
        if (num1 == 0 && num2 == 0)
        {
            throw new ArgumentException("Both values are zero.");
        }
        else if (num2 == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }
        else
        {
            return (num1 / num2);
        }
    }

    public double Factorial(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException("Factorial is not defined for negative numbers.");
        }

        if (num == 0 || num == 1)
        {
            return 1;
        }

        double result = 1;
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }

        return result;
    }

    //16
    public double AreaOfTriangle(double height, double length)
    {
        return 0.5 * height * length;
    }

    //16b
    public double AreaOfCircle(double radius)
    {
        return Math.PI * Math.Pow(radius, 2);
    }

    //17a
    public double UnknownFunctionA(double num1, double num2)
    {
        if (num1 < 0 || num2 < 0)
        {
            throw new ArgumentException("Negative inputs are not allowed.");
        }

        if (num1 < num2)
        {
            throw new ArgumentException("The first number must be greater than or equal to the second number.");
        }

        double factorial = Factorial((int)num1);
        double difference = num1 - num2;

        if (difference == 0)
        {
            return factorial;
        }

        return factorial / difference;
    }


    //17b
    public double UnknownFunctionB(double n, double k)
    {
        if (n < 0 || k < 0)
        {
            throw new ArgumentException("n and k must be non-negative.");
        }

        if (n < k)
        {
            throw new ArgumentException("n must be greater than or equal to k.");
        }

        return Factorial((int)n) / (Factorial((int)k) * Factorial((int)n - (int)k));
    }


    //lab2.2 part 17
    public double MTBF(double totalTime, double failures)
    {
        return totalTime / failures;
    }
    public double Availability(double uptime, double downtime)
    {
        double totalTime = uptime + downtime;

        if (totalTime == 0) throw new ArgumentException("Total time cannot be zero.");

        // Round the result to 2 decimal places before returning
        return Math.Round((uptime / totalTime) * 100, 2);
    }


    //lab2.2 part 18
    // Basic Musa Failure Intensity (λ(τ))
    public double CalculateFailureIntensity(double lambda0, double mu0, double time)
    {
        // Formula: λ(τ) = λ0 * e^(-λ0 * τ / μ0)
        return lambda0 * Math.Exp(-(lambda0 * time) / mu0);
    }

    // Basic Musa Expected Number of Failures (μ(τ))
    public double CalculateExpectedFailures(double lambda0, double mu0, double time)
    {
        // Formula: μ(τ) = μ0 * (1 - e^(-λ0 * τ / μ0))
        double result =  mu0 * (1 - Math.Exp(-(lambda0 * time) / mu0));
        return Math.Round(result, 0);  // Round to nearest whole number
    }


    //lab2.3 part 23 and 24
    // Calculate Defect Density
    public double CalculateDefectDensity(double defects, double sourceLinesOfCode)
    {
        if (sourceLinesOfCode == 0) throw new ArgumentException("Source lines of code cannot be zero.");
        return defects / sourceLinesOfCode;
    }

    // Calculate Shipped Source Instructions
    public double CalculateShippedSourceInstructions(double firstRelease, double secondRelease)
    {
        return firstRelease + secondRelease;
    }

    // Musa Logarithmic Failure Intensity (λ(τ)) Formula
    public double CalculateLogMusaFailureIntensity(double lambda0, double v0, double time)
    {
        // λ(τ) = λ0 / (1 + (λ0 / v0) * τ)
        double denominator = 1 + (lambda0 * time) / v0;
        return lambda0 / denominator;
    }

    // Musa Logarithmic Expected Number of Failures (μ(τ)) Formula
    public double CalculateLogMusaExpectedFailures(double lambda0, double v0, double time)
    {
        // μ(τ) = v0 * ln(1 + (λ0 / v0) * τ)
        double logTerm = Math.Log(1 + (lambda0 * time) / v0);
        return v0 * logTerm;
    }



}