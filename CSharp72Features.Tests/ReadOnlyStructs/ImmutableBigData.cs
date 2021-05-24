using System;

namespace CSharp72Features.Tests.ReadOnlyStructs
{
    public readonly struct ImmutableBigData
    {
        public ImmutableBigData(byte value1, byte value2)
        {
            Value1 = value1;
            ValueN = value2;
        }

        public readonly byte Value1;
        // ...
        public readonly byte ValueN;

        public byte Manipulate()
        {
            // Compilation error since struct is declared as readonly and its fields are also readonly.
            // Value1++;

            return Math.Max(Value1, ValueN);
        }
    }
}
