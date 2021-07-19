using Xunit;

namespace CSharp90Features.Tests.CovariantReturnTypes
{
    public class CovariantReturnTypesTests
    {
        [Fact]
        public void OverriddenMethodsCanReturnDerivedClasses()
        {
            VehicleFactory vehicleFactory = new TruckFactory();
            TruckFactory truckFactory = new TruckFactory();

            Assert.IsType<Truck>(vehicleFactory.GetVehicle());
            Assert.IsType<Truck>(truckFactory.GetVehicle());
        }
    }
}
