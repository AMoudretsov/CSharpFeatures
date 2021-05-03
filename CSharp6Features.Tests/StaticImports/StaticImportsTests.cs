using Xunit;
using static System.Math;

namespace CSharp6Features.Tests.StaticImports
{
    public class StaticImportsTests
    {
        [Fact]
        public void CallMethodWithoutSpecifyingClassName()
        {
            Assert.Equal(5, Abs(-5));
        }

        [Fact]
        public void NestedInstanceMethodOverloadsStaticImports()
        {
            Assert.Equal(50, System.Math.Max(-100, 50));
            Assert.Equal(100, Max(-100, 50));
        }

        [Fact]
        public void NestedStaticMethodOverloadsStaticImports()
        {
            Assert.Equal(1, System.Math.Round(1.25m));
            Assert.Equal(2, Round(1.25m));
        }

        private decimal Max(int value1, int value2)
        {
            return System.Math.Max(Abs(value1), Abs(value2));
        }

        private static decimal Round(decimal value)
        {
            return Ceiling(value);
        }
    }
}
