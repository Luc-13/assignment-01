namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            foreach (var word in Regex.Split(line, @"[^a-zA-Z0-9]+"))
            {
                if (word != "")
                {
                    yield return word;
                }
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {
        foreach (Match match in Regex.Matches(resolutions, @"(?<width>\d+)x(?<height>\d+)"))
        {
            yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        var outer = @"<(" + tag + @"*)\b[^>]*>(?<INNER>.*?)</\1>";
        var inner = @"</{0,1}\w*\b[^>]*>";

        foreach (Match outerMatch in Regex.Matches(html, outer))
        {
            foreach (var innerMatch in Regex.Split(outerMatch.Groups["INNER"].Value, inner))
            {
                yield return innerMatch;
            }
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        string pattern = @"<a(?=[^>]*(href=""(?<URL>[^""]*)"")){0,1}(?=[^>]*(title=""(?<TITLE>[^""]*)"")){0,1}[^>]*>(?(2)(?:[^<>]*)|)(?<TITLE>[^<>]*)</a>";

        foreach (Match urlmatch in Regex.Matches(html, pattern, RegexOptions.Multiline))
        {
            yield return (
                new Uri(urlmatch.Groups["URL"].Value),
                urlmatch.Groups["TITLE"].Captures[0].Value
            );
        }
    }
}