using System;

namespace OOPCalculator
{
    public class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            try
            {
                if (b == 0)
                    throw new DivideByZeroException("Cannot divide by zero!");
                return a / b;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
        }

        public double Percentage(double total, double percent)
        {
            try
            {
                if (percent < 0 || percent > 100)
                    throw new ArgumentException("Percentage must be between 0 and 100");
                return (total * percent) / 100;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public string EvenOrOdd(int number)
        {
            try
            {
                return number % 2 == 0 ? "Even" : "Odd";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error determining even/odd: {ex.Message}");
            }
        }

        public double Power(double baseNumber, double exponent)
        {
            try
            {
                return Math.Pow(baseNumber, exponent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating power: {ex.Message}");
            }
        }

        public double SquareRoot(double number)
        {
            try
            {
                if (number < 0)
                    throw new ArgumentException("Cannot calculate square root of negative number");
                return Math.Sqrt(number);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }

    public class CalculatorUI
    {
        private readonly Calculator _calculator;

        public CalculatorUI()
        {
            _calculator = new Calculator();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the OOP Calculator!");
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1 - Addition (+)");
            Console.WriteLine("2 - Subtraction (-)");
            Console.WriteLine("3 - Multiplication (*)");
            Console.WriteLine("4 - Division (/)");
            Console.WriteLine("5 - Percentage (%)");
            Console.WriteLine("6 - Even or Odd");
            Console.WriteLine("7 - Power (x^y)");
            Console.WriteLine("8 - Square Root");
            Console.WriteLine("9 - Exit");
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    DisplayMenu();
                    int choice = GetValidChoice();

                    if (choice == 9)
                    {
                        Console.WriteLine("Thank you for using the calculator!");
                        break;
                    }

                    ProcessOperation(choice);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        private int GetValidChoice()
        {
            while (true)
            {
                try
                {
                    Console.Write("\nEnter your choice (1-9): ");
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1-9.");
                        continue;
                    }

                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 9)
                    {
                        return choice;
                    }
                    
                    Console.WriteLine("Invalid input. Please enter a number between 1-9.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading input: {ex.Message}");
                }
            }
        }

        private void ProcessOperation(int choice)
        {
            try
            {
                switch (choice)
                {
                    case 1:
                        PerformAddition();
                        break;
                    case 2:
                        PerformSubtraction();
                        break;
                    case 3:
                        PerformMultiplication();
                        break;
                    case 4:
                        PerformDivision();
                        break;
                    case 5:
                        PerformPercentage();
                        break;
                    case 6:
                        PerformEvenOrOdd();
                        break;
                    case 7:
                        PerformPower();
                        break;
                    case 8:
                        PerformSquareRoot();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select between 1-9.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numbers only.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        private void PerformAddition()
        {
            double a = GetDouble("Enter first number: ");
            double b = GetDouble("Enter second number: ");
            double result = _calculator.Add(a, b);
            Console.WriteLine($"Result: {a} + {b} = {result}");
        }

        private void PerformSubtraction()
        {
            double a = GetDouble("Enter first number: ");
            double b = GetDouble("Enter second number: ");
            double result = _calculator.Subtract(a, b);
            Console.WriteLine($"Result: {a} - {b} = {result}");
        }

        private void PerformMultiplication()
        {
            double a = GetDouble("Enter first number: ");
            double b = GetDouble("Enter second number: ");
            double result = _calculator.Multiply(a, b);
            Console.WriteLine($"Result: {a} * {b} = {result}");
        }

        private void PerformDivision()
        {
            double a = GetDouble("Enter dividend: ");
            double b = GetDouble("Enter divisor: ");
            double result = _calculator.Divide(a, b);
            Console.WriteLine($"Result: {a} / {b} = {result}");
        }

        private void PerformPercentage()
        {
            double total = GetDouble("Enter total value: ");
            double percent = GetDouble("Enter percentage: ");
            double result = _calculator.Percentage(total, percent);
            Console.WriteLine($"Result: {percent}% of {total} = {result}");
        }

        private void PerformEvenOrOdd()
        {
            int number = GetInt("Enter a number: ");
            string result = _calculator.EvenOrOdd(number);
            Console.WriteLine($"Result: {number} is {result}");
        }

        private void PerformPower()
        {
            double baseNumber = GetDouble("Enter base number: ");
            double exponent = GetDouble("Enter exponent: ");
            double result = _calculator.Power(baseNumber, exponent);
            Console.WriteLine($"Result: {baseNumber} ^ {exponent} = {result}");
        }

        private void PerformSquareRoot()
        {
            double number = GetDouble("Enter number: ");
            double result = _calculator.SquareRoot(number);
            Console.WriteLine($"Result: Square root of {number} = {result}");
        }

        private double GetDouble(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    if (double.TryParse(input, out double result))
                    {
                        return result;
                    }
                    
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading input: {ex.Message}");
                }
            }
        }

        private int GetInt(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        continue;
                    }

                    if (int.TryParse(input, out int result))
                    {
                        return result;
                    }
                    
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading input: {ex.Message}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CalculatorUI calculatorUI = new CalculatorUI();
                calculatorUI.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical error: {ex.Message}");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}