using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class LongIntervalTests
    {
        [Fact]
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = long.MinValue;
            var upperBound = long.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<long>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(0L, 0L, 0L)]
        [InlineData(-1L, 1L, -1L)]
        [InlineData(-1L, 1L, 0L)]
        [InlineData(-1L, 1L, 1L)]
        public void ReturnsTrueIfValueInInterval(
            long lowerBound,
            long upperBound,
            long valueToTest)
        {
            // Arrange
            var sut = new Interval<long>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1L, 1L, -2L)]
        [InlineData(-1L, 1L, 2L)]
        public void ReturnsFalseIfValueOutOfInterval(
            long lowerBound,
            long upperBound,
            long valueToTest)
        {
            // Arrange
            var sut = new Interval<long>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
