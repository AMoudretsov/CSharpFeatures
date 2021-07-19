using System.Collections.Generic;
using Xunit;

namespace CSharp90Features.Tests.ExtensionGetEnumerator
{
    public class ExtensionGetEnumeratorTests
    {
        [Fact]
        public void GetEnumeratorCanBeImplementedAsExtensionMethod()
        {
            var foreachLog = new List<int>();

            var customList = new CustomList<int>(new List<int> { 1, 2, 3 });

            foreach (var item in customList)
            {
                foreachLog.Add(item);
            }

            Assert.Equal(new[] { 1, 2, 3 }, foreachLog);
        }
    }
}
