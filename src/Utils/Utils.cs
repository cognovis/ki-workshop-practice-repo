using System.Text.Json;

namespace WorkshopPractice.Utils;

/// <summary>
/// Utility functions with various intentional issues for students to find and fix.
/// </summary>
public static class Utils
{
    // BUG: Empty strings return true (should return false?)
    public static bool IsPalindrome(string str)
    {
        var cleaned = new string(str.ToLowerInvariant()
            .Where(c => char.IsLetterOrDigit(c))
            .ToArray());
        var reversed = new string(cleaned.Reverse().ToArray());
        return cleaned == reversed;
    }

    // BUG: Off-by-one error in loop — last element is never compared
    public static int? FindMax(IList<int>? numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            return null;
        }
        int max = numbers[0];
        for (int i = 0; i < numbers.Count - 1; i++)  // BUG: should be < numbers.Count
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }

    // Missing error handling — throws on malformed JSON instead of returning a sensible default
    public static T? ParseJson<T>(string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString);  // No try/catch
    }

    // Inefficient implementation — O(n²), could be O(n) with HashSet
    public static List<T> RemoveDuplicates<T>(IList<T> items)
    {
        var result = new List<T>();
        for (int i = 0; i < items.Count; i++)
        {
            bool isDuplicate = false;
            for (int j = 0; j < result.Count; j++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], result[j]))
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                result.Add(items[i]);
            }
        }
        return result;
    }

    // Incomplete — only checks for "@", not a real validation
    public static bool ValidateEmail(string email)
    {
        // TODO: Implement proper email validation
        return email.Contains('@');
    }

    // Working function (no bugs)
    public static string Capitalize(string? str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }
        return char.ToUpperInvariant(str[0]) + str[1..].ToLowerInvariant();
    }

    // BUG: Doesn't account for the fact that the birthday may not have happened yet this year
    public static int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        // BUG: should subtract 1 if birthday hasn't happened yet this year
        return age;
    }
}
