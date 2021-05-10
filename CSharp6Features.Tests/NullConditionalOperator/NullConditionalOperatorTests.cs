using Xunit;

namespace CSharp6Features.Tests.NullConditionalOperator
{
    public class NullConditionalOperatorTests
    {
        [Fact]
        public void NullInstanceAccessPropertyReturnsNull()
        {
            MemberContainer instance = null;

            Assert.Null(instance?.Property);
        }

        [Fact]
        public void NullInstanceAccessIndexerReturnsNull()
        {
            MemberContainer instance = null;

            Assert.Null(instance?[0]);
        }

        [Fact]
        public void NullInstanceCallMethodReturnsNull()
        {
            MemberContainer instance = null;

            Assert.Null(instance?.Echo("Method arg"));
        }

        [Fact]
        public void NotNullInstanceAccessPropertyReturnsPropertyValue()
        {
            var instance = new MemberContainer(new int[0])
            {
                Property = "Property value"
            };

            Assert.Equal("Property value", instance?.Property);
        }

        [Fact]
        public void NotNullInstanceAccessIndexerReturnsIndexerValue()
        {
            var instance = new MemberContainer(new[] { 1, 2, 3 });

            Assert.Equal(2, instance?[1]);
        }

        [Fact]
        public void NotNullInstanceCallMethodReturnsMethodValue()
        {
            MemberContainer instance = new MemberContainer(new int[0]);

            Assert.Equal("Method arg", instance?.Echo("Method arg"));
        }
    }
}
