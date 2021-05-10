using System;
using Xunit;

namespace CSharp7Features.Tests.PatternMatching
{
    public class PatternMatchingTests
    {
        [Fact]
        public void IsExpressionWithConstPatternChecksIfReferenceIsNull()
        {
            string value = null;

            var actual = value is null;

            Assert.True(actual);
        }

        [Fact]
        public void IsExpressionWithConstPatternChecksIfValuesAreEqual()
        {
            decimal? value = 1.0m;

            var actual = value is 1;

            Assert.True(actual);
        }

        [Fact]
        public void IsExpressionWithTypePatternChecksInputTypeAndExtractsInputValue()
        {
            object value = 10;
            if (!(value is int actual))
            {
                actual = default;
            }

            Assert.Equal(10, actual);
        }


        [Fact]
        public void CaseClauseWithTypePatternChecksInputTypeAndExtractsInputValue()
        {
            object value = 20;

            var actual = ConvertToInt(value);

            Assert.Equal(20, actual);
        }

        [Fact]
        public void CaseClauseWithTypePatternChecksInputTypeAndExtractsInputValueAndVerifyCondition()
        {
            object value = "One";

            var actual = ConvertToInt(value);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void CaseClauseWithConstantPatternChecksIfValueIsNullReference()
        {
            object value = null;

            var actual = ConvertToInt(value);

            Assert.Equal(default, actual);
        }

        private int ConvertToInt(object value)
        {
            switch (value)
            {
                case int i:
                    return i;
                case string s when s.Equals("one", StringComparison.OrdinalIgnoreCase):
                    return 1;
                case null:
                    return default;
                default:
                    throw new ArgumentException("Not supported argument type.", nameof(value));
            }
        }
    }
}
