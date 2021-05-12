using System.Globalization;
using Xunit;

namespace CSharp71Features.Tests.PatternMatching
{
    public class PatternMatchingTests
    {
        [Fact]
        public void PatternMatchingCanBeUsedOnGenericTypeParameter()
        {
            string toString<T>(T value)
            {
                switch (value)
                {
                    case int intValue:
                        return intValue.ToString(NumberFormatInfo.InvariantInfo);
                    case string stringValue:
                        return stringValue;
                    case null:
                        return "Null";
                    default:
                        return "Unknown";
                }
            };

            Assert.Equal("10", toString(10));
            Assert.Equal("Test value", toString("Test value"));
            Assert.Equal("Null", toString<object>(null));
            Assert.Equal("Unknown", toString(new object()));
        }
    }
}
