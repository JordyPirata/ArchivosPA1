using System.Text.RegularExpressions;


namespace Archivos
{
    public class VocalCounter
    {
        // Count the vocals
        public static void CountVocals(ref string content){
            Vocalreplace(RegexA(), ref content);
            Vocalreplace(RegexE(), ref content);
            Vocalreplace(RegexI(), ref content);
            Vocalreplace(RegexO(), ref content);
            Vocalreplace(RegexU(), ref content);
        }
        // Process the regex and replace the last match with the count
        private static void Vocalreplace(Regex regex, ref string content)
        {
            try{
                var matches = regex.Matches(content);
                var count = matches.Count;
                WriteLine($"The file has {count} '{regex}' characters");
                var lastMatch = matches[^1].Index;
                content = content.Remove(lastMatch, 1).Insert(lastMatch, count.ToString());
            }catch(ArgumentOutOfRangeException){
                WriteLine($"The file has no '{regex}' characters");
            }
            
        }
        private static Regex RegexA() => new Regex("[aA]");
        private static Regex RegexE() => new Regex("[eE]");
        private static Regex RegexI() => new Regex("[iI]");
        private static Regex RegexO() => new Regex("[oO]");
        private static Regex RegexU() => new Regex("[uU]");
    }
}