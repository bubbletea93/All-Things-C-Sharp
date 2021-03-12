using FluentAssertions;
using System;
using Xunit;

namespace StringCalculator.UnitTest
{
    public class ProgramUnitTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData(",", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,", 6)]
        [InlineData("1\n2,3,", 6)]
        public void Add_ShouldAddAnyNumbers_WhenStringIsValid(string calculations, int expected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(calculations);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Add_ShouldThrowArguementException_WhenStringIsInvalid()
        {
            //Arrange
            var calculator = new Calculator();
            int[] myArray = new int[3];
            //Act & Assert
            var numbers = "a,a";
            Assert.Throws<ArgumentException>(() => calculator.Add(numbers));
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        public void Add_ShouldSupportDifferentDelimiters_WhenDelimiterIsProvided(string calculations, int expected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(calculations);

            //Assert
            result.Should().Be(expected);
        }

    }
}
