using System.Collections.Generic;
using Xunit;

namespace CSharp80Features.Tests.UsingDeclarations
{
    public class UsingDeclationsTests
    {
        [Fact]
        public void UsingDeclationsAutomaticallyDisposeVariables()
        {
            var disposeLog = new List<string>();

            ProcessResource("R1", disposeLog);
            ProcessResource("R2", disposeLog);
            ProcessResource("R3", disposeLog);

            Assert.Equal(new[] { "R1", "R2", "R3" }, disposeLog);
        }

        private string ProcessResource(string name, IList<string> disposeLog)
        {
            using var disposableResource = new DisposableResource(
                name,
                disposeLog);

            return disposableResource.Process();
        }
    }
}
