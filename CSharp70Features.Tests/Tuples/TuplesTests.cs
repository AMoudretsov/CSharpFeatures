using System.Collections.Generic;
using Xunit;

namespace CSharp70Features.Tests.Tuples
{
    public class TuplesTests
    {
        [Fact]
        public void MethodReturnsMultipleNamedValuesInFormOfTuple()
        {
            var actual = VaryCase("Test String");

            Assert.Equal("test string", actual.Lower);
            Assert.Equal("Test String", actual.Original);
            Assert.Equal("TEST STRING", actual.Upper);
        }

        [Fact]
        public void TuplesWithIdenticalValuesAreEqualRegardlessOfFieldNames()
        {
            var cases = ("test string", "Test String", "TEST STRING");
            var namedCases = (Lower: "test string", Original: "Test String", Upper: "TEST STRING");

            Assert.Equal(cases, namedCases);
        }

        [Fact]
        public void TuplesCanBeUsedAsCompoundDictionaryKeys()
        {
            var values = new Dictionary<(int? key1, string key2), string>
            {
                [(1, null)] = "Value #1",
                [(null, "key2")] = "Value #2",
                [(3, "key3")] = "Value #3",
            };

            Assert.Equal("Value #2", values[(null, "key2")]);
        }

        private (string Lower, string Original, string Upper) VaryCase(string value)
        {
            return (value.ToLower(), value, value.ToUpper());
        }
    }
}
