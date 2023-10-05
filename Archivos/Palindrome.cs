using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archivos
{
    public class Palindrome
    {
        // Check if the word is a palindrome
        public static bool IsPalindrome(string content)
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
        public static (int, string) MaximumPalindrome(ref string content)
        {
            var words = content.Split(' ');
            var palindormes = words.Where(IsPalindrome);

            var (res, maxPalindrome) = palindormes.Aggregate((0, ""), (acc, word) =>
            {
                return word.Length > acc.Item1 ? (word.Length, word) : acc;
            });

            return (res, maxPalindrome);
        }
    }
}