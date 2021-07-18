using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CSharp80Features.Tests.AsyncDisposable
{
    public class AsyncDisaposableTests
    {
        [Fact]
        public async void AsyncDisposablesAreCalledByAwaitUsing()
        {
            var disposeLog = new List<string>();

            var disposableResource1 = new DisposableResource("R1", disposeLog);
            await using (disposableResource1.ConfigureAwait(false))
            {
                disposableResource1.Process();
            }

            var disposableResource2 = new DisposableResource("R2", disposeLog);
            await using (disposableResource2.ConfigureAwait(false))
            {
                disposableResource2.Process();
            }

            var disposableResource3 = new DisposableResource("R3", disposeLog);
            await using (disposableResource3.ConfigureAwait(false))
            {
                disposableResource3.Process();
            }

            Assert.Equal(disposeLog, new[] { "R1", "R2", "R3" });
        }

        [Fact]
        public async void StackedAsyncDisposablesAreCalledInReverseOrder()
        {
            var disposeLog = new List<string>();

            var disposableResource1 = new DisposableResource("R1", disposeLog);
            await using (disposableResource1.ConfigureAwait(false))
            {
                var disposableResource2 = new DisposableResource("R2", disposeLog);
                await using (disposableResource2.ConfigureAwait(false))
                {
                    var disposableResource3 = new DisposableResource("R3", disposeLog);
                    await using (disposableResource3.ConfigureAwait(false))
                    {
                        disposableResource1.Process();
                        disposableResource2.Process();
                        disposableResource3.Process();
                    }
                }
            }

            Assert.Equal(disposeLog, new[] { "R3", "R2", "R1" });
        }

        [Fact]
        public async void AsyncDisposablesAreHandledByUsingDeclaration()
        {
            var disposeLog = new List<string>();

            await ProcessResource("R1", disposeLog);
            await ProcessResource("R2", disposeLog);
            await ProcessResource("R3", disposeLog);

            Assert.Equal(disposeLog, new[] { "R1", "R2", "R3" });
        }

        private async Task<string> ProcessResource(string name, IList<string> disposeLog)
        {
            var disposableResource = new DisposableResource(name, disposeLog);
            await using var asyncDisposableDecorator = disposableResource.ConfigureAwait(false);

            return disposableResource.Process();
        }
    }
}
