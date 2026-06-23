using System;

namespace api.Services
{
    public class CalculatorService
    {
        public double Add(double a, double b) => a + b;

        public double Subtract(double a, double b) => a - b;

        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            return a / b;
        }

        public double Power(double baseNum, double exponent) => Math.Pow(baseNum, exponent);

        public double SquareRoot(double number)
        {
            if (number < 0)
                throw new ArgumentException("Cannot take the square root of a negative number.");

            return Math.Sqrt(number);
        }
    }
}