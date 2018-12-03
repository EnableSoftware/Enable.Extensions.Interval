using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class DoubleIntervalTests
    {
        [Fact]
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = double.MinValue;
            var upperBound = double.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<double>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(0d, 0d, 0d)]
        [InlineData(-1d, 1d, -1d)]
        [InlineData(-1d, 1d, 0d)]
        [InlineData(-1d, 1d, 1d)]
        public void ReturnsTrueIfValueInInterval(
            double lowerBound,
            double upperBound,
            double valueToTest)
        {
            // Arrange
            var sut = new Interval<double>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1d, 1d, -2d)]
        [InlineData(-1d, 1d, 2d)]
        public void ReturnsFalseIfValueOutOfInterval(
            double lowerBound,
            double upperBound,
            double valueToTest)
        {
            // Arrange
            var sut = new Interval<double>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
