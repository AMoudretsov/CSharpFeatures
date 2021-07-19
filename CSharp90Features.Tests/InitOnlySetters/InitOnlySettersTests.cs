using Xunit;

namespace CSharp90Features.Tests.InitOnlySetters
{
    public class InitOnlySettersTests
    {
        [Fact]
        public void InitSettersAreNotCalledByDefault()
        {
            var point = new Point();

            Assert.Null(point.X);
            Assert.Null(point.Y);
        }

        [Fact]
        public void InitSettersAreCalledInCtor()
        {
            var point = new Point(1, 1);

            Assert.Equal(1, point.X);
            Assert.Equal(1, point.Y);
        }

        [Fact]
        public void InitSettersAreCalledInInitializer()
        {
            var point = new Point { X = 5, Y = 5 };

            Assert.Equal(5, point.X);
            Assert.Equal(5, point.Y);
        }

        [Fact]
        public void InitSetterCanContainCustomLogic()
        {
            var point = new EquidistantPoint { Distance = 7 };

            Assert.Equal(7, point.X);
            Assert.Equal(7, point.Y);
        }
    }
}
