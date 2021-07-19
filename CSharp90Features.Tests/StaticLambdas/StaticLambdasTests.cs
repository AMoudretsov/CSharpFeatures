using System;
using Xunit;

namespace CSharp90Features.Tests.StaticLambdas
{
    public class StaticLambdasTests
    {
        [Fact]
        public void StaticLambdaCannotCaptureVariablesFromEnclosingScope()
        {
            var value = 11;

            Func<int, bool> isOdd = static (x) => x % 2 != 0;

            // Cannot capture variable value inside static lambda
            // Func<bool> isOdd = static () => value % 2 != 0;

            Assert.True(isOdd(value));
        }

        [Fact]
        public void StaticAnonymousDelegateCannotCaptureVariablesFromEnclosingScope()
        {
            var value = 11;

            Func<int, bool> isOdd = static delegate (int x)
            {
                return x % 2 != 0;
            };

            // Cannot capture variable value inside static anonymous delegate
            // Func<bool> isOdd = static delegate ()
            // {
            //     return value % 2 != 0;
            // };

            Assert.True(isOdd(value));
        }
    }
}
