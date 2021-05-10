using Xunit;

namespace CSharp6Features.Tests.Nameof
{
    public class NameofTests
    {
        private readonly string _field = string.Empty;

        public string Property { get; } = string.Empty;

        public string Method(string arg)
        {
            return arg;
        }

        [Fact]
        public void NameofClassReturnsClassName()
        {
            Assert.Equal("NameofTests", nameof(NameofTests));
            Assert.Equal("NameofTests", nameof(CSharp6Features.Tests.Nameof.NameofTests));
        }

        [Fact]
        public void NameofFieldReturnsFieldName()
        {
            Assert.Equal("_field", nameof(_field));
            Assert.Equal("_field", nameof(NameofTests._field));
        }

        [Fact]
        public void NameofPropertyReturnsPropertyName()
        {
            Assert.Equal("Property", nameof(Property));
            Assert.Equal("Property", nameof(NameofTests.Property));
        }

        [Fact]
        public void NameofMethodReturnsPropertyName()
        {
            Assert.Equal("Method", nameof(Method));
            Assert.Equal("Method", nameof(NameofTests.Method));
        }

        [Theory]
        [InlineData(1)]
        public void NameofArgumentReturnsArgumentName(int arg)
        {
            Assert.Equal("arg", nameof(arg));
        }
    }
}
