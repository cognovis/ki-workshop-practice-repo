namespace WorkshopPractice.Calculator;

/// <summary>
/// Calculator for workshop exercises.
/// </summary>
public class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }

        return a / b;
    }

    public double Power(double baseValue, double exponent)
    {
        return Math.Pow(baseValue, exponent);
    }

    public double Sqrt(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Cannot calculate square root of negative number", nameof(value));
        }
        return Math.Sqrt(value);
    }

    public double Percentage(double value, double percent)
    {
        return value * percent / 100;
    }

    public long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Factorial not defined for negative numbers", nameof(n));
        }
        if (n == 0 || n == 1)
        {
            return 1;
        }
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
