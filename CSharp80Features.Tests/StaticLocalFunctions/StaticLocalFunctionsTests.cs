using Xunit;

namespace CSharp80Features.Tests.StaticLocalFunctions
{
    public class StaticLocalFunctionsTests
    {
        [Fact]
        public void LocalFunctionsCanBeMadeStatic()
        {
            Assert.True(IsSymmetric("ABBA"));
            Assert.True(IsSymmetric("ABXBA"));
            Assert.False(IsSymmetric("ABAB"));

            // Static local functions cannot reference variables from outer scope,
            // so pass value as argument.
            static bool IsSymmetric(string value)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }

                for (var i = 0; i < value.Length / 2; i++)
                {
                    if (value[i] != value[value.Length - i - 1])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
