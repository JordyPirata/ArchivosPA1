// See https://aka.ms/new-console-template for more information
using System.IO;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    struct Vocals
    {
        public int a;
        public int e;
        public int i;
        public int o;
        public int u;
    }
    static void Main()
    {
        string content = string.Empty; 
        // Read the entire contents of the file
        content = FileScanner();
        // Count the vocals
        Vocals vocals = new Vocals();
        vocals = CountVocals(content);

        //Substitute the last vowel with an "@"
        content = Regex.Replace(content, "a", "@");

        //WriteLine(content);
        WriteLine($"The file has the following content:\n{content}");

        // Print the results
        WriteLine($"The file has a vocal 'a' {vocals.a} times");
        WriteLine($"The file has a vocal 'e' {vocals.e} times");
        WriteLine($"The file has a vocal 'i' {vocals.i} times");
        WriteLine($"The file has a vocal 'o' {vocals.o} times");
        WriteLine($"The file has a vocal 'u' {vocals.u} times");
    }

    static Vocals CountVocals(string content)
    {
        Vocals vocals = new Vocals();
        // Count the vocals
        vocals.a = Regex.Matches(content, "a").Count;
        vocals.e = Regex.Matches(content, "e").Count;
        vocals.i = Regex.Matches(content, "i").Count;
        vocals.o = Regex.Matches(content, "o").Count;
        vocals.u = Regex.Matches(content, "u").Count;

        return vocals;
    }
    static string FileScanner()
    {
        string? filePath = null;

        // Prompt the user to enter file path
        do
        {
            WriteLine("Enter the file path to analize:");
            filePath = ReadLine();
        } while (string.IsNullOrEmpty(filePath));

        // Read the entire contents of the file
        string content = File.ReadAllText(filePath);

        return content;
    }
}
