using Xunit;

namespace CSharp7Features.Tests.ExpressionBodiedMembers
{
    public class ExpressionBodiedMembersTests
    {
        [Fact]
        public void CtorCanBeExpressionBodied()
        {
            var actual = new ExpressionBodiedMembersContainer("Test value");

            Assert.Equal("Test value", actual.Value);
        }

        [Fact]
        public void PropertyAccessorsCanBeExpressionBodied()
        {
            var actual = new ExpressionBodiedMembersContainer(null)
            {
                Value = "Test value"
            };

            Assert.Equal("Test value", actual.Value);
        }

        private class ExpressionBodiedMembersContainer
        {
            private string _value;

            public ExpressionBodiedMembersContainer(string value) => _value = value;

            public string Value
            {
                get => _value;
                set => _value = value;
            }
        }
    }
}
