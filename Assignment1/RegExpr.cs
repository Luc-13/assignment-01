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

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}