using Xunit;

namespace CSharp6Features.Tests.ExpressionBodiedMethods
{
    public class ExpressionBodiedMethodsTests
    {
        private string Echo(string value) => value;

        [Fact]
        public void ExpressionBodiedMethodReturnsExpressionResult()
        {
            Assert.Equal("Test value", Echo("Test value"));
        }
    }
}
