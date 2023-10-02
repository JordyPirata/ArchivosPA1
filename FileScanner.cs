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
            string? filePath = string.Empty;
            
            // Prompt the user to enter file path
            try
            {
                WriteLine("Enter the file path to analize:");
                filePath = ReadLine() ?? string.Empty;
            }
            catch (Exception e)
            {
                WriteLine($"The file path is not valid: {e}");
                Environment.Exit(1);
            }
            finally 
            { 
                while (string.IsNullOrEmpty(filePath))
                {
                    WriteLine("Enter the file path to analize:");
                    filePath = ReadLine() ?? string.Empty;
                }
            }

            // Read the entire contents of the file
            string? content = string.Empty;
            try
            {
                content = File.ReadAllText(filePath ?? throw new ArgumentNullException(nameof(filePath)));
            }
            catch(FileNotFoundException)
            {
                WriteLine($"The file content in the path {filePath} not found:");
                Environment.Exit(1);
            }
            catch (ArgumentNullException)
            {
                WriteLine($"The file content in the path {filePath} is null:");
                Environment.Exit(1);
            }catch(UnauthorizedAccessException)
            {
                WriteLine($"The file content in the path {filePath} is not accessible:");
                Environment.Exit(1);
                
            }catch(DirectoryNotFoundException)
            {
                WriteLine($"The file content in the path {filePath} is not found:");
                Environment.Exit(1);
                
            }catch(PathTooLongException){
                WriteLine($"The file content in the path {filePath} is too long:");
                Environment.Exit(1);
            }catch(Exception e){
                WriteLine($"Something went wrong: {e}");
                Environment.Exit(1);
            }

            return (content,filePath);
        }
    }
}