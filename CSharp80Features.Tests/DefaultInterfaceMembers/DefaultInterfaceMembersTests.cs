using Xunit;

namespace CSharp80Features.Tests.DefaultInterfaceMembers
{
    public class DefaultInterfaceMembersTests
    {
        [Fact]
        public void DefaultInterfaceMembersAreAccessibleByCastingToInterface()
        {
            var scooter = new Scooter();
            var vehicle = (IVehicle)scooter;

            var actual = vehicle.Description();

            Assert.Equal($"{nameof(Scooter)} {scooter.NumberOfWheels} {scooter.MaxSpeed}", actual);
        }

        [Fact]
        public void DefaultInterfaceMembersAreNotInheritedByClass()
        {
            var bicycle = new Bicycle();

            var actual = bicycle.Description();

            Assert.Equal($"Eco vehicle", actual);
        }

        [Fact]
        public void DefaultInterfaceMembersCanBeOverridenInExtendingInterface()
        {
            var minivan = new Minivan();
            var vehicle = (IVehicle)minivan;
            var car = (ICar)minivan;

            Assert.Equal($"{nameof(Minivan)} {vehicle.NumberOfWheels} {vehicle.MaxSpeed}", vehicle.Description());
            Assert.Equal($"Fuel engine {minivan.MaxSpeed}", car.Description());
        }

        [Fact]
        public void StaticInterfaceMembersCanBeReusedInClasses()
        {
            var scooter = new Scooter();

            Assert.Equal($"{nameof(Scooter)} Model #1", scooter.Model);
        }
    }
}
