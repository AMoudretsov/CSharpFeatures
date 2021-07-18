using Xunit;

namespace CSharp80Features.Tests.IndicesRanges
{
    public class RangesTests
    {
        [Fact]
        public void GetItemsUsingRangeOperator()
        {
            var items = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.Equal(new[] { 0, 1 }, items[0..2]);
            Assert.Equal(new[] { 0, 1 }, items[..2]);
            Assert.Equal(new[] { 0, 1 }, items[^10..^8]);
            Assert.Equal(new[] { 0, 1 }, items[..^8]);
            Assert.Equal(new[] { 3, 4, 5 }, items[3..6]);
            Assert.Equal(new[] { 3, 4, 5 }, items[^7..^4]);
            Assert.Equal(new[] { 8, 9 }, items[8..10]);
            Assert.Equal(new[] { 8, 9 }, items[8..]);
            Assert.Equal(new[] { 8, 9 }, items[^2..^0]);
            Assert.Equal(new[] { 8, 9 }, items[^2..]);
            Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, items[..]);
        }

        [Fact]
        public void GetItemsUsingExplicitIndexerImplementation()
        {
            var items = new ExplicitlyIndexedCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Assert.Equal(new[] { 0, 1 }, items[0..2]);
            Assert.Equal(new[] { 0, 1 }, items[..2]);
            Assert.Equal(new[] { 0, 1 }, items[^10..^8]);
            Assert.Equal(new[] { 0, 1 }, items[..^8]);
            Assert.Equal(new[] { 3, 4, 5 }, items[3..6]);
            Assert.Equal(new[] { 3, 4, 5 }, items[^7..^4]);
            Assert.Equal(new[] { 8, 9 }, items[8..10]);
            Assert.Equal(new[] { 8, 9 }, items[8..]);
            Assert.Equal(new[] { 8, 9 }, items[^2..^0]);
            Assert.Equal(new[] { 8, 9 }, items[^2..]);
            Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, items[..]);
        }

        [Fact]
        public void GetItemsUsingImplicitIndexerImplementation()
        {
            var items = new ImplicitlyIndexedCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Assert.Equal(new[] { 0, 1 }, items[0..2]);
            Assert.Equal(new[] { 0, 1 }, items[..2]);
            Assert.Equal(new[] { 0, 1 }, items[^10..^8]);
            Assert.Equal(new[] { 0, 1 }, items[..^8]);
            Assert.Equal(new[] { 3, 4, 5 }, items[3..6]);
            Assert.Equal(new[] { 3, 4, 5 }, items[^7..^4]);
            Assert.Equal(new[] { 8, 9 }, items[8..10]);
            Assert.Equal(new[] { 8, 9 }, items[8..]);
            Assert.Equal(new[] { 8, 9 }, items[^2..^0]);
            Assert.Equal(new[] { 8, 9 }, items[^2..]);
            Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, items[..]);
        }
    }
}
