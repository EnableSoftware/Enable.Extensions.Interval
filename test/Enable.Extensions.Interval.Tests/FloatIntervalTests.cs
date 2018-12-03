using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class FloatIntervalTests
    {
        [Fact]
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = float.MinValue;
            var upperBound = float.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<float>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(0f, 0f, 0f)]
        [InlineData(-1f, 1f, -1f)]
        [InlineData(-1f, 1f, 0f)]
        [InlineData(-1f, 1f, 1f)]
        public void ReturnsTrueIfValueInInterval(
            float lowerBound,
            float upperBound,
            float valueToTest)
        {
            // Arrange
            var sut = new Interval<float>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1f, 1f, -2f)]
        [InlineData(-1f, 1f, 2f)]
        public void ReturnsFalseIfValueOutOfInterval(
            float lowerBound,
            float upperBound,
            float valueToTest)
        {
            // Arrange
            var sut = new Interval<float>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
