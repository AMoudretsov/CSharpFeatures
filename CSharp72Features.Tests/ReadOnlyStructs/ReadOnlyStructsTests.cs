using Xunit;

namespace CSharp72Features.Tests.ReadOnlyStructs
{
    public class ReadOnlyStructsTests
    {
        [Fact]
        public void ReadonlyStructsPreventDefensiveCopyingOnMethodCalls()
        {
            var data = new ImmutableBigData(byte.MinValue, byte.MaxValue);

            // Test cannot demonstrate the fact that method Manipulate is called against
            // initial struct instance rather than its copy. Compiler enforces immutability
            // of the readonly struct. Therefore runtime does not need to worry about potential
            // changes of struct fields. As result no defensive copy is made and memory usage is optimized.
            var actual = data.Manipulate();

            Assert.Equal(byte.MaxValue, actual);
        }
    }
}
