using Xunit;

namespace CSharp80Features.Tests.IndicesRanges
{
    public class IndicesTests
    {
        [Fact]
        public void GetItemFromEndUsingHatOperator()
        {
            var items = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.Equal(9, items[^1]);
            Assert.Equal(8, items[^2]);
            Assert.Equal(7, items[^3]);
            Assert.Equal(6, items[^4]);
            Assert.Equal(5, items[^5]);
            Assert.Equal(4, items[^6]);
            Assert.Equal(3, items[^7]);
            Assert.Equal(2, items[^8]);
            Assert.Equal(1, items[^9]);
            Assert.Equal(0, items[^10]);
        }

        [Fact]
        public void GetItemUsingExplicitIndexerImplementation()
        {
            var items = new ExplicitlyIndexedCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Assert.Equal(9, items[^1]);
            Assert.Equal(8, items[^2]);
            Assert.Equal(7, items[^3]);
            Assert.Equal(6, items[^4]);
            Assert.Equal(5, items[^5]);
            Assert.Equal(4, items[^6]);
            Assert.Equal(3, items[^7]);
            Assert.Equal(2, items[^8]);
            Assert.Equal(1, items[^9]);
            Assert.Equal(0, items[^10]);
        }

        [Fact]
        public void GetItemUsingImplicitIndexerImplementation()
        {
            var items = new ImplicitlyIndexedCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Assert.Equal(9, items[^1]);
            Assert.Equal(8, items[^2]);
            Assert.Equal(7, items[^3]);
            Assert.Equal(6, items[^4]);
            Assert.Equal(5, items[^5]);
            Assert.Equal(4, items[^6]);
            Assert.Equal(3, items[^7]);
            Assert.Equal(2, items[^8]);
            Assert.Equal(1, items[^9]);
            Assert.Equal(0, items[^10]);
        }
    }
}
