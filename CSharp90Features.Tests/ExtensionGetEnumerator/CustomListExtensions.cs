using System.Collections.Generic;

namespace CSharp90Features.Tests.ExtensionGetEnumerator
{
    public static class CustomListExtensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this CustomList<T> customList)
        {
            return ((IEnumerable<T>)customList.Items).GetEnumerator();
        }
    }
}
