using System;
using Xunit;

namespace CSharp90Features.Tests.Patterns
{
    public class PatternsTests
    {
        [Fact]
        public void TypePatternDoesNotRequireDeclarationOrDiscardPattern()
        {
            string GetTypeCategory(object value) =>
                value switch
                {
                    char or string => "Char/String",
                    byte or short or int or long or decimal => "Numeric",
                    bool => "Boolean",
                    ValueType => "Struct",
                    null => "Null",
                    _ => "Reference type"
                };

            Assert.Equal("Char/String", GetTypeCategory('A'));
            Assert.Equal("Char/String", GetTypeCategory("Test string"));
            Assert.Equal("Numeric", GetTypeCategory((byte)1));
            Assert.Equal("Numeric", GetTypeCategory((short)1));
            Assert.Equal("Numeric", GetTypeCategory(1));
            Assert.Equal("Numeric", GetTypeCategory(1L));
            Assert.Equal("Numeric", GetTypeCategory(1m));
            Assert.Equal("Struct", GetTypeCategory(DateTime.Now));
            Assert.Equal("Null", GetTypeCategory(null));
            Assert.Equal("Reference type", GetTypeCategory(new object()));
        }

        [Fact]
        public void LogicalAndCanBeUsedInPatterns()
        {
            bool IsThousands(int value) => value is > 999 and < 1_000_000;

            Assert.False(IsThousands(100));
            Assert.True(IsThousands(10_000));
            Assert.False(IsThousands(1_000_000));
        }

        [Fact]
        public void LogicalOrCanBeUsedInPatterns()
        {
            bool IsNonThousands(int value) => value is < 1_000 or > 999_999;

            Assert.True(IsNonThousands(100));
            Assert.False(IsNonThousands(10_000));
            Assert.True(IsNonThousands(1_000_000));
        }

        [Fact]
        public void LogicalNotCanBeUsedInPatterns()
        {
            bool IsNotNull(char? value) => value is not null;

            Assert.True(IsNotNull('A'));
            Assert.False(IsNotNull(null));
        }

        [Fact]
        public void ParenthesesCanBeUsedInPatterns()
        {
            bool IsNonThousands(object value) => value is int and (< 1000 or > 999_999);

            Assert.False(IsNonThousands(new object()));
            Assert.True(IsNonThousands(100));
            Assert.False(IsNonThousands(10_000));
            Assert.True(IsNonThousands(1_000_000));
        }
    }
}
