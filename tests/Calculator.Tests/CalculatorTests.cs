using FluentAssertions;
using WorkshopPractice.Calculator;
using Xunit;

namespace WorkshopPractice.Calculator.Tests;

/// <summary>
/// Test suite for Calculator. Calculator.cs is intentionally clean — it serves as a
/// reference for "what good looks like". Workshop participants should:
///   1. Extend coverage to Power, Sqrt (incl. negative), Percentage, Factorial.
///   2. Practice using a coding agent to generate xUnit tests with FluentAssertions.
/// The intentional bugs live in Utils.cs (see Utils.Tests for the bug-hunt exercise).
/// </summary>
public class CalculatorTests
{
    private readonly Calculator _calc = new();

    [Fact]
    public void Add_Should_Return_Sum()
    {
        _calc.Add(2, 3).Should().Be(5);
    }

    [Fact]
    public void Subtract_Should_Return_Difference()
    {
        _calc.Subtract(5, 3).Should().Be(2);
    }

    [Fact]
    public void Multiply_Should_Return_Product()
    {
        _calc.Multiply(4, 3).Should().Be(12);
    }

    [Fact]
    public void Divide_Should_Return_Quotient()
    {
        _calc.Divide(10, 2).Should().Be(5);
    }

    [Fact]
    public void Divide_By_Zero_Should_Throw()
    {
        Action act = () => _calc.Divide(10, 0);

        act.Should().Throw<DivideByZeroException>();
    }

    // TODO Workshop: Extend coverage to Power, Sqrt (incl. negative), Percentage, Factorial.
    // Note: Calculator.cs has no known bugs — for the bug-hunt exercise, look at Utils.cs.
}
