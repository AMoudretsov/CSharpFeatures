using Xunit;

namespace CSharp6Features.Tests.AutoPropertyInitializers
{
    public class AutoPropertyInitializersTests
    {
        [Fact]
        public void ReadOnlyAutoPropertyIsInitialized()
        {
            var actual = new AutoPropertyContainer().ReadOnlyAutoProperty;

            Assert.Equal(nameof(AutoPropertyContainer.ReadOnlyAutoProperty), actual);
        }


        [Fact]
        public void AutoPropertyIsInitialized()
        {
            var actual = new AutoPropertyContainer().AutoProperty;

            Assert.Equal(nameof(AutoPropertyContainer.AutoProperty), actual);
        }

        [Fact]
        public void NotInitializedReadOnlyAutoPropertyIsNull()
        {
            var actual = new AutoPropertyContainer().NotInitializedReadOnlyAutoProperty;

            Assert.Null(actual);
        }


        [Fact]
        public void NotInitializedAutoPropertyIsNull()
        {
            var actual = new AutoPropertyContainer().NotInitializedAutoProperty;

            Assert.Null(actual);
        }
    }
}
