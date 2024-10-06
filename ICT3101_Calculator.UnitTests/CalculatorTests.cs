namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        //no13
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            // Act
            double result = _calculator.Subtract(10, 5);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
        {
            // Act
            double result = _calculator.Multiply(10, 2);
            // Assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Divide_WhenDividingTwoNumbers_ResultEqualToQuotient()
        {
            //Act
            double result = _calculator.Divide(10, 2);
            //Assert
            Assert.That(result, Is.EqualTo(5));
        }


        [Test]
        [TestCase(0, 0, true)]
        [TestCase(0, 10, false)]
        [TestCase(10, 0, true)]
        public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b, bool shouldThrowException)
        {
            // Act & Assert
            if (shouldThrowException)
            {
                // Act & Assert for cases that should throw an exception
                Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
            }
            else
            {
                // Act for valid cases
                double result = _calculator.Divide(a, b);

                // Assert for cases that should return a result (0 / 10 = 0)
                Assert.That(result, Is.EqualTo(0));
            }
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(5, 120)]
        [TestCase(10, 3628800)]
        public void Factorial_WhenGivenValidInput_ReturnsCorrectResult(int input, double expectedResult)
        {
            // Act
            double result = _calculator.Factorial(input);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Factorial_WhenGivenNegativeInput_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.That(() => _calculator.Factorial(-1), Throws.ArgumentException);
        }

        //16
        [Test]
        [TestCase(10, 5, 25)]
        [TestCase(8, 4, 16)]
        [TestCase(0, 5, 0)]
        [TestCase(10, 0, 0)]
        public void AreaOfTriangle_WhenGivenHeightAndBase_ReturnsCorrectArea(double height, double length, double expectedResult)
        {
            // Act
            double result = _calculator.AreaOfTriangle(height, length);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //16b
        [Test]
        [TestCase(5, 78.54)]
        [TestCase(10, 314.16)]
        [TestCase(0, 0)]
        public void AreaOfCircle_WhenGivenRadius_ReturnsCorrectArea(double radius, double expectedResult)
        {
            // Act
            double result = _calculator.AreaOfCircle(radius);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.01)); // Allowing small precision errors
        }

        //17a
        [Test]
        public void UnknownFunctionA_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(60));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
        }

        //17b
        [Test]
        public void UnknownFunctionB_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
        }

    }
}