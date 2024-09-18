using System;
using System.Text.RegularExpressions;

namespace kotli_english.Services;

public class RegexService
{
    public string GetStringBetweenKeywords(string source, string front, string behind)
    {
        var pattern = $"({front})(?<g>.*)({behind})";

        var options = RegexOptions.IgnoreCase;

        if (Regex.IsMatch(source, pattern))
        {
            return Regex.Match(source, pattern, options).Groups["g"].Value;
        }
        else
        {
            return string.Empty;
        }
    }
}
