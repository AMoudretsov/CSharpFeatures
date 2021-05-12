using System;
using Xunit;

namespace CSharp71Features.Tests.DefaultLiterals
{
    public class DefaultLiteralsTests
    {
        [Fact]
        public void DefaultInfersTargetType()
        {
            int intDefault = default;
            DateTime dateDefault = default;
            string stringDefault = default;
            object objectDefault = default;

            Assert.Equal(0, intDefault);
            Assert.Equal(DateTime.MinValue, dateDefault);
            Assert.Null(stringDefault);
            Assert.Null(objectDefault);
        }

        [Fact]
        public void DefaultInfersTypeOfGenericTypeParameter()
        {
            T echo<T>(T value = default)
            {
                return value;
            }

            Assert.Equal(0, echo<int>());
            Assert.Equal(DateTime.MinValue, echo<DateTime>());
            Assert.Null(echo<string>());
            Assert.Null(echo<object>());
        }
    }
}
