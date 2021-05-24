using System;
using Xunit;

namespace CSharp72Features.Tests.InParameters
{
    public class InParametersTests
    {
        [Fact]
        public unsafe void RegularArgumentIsCopyOfOrigin()
        {
            var data = new BigData();
            BigData* originPointer = &data;

            Assert.NotEqual((int)originPointer, ArgumentPointerAddress(data));
        }

        [Fact]
        public unsafe void InArgumentIsReferenceOnOrigin()
        {
            var data = new BigData();
            BigData* originPointer = &data;

            Assert.Equal((int)originPointer, ArgumentPointerAddress(in data));
        }

        [Fact]
        public void InArgumentIsReadOnly()
        {
            var data = new BigData
            {
                Value1 = byte.MinValue,
                ValueN = byte.MaxValue
            };

            Assert.Equal(byte.MaxValue, GetLastByte(in data));
        }

        [Fact]
        public void InArgumentStillCanBeChangedOutside()
        {
            var value = 100;

            Assert.Throws<DivideByZeroException>(
                () => DivideBy(in value, () => { value = 0; }));
        }

        [Fact]
        public void InArgumentCanBeThisArgumentInExtensionMethods()
        {
            var data = new BigData
            {
                Value1 = byte.MinValue,
                ValueN = byte.MaxValue
            };

            var actual = data.Max();

            Assert.Equal(byte.MaxValue, actual);
        }

        private unsafe int ArgumentPointerAddress(BigData data)
        {
            BigData* pointer = &data;
            return (int)pointer;
        }

        private unsafe int ArgumentPointerAddress(in BigData data)
        {
            fixed (BigData* pointer = &data)
            {
                return (int)pointer;
            }
        }

        private byte GetLastByte(in BigData data)
        {
            // Compile time error since data is readonly argument.
            // data.Value1 = 100;

            return data.ValueN;
        }

        private double DivideBy(in int value, Action action)
        {
            action();
            return 100 / value;
        }
    }
}
