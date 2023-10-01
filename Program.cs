using Archivos;
partial class Program
{
    static void Main()
    {
        // Read the entire contents of the file
        FileScanner.SetContent(out var content, out var filePath);

        // Print the maximum palindrome
        var (res, maxPalindrome) = Palindrome.MaximumPalindrome(ref content);
        WriteLine($"The maximum palindrome is '{maxPalindrome}' with {res} characters");
        
        // Count the vocals
        VocalCounter.CountVocals(ref content);

        // Write the new content to the file
        File.WriteAllText(filePath, content);

        // Print the results
        WriteLine($"The file has the following content:\n{content}");
    }
}
