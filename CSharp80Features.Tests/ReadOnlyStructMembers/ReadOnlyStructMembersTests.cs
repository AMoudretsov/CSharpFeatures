using Xunit;

namespace CSharp80Features.Tests.ReadOnlyStructMembers
{
    public class ReadOnlyStructMembersTests
    {
        [Fact]
        public void MethodsThatDoNotChangeStateCanBeMarkedReadonly()
        {
            var repeater = new Repeater { Value = "abc" };

            Assert.Equal("ABCABC", repeater.Twice());
        }

        [Fact]
        public void GetAccessorNeedToBeMarkedReadonly()
        {
            var repeater = new Repeater { Value = "abc" };

            Assert.Equal("ABCABCABC", repeater.Trice());
        }

        [Fact]
        public void ReadonlyMethodCannotModifyState()
        {
            var repeater = new Repeater { Value = "abc" };

            Assert.Equal("ABCABCABCABC", repeater.FourFold());
        }
    }
}
