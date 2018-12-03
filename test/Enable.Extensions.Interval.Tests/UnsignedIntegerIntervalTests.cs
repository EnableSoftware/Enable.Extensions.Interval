using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class UnsignedIntegerIntervalTests
    {
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = uint.MinValue;
            var upperBound = uint.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<uint>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(0, 2, 1)]
        [InlineData(0, 2, 2)]
        public void ReturnsTrueIfValueInInterval(
            uint lowerBound,
            uint upperBound,
            uint valueToTest)
        {
            // Arrange
            var sut = new Interval<uint>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(1, 3, 0)]
        [InlineData(1, 3, 4)]
        public void ReturnsFalseIfValueOutOfInterval(
            uint lowerBound,
            uint upperBound,
            uint valueToTest)
        {
            // Arrange
            var sut = new Interval<uint>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
