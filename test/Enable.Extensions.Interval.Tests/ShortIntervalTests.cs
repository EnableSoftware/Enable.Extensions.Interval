using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class ShortIntervalTests
    {
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = short.MinValue;
            var upperBound = short.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<short>(upperBound, lowerBound));

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
            short lowerBound,
            short upperBound,
            short valueToTest)
        {
            // Arrange
            var sut = new Interval<short>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1, 1, -2)]
        [InlineData(-1, 1, 2)]
        public void ReturnsFalseIfValueOutOfInterval(
            short lowerBound,
            short upperBound,
            short valueToTest)
        {
            // Arrange
            var sut = new Interval<short>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
