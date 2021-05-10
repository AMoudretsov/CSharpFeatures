using Xunit;

namespace CSharp7Features.Tests.OutVariables
{
    public class OutVariablesTests
    {
        [Fact]
        public void ExplicitlyTypedOutVariableIsInitialized()
        {
            TryParse("trUe", out bool actual);

            Assert.True(actual);
        }

        [Fact]
        public void ImplicitlyTypedOutVariableIsInitialized()
        {
            TryParse("1", out var actual);

            Assert.True(actual);
        }


        [Fact]
        public void DiscardOutVariableIndicatesThatValueIsUnnecessary()
        {
            var isParsable = TryParse("Valid", out var _);

            Assert.False(isParsable);
        }

        private bool TryParse(string raw, out bool value)
        {
            if (string.IsNullOrEmpty(raw))
            {
                value = false;
                return false;
            }

            switch (raw.Trim().ToUpper())
            {
                case "TRUE":
                case "YES":
                case "1":
                    value = true;
                    return true;
                case "FALSE":
                case "NO":
                case "0":
                    value = false;
                    return true;
                default:
                    value = false;
                    return false;
            }
        }
    }
}
