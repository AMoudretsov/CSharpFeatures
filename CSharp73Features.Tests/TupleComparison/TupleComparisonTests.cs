using Xunit;

namespace CSharp73Features.Tests.TupleComparison
{
    public class TupleComparisonTests
    {
        [Fact]
        public void EqualWorksForTuples()
        {
            var tuple1 = (Category: "Planets", (Number: 3, Name: "Earth"));
            var tuple2 = (Type: "Planets", (Id: 3L, Name: "Earth"));

            Assert.True(tuple1 == tuple2);
        }

        [Fact]
        public void EqualWorksForTuplesContainingNull()
        {
            var tuple1 = (Category: "Planets", (Number: 3, Name: (string)null));
            var tuple2 = (Type: "Planets", (Id: 3L, Name: (string)null));

            Assert.True(tuple1 == tuple2);
        }

        [Fact]
        public void NonEqualWorksForTuples()
        {
            var tuple1 = (Category: "Planets", (Number: 3, Name: "Earth"));
            var tuple2 = (Type: "Planets", (Id: 2L, Name: "Venus"));

            Assert.True(tuple1 != tuple2);
        }

        [Fact]
        public void NonEqualWorksForTuplesContainingNull()
        {
            var tuple1 = (Category: "Planets", (Number: 3, Name: "Earth"));
            var tuple2 = (Type: "Planets", (Id: 3L, Name: (string)null));

            Assert.True(tuple1 != tuple2);
        }
    }
}
