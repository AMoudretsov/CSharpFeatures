using Xunit;

namespace CSharp72Features.Tests.ConditionalRefExpressions
{
    public class ConditionalRefExpressionsTests
    {
        [Fact]
        public void RefCanBeReturnedFromConditionalExpression()
        {
            var values1 = new[] { 10, 20, 30, 40, 50 };
            var values2 = new[] { 1, 2, 3, 4, 5, 6 };

            ref int last = ref Last(values1, values2);
            last = 7;


            Assert.Equal(7, values2[values2.Length - 1]);
        }

        private ref int Last(int[] values1, int[] values2)
        {
            return ref values1.Length >= values2.Length
                ? ref values1[values1.Length - 1]
                : ref values2[values2.Length - 1];
        }
    }
}
