namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;

public class IteratorsTests
{

    [Fact]
    public void Flatten_Empty()
    {
        // Arrange
        var empty = Enumerable.Empty<IEnumerable<int>>();

        // Act
        var actual = Assignment1.Iterators.Flatten(empty);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void Flatten_Single()
    {
        // Arrange
        var single = new[] { new[] { 1, 2, 3 } };

        // Act
        var actual = Assignment1.Iterators.Flatten(single);

        // Assert
        actual.Should().Equal(1, 2, 3);
    }

    [Fact]
    public void Flatten_Multiple()
    {
        // Arrange
        var multiple = new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } };

        // Act
        var actual = Assignment1.Iterators.Flatten(multiple);

        // Assert
        actual.Should().Equal(1, 2, 3, 4, 5, 6);
    }

    [Fact]
    public void Filter_Empty()
    {
        // Arrange
        var empty = Enumerable.Empty<int>();

        // Act
        var actual = Assignment1.Iterators.Filter(empty, _ => true);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void Filter_Single()
    {
        // Arrange
        var single = new[] { 1 };

        // Act
        var actual = Assignment1.Iterators.Filter(single, _ => true);

        // Assert
        actual.Should().Equal(1);
    }

    [Fact]
    public void Filter_Multiple()
    {
        // Arrange
        var multiple = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        var actual = Assignment1.Iterators.Filter(multiple, x => x % 2 == 0);

        // Assert
        actual.Should().Equal(2, 4, 6);
    }
}
