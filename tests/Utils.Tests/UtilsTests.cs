using FluentAssertions;
using WorkshopPractice.Utils;
using Xunit;

namespace WorkshopPractice.Utils.Tests;

/// <summary>
/// Sparse test suite. Most utility methods are not covered.
/// TODO Workshop: extend coverage and let OpenCode help.
/// </summary>
public class UtilsTests
{
    [Fact]
    public void Capitalize_Should_Capitalize_First_Letter()
    {
        Utils.Capitalize("hello").Should().Be("Hello");
    }

    [Fact]
    public void Capitalize_Should_Return_Empty_For_Null()
    {
        Utils.Capitalize(null).Should().Be(string.Empty);
    }

    // TODO Workshop:
    // - IsPalindrome: empty string, single char, mixed case, with punctuation
    // - FindMax: max at last position (this catches the off-by-one bug),
    //            single element, empty list, null
    // - ParseJson<T>: malformed JSON, empty string, valid JSON
    // - RemoveDuplicates: integers, strings, custom records
    // - ValidateEmail: missing @, multiple @, no domain, invalid TLD
    // - CalculateAge: birthday today, birthday tomorrow, birthday yesterday, leap year
}
