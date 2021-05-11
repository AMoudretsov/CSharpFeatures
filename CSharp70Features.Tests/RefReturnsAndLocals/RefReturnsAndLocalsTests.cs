using System;
using Xunit;

namespace CSharp70Features.Tests.RefReturnsAndLocals
{
    public class RefReturnsAndLocalsTests
    {
        [Fact]
        public void AssigningValueToRefChangesOriginalCollection()
        {
            var values = new[] { 0, 1, 2, 3, 4, 5 };

            ref int two = ref FindElement(values, x => x == 2);

            two = 22;

            Assert.Equal(22, values[2]);
        }

        [Fact]
        public void AssigningValueToOriginalCollectionChangesRef()
        {
            var values = new[] { 0, 1, 2, 3, 4, 5 };

            ref int two = ref FindElement(values, x => x == 2);

            values[2] = 22;

            Assert.Equal(22, two);
        }

        [Fact]
        public void RefLocalCanBeReassignedToAnotherReference()
        {
            var values1 = new[] { 0, 1, 2, 3, 4, 5 };
            var values2 = new[] { 0, 10, 20, 30, 40, 50 };

            ref int ref1 = ref FindElement(values1, x => x == 2);
            ref int ref2 = ref FindElement(values2, x => x == 20);

            ref1 = ref ref2;
            ref1 = 22;

            Assert.Equal(2, values1[2]);
            Assert.Equal(22, values2[2]);
        }

        private ref T FindElement<T>(T[] elements, Predicate<T> predicate)
        {
            for (var i = 0; i < elements.Length; i++)
            {
                if (predicate(elements[i]))
                {
                    return ref elements[i];
                }
            }

            throw new InvalidOperationException("Cannot find reference.");
        }
    }
}
