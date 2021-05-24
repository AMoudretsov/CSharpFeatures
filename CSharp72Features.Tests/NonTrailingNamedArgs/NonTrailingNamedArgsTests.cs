using Xunit;

namespace CSharp72Features.Tests.NonTrailingNamedArgs
{
    public class NonTrailingNamedArgsTests
    {
        [Fact]
        public void NamedArgsCanPrecedePositionalArgs()
        {
            var actual = FullName("Mary", middleName: "Elizabeth", "Smith");

            Assert.Equal("Mary Elizabeth Smith", actual);
        }

        private string FullName(string firstName, string middleName, string lastName)
        {
            return $"{firstName} {middleName} {lastName}";
        }
    }
}
