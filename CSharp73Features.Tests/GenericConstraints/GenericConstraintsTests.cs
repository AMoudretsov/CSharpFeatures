using System;
using Xunit;

namespace CSharp73Features.Tests.GenericConstraints
{
    public class GenericConstraintsTests
    {
        [Fact]
        public void EnumConstraintLimitsGenericType()
        {
            var actual = Echo(Color.Green);

            // Compilation error since argument is not enumeration.
            // Echo(2);
            // Echo("Green");

            Assert.Equal("Green", actual);
        }

        [Fact]
        public void DelegateConstraintLimitsGenericType()
        {
            var isPositive = false;
            var isEven = false;

            Action<int> checkPositive = x => isPositive = x > 0;
            Action<int> checkEven = x => isEven = x % 2 == 0;
            Action<string> checkUpperCase = x => x.Equals(x.ToUpper(), StringComparison.OrdinalIgnoreCase);

            Combine(checkPositive, checkEven)(11);

            // Compilation error since delegate types do not match.
            // Combine(checkPositive, checkUpperCase)(11);

            Assert.True(isPositive);
            Assert.False(isEven);
        }

        [Fact]
        public void UnmanagedConstraintLimitsGenericType()
        {
            var actual = Coalesce<int>(null, null, 5, null, 1);

            // Compilation error since argument types do not match int?.
            // Coalesce<int>(12.5m, "string", 5, null, 1);

            Assert.Equal(5, actual);
        }

        private string Echo<TEnum>(TEnum value) where TEnum : Enum => value.ToString();

        private TDelegate Combine<TDelegate>(TDelegate delegate1, TDelegate delegate2) where TDelegate : Delegate
        {
            return (TDelegate)Delegate.Combine(delegate1, delegate2);
        }

        private TUnmanaged Coalesce<TUnmanaged>(params TUnmanaged?[] items) where TUnmanaged : unmanaged
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    return item.Value;
                }
            }

            return default;
        }
    }

    public enum Color
    {
        Red,
        Green,
        Blue
    }
}
