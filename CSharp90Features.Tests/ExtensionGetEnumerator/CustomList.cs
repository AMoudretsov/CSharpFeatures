using System;
using System.Collections.Generic;

namespace CSharp90Features.Tests.ExtensionGetEnumerator
{
    public class CustomList<T>
    {
        public CustomList()
        {
            Items = new List<T>();
        }

        public CustomList(IList<T> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public IList<T> Items { get; }
    }
}
