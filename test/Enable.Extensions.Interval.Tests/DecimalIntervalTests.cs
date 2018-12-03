using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class DecimalIntervalTests
    {
        public static TheoryData<decimal, decimal, decimal> ValuesInRangeTests => new TheoryData<decimal, decimal, decimal>
        {
            { 0m, 0m, 0m },
            { -1m, 1m, -1m },
            { -1m, 1m, 0m },
            { -1m, 1m, 1m }
        };

        public static TheoryData<decimal, decimal, decimal> ValuesOutOfRangeTests => new TheoryData<decimal, decimal, decimal>
        {
            { -1m, 1m, -2m },
            { -1m, 1m, 2m }
        };

        [Fact]
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = decimal.MinValue;
            var upperBound = decimal.MaxValue;

            // Act
            var exception = Record.Exception(() => new Interval<decimal>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [MemberData(nameof(ValuesInRangeTests))]
        public void ReturnsTrueIfValueInInterval(
            decimal lowerBound,
            decimal upperBound,
            decimal valueToTest)
        {
            // Arrange
            var sut = new Interval<decimal>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(ValuesOutOfRangeTests))]
        public void ReturnsFalseIfValueOutOfInterval(
            decimal lowerBound,
            decimal upperBound,
            decimal valueToTest)
        {
            // Arrange
            var sut = new Interval<decimal>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
