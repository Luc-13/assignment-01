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

}