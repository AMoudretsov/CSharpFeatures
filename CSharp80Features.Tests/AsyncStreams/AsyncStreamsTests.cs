using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CSharp80Features.Tests.AsyncStreams
{
    public class AsyncStreamsTests
    {
        [Fact]
        public async void IterateAsynchronouslyThroughCollectionOfTasks()
        {
            var iterations = new List<int>();

            await foreach (var iteration in Repeat(100, 1000))
            {
                iterations.Add(iteration);
            }

            Assert.Equal(Enumerable.Range(1, 10), iterations);
        }

        [Fact]
        public async void AsyncStreamCanBeCanceledWithCancellationToken()
        {
            var iterations = new List<int>();

            var cts = new CancellationTokenSource();
            var token = cts.Token;

            try
            {
                await foreach (var iteration in Repeat(100, 1000).WithCancellation(token))
                {
                    iterations.Add(iteration);

                    if (iteration % 5 == 0)
                    {
                        cts.Cancel();
                    }
                }
            }
            catch (Exception e)
            {
                Assert.IsType<TaskCanceledException>(e);
            }
        }

        [Fact]
        public async void AsyncStreamCanBeUsedWithLinqMethods()
        {
            var iterations = new List<int>();

            await foreach (var iteration in Repeat(100, 1000).Where(x => x % 2 == 0))
            {
                iterations.Add(iteration);
            }

            Assert.Equal(new[] { 2, 4, 6, 8, 10 }, iterations);
        }

        private async IAsyncEnumerable<int> Repeat(
            int intervalMs,
            int totalMs,
            [EnumeratorCancellation] CancellationToken token = default)
        {
            for (var i = 0; i < totalMs / intervalMs; i++)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(intervalMs), token);
                yield return i + 1;
            }
        }
    }
}
