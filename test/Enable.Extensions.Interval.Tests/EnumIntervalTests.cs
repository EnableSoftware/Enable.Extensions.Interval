using System;
using Xunit;

namespace Enable.Extensions.Interval.Tests
{
    public class EnumIntervalTests
    {
        public enum TestEnum
        {
            Foo,
            Bar,
            Baz,
            Qux
        }

        [Fact]
        public void ThrowsException_IfBoundsAreInvalid()
        {
            // Arrange
            var expectedExceptionMessage = "Invalid bounds specified: upper bound must be greater or equal to lower bound." + Environment.NewLine + "Parameter name: upperBound";

            var lowerBound = TestEnum.Foo;
            var upperBound = TestEnum.Qux;

            // Act
            var exception = Record.Exception(() => new Interval<TestEnum>(upperBound, lowerBound));

            // Assert
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(TestEnum.Foo, TestEnum.Foo, TestEnum.Foo)]
        [InlineData(TestEnum.Foo, TestEnum.Baz, TestEnum.Foo)]
        [InlineData(TestEnum.Foo, TestEnum.Baz, TestEnum.Bar)]
        [InlineData(TestEnum.Foo, TestEnum.Baz, TestEnum.Baz)]
        public void ReturnsTrueIfValueInInterval(
            TestEnum lowerBound,
            TestEnum upperBound,
            TestEnum valueToTest)
        {
            // Arrange
            var sut = new Interval<TestEnum>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(TestEnum.Bar, TestEnum.Baz, TestEnum.Foo)]
        [InlineData(TestEnum.Bar, TestEnum.Baz, TestEnum.Qux)]
        public void ReturnsFalseIfValueOutOfInterval(
            TestEnum lowerBound,
            TestEnum upperBound,
            TestEnum valueToTest)
        {
            // Arrange
            var sut = new Interval<TestEnum>(lowerBound, upperBound);

            // Act
            var result = sut.Contains(valueToTest);

            // Assert
            Assert.False(result);
        }
    }
}
