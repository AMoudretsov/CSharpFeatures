using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp80Features.Tests.IndicesRanges
{
    public class ExplicitlyIndexedCollection<T>
    {
        private readonly IList<T> _items;

        public ExplicitlyIndexedCollection(IEnumerable<T> items)
        {
            _items = new List<T>(items);
        }

        public T this[Index index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public IEnumerable<T> this[Range range]
        {
            get
            {
                return _items.ToArray()[range];
            }
        }
    }
}
