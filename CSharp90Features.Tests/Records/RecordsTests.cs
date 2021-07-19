using Xunit;

namespace CSharp90Features.Tests.Records
{
    public class RecordsTests
    {
        [Fact]
        public void PropertiesCanBeSetByCtor()
        {
            var vehicle = new Vehicle(4, 150);

            Assert.Equal(4, vehicle.Wheels);
            Assert.Equal(150, vehicle.Speed);
        }

        [Fact]
        public void PropertiesCanBeSetByInitializer()
        {
            var vehicle = new Vehicle(4, 150) { Speed = 180 };

            Assert.Equal(4, vehicle.Wheels);
            Assert.Equal(180, vehicle.Speed);
        }

        [Fact]
        public void PropertiesCanBeSetByPositionalSyntax()
        {
            Vehicle vehicle = new(4, 150);

            Assert.Equal(4, vehicle.Wheels);
            Assert.Equal(150, vehicle.Speed);
        }

        [Fact]
        public void RecordsImplementValueEquality()
        {
            var vehicle1 = new Vehicle(4, 150);
            var vehicle2 = new Vehicle(4, 150);

            Assert.True(vehicle1 == vehicle2);
            Assert.True(vehicle1.Equals(vehicle2));
            Assert.True(Equals(vehicle1, vehicle2));
            Assert.False(ReferenceEquals(vehicle1, vehicle2));
        }

        [Fact]
        public void RecordsOfDifferentTypeWithEqualPropertyValuesAreNonEqual()
        {
            var bicycle = new Bicycle(2, 30, "Model #1");
            var scooter = new Scooter(2, 30, "Model #1");

            Assert.False(bicycle == scooter);
            Assert.False(bicycle.Equals(scooter));
        }

        [Fact]
        public void RecordsImplementDeconstruct()
        {
            var vehicle = new Vehicle(4, 150);

            (int wheels, int speed) = vehicle;

            Assert.Equal(4, wheels);
            Assert.Equal(150, speed);
        }

        [Fact]
        public void RecordsAreReferenceTypes()
        {
            var vehicle1 = new Vehicle(4, 150);
            var vehicle2 = vehicle1;

            Assert.True(ReferenceEquals(vehicle1, vehicle2));
        }

        [Fact]
        public void CreateRecordCopyWithNondestructiveMutation()
        {
            var vehicle1 = new Vehicle(4, 150);
            var vehicle2 = vehicle1 with { Speed = 180 };

            Assert.Equal(4, vehicle1.Wheels);
            Assert.Equal(150, vehicle1.Speed);
            Assert.Equal(4, vehicle2.Wheels);
            Assert.Equal(180, vehicle2.Speed);
            Assert.False(ReferenceEquals(vehicle1, vehicle2));
        }
    }
}
