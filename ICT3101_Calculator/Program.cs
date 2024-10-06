class Program
{
    static void Main(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        bool endApp = false;
        Calculator _calculator = new Calculator();
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
        while (!endApp)
        {
            // Declare variables and set to empty.
            string numInput1 = "";
            string numInput2 = "";
            string numInput3 = ""; // Third input for Musa and SSI/Defect Density model
            double result = 0;

            // Ask the user to type the first number.
            Console.Write("Type the first number (or radius for a circle or uptime for availability): ");
            numInput1 = Console.ReadLine();
            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            // Ask the user to type the second number if applicable.
            Console.Write("Type the second number (if applicable, or 0 for single-input operations like Factorial): ");
            numInput2 = Console.ReadLine();
            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            // Ask the user to type a third number if using Musa, SSI, or Defect Density functions.
            Console.Write("Type the third number (if applicable for Musa model or SSI/Defect Density): ");
            numInput3 = Console.ReadLine();
            double cleanNum3 = 0;
            while (!double.TryParse(numInput3, out cleanNum3))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput3 = Console.ReadLine();
            }

            // Ask the user to choose an operator.
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\tb - Add Binary (concatenate)");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tf - Factorial of the first number");
            Console.WriteLine("\tt - Area of a Triangle");
            Console.WriteLine("\tc - Area of a Circle");
            Console.WriteLine("\tuA - Unknown Function A");
            Console.WriteLine("\tuB - Unknown Function B");
            Console.WriteLine("\tmtbf - Calculate MTBF");
            Console.WriteLine("\tavail - Calculate Availability");
            Console.WriteLine("\tfailure - Calculate Failure Intensity (λ(τ))");
            Console.WriteLine("\texpected - Calculate Expected Number of Failures (μ(τ))");
            Console.WriteLine("\tlogf - Calculate Log Musa Failure Intensity");
            Console.WriteLine("\tloge - Calculate Log Musa Expected Number of Failures");
            Console.WriteLine("\tssi - Calculate Shipped Source Instructions (SSI)");
            Console.WriteLine("\tdd - Calculate Defect Density for a system");
            Console.Write("Your option? ");
            string op = Console.ReadLine();

            try
            {
                switch (op)
                {
                    case "f":
                        // Factorial operation
                        result = _calculator.Factorial((int)cleanNum1);
                        break;
                    case "t":
                        // Area of Triangle operation
                        result = _calculator.AreaOfTriangle(cleanNum1, cleanNum2);
                        break;
                    case "c":
                        // Area of Circle operation
                        result = _calculator.AreaOfCircle(cleanNum1);
                        break;
                    case "uA":
                        // Unknown Function A
                        result = _calculator.UnknownFunctionA(cleanNum1, cleanNum2);
                        break;
                    case "uB":
                        // Unknown Function B
                        result = _calculator.UnknownFunctionB(cleanNum1, cleanNum2);
                        break;
                    case "mtbf":
                        // MTBF Calculation
                        result = _calculator.MTBF(cleanNum1, cleanNum2);
                        break;
                    case "avail":
                        // Availability Calculation
                        result = _calculator.Availability(cleanNum1, cleanNum2);
                        break;
                    case "failure":
                        // Musa Failure Intensity Calculation
                        Console.WriteLine($"Inputs: λ0 = {cleanNum1}, μ0 = {cleanNum2}, time = {cleanNum3}");
                        result = _calculator.CalculateFailureIntensity(cleanNum1, cleanNum2, cleanNum3);
                        break;
                    case "expected":
                        // Musa Expected Number of Failures Calculation
                        Console.WriteLine($"Inputs: λ0 = {cleanNum1}, μ0 = {cleanNum2}, time = {cleanNum3}");
                        result = _calculator.CalculateExpectedFailures(cleanNum1, cleanNum2, cleanNum3);
                        break;
                    case "logf":
                        // Musa Log Failure Intensity Calculation
                        Console.WriteLine($"Inputs: λ0 = {cleanNum1}, μ0 = {cleanNum2}, time = {cleanNum3}");
                        result = _calculator.CalculateLogMusaFailureIntensity(cleanNum1, cleanNum2, cleanNum3);
                        break;
                    case "loge":
                        // Musa Log Expected Number of Failures Calculation
                        Console.WriteLine($"Inputs: λ0 = {cleanNum1}, μ0 = {cleanNum2}, time = {cleanNum3}");
                        result = _calculator.CalculateLogMusaExpectedFailures(cleanNum1, cleanNum2, cleanNum3);
                        break;
                    case "ssi":
                        // Ask for multiple releases if required
                        Console.WriteLine($"Inputs: First release SSI = {cleanNum1}, Second release SSI = {cleanNum2} (and beyond if necessary)");
                        result = _calculator.CalculateShippedSourceInstructions(cleanNum1, cleanNum2);
                        break;
                    case "dd":
                        // Defect Density Calculation
                        Console.WriteLine($"Inputs: Defects = {cleanNum1}, Size (KLOC) = {cleanNum2}");
                        result = _calculator.CalculateDefectDensity(cleanNum1, cleanNum2);
                        break;
                    default:
                        // Standard operations: Add, Add Binary, Subtract, Multiply, Divide
                        result = _calculator.DoOperation(cleanNum1, cleanNum2, op);
                        break;
                }

                // Check if the result is NaN, which indicates an invalid operation.
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else
                {
                    // Check if the operation is Availability or Defect Density, then format as percentage
                    if (op == "avail" || op == "dd")
                    {
                        Console.WriteLine("Your result: {0:0.##}%\n", result);
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Oh no! An exception occurred: " + e.Message + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("An unexpected error occurred: " + e.Message + "\n");
            }

            Console.WriteLine("------------------------\n");

            // Ask the user whether to continue or quit.
            Console.Write("Press 'q' and Enter to quit the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine().ToLower() == "q")
            {
                endApp = true;
            }

            Console.WriteLine("\n"); // Friendly linespacing.
        }
    }
}
