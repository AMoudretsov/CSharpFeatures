using System;

namespace CSharp72Features.Tests.InParameters
{
    public static class BigDataExtensions
    {
        public static byte Max(in this BigData data)
        {
            return Math.Max(data.Value1, data.ValueN);
        }
    }
}
