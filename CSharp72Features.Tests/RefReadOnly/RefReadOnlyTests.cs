using Xunit;

namespace CSharp72Features.Tests.RefReadOnly
{
    public class RefReadOnlyTests
    {
        [Fact]
        public void RefReadonlyVariableCannotBeChanged()
        {
            var value1 = 100;
            ref readonly int value2 = ref value1;

            value1++;

            // Compilation error since value2 is readonly.
            // value2++;

            Assert.Equal(101, value2);
        }

        [Fact]
        public void MethodCanReturnReadonlyReference()
        {
            var values = new[] { 1, 2, 4, 8, 16 };
            ref readonly int last = ref LastElementReference(values);

            values[values.Length - 1] = 32;

            // Compilation error since last is readonly.
            // last = 64;

            Assert.Equal(32, last);
        }

        private ref readonly int LastElementReference(int[] values)
        {
            return ref values[values.Length - 1];
        }
    }
}
