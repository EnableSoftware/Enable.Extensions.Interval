using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class CharIntervalTests
    {
        [Fact]
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = char.MinValue;
            var upperBound = char.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<char>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData('a', 'a', 'a')]
        [InlineData('a', 'c', 'a')]
        [InlineData('a', 'c', 'b')]
        [InlineData('a', 'c', 'c')]
        public void ReturnsTrueIfValueInInterval(
            char lowerBound,
            char upperBound,
            char valueToTest)
        {
            // Arrange
            var sut = new Interval<char>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData('b', 'd', 'a')]
        [InlineData('b', 'd', 'e')]
        public void ReturnsFalseIfValueOutOfInterval(
            char lowerBound,
            char upperBound,
            char valueToTest)
        {
            // Arrange
            var sut = new Interval<char>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
