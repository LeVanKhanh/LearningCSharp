using System.Text.RegularExpressions;

namespace Common.Regrex
{
    public class Excluding
    {
        public bool ExcludeRegrexCharacters(string text)
        {
            var rx = new Regex(@"^([^$@~;'+=,<>|/\\:?&*""#\[\]])*$");
            bool isMatch = rx.IsMatch(text);
            return isMatch;
        }
    }
}
