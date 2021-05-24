using Xunit;

namespace CSharp72Features.Tests.LeadingUnderscoreInNumericLiterals
{
    public class LeadingUnderscoreTests
    {
        [Fact]
        public void LeadingUnderscoreCanBeUsedInHexLiterals()
        {
            var upperCase = 0X_FF_CC;
            var lowerCase = 0x_FF_CC;

            Assert.Equal(65484, upperCase);
            Assert.Equal(65484, lowerCase);
        }

        [Fact]
        public void LeadingUnderscoreCanBeUsedInBinaryLiterals()
        {
            var upperCase = 0B_11_00_10_01;
            var lowerCase = 0b_11_00_10_01;

            Assert.Equal(201, upperCase);
            Assert.Equal(201, lowerCase);
        }
    }
}
