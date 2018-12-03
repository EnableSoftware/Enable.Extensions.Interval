using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class UnsignedLongIntervalTests
    {
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = ulong.MinValue;
            var upperBound = ulong.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<ulong>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(0ul, 0ul, 0ul)]
        [InlineData(0ul, 2ul, 0ul)]
        [InlineData(0ul, 2ul, 1ul)]
        [InlineData(0ul, 2ul, 2ul)]
        public void ReturnsTrueIfValueInInterval(
            ulong lowerBound,
            ulong upperBound,
            ulong valueToTest)
        {
            // Arrange
            var sut = new Interval<ulong>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(1ul, 3ul, 0ul)]
        [InlineData(1ul, 3ul, 4ul)]
        public void ReturnsFalseIfValueOutOfInterval(
            ulong lowerBound,
            ulong upperBound,
            ulong valueToTest)
        {
            // Arrange
            var sut = new Interval<ulong>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
