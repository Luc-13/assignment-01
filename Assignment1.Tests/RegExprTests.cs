namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;

public class RegExprTests
{
    [Fact]
    public void SplitLine_Empty()
    {
        // Arrange
        var empty = Enumerable.Empty<string>();

        // Act
        var actual = Assignment1.RegExpr.SplitLine(empty);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void SplitLine_Single()
    {
        // Arrange
        var single = new[] { "Hello, World!" };

        // Act
        var actual = Assignment1.RegExpr.SplitLine(single);

        // Assert
        actual.Should().Equal("Hello", "World");
    }

    [Fact]
    public void SplitLine_Multiple()
    {
        // Arrange
        var multiple = new[] { "Hello, World!", "Hello, Test!" };

        // Act
        var actual = Assignment1.RegExpr.SplitLine(multiple);

        // Assert
        actual.Should().Equal("Hello", "World", "Hello", "Test");
    }

    [Fact]
    public void Resolution_Empty()
    {
        // Arrange
        var empty = "";

        // Act
        var actual = Assignment1.RegExpr.Resolution(empty);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void Resolution_Single()
    {
        // Arrange
        var single = "1920x1080";

        // Act
        var actual = Assignment1.RegExpr.Resolution(single);

        // Assert
        actual.Should().Equal((1920, 1080));
    }

    [Fact]
    public void Resolution_Multiple()
    {
        // Arrange
        var multiple = "1920x1080, 1024x768, 800x600, 640x480, 320x200, 320x240, 800x600, 1280x960";

        // Act
        var actual = Assignment1.RegExpr.Resolution(multiple);

        // Assert
        actual.Should().Equal(
            (1920, 1080),
            (1024, 768),
            (800, 600),
            (640, 480),
            (320, 200),
            (320, 240),
            (800, 600),
            (1280, 960));
    }

    [Fact]
    public void InnerText_Empty()
    {
        // Arrange
        var html = "";
        var tag = "a";

        // Act
        var actual = Assignment1.RegExpr.InnerText(html, tag);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void InnerText_Single()
    {
        // Arrange
        var html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        var tag = "a";

        // Act
        var actual = Assignment1.RegExpr.InnerText(html, tag);

        // Assert
        actual.Should().Equal("theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings");
    }

}