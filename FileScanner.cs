using System.IO.Pipes;
using System.Net.Mail;

namespace Archivos
{
    public class FileScanner
    {
        //set the content and the file path
        public static void SetContent(out string content, out string filePath)
        {
            // Read the entire contents of the file
            (content, filePath) = Scanner();
        }

        // Prompt the user to enter file path 
        private static (string,string) Scanner()
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

            return (content,filePath);
        }
    }
}