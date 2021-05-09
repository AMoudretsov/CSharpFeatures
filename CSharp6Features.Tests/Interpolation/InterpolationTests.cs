using System;
using Xunit;

namespace CSharp6Features.Tests.Interpolation
{
    public class InterpolationTests
    {
        [Fact]
        public void InterpolatedStringInludesResultsOfInterpolationExpressions()
        {
            var name = "Saturn";
            var number = 6;

            Assert.Equal(
                "Saturn is the 6 planet from the sun.",
                $"{name} is the {number} planet from the sun.");
        }

        [Fact]
        public void AddingFormatStringReturnsFormattedResultOfInterpolationExpression()
        {
            var date = new DateTime(2020, 5, 15, 10, 30, 55);

            Assert.Equal("20200515 10:30:55", $"{date:yyyyMMdd hh:mm:ss}");
        }

        [Fact]
        public void AddingAlignmentReturnsFormattedResultOfInterpolationExpression()
        {
            var name = "Saturn";
            var number = 6;

            Assert.Equal("Saturn             6", $"{name,-10}{number,10}");
        }
    }
}
