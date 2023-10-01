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
        (var length, var maxPalindrome) = MaximumPalindrome(ref content);
        WriteLine($"The longest palindrome '{maxPalindrome}' has {length} characters");

        // Count the vocals
        Process(ref content);

        // Write the new content to the file
        File.WriteAllText(filePath, content);

        // Print the results
        WriteLine($"The file has the following content:\n{content}");
    }

    private static void Process(ref string content)
    {
        ProcessRegex(RegexA(), ref content);
        ProcessRegex(RegexE(), ref content);
        ProcessRegex(RegexI(), ref content);
        ProcessRegex(RegexO(), ref content);
        ProcessRegex(RegexU(), ref content);
    }
    // Process the regex and replace the last match with the count
    private static void ProcessRegex(Regex regex, ref string content)
    {
        var matches = regex.Matches(content);
        var count = matches.Count;
        WriteLine($"The file has {count} '{regex}' characters");
        var lastMatch = matches[^1].Index;
        content = content.Remove(lastMatch, 1).Insert(lastMatch, count.ToString());
    }
    // Prompt the user to enter file path
    private static (string, string) FileScanner()
    {
        string? filePath;

        // Prompt the user to enter file path
        do
        {
            WriteLine("Enter the file path to analize:");
            filePath = ReadLine();
        } while (string.IsNullOrEmpty(filePath));

        // Read the entire contents of the file
        string content = File.ReadAllText(filePath);

        return (filePath, content);
    }
    // Check if the word is a palindrome
    private static bool IsPalindrome(string content)
    {
        content = content.ToLower();

        for (int i = 0; i < content.Length; i++)
        {
            if (content[i] != content[content.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
    // Find the maximum palindrome
    private static (int, string) MaximumPalindrome(ref string content)
    {
        var words = content.Split(' ');
        var palindormes = words.Where(IsPalindrome);

        var (res, maxPalindrome) = palindormes.Aggregate((0, ""), (acc, word) =>
        {
            return word.Length > acc.Item1 ? (word.Length, word) : acc;
        });

        return (res, maxPalindrome);
    }

    private static Regex RegexA() => new Regex("[aA]");
    private static Regex RegexE() => new Regex("[eE]");
    private static Regex RegexI() => new Regex("[iI]");
    private static Regex RegexO() => new Regex("[oO]");
    private static Regex RegexU() => new Regex("[uU]");
}
