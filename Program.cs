using System.Text.RegularExpressions;
using static System.Console;

partial class Program
{
    static void Main()
    {
        string content, filePath;
        // Read the entire contents of the file
        (filePath, content) = FileScanner();

        // Print the maximum palindrome
        (var length, var maxPalindrome) = MaximumPalindrome(content);
        WriteLine($"The longest palindrome '{maxPalindrome}' has {length} characters");

        // Count the vocals
        var newContent = Process(content);

        // Write the new content to the file
        File.WriteAllText($"{filePath}.output.txt", newContent);

        // Print the results
        WriteLine($"The file has the following content:\n{newContent}");
    }

    private static string Process(string content)
    {
        content = ProcessRegex(RegexA(), content);
        content = ProcessRegex(RegexE(), content);
        content = ProcessRegex(RegexI(), content);
        content = ProcessRegex(RegexO(), content);
        content = ProcessRegex(RegexU(), content);

        return content;
    }

    private static string ProcessRegex(Regex regex, string content)
    {
        var matches = regex.Matches(content);
        var count = matches.Count;
        WriteLine($"The file has {count} '{regex}' characters");
        var lastMatch = matches[^1].Index;
        content = content.Remove(lastMatch, 1).Insert(lastMatch, count.ToString());
        return content;
    }

    private static (string, string) FileScanner()
    {
        string? filePath;

        // Prompt the user to enter file path
        do {
            WriteLine("Enter the file path to analize:");
            filePath = ReadLine();
        } while (string.IsNullOrEmpty(filePath));

        // Read the entire contents of the file
        string content = File.ReadAllText(filePath);

        return (filePath, content);
    }

    private static bool IsPalindrome(string content)
    {
        content = content.ToLower();

        for (int i = 0; i < content.Length; i++) {
            if (content[i] != content[content.Length - i - 1]) {
                return false;
            }
        }

        return true;
    }

    private static (int, string) MaximumPalindrome(string content)
    {
        var words = content.Split(' ');
        var palindormes = words.Where(IsPalindrome);

        var (res, maxPalindrome) = palindormes.Aggregate((0, ""),
            (acc, word) => word.Length > acc.Item1 ? (word.Length, word) : acc
        );

        return (res, maxPalindrome);
    }

    [GeneratedRegex("[aA]")]
    private static partial Regex RegexA();

    [GeneratedRegex("[eE]")]
    private static partial Regex RegexE();

    [GeneratedRegex("[iI]")]
    private static partial Regex RegexI();

    [GeneratedRegex("[oO]")]
    private static partial Regex RegexO();

    [GeneratedRegex("[uU]")]
    private static partial Regex RegexU();
}
