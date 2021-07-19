namespace CSharp90Features.Tests.CovariantReturnTypes
{
    public class TruckFactory : VehicleFactory
    {
        public override Truck GetVehicle() => new Truck();
    }
}
