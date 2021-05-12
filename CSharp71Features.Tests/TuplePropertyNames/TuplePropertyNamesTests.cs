using Xunit;

namespace CSharp71Features.Tests.TuplePropertyNames
{
    public class TuplePropertyNamesTests
    {
        [Fact]
        public void TuplePropertyNamesAreInferredFromLocalVariables()
        {
            var name = "Test name";
            var number = 10;

            var actual = (name, number);

            Assert.Equal(name, actual.name);
            Assert.Equal(number, actual.number);
        }

        [Fact]
        public void TuplePropertyNamesAreInferredFromObjectProperties()
        {
            var entity = new
            {
                Name = "Test name",
                Number = 10,
                Description = "Test description"
            };

            var actual = (entity.Name, entity.Number);

            Assert.Equal(entity.Name, actual.Name);
            Assert.Equal(entity.Number, actual.Number);
        }
    }
}
