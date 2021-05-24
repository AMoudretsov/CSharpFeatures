using Xunit;

namespace CSharp72Features.Tests.PrivateProtected
{
    public class PrivateProtectedTests
    {
        [Fact]
        public void PrivateProtectedMemberIsAccesibleForDescendantsWithinTheSameAssembly()
        {
            var bicycle = new Bicycle();

            Assert.Equal(2, bicycle.HowManyWheels());
        }
    }
}
