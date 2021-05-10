using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharp6Features.Tests.AwaitInCatchFinally
{
    public class AwaitInCatchFinallyTests
    {
        [Fact]
        public async void AwaitCanBeUsedInCatchBlock()
        {
            string actual = null;

            try
            {
                await ThrowAfterDelay();
            }
            catch
            {
                actual = await EchoAfterDelay("Catch block");
            }

            Assert.Equal("Catch block", actual);
        }

        [Fact]
        public async void AwaitCanBeUsedInFinallyBlock()
        {
            string actual = null;

            try
            {
                await ThrowAfterDelay();
            }
            catch
            {
                actual = await EchoAfterDelay("Catch block");
            }
            finally
            {
                actual = await EchoAfterDelay("Finally block");
            }

            Assert.Equal("Finally block", actual);
        }

        private async Task ThrowAfterDelay()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));

            throw new Exception("Test exception.");
        }

        private async Task<string> EchoAfterDelay(string value)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            return value;
        }
    }
}
