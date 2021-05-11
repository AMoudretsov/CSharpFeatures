using System;
using Xunit;

namespace CSharp7Features.Tests.ThrowExpressions
{
    public class ThrowExpressionsTests
    {
        [Fact]
        public void UseThrowExpressionAlongWithNullCoalescingOperator()
        {
            string echo(string value)
            {
                return value ?? throw new ArgumentNullException(nameof(value));
            };


            Assert.Throws<ArgumentNullException>(() => echo(null));
        }

        [Fact]
        public void UseThrowExpressionAlongWithTernaryConditionalOperator()
        {
            string echo(string value)
            {
                return value is null ? throw new ArgumentNullException(nameof(value)) : value;
            };


            Assert.Throws<ArgumentNullException>(() => echo(null));
        }
    }
}
