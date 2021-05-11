using Xunit;

namespace CSharp7Features.Tests.Literals
{
    public class LiteralsTests
    {
        [Fact]
        public void DigitalSeparatorsCanBeUsedInIntegersToImproveReadability()
        {
            var actual = 2_147_483_647;

            Assert.Equal(int.MaxValue, actual);
        }

        [Fact]
        public void DigitalSeparatorsCanBeUsedInDecimalsToImproveReadability()
        {
            var actual = 9_999_999.99m;

            Assert.Equal(9999999.99m, actual);
        }


        [Fact]
        public void DigitalSeparatorsCanBeUsedInHexToImproveReadability()
        {
            var actual = 0xFF_FF;

            Assert.Equal(65535, actual);
        }

        [Fact]
        public void BinaryLiteralsCanBeUsedToImproveReadability()
        {
            var actual = 0b1100_0101 ^ 0b0011_1010;

            Assert.Equal(255, actual);
        }
    }
}
