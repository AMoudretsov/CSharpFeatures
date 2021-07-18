using Xunit;

namespace CSharp80Features.Tests.NullCoalescing
{
    public class NullCoalescingTests
    {
        [Fact]
        public void NullCoalescingOperatorAssignsValueIfVariableIsNull()
        {
            var defaultObject = new object();
            var defaultString = "Default value";
            var defaultNullable = 42;

            object actualObject = null;
            string actualString = null;
            int? actualNullable = null;

            actualObject ??= defaultObject;
            actualString ??= defaultString;
            actualNullable ??= defaultNullable;

            Assert.Equal(defaultObject, actualObject);
            Assert.Equal(defaultString, actualString);
            Assert.Equal(defaultNullable, actualNullable);
        }
    }
}
