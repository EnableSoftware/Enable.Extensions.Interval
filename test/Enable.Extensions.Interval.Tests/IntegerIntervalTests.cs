using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class IntegerIntervalTests
    {
        [Fact]
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = int.MinValue;
            var upperBound = int.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<int>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-1, 1, -1)]
        [InlineData(-1, 1, 0)]
        [InlineData(-1, 1, 1)]
        public void ReturnsTrueIfValueInInterval(
            int lowerBound,
            int upperBound,
            int valueToTest)
        {
            // Arrange
            var sut = new Interval<int>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1, 1, -2)]
        [InlineData(-1, 1, 2)]
        public void ReturnsFalseIfValueOutOfInterval(
            int lowerBound,
            int upperBound,
            int valueToTest)
        {
            // Arrange
            var sut = new Interval<int>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
