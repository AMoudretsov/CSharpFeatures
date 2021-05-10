using Xunit;

namespace CSharp6Features.Tests.IndexInitializers
{
    public class IndexInitializersTests
    {
        [Fact]
        public void MatrixIsInitializedUsingCellInitializer()
        {
            var matrix = new Matrix
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,

                [1, 0] = 10,
                [1, 1] = 20,
                [1, 2] = 30,

                [2, 0] = 100,
                [2, 1] = 200,
                [2, 2] = 300,
            };

            Assert.Equal(new[] { 1, 2, 3 }, matrix[0]);
            Assert.Equal(new[] { 10, 20, 30 }, matrix[1]);
            Assert.Equal(new[] { 100, 200, 300 }, matrix[2]);
        }

        [Fact]
        public void NotInitializedCellsHaveDefaultValues()
        {
            var matrix = new Matrix
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,

                [2, 0] = 100,
                [2, 1] = 200,
                [2, 2] = 300,
            };

            Assert.Equal(new[] { 1, 2, 3 }, matrix[0]);
            Assert.Equal(new int[3], matrix[1]);
            Assert.Equal(new[] { 100, 200, 300 }, matrix[2]);
        }

        [Fact]
        public void MatrixIsInitializedUsingRowInitializer()
        {
            var matrix = new Matrix
            {
                [0] = new[] { 1, 2, 3 },
                [1] = new[] { 10, 20, 30 },
                [2] = new[] { 100, 200, 300 },
            };

            Assert.Equal(new[] { 1, 2, 3 }, matrix[0]);
            Assert.Equal(new[] { 10, 20, 30 }, matrix[1]);
            Assert.Equal(new[] { 100, 200, 300 }, matrix[2]);
        }

        [Fact]
        public void NotInitializedRowsConsistOfDefaultValues()
        {
            var matrix = new Matrix
            {
                [1] = new[] { 10, 20, 30 },
                [2] = new[] { 100, 200, 300 },
            };

            Assert.Equal(new int[3], matrix[0]);
            Assert.Equal(new[] { 10, 20, 30 }, matrix[1]);
            Assert.Equal(new[] { 100, 200, 300 }, matrix[2]);
        }
    }
}
