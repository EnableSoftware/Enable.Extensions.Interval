using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class IntervalTests
    {
        [Fact]
        public void EqualsReturnsTrueWhenComparedToSelf()
        {
            // Arrange
            var interval = new Interval<int>(int.MinValue, int.MaxValue);

            // Act
            var result = interval.Equals(interval);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EqualsReturnsTrueForIntervalsWithSameBounds()
        {
            // Arrange
            var interval1 = new Interval<int>(int.MinValue, int.MaxValue);
            var interval2 = new Interval<int>(int.MinValue, int.MaxValue);

            // Act
            var result = interval1.Equals(interval2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EqualsReturnsFalseForIntervalsWithDifferentBounds()
        {
            // Arrange
            var interval1 = new Interval<int>(int.MinValue, 0);
            var interval2 = new Interval<int>(0, int.MaxValue);

            // Act
            var result = interval1.Equals(interval2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void EqualsOperatorReturnsTrueWhenComparedToSelf()
        {
            // Arrange
            var interval = new Interval<int>(int.MinValue, int.MaxValue);

            // Act
#pragma warning disable 1718
            var result = interval == interval;
#pragma warning restore 1718

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EqualsOperatorReturnsTrueForIntervalsWithSameBounds()
        {
            // Arrange
            var interval1 = new Interval<int>(int.MinValue, int.MaxValue);
            var interval2 = new Interval<int>(int.MinValue, int.MaxValue);

            // Act
            var result = interval1 == interval2;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EqualsOperatorReturnsFalseForIntervalsWithDifferentBounds()
        {
            // Arrange
            var interval1 = new Interval<int>(int.MinValue, 0);
            var interval2 = new Interval<int>(0, int.MaxValue);

            // Act
            var result = interval1 != interval2;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void NotEqualsOperatorReturnsFalseWhenComparedToSelf()
        {
            // Arrange
            var interval = new Interval<int>(int.MinValue, int.MaxValue);

            // Act
#pragma warning disable 1718
            var result = interval != interval;
#pragma warning restore 1718

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NotEqualsOperatorReturnsFalseForIntervalsWithSameBounds()
        {
            // Arrange
            var interval1 = new Interval<int>(int.MinValue, int.MaxValue);
            var interval2 = new Interval<int>(int.MinValue, int.MaxValue);

            // Act
            var result = interval1 != interval2;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NotEqualsOperatorReturnsTrueForIntervalsWithDifferentBounds()
        {
            // Arrange
            var interval1 = new Interval<int>(int.MinValue, 0);
            var interval2 = new Interval<int>(0, int.MaxValue);

            // Act
            var result = interval1 != interval2;

            // Assert
            Assert.True(result);
        }
    }
}
