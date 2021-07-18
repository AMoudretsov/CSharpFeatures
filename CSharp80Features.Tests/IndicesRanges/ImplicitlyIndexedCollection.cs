using System.Collections.Generic;
using System.Linq;

namespace CSharp80Features.Tests.IndicesRanges
{
    public class ImplicitlyIndexedCollection<T>
    {
        private readonly IList<T> _items;

        public ImplicitlyIndexedCollection(IEnumerable<T> items)
        {
            _items = new List<T>(items);
        }

        public int Count => _items.Count;

        public T this[int index] => _items[index];

        public IEnumerable<T> Slice(int start, int length)
        {
            return _items.Where((x, i) => start <= i && i < start + length).ToArray();
        }
    }
}
